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
            ListarCombos();
        }
        public CursoDesktop(int id, ModoForm modo) : this()
        {
            CursoLogic cl = new CursoLogic();
            CursoActual = cl.GetOne(id);
            Modo = modo;
            this.ListarCombos();
            this.MapearDeDatos();
        }
        public override void MapearDeDatos()
        {
            this.txtID.Text = this.CursoActual.ID.ToString();
            this.comboComision.SelectedValue = this.CursoActual.IDComision;
            this.comboMateria.SelectedValue = this.CursoActual.IDMateria;
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
            return true;
        }
        public override void GuardarCambios()
        {
            this.MapearADatos();
            CursoLogic cl = new CursoLogic();
            cl.Save(CursoActual);
        }
        private void ListarCombos()
        {
            MateriaLogic ml = new MateriaLogic();
            ComisionLogic cl = new ComisionLogic();
            List<Materia> materias = ml.GetAll();
            List<Comision> comisiones = cl.GetAll();
            Dictionary<int, string> comboSourceM = new Dictionary<int, string>();
            Dictionary<int, string> comboSourceC = new Dictionary<int, string>();
            comboSourceM.Add(0, "-- Seleccione una materia--");
            comboSourceC.Add(0, "-- Seleccione una comisión --");
            foreach (Materia m in materias)
            {
                comboSourceM.Add(m.ID, m.Descripcion);
            }
            foreach (Comision c in comisiones)
            {
                comboSourceC.Add(c.ID, c.Descripcion);
            }
            this.comboMateria.DataSource = new BindingSource(comboSourceM, null);
            this.comboComision.DataSource = new BindingSource(comboSourceC, null);
            this.comboMateria.DisplayMember = "Value";
            this.comboComision.DisplayMember = "Value";
            this.comboMateria.ValueMember = "Key";
            this.comboComision.ValueMember = "Key";
            this.comboMateria.SelectedValue = 0;
            this.comboComision.SelectedValue = 0;
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.Validar())
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
