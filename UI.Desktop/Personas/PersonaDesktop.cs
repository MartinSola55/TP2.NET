using Business.Entities;
using Business.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Desktop
{
    public partial class PersonaDesktop : ApplicationForm
    {
        private PersonaLogic pl = new PersonaLogic();
        public PersonaDesktop()
        {
            InitializeComponent();
            this.dtpNacimiento.MaxDate = DateTime.Now;
            this.dtpNacimiento.MinDate = DateTime.Now.AddYears(-100);
        }
        public Persona PersonaActual
        {
            get;
            set;
        }
        public PersonaDesktop(ModoForm modo) : this()
        {
            Modo = modo;
            if (modo == ModoForm.Alta)
            {
                btnAceptar.Text = "Guardar";
            }
            ListarCombos();
        }
        public PersonaDesktop(int id, ModoForm modo) : this()
        {
            Modo = modo;
            PersonaActual = pl.GetOne(id);
            this.ListarCombos();
            this.MapearDeDatos();
        }
        public override void MapearDeDatos()
        {
            this.txtID.Text = this.PersonaActual.ID.ToString();
            this.txtNombre.Text = this.PersonaActual.Nombre;
            this.txtApellido.Text = this.PersonaActual.Apellido;
            this.txtDireccion.Text = this.PersonaActual.Direccion;
            this.txtEmail.Text = this.PersonaActual.Email;
            this.txtTelefono.Text = this.PersonaActual.Telefono;
            this.txtLegajo.Text = this.PersonaActual.Legajo.ToString();
            this.dtpNacimiento.Value = this.PersonaActual.FechaNacimiento;
            this.comboTipoPersona.SelectedValue = this.PersonaActual.TipoPersona;
            this.comboPlanes.SelectedValue = this.PersonaActual.IDPlan;
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
                        comboTipoPersona.Enabled = false;
                        comboPlanes.Enabled = false;
                        txtNombre.Enabled = false;
                        txtApellido.Enabled = false;
                        txtDireccion.Enabled = false;
                        txtEmail.Enabled = false;
                        txtTelefono.Enabled = false;
                        txtLegajo.Enabled = false;
                        dtpNacimiento.Enabled = false;
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
                Persona persona = new Persona();
                PersonaActual = persona;
            }
            if (this.Modo == ModoForm.Alta || this.Modo == ModoForm.Modificacion)
            {
                this.PersonaActual.TipoPersona = int.Parse(this.comboTipoPersona.SelectedValue.ToString());
                this.PersonaActual.IDPlan = int.Parse(this.comboPlanes.SelectedValue.ToString());
                this.PersonaActual.Nombre = this.txtNombre.Text;
                this.PersonaActual.Apellido = this.txtApellido.Text;
                this.PersonaActual.Direccion = this.txtDireccion.Text;
                this.PersonaActual.FechaNacimiento = this.dtpNacimiento.Value;
                this.PersonaActual.Email = this.txtEmail.Text;
                this.PersonaActual.Telefono = this.txtTelefono.Text;
                this.PersonaActual.Legajo = int.Parse(this.txtLegajo.Text);
                if (this.Modo == ModoForm.Alta)
                {
                    this.PersonaActual.State = BusinessEntity.States.New;
                }
                else
                {
                    this.PersonaActual.State = BusinessEntity.States.Modified;
                }
            }
            if (this.Modo == ModoForm.Baja)
            {
                this.PersonaActual.State = BusinessEntity.States.Deleted;
            }
        }
        public override bool Validar()
        {
            if (txtNombre.Text.Length == 0 || txtApellido.Text.Length == 0 || txtDireccion.Text.Length == 0 || 
                txtEmail.Text.Length == 0 || txtTelefono.Text.Length == 0 || txtLegajo.Text.Length == 0)
            {
                this.Notificar("ERROR", "Debes completar todos los campos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (this.comboPlanes.SelectedValue.ToString() == "0")
            {
                this.Notificar("ERROR", "Debes seleccionar un plan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (this.comboTipoPersona.SelectedValue.ToString() == "0")
            {
                this.Notificar("ERROR", "Debes seleccionar un tipo de persona", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (int.Parse(txtLegajo.Text) < 1 || int.Parse(txtLegajo.Text) > 100000)
            {
                this.Notificar("ERROR", "Debes ingresar un legajo entre 1 y 100.000", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (!Validaciones.esMailValido(this.txtEmail.Text))
            {
                this.Notificar("ERROR", "El formato del email es inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (!Validaciones.esNombreValido(this.txtNombre.Text) || !Validaciones.esNombreValido(this.txtApellido.Text) ||
                !Validaciones.esDireccionValida(this.txtDireccion.Text) || !Validaciones.esNumeroValido(this.txtTelefono.Text) ||
                !Validaciones.esNumeroValido(this.txtLegajo.Text))
            {
                this.Notificar("ERROR", "El formato de uno de los campos es inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            Persona per = new Persona
            {
                Legajo = int.Parse(this.txtLegajo.Text),
                Nombre = this.txtNombre.Text,
                Apellido = this.txtApellido.Text,
                FechaNacimiento = this.dtpNacimiento.Value,
                TipoPersona = int.Parse(this.comboTipoPersona.SelectedValue.ToString()),
                IDPlan = int.Parse(this.comboPlanes.SelectedValue.ToString())
            };
            per.ID = this.txtID.Text != "" ? int.Parse(this.txtID.Text) : 0;
            if (pl.EsLegajoRepetido(per))
            {
                this.Notificar("ERROR", "El legajo ingresado ya existe", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            Persona persona = pl.GetRepetido(per);
            if (pl.GetRepetido(per).ID != 0)
            {
                this.Notificar("ERROR", "La persona que deseas guardar ya existe", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
        public override void GuardarCambios()
        {
            this.MapearADatos();
            pl.Save(PersonaActual);
        }
        private void ListarCombos()
        {
            PlanLogic pl = new PlanLogic();
            List<Plan> planes = pl.GetAll();
            Dictionary<int, string> comboSource = new Dictionary<int, string>();
            Dictionary<int, string> comboSourceTipo = new Dictionary<int, string>();
            comboSource.Add(0, "-- Seleccione un plan--");
            comboSourceTipo.Add(0, "-- Seleccione un tipo--");
            foreach (Plan p in planes)
            {
                comboSource.Add(p.ID, p.Descripcion + " - " + p.DescripcionEsp);
            }
            comboSourceTipo.Add(1, "Docente");
            comboSourceTipo.Add(2, "Alumno");
            this.comboPlanes.DataSource = new BindingSource(comboSource, null);
            this.comboTipoPersona.DataSource = new BindingSource(comboSourceTipo, null);
            this.comboPlanes.DisplayMember = "Value";
            this.comboTipoPersona.DisplayMember = "Value";
            this.comboPlanes.ValueMember = "Key";
            this.comboTipoPersona.ValueMember = "Key";
            this.comboPlanes.SelectedValue = 0;
            this.comboTipoPersona.SelectedValue = 0;
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
                MessageBox.Show("Alguno de los campos ingresados no tiene el formato adecuado", "ERROR AL GUARDAR LA PERSONA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception exceptionManejada)
            {
                MessageBox.Show(exceptionManejada.Message, "ERROR AL GUARDAR LA PERSONA", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
