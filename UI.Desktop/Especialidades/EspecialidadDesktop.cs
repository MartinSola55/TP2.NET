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
    public partial class EspecialidadDesktop : ApplicationForm
    {
        public EspecialidadDesktop()
        {
            InitializeComponent();
        }
        public Business.Entities.Especialidad EspecialidadActual
        {
            get;
            set;
        }
        public EspecialidadDesktop(ModoForm modo) : this()
        {
            Modo = modo;
            if (modo == ModoForm.Alta)
            {
                btnAceptar.Text = "Guardar";
            }

        }

        public override bool Validar()
        {
            if (this.txtDesc.Text.Length == 0)
            {
                this.Notificar("ERROR", "Debes ingresar una descripción", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            } else if (this.txtDesc.Text.Length < 3 || this.txtDesc.Text.Length > 30)
            {
                this.Notificar("ERROR", "Debes ingresar una descripción de entre 3 y 30 caracteres", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            } else if (!Validaciones.esNombreValido(this.txtDesc.Text))
            {
                this.Notificar("ERROR", "Sólo se permiten caracteres alfanuméricos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        public EspecialidadDesktop(int id, ModoForm modo) : this()
        {
            EspecialidadLogic el = new EspecialidadLogic();
            EspecialidadActual = el.GetOne(id);
            Modo = modo;
            this.MapearDeDatos();
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.Validar())
                {
                    this.GuardarCambios();
                    this.Close();
                } else
                {
                    MessageBox.Show("Debes escribir una descripción", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            } catch (FormatException)
            {
                MessageBox.Show("Alguno de los campos ingresados no tiene el formato adecuado", "ERROR AL GUARDAR LA ESPECIALIDAD", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } catch (Exception exceptionManejada)
            {
                MessageBox.Show(exceptionManejada.Message, "ERROR AL GUARDAR LA ESPECIALIDAD", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public override void GuardarCambios()
        {
            try
            {
                this.MapearADatos();
                EspecialidadLogic el = new EspecialidadLogic();
                el.Save(EspecialidadActual);
            } catch (Exception exceptionManejada)
            {
                MessageBox.Show(exceptionManejada.Message, "ERROR AL GUARDAR LA ESPECIALIDAD", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public override void MapearDeDatos()
        {
            this.txtID.Text = this.EspecialidadActual.ID.ToString();
            this.txtDesc.Text = this.EspecialidadActual.Descripcion;
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
                        txtDesc.Enabled = false;
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
                Business.Entities.Especialidad especialidad = new Business.Entities.Especialidad();
                EspecialidadActual = especialidad;
            }
            if (this.Modo == ModoForm.Alta || this.Modo == ModoForm.Modificacion)
            {
                this.EspecialidadActual.Descripcion = this.txtDesc.Text;
                if (this.Modo == ModoForm.Alta)
                {
                    this.EspecialidadActual.State = BusinessEntity.States.New;
                }
                else
                {
                    this.EspecialidadActual.State = BusinessEntity.States.Modified;
                }
            }
            if (this.Modo == ModoForm.Baja)
            {
                this.EspecialidadActual.State = BusinessEntity.States.Deleted;
            }
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
