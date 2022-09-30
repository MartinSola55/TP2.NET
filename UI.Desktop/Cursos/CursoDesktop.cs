using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Entities;
using Business.Logic;

namespace UI.Desktop
{
    public partial class CursoDesktop : ApplicationForm
    {
        private CursoLogic cl = new CursoLogic();
        public CursoDesktop()
        {
            InitializeComponent();
        }
        private void CursoDesktop_Load(object sender, EventArgs e)
        {

        }
        public Curso CursoActual
        {
            get;
            set;
        }
        public CursoDesktop(ModoForm modo) : this()
        {
            Modo = modo;
            if (modo == ModoForm.Alta)
            {
                btnAceptar.Text = "Guardar";
            }
            ListarComboMaterias();
        }
        public CursoDesktop(int id, ModoForm modo) : this()
        {
            CursoActual = cl.GetOne(id);
            Modo = modo;
            this.ListarComboMaterias();
            this.MapearDeDatos();
        }
        public override void MapearDeDatos()
        {
            this.txtID.Text = this.CursoActual.ID.ToString();
            this.comboMateria.SelectedValue = this.CursoActual.IDMateria;
            this.comboComision.SelectedValue = this.CursoActual.IDComision;
            this.txtAnio.Text = this.CursoActual.AnioCalendario.ToString();
            this.txtCupo.Text = this.CursoActual.Cupo.ToString();
            switch (this.Modo)
            {
                case ModoForm.Modificacion:
                    {
                        btnAceptar.Text = "Guardar";
                        break;
                    }
                case ModoForm.Baja:
                    {
                        btnAceptar.Text = "Eliminar";
                        comboComision.Enabled = false;
                        comboMateria.Enabled = false;
                        txtAnio.Enabled = false;
                        txtCupo.Enabled = false;
                        break;
                    }
                case ModoForm.Consulta:
                    {
                        btnAceptar.Text = "Aceptar";
                        break;
                    }
            }
        }
        public override void MapearADatos()
        {
            if (this.Modo == ModoForm.Alta)
            {
                Curso curso = new Curso();
                CursoActual = curso;
            }
            if (this.Modo == ModoForm.Alta || this.Modo == ModoForm.Modificacion)
            {
                this.CursoActual.IDMateria = int.Parse(this.comboMateria.SelectedValue.ToString());
                this.CursoActual.IDComision = int.Parse(this.comboComision.SelectedValue.ToString());
                this.CursoActual.AnioCalendario = int.Parse(this.txtAnio.Text);
                this.CursoActual.Cupo = int.Parse(this.txtCupo.Text);
                if (this.Modo == ModoForm.Alta)
                {
                    this.CursoActual.State = BusinessEntity.States.New;
                }
                else
                {
                    this.CursoActual.State = BusinessEntity.States.Modified;
                }
            }
            if (this.Modo == ModoForm.Baja)
            {
                this.CursoActual.State = BusinessEntity.States.Deleted;
            }
        }
        public override bool Validar()
        {
            if (txtAnio.Text.Length == 0 || txtCupo.Text.Length == 0)
            {
                this.Notificar("ERROR", "Debes completar todos los campos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (int.Parse(txtAnio.Text) < 1980 || int.Parse(txtAnio.Text) > System.DateTime.Now.Year)
            {
                this.Notificar("ERROR", "Debes ingresar un año entre 1980 y " + System.DateTime.Now.Year, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (int.Parse(txtCupo.Text) <= 0 || int.Parse(txtCupo.Text) > 500)
            {
                this.Notificar("ERROR", "El cupo debe ser estar entre 1 y 500", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (this.comboMateria.SelectedValue.ToString() == "0")
            {
                this.Notificar("ERROR", "Debes seleccionar una materia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (this.comboComision.SelectedValue.ToString() == "0")
            {
                this.Notificar("ERROR", "Debes seleccionar una comisión", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            Curso cur = new Curso
            {
                IDMateria = int.Parse(this.comboMateria.SelectedValue.ToString()),
                IDComision = int.Parse(this.comboComision.SelectedValue.ToString()),
                AnioCalendario = int.Parse(this.txtAnio.Text)
            };
            cur.ID = this.txtID.Text != "" ? int.Parse(this.txtID.Text) : 0;
            if (cl.GetRepetido(cur).ID != 0)
            {
                this.Notificar("ERROR", "El curso que deseas guardar ya existe", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
        public override void GuardarCambios()
        {
            this.MapearADatos();
            cl.Save(CursoActual);
        }
        private void ListarComboMaterias()
        {
            MateriaLogic ml = new MateriaLogic();
            List<Materia> materias = ml.GetAll();
            Dictionary<int, string> comboSource = new Dictionary<int, string>();
            comboSource.Add(0, "-- Seleccione una materia--");
            foreach (Materia m in materias)
            {
                comboSource.Add(m.ID, m.Descripcion + " - " + m.DescripcionPlan);
            }

            this.comboMateria.DataSource = new BindingSource(comboSource, null);
            this.comboMateria.DisplayMember = "Value";
            this.comboMateria.ValueMember = "Key";
            this.comboMateria.SelectedValue = 0;
        }
        private void ListarComboComi(int id_plan)
        {
            ComisionLogic cl = new ComisionLogic();
            List<Comision> comisiones = cl.GetXPlan(id_plan);
            Dictionary<int, string> comboSource = new Dictionary<int, string>();
            comboSource.Add(0, "-- Seleccione una comisión --");
            foreach (Comision c in comisiones)
            {
                comboSource.Add(c.ID, c.Descripcion);
            }
            this.comboComision.DataSource = new BindingSource(comboSource, null);
            this.comboComision.DisplayMember = "Value";
            this.comboComision.ValueMember = "Key";
            this.comboComision.SelectedValue = 0;
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Modo != ModoForm.Baja)
                {
                    if (this.Validar())
                    {
                        this.GuardarCambios();
                        this.Close();
                    }
                }
                else
                {
                    this.GuardarCambios();
                    this.Close();
                }
            } catch (FormatException)
            {
                MessageBox.Show("Alguno de los campos ingresados no tiene el formato adecuado", "ERROR AL GUARDAR EL CURSO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } catch (Exception exceptionManejada)
            {
                MessageBox.Show(exceptionManejada.Message, "ERROR AL GUARDAR EL CURSO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboMateria_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                MateriaLogic ml = new MateriaLogic();
                Materia materia = ml.GetOne(int.Parse(this.comboMateria.SelectedValue.ToString()));
                this.ListarComboComi(materia.IDPlan);
            } catch
            {

            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_MouseEnter(object sender, EventArgs e)
        {
            this.btnAceptar.BackColor = Color.Green;
            this.btnAceptar.ForeColor = Color.FromArgb(44, 48, 52);
        }

        private void btnAceptar_MouseLeave(object sender, EventArgs e)
        {
            this.btnAceptar.BackColor = Color.FromArgb(44, 48, 52);
            this.btnAceptar.ForeColor = Color.Green;
        }

        private void btnCancelar_MouseEnter(object sender, EventArgs e)
        {
            this.btnCancelar.BackColor = Color.Red;
            this.btnCancelar.ForeColor = Color.FromArgb(44, 48, 52);
        }

        private void btnCancelar_MouseLeave(object sender, EventArgs e)
        {
            this.btnCancelar.BackColor = Color.FromArgb(44, 48, 52);
            this.btnCancelar.ForeColor = Color.Red;
        }
    }
}
