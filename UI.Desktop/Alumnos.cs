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
    public partial class Alumnos : ApplicationForm
    {
        public Alumnos()
        {
            InitializeComponent();
            this.dgvPersonas.AutoGenerateColumns = false;
        }
        public void Listar()
        {
            try
            {
                PersonaLogic pl = new PersonaLogic();
                this.dgvPersonas.DataSource = pl.GetAlumnos();
            }
            catch (Exception exceptionManejada)
            {
                MessageBox.Show(exceptionManejada.Message, "ERROR AL RECUPERAR ALUMNOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Personas_Load(object sender, EventArgs e)
        {
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
            PersonaDesktop ad = new PersonaDesktop(ApplicationForm.ModoForm.Alta);
            ad.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvPersonas.SelectedRows != null)
                {
                    int ID = ((Persona)this.dgvPersonas.SelectedRows[0].DataBoundItem).ID;
                    PersonaDesktop ad = new PersonaDesktop(ID, ApplicationForm.ModoForm.Modificacion);
                    ad.ShowDialog();
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
                int ID = ((Persona)this.dgvPersonas.SelectedRows[0].DataBoundItem).ID;
                PersonaDesktop ad = new PersonaDesktop(ID, ApplicationForm.ModoForm.Baja);
                ad.ShowDialog();
                this.Listar();
            }
            catch (Exception exceptionManejada)
            {
                MessageBox.Show(exceptionManejada.Message, "ERROR AL ELIMINAR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsbInscripciones_Click(object sender, EventArgs e)
        {
            try
            {
                int ID = ((Business.Entities.Persona)this.dgvPersonas.SelectedRows[0].DataBoundItem).ID;
                AlumnoInscripcion ai = new AlumnoInscripcion(ID);
                ai.ShowDialog();
                this.Listar();
            }
            catch (Exception exceptionManejada)
            {
                MessageBox.Show(exceptionManejada.Message, "ERROR AL VER LAS INSCRIPCIONES", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnActualizar_MouseEnter(object sender, EventArgs e)
        {
            this.btnActualizar.BackColor = Color.White;
            this.btnActualizar.ForeColor = Color.FromArgb(44, 48, 52);
        }

        private void btnActualizar_MouseLeave(object sender, EventArgs e)
        {
            this.btnActualizar.BackColor = Color.FromArgb(44, 48, 52);
            this.btnActualizar.ForeColor = Color.White;
        }

        private void btnSalir_MouseEnter(object sender, EventArgs e)
        {
            this.btnSalir.BackColor = Color.Red;
            this.btnSalir.ForeColor = Color.FromArgb(44, 48, 52);
        }

        private void btnSalir_MouseLeave(object sender, EventArgs e)
        {
            this.btnSalir.BackColor = Color.FromArgb(44, 48, 52);
            this.btnSalir.ForeColor = Color.Red;
        }

        private void tsbEditar_MouseEnter(object sender, EventArgs e)
        {
            this.tsbEditar.ForeColor = Color.Black;
        }

        private void tsbEditar_MouseLeave(object sender, EventArgs e)
        {
            this.tsbEditar.ForeColor = Color.White;
        }

        private void tsbInscripciones_MouseEnter(object sender, EventArgs e)
        {
            this.tsbInscripciones.ForeColor = Color.Black;
        }

        private void tsbInscripciones_MouseLeave(object sender, EventArgs e)
        {
            this.tsbInscripciones.ForeColor = Color.White;
        }
    }
}
