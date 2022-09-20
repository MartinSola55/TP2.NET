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
    public partial class PlanDesktop : ApplicationForm
    {
        private PlanLogic pl = new PlanLogic();
        public PlanDesktop()
        {
            InitializeComponent();
        }
        public Business.Entities.Plan PlanActual
        {
            get;
            set;
        }
        public PlanDesktop(ModoForm modo) : this()
        {
            Modo = modo;
            if (modo == ModoForm.Alta)
            {
                btnAceptar.Text = "Guardar";
            }
            this.ListarCombo();
        }
        public PlanDesktop(int id, ModoForm modo) : this()
        {
            PlanActual = pl.GetOne(id);
            Modo = modo;
            this.ListarCombo();
            this.MapearDeDatos();
        }
        public override void MapearDeDatos()
        {
            this.txtID.Text = this.PlanActual.ID.ToString();
            this.txtDescripcion.Text = this.PlanActual.Descripcion;
            this.comboEspecialidad.SelectedValue = this.PlanActual.IDEspecialidad;
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
                        txtDescripcion.Enabled = false;
                        comboEspecialidad.Enabled = false;
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
                Business.Entities.Plan plan = new Business.Entities.Plan();
                PlanActual = plan;
            }
            if (this.Modo == ModoForm.Alta || this.Modo == ModoForm.Modificacion)
            {
                this.PlanActual.Descripcion = this.txtDescripcion.Text;
                this.PlanActual.IDEspecialidad = int.Parse(this.comboEspecialidad.SelectedValue.ToString());
                if (this.Modo == ModoForm.Alta)
                {
                    this.PlanActual.State = BusinessEntity.States.New;
                }
                else
                {
                    this.PlanActual.State = BusinessEntity.States.Modified;
                }
            }
            if (this.Modo == ModoForm.Baja)
            {
                this.PlanActual.State = BusinessEntity.States.Deleted;
            }
        }
        public override bool Validar()
        {
            if (this.txtDescripcion.Text.Length == 0)
            {
                this.Notificar("ERROR", "Debes escribir una descripción", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            } else if (this.comboEspecialidad.SelectedValue.ToString() == "0")
            {
                this.Notificar("ERROR", "Debes seleccionar una especialidad", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            } else if (!Validaciones.esDireccionValida(this.txtDescripcion.Text))
            {
                this.Notificar("ERROR", "Sólo se permite una descripción con caracteres alfanuméricos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            } else if (this.txtDescripcion.Text.Length < 3 || this.txtDescripcion.Text.Length > 50)
            {
                this.Notificar("ERROR", "Ingrese una descripción de entre 3 y 50 caracteres", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            Plan plan = new Plan
            {
                ID = this.txtID.Text != "" ? int.Parse(this.txtID.Text) : 0,
                Descripcion = this.txtDescripcion.Text,
                IDEspecialidad = int.Parse(this.comboEspecialidad.SelectedValue.ToString())
            };
            if (pl.GetRepetido(plan).ID != 0)
            {
                this.Notificar("ERROR", "El plan que deseas guardar ya existe", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
        public override void GuardarCambios()
        {
            this.MapearADatos();
            pl.Save(PlanActual);
        }
        private void ListarCombo()
        {
            EspecialidadLogic el = new EspecialidadLogic();
            List<Especialidad> especialidades = el.GetAll();
            Dictionary<int, string> comboSource = new Dictionary<int, string>();
            comboSource.Add(0, "-- Seleccione una especialidad --");
            foreach (Especialidad esp in especialidades)
            {
                comboSource.Add(esp.ID, esp.Descripcion);
            }
            this.comboEspecialidad.DataSource = new BindingSource(comboSource, null);
            this.comboEspecialidad.DisplayMember = "Value";
            this.comboEspecialidad.ValueMember = "Key";
            this.comboEspecialidad.SelectedValue = 0;
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
            }
            catch (FormatException)
            {
                MessageBox.Show("Alguno de los campos no tiene el formato adecuado", "ERROR AL GUARDAR EL PLAN", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception exceptionManejada)
            {
                MessageBox.Show(exceptionManejada.Message, "ERROR AL GUARDAR EL PLAN", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
