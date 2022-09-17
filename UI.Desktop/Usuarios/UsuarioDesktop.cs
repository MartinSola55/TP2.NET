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
    public partial class UsuarioDesktop : ApplicationForm
    {
        public UsuarioDesktop()
        {
            InitializeComponent();
        }

        private void UsuarioDesktop_Load(object sender, EventArgs e)
        {

        }
        private void tlUsuario_Paint(object sender, PaintEventArgs e)
        {

        }
        public Business.Entities.Usuario UsuarioActual
        {
            get;
            set;
        }
        public UsuarioDesktop(ModoForm modo, int IDPersona) : this() 
        {
            UsuarioActual = new Usuario();
            UsuarioActual.IDPersona = IDPersona;
            Modo = modo;
            if (modo == ModoForm.Alta) 
            {
                btnAceptar.Text = "Guardar";
            } 
                
        }
        public UsuarioDesktop(int id, ModoForm modo) : this() 
        {
            UsuarioLogic ul = new UsuarioLogic();
            UsuarioActual = ul.GetOne(id);
            Modo = modo;
            this.MapearDeDatos();
        }
        public override void MapearDeDatos()
        {
            this.txtID.Text = this.UsuarioActual.ID.ToString();
            this.chkHabilitado.Checked = this.UsuarioActual.Habilitado;
            this.txtUsuario.Text = this.UsuarioActual.NombreUsuario;
            this.txtClave.Text = this.UsuarioActual.Clave;
            switch (this.Modo)
            {
                case ModoForm.Modificacion:
                    {
                        btnAceptar.Text = "Guardar";
                        break;
                    }
                case ModoForm.Baja:
                    {
                        this.txtConfimarClave.Text = this.UsuarioActual.Clave;
                        btnAceptar.Text = "Eliminar";
                        txtUsuario.Enabled = false;
                        txtClave.Enabled = false;
                        txtConfimarClave.Enabled = false;
                        chkHabilitado.Enabled = false;
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
            if (this.Modo == ModoForm.Alta || this.Modo == ModoForm.Modificacion)
            {
                this.UsuarioActual.Habilitado = this.chkHabilitado.Checked;
                this.UsuarioActual.NombreUsuario = this.txtUsuario.Text;
                this.UsuarioActual.Clave = this.txtClave.Text;
                this.UsuarioActual.Clave = this.txtConfimarClave.Text;
                if (this.Modo == ModoForm.Alta)
                {
                    this.UsuarioActual.State = BusinessEntity.States.New;
                } else
                {
                    this.UsuarioActual.State = BusinessEntity.States.Modified;
                }
            }
            if (this.Modo == ModoForm.Baja)
            {
                this.UsuarioActual.State = BusinessEntity.States.Deleted;
            }
        }
        public override bool Validar()
        {
            if (this.txtUsuario.Text.Length == 0 || this.txtClave.Text.Length == 0 || this.txtConfimarClave.Text.Length == 0)
            {
                this.Notificar("ERROR", "Debes completar todos los campos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (this.txtConfimarClave.Text != this.txtClave.Text)
            {
                this.Notificar("ERROR", "Las contraseñas no coinciden", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (this.txtUsuario.Text.Length < 5 || this.txtUsuario.Text.Length > 18)
            {
                this.Notificar("ERROR", "El usuario debe contener entre 5 y 18 caracteres", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (this.txtClave.Text.Length < 3)
            {
                this.Notificar("ERROR", "La contraseña debe ser de al menos 3 carateres", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (!Validaciones.esUsuarioValido(this.txtUsuario.Text))
            {
                this.Notificar("ERROR", "Debes ingresar un usuario válido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (!Validaciones.esPassValida(this.txtClave.Text))
            {
                this.Notificar("ERROR", "Debes ingresar una contraseña válida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
        public override void GuardarCambios()
        {
            try
            {
                this.MapearADatos();
                UsuarioLogic ul = new UsuarioLogic();
                ul.Save(UsuarioActual);
            } catch (Exception exceptionManejada)
            {
                MessageBox.Show(exceptionManejada.Message, "ERROR AL GUARDAR EL USUARIO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (this.Validar())
            {
                this.GuardarCambios();
                this.Close();
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