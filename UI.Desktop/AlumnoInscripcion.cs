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
    public partial class AlumnoInscripcion : ApplicationForm
    {
        private int IDAlumno;
        public Business.Entities.Persona AlumnoActual
        {
            get;
            set;
        }
        public AlumnoInscripcion(int id)
        {
            InitializeComponent();
            this.IDAlumno = id;
            this.dgvAlumnoInscripcion.AutoGenerateColumns = false;
            PersonaLogic pl = new PersonaLogic();
            AlumnoActual = pl.GetOne(IDAlumno);
            this.Text = "Inscripciones de " + AlumnoActual.Apellido + ", " + AlumnoActual.Nombre;
            this.MapearDeDatos();
        }
        public override void MapearDeDatos()
        {
            this.txtNombre.Text = this.AlumnoActual.Nombre;
            this.txtApellido.Text = this.AlumnoActual.Apellido;
            this.txtPlan.Text = this.AlumnoActual.DescPlan;
            this.txtLegajo.Text = this.AlumnoActual.Legajo.ToString();
            this.txtEmail.Text = this.AlumnoActual.Email;
            this.txtUsuario.Text = this.AlumnoActual.NombreUsuario;
        }
        public void Listar()
        {
            try
            {
                PersonaLogic pl = new PersonaLogic();
                this.dgvAlumnoInscripcion.DataSource = pl.GetInscripcionesAlumnno(IDAlumno);
            }
            catch (Exception exceptionManejada)
            {
                MessageBox.Show(exceptionManejada.Message, "ERROR AL RECUPERAR DATOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AlumnoInscripcion_Load(object sender, EventArgs e)
        {
            if (LoginInfo.TipoPersona != 3)
            {
                this.tsbEditar.Visible = false;
                this.tsbEliminar.Visible = false;
                this.toolStripSeparator1.Visible = false;
                this.toolStripSeparator2.Visible = false;
            }
            else
            {
                this.tsbEditar.Visible = true;
                this.tsbEliminar.Visible = true;
                this.toolStripSeparator1.Visible = true;
                this.toolStripSeparator2.Visible = true;
            }
            this.Listar();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            this.Listar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            InscripcionDesktop insd = new InscripcionDesktop(ApplicationForm.ModoForm.Alta, AlumnoActual.ID);
            insd.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvAlumnoInscripcion.SelectedRows != null)
                {
                    int ID = ((Business.Entities.AlumnoInscripcion)this.dgvAlumnoInscripcion.SelectedRows[0].DataBoundItem).ID;
                    InscripcionDesktop insd = new InscripcionDesktop(ID, ApplicationForm.ModoForm.Modificacion);
                    insd.ShowDialog();
                    this.Listar();
                }
            }
            catch (Exception exceptionManejada)
            {
                MessageBox.Show(exceptionManejada.Message, "ERROR AL EDITAR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                int ID = ((Business.Entities.AlumnoInscripcion)this.dgvAlumnoInscripcion.SelectedRows[0].DataBoundItem).ID;
                InscripcionDesktop insd = new InscripcionDesktop(ID, ApplicationForm.ModoForm.Baja);
                insd.ShowDialog();
                this.Listar();
            }
            catch (Exception exceptionManejada)
            {
                MessageBox.Show(exceptionManejada.Message, "ERROR AL ELIMINAR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
