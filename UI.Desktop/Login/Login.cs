﻿using System;
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
            if (this.txtUsuario.Text == "")
            {
                MessageBox.Show("Por favor, ingrese un usuario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            } else if (this.txtPass.Text == "")
            {
                MessageBox.Show("Por favor, ingrese una contraseña", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            } else if (this.Validar())
            {
                this.DialogResult = DialogResult.OK;
            } else
            {
                MessageBox.Show("Usuario y/o contraseña incorrectos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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