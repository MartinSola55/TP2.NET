using Business.Entities;
using Business.Logic;
using Rotativa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UI.WebMVC.Filter;

namespace UI.WebMVC.Controllers
{
    public class CursosController : Controller
    {
        private CursoLogic cl = new CursoLogic();
        private MateriaLogic ml = new MateriaLogic();
        private ComisionLogic coml = new ComisionLogic();
        private DataClassesDataContext db = new DataClassesDataContext();

        // GET: Curso
        [Seguridad]
        public ActionResult Inicio()
        {
            ViewBag.listadoMaterias = listadoMaterias();
            ViewBag.listadoComisiones = listadoComisiones();
            return View();
        }
        [Seguridad]
        [HttpPost]
        public ActionResult Inicio(Curso curso)
        {
            ViewBag.listadoMaterias = listadoMaterias();
            ViewBag.listadoComisiones = listadoComisiones();
            if (ModelState.IsValid)
            {
                return View(curso);
            }
            return RedirectToAction(nameof(Inicio));
        }
        [Seguridad]
        public JsonResult getAll()
        {
            try
            {
                var cursos = from c in db.Cursos
                             join m in db.Materias
                                on c.IDMateria equals m.ID
                             join com in db.Comisiones
                                on c.IDComision equals com.ID
                             orderby m.Descripcion, com.Descripcion
                             select new
                             {
                                 c.ID,
                                 c.IDComision,
                                 c.IDMateria,
                                 c.AnioCalendario,
                                 c.Cupo,
                                 MateriaDesc = m.Descripcion,
                                 ComisionDesc = com.Descripcion
                             };
                return Json(cursos, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(0, JsonRequestBehavior.AllowGet);
            }
        }
        [Seguridad]
        public JsonResult getOne(int id)
        {
            try
            {
                var curso = db.Cursos
                    .Where(c => c.ID.Equals(id))
                    .Select(c => new { c.ID, c.IDMateria, c.IDComision, c.AnioCalendario, c.Cupo })
                    .FirstOrDefault();
                return Json(curso, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(0, JsonRequestBehavior.AllowGet);
            }
        }
        [Seguridad]
        [Admin]
        public ActionResult Delete(Curso curso)
        {
            try
            {
                cl.Delete(curso.ID);
                ViewBag.Message = "El curso se eliminó correctamente";
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                ViewBag.Error = 2;
            }
            ViewBag.listadoMaterias = listadoMaterias();
            ViewBag.listadoComisiones = listadoComisiones();
            return View("Inicio");
        }
        [Seguridad]
        [Admin]
        public ActionResult Save(Curso curso)
        {
            try
            {
                Cursos repetido = db.Cursos
                    .Where(c => c.IDMateria.Equals(curso.IDMateria) && c.IDComision.Equals(curso.IDComision)
                    && c.AnioCalendario.Equals(curso.AnioCalendario) && !c.ID.Equals(curso.ID))
                    .FirstOrDefault();
                if (repetido == null)
                {
                    if (curso.ID == 0)
                    {
                        curso.State = BusinessEntity.States.New;
                        ViewBag.Message = "El curso se guardó correctamente";
                    }
                    else
                    {
                        curso.State = BusinessEntity.States.Modified;
                        ViewBag.Message = "El curso se actualizó correctamente";
                    }
                    cl.Save(curso);
                }
                else
                {
                    ViewBag.Message = "El curso que desea guardar ya existe";
                    ViewBag.Error = 1;
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                ViewBag.Error = 2;
            }
            ViewBag.listadoMaterias = listadoMaterias();
            ViewBag.listadoComisiones = listadoComisiones();
            return View("Inicio");
        }
        [Seguridad]
        public IEnumerable<SelectListItem> listadoMaterias()
        {
            IEnumerable<SelectListItem> lista = null;
            try
            {
                IEnumerable<Materia> materias = ml.GetAll();
                lista = materias.Select(m => new SelectListItem { Text = m.Descripcion + " - " + m.DescripcionPlan, Value = m.ID.ToString() });
            }
            catch (Exception e)
            {

            }
            return lista;
        }
        [Seguridad]
        public IEnumerable<SelectListItem> listadoComisiones()
        {
            IEnumerable<SelectListItem> lista = null;
            try
            {
                IEnumerable<Comision> comisiones = coml.GetAll();
                lista = comisiones.Select(c => new SelectListItem { Text = c.Descripcion + " - " + c.PlanDesc, Value = c.ID.ToString() });
            }
            catch (Exception e)
            {

            }
            return lista;
        }
        public ActionResult Report()
        {
            var cursos = from c in db.Cursos
                         join m in db.Materias
                            on c.IDMateria equals m.ID
                         join com in db.Comisiones
                            on c.IDComision equals com.ID
                         orderby m.Descripcion, com.Descripcion
                         select new
                         {
                             c.ID,
                             c.IDComision,
                             c.IDMateria,
                             c.AnioCalendario,
                             c.Cupo,
                             MateriaDesc = m.Descripcion,
                             ComisionDesc = com.Descripcion
                         };
            List<Curso> listadoCursos = new List<Curso>();
            foreach (var curso in cursos)
            {
                listadoCursos.Add(new Curso
                {
                    ID = curso.ID,
                    IDComision = curso.IDComision,
                    IDMateria = curso.IDMateria,
                    AnioCalendario = curso.AnioCalendario,
                    Cupo = curso.Cupo,
                    MateriaDesc = curso.MateriaDesc,
                    ComisionDesc = curso.ComisionDesc
                });
            }
            return View(listadoCursos);
        }
        [Seguridad]
        public ActionResult Print()
        {
            var report = new ActionAsPdf("Report")
            {
                FileName = "Reporte Cursos.pdf",
            };
            return report;
        }
    }
}