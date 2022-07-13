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
            if (this.Validar())
            {
                MessageBox.Show("Ha ingresado correctamente al sistema", "Enhorabuena", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
            } else
            {
                MessageBox.Show("Usuario y/o contraseña incorrectos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void lnkOlvidaPass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Es Ud. un usuario muy descuidado, haga memoria", "Olvidé mi contraseña", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
