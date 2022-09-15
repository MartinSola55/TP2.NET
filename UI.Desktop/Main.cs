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
    public partial class Main : ApplicationForm
    {
        public Main()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void LogIn()
        {
            Login login = new Login();
            if (login.ShowDialog() == DialogResult.OK)
            {
                this.mnsPrincipal.Visible = true;
                this.lblBienvenido.Text = "Bienvenido al SYSACAD\n" + LoginInfo.NombreApellido;
                switch (LoginInfo.TipoPersona)
                {
                    case 1:
                        {
                            this.mnuUsuarios.Visible = false;
                            this.mnuPersonas.Visible = false;
                            this.mnuInscripciones.Visible = false;
                            this.mnuCargos.Visible = true;
                            break;
                        }
                    case 2:
                        {
                            this.mnuUsuarios.Visible = false;
                            this.mnuPersonas.Visible = false;
                            this.mnuInscripciones.Visible = true;
                            this.mnuCargos.Visible = false;
                            break;
                        }
                    case 3:
                        {
                            this.mnuUsuarios.Visible = true;
                            this.mnuPersonas.Visible = true;
                            this.mnuInscripciones.Visible = false;
                            this.mnuCargos.Visible = false;
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
            }
            else
            {
                this.Dispose();
            }
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            LoginInfo.IDPersona = null;
            LoginInfo.TipoPersona = null;
            LoginInfo.NombreApellido = null;
            this.lblBienvenido.Text = "Debes iniciar sesión";
            this.mnsPrincipal.Visible = false;
            this.LogIn();
        }

        private void mnuSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        private void Main_Shown(object sender, EventArgs e)
        {
            this.mnsPrincipal.Visible = false;
            this.LogIn();
        }

        private void mnuVerComisiones_Click(object sender, EventArgs e)
        {
            Comisiones comisiones = new Comisiones();
            comisiones.ShowDialog();
            comisiones.Listar();
        }

        private void mnuVerCursos_Click(object sender, EventArgs e)
        {
            Cursos cursos = new Cursos();
            cursos.ShowDialog();
            cursos.Listar();
        }

        private void mnuVerEspecialidades_Click(object sender, EventArgs e)
        {
            Especialidades especialidades = new Especialidades();
            especialidades.ShowDialog();
            especialidades.Listar();
        }

        private void mnuVerMaterias_Click(object sender, EventArgs e)
        {
            Materias materias = new Materias();
            materias.ShowDialog();
            materias.Listar();
        }

        private void mnuVerPlanes_Click(object sender, EventArgs e)
        {
            Planes planes = new Planes();
            planes.ShowDialog();
            planes.Listar();
        }

        private void mnuVerUsuarios_Click(object sender, EventArgs e)
        {
            Usuarios usuarios = new Usuarios();
            usuarios.ShowDialog();
            usuarios.Listar();
        }

        private void mnuAlumnos_Click(object sender, EventArgs e)
        {
            Alumnos alumnos = new Alumnos();
            alumnos.ShowDialog();
            alumnos.Listar();
        }

        private void mnuVerInscripciones_Click(object sender, EventArgs e)
        {
            AlumnoInscripcion inscripciones = new AlumnoInscripcion(LoginInfo.IDPersona ?? 0);
            inscripciones.ShowDialog();
            inscripciones.Listar();
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

        private void btnLogOut_MouseEnter(object sender, EventArgs e)
        {
            this.btnLogOut.BackColor = Color.FloralWhite;
            this.btnLogOut.ForeColor = Color.FromArgb(44, 48, 52);
        }

        private void btnLogOut_MouseLeave(object sender, EventArgs e)
        {
            this.btnLogOut.BackColor = Color.FromArgb(44, 48, 52);
            this.btnLogOut.ForeColor = Color.FloralWhite;
        }
    }
}
