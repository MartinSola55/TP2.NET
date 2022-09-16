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
using UI.Desktop.Personas.Docentes;

namespace UI.Desktop
{
    public partial class CargosDocentes : ApplicationForm
    {
        private int IDDocente;
        public Business.Entities.Persona DocenteActual
        {
            get;
            set;
        }
        public CargosDocentes(int id)
        {
            InitializeComponent();
            this.IDDocente = id;
            this.dgvCargosDocente.AutoGenerateColumns = false;
            PersonaLogic pl = new PersonaLogic();
            DocenteActual = pl.GetOne(IDDocente);
            this.Text = "Cargos de " + DocenteActual.Apellido + ", " + DocenteActual.Nombre;
            this.MapearDeDatos();
        }
        public override void MapearDeDatos()
        {
            this.txtNombre.Text = this.DocenteActual.Nombre;
            this.txtApellido.Text = this.DocenteActual.Apellido;
            this.txtPlan.Text = this.DocenteActual.DescPlan;
            this.txtLegajo.Text = this.DocenteActual.Legajo.ToString();
            this.txtEmail.Text = this.DocenteActual.Email;
            this.txtUsuario.Text = this.DocenteActual.NombreUsuario;
        }
        public void Listar()
        {
            try
            {
                PersonaLogic pl = new PersonaLogic();
                this.dgvCargosDocente.DataSource = pl.GetInscripcionesDocente(IDDocente);
            }
            catch (Exception exceptionManejada)
            {
                MessageBox.Show(exceptionManejada.Message, "ERROR AL RECUPERAR DATOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargosDocentes_Load(object sender, EventArgs e)
        {
            if (LoginInfo.TipoPersona != 3)
            {
                this.tsbNotas.Visible = true;
                this.tsbNuevo.Visible = false;
                this.tsbEditar.Visible = false;
                this.tsbEliminar.Visible = false;
                this.toolStripSeparator1.Visible = false;
                this.toolStripSeparator2.Visible = false;
            }
            else
            {
                this.tsbNotas.Visible = false;
                this.tsbNuevo.Visible = true;
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
            CargoDesktop cargo = new CargoDesktop(ApplicationForm.ModoForm.Alta, DocenteActual.ID);
            cargo.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvCargosDocente.SelectedRows != null)
                {
                    int ID = ((Business.Entities.DocenteCurso)this.dgvCargosDocente.SelectedRows[0].DataBoundItem).ID;
                    CargoDesktop cargo = new CargoDesktop(ID, ApplicationForm.ModoForm.Modificacion);
                    cargo.ShowDialog();
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
                int ID = ((Business.Entities.DocenteCurso)this.dgvCargosDocente.SelectedRows[0].DataBoundItem).ID;
                CargoDesktop cargo = new CargoDesktop(ID, ApplicationForm.ModoForm.Baja);
                cargo.ShowDialog();
                this.Listar();
            }
            catch (Exception exceptionManejada)
            {
                MessageBox.Show(exceptionManejada.Message, "ERROR AL ELIMINAR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void tsbNotas_Click(object sender, EventArgs e)
        {
            int ID = ((Business.Entities.DocenteCurso)this.dgvCargosDocente.SelectedRows[0].DataBoundItem).IDCurso;
            CondicionesAlumnos notas = new CondicionesAlumnos(ID);
            notas.ShowDialog();
            this.Listar();
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

        private void tsbNotas_MouseEnter(object sender, EventArgs e)
        {
            this.tsbNotas.ForeColor = Color.Black;
        }

        private void tsbNotas_MouseLeave(object sender, EventArgs e)
        {
            this.tsbNotas.ForeColor = Color.White;
        }
    }
}
