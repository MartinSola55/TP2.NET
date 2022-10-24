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
    public partial class Login : ApplicationForm
    {
        public Login()
        {
            InitializeComponent();
        }
        public Usuario UsuarioActual
        {
            get;
            set;
        }
        public override bool Validar()
        {
            try
            {
                UsuarioLogic ul = new UsuarioLogic();
                if (ul.ValidaLogin(this.txtUsuario.Text, this.txtPass.Text))
                {
                    LoginInfo.IDPersona = ul.GetIDPersona(this.txtUsuario.Text, this.txtPass.Text);
                    LoginInfo.TipoPersona = ul.GetTipoUsuario(this.txtUsuario.Text, this.txtPass.Text);
                    LoginInfo.NombreApellido = ul.GetNombreApellido(this.txtUsuario.Text, this.txtPass.Text);
                    return true;
                }
            } catch (Exception exceptionManejada)
            {
                MessageBox.Show(exceptionManejada.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }
        private void btnIngresar_Click(object sender, EventArgs e)
        {
            List<string> errores = new List<string>();
            if (this.txtUsuario.Text == "")
            {
                errores.Add("Por favor, ingrese un usuario");
            }
            if (this.txtPass.Text == "")
            {
                errores.Add("Por favor, ingrese una contraseña");
            }
            if (!Validaciones.esUsuarioValido(this.txtUsuario.Text))
            { 
                errores.Add("Por favor, ingrese un usuario válido");
            }
            if (!Validaciones.esPassValida(this.txtPass.Text))
            { 
                errores.Add("Por favor, ingrese una contraseña válida");
            }
            if (errores.Count == 0)
            {
                if (this.Validar())
                {
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Usuario y/o contraseña incorrectos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                string cadena = "";
                foreach (string s in errores)
                {
                    cadena += s;
                    cadena += "\n";
                }
                this.Notificar("ERROR", cadena, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void lnkOlvidaPass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Contacte con un administrador para cambiar su contraseña", "Olvidé mi contraseña", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
        }

        private void btnIngresar_MouseEnter(object sender, EventArgs e)
        {
            this.btnIngresar.BackColor = Color.White;
            this.btnIngresar.ForeColor = Color.FromArgb(44, 48, 52);
        }

        private void btnIngresar_MouseLeave(object sender, EventArgs e)
        {
            this.btnIngresar.BackColor = Color.FromArgb(44, 48, 52);
            this.btnIngresar.ForeColor = Color.White;
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
    }
}
