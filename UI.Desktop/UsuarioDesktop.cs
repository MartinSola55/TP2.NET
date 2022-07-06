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
        public Usuario UsuarioActual
        {
            get;
            set;
        }
        public UsuarioDesktop(ModoForm modo) : this() 
        {
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
            this.txtNombre.Text = this.UsuarioActual.Nombre;
            this.txtApellido.Text = this.UsuarioActual.Apellido;
            this.txtEmail.Text = this.UsuarioActual.Email;
            this.txtUsuario.Text = this.UsuarioActual.NombreUsuario;
            this.txtClave.Text = this.UsuarioActual.Clave;
            this.txtConfimarClave.Text = this.UsuarioActual.Clave;
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
                        txtNombre.Enabled = false;
                        txtApellido.Enabled = false;
                        txtEmail.Enabled = false;
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
            if (this.Modo == ModoForm.Alta)
            {
                Usuario usuario = new Usuario();
                UsuarioActual = usuario;
            }
            if (this.Modo == ModoForm.Alta || this.Modo == ModoForm.Modificacion)
            {
                this.UsuarioActual.Habilitado = this.chkHabilitado.Checked;
                this.UsuarioActual.Nombre = this.txtNombre.Text;
                this.UsuarioActual.Apellido = this.txtApellido.Text;
                this.UsuarioActual.Email = this.txtEmail.Text;
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
            if (this.txtNombre.Text.Length == 0 || this.txtApellido.Text.Length == 0 || this.txtEmail.Text.Length == 0 ||
                this.txtUsuario.Text.Length == 0 || this.txtClave.Text.Length == 0 || this.txtConfimarClave.Text.Length == 0)
            {
                this.Notificar("ERROR", "Debes completar todos los campos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (this.txtConfimarClave.Text != this.txtClave.Text)
            {
                this.Notificar("ERROR", "Las contraseñas no coinciden", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (this.txtClave.Text.Length < 8)
            {
                this.Notificar("ERROR", "La contraseña debe ser de al menos 8 carateres", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (Validaciones.esMailValido(this.txtEmail.Text) == false)
            {
                this.Notificar("ERROR", "El formato del email es inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
    }
}