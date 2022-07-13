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
        private void btnCursos_Click(object sender, EventArgs e)
        {
            Cursos cursos = new Cursos();
            cursos.ShowDialog();
            cursos.Listar();
        }
        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            Usuarios usuarios = new Usuarios();
            usuarios.ShowDialog();
            usuarios.Listar();
        }
        private void btnEspecialidades_Click(object sender, EventArgs e)
        {
            Especialidades especialidades = new Especialidades();
            especialidades.ShowDialog();
            especialidades.Listar();
        }
        private void btnComisiones_Click(object sender, EventArgs e)
        {
            Comisiones comisiones = new Comisiones();
            comisiones.ShowDialog();
            comisiones.Listar();
        }
        private void btnPlanes_Click(object sender, EventArgs e)
        {
            Planes planes = new Planes();
            planes.ShowDialog();
            planes.Listar();
        }
        private void btnMaterias_Click(object sender, EventArgs e)
        {
            Materias materias = new Materias();
            materias.ShowDialog();
            materias.Listar();
        }
        private void mnuSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        private void Main_Shown(object sender, EventArgs e)
        {
            Login login = new Login();
            if (login.ShowDialog() != DialogResult.OK)
            {
                this.Dispose();
            }
        }

        private void mnuArchivo_CheckStateChanged(object sender, EventArgs e)
        {
            if (this.mnuArchivo.CheckState == CheckState.Checked) {
                this.mnuArchivo.BackColor = Color.FromArgb(44, 48, 52);
            }
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

        private void btnCursos_MouseEnter(object sender, EventArgs e)
        {
            this.btnCursos.BackColor = Color.White;
            this.btnCursos.ForeColor = Color.FromArgb(44, 48, 52);
        }

        private void btnCursos_MouseLeave(object sender, EventArgs e)
        {
            this.btnCursos.BackColor = Color.FromArgb(44, 48, 52);
            this.btnCursos.ForeColor = Color.White;
        }

        private void btnUsuarios_MouseEnter(object sender, EventArgs e)
        {
            this.btnUsuarios.BackColor = Color.White;
            this.btnUsuarios.ForeColor = Color.FromArgb(44, 48, 52);
        }

        private void btnUsuarios_MouseLeave(object sender, EventArgs e)
        {
            this.btnUsuarios.BackColor = Color.FromArgb(44, 48, 52);
            this.btnUsuarios.ForeColor = Color.White;
        }

        private void btnPlanes_MouseEnter(object sender, EventArgs e)
        {
            this.btnPlanes.BackColor = Color.White;
            this.btnPlanes.ForeColor = Color.FromArgb(44, 48, 52);
        }

        private void btnPlanes_MouseLeave(object sender, EventArgs e)
        {
            this.btnPlanes.BackColor = Color.FromArgb(44, 48, 52);
            this.btnPlanes.ForeColor = Color.White;
        }

        private void btnEspecialidades_MouseEnter(object sender, EventArgs e)
        {
            this.btnEspecialidades.BackColor = Color.White;
            this.btnEspecialidades.ForeColor = Color.FromArgb(44, 48, 52);
        }

        private void btnEspecialidades_MouseLeave(object sender, EventArgs e)
        {
            this.btnEspecialidades.BackColor = Color.FromArgb(44, 48, 52);
            this.btnEspecialidades.ForeColor = Color.White;
        }

        private void btnComisiones_MouseEnter(object sender, EventArgs e)
        {
            this.btnComisiones.BackColor = Color.White;
            this.btnComisiones.ForeColor = Color.FromArgb(44, 48, 52);
        }

        private void btnComisiones_MouseLeave(object sender, EventArgs e)
        {
            this.btnComisiones.BackColor = Color.FromArgb(44, 48, 52);
            this.btnComisiones.ForeColor = Color.White;
        }

        private void btnMaterias_MouseEnter(object sender, EventArgs e)
        {
            this.btnMaterias.BackColor = Color.White;
            this.btnMaterias.ForeColor = Color.FromArgb(44, 48, 52);
        }

        private void btnMaterias_MouseLeave(object sender, EventArgs e)
        {
            this.btnMaterias.BackColor = Color.FromArgb(44, 48, 52);
            this.btnMaterias.ForeColor = Color.White;
        }
    }
}
