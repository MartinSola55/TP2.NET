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
    public partial class EspecialidadDesktop : ApplicationForm
    {
        private EspecialidadLogic el = new EspecialidadLogic();
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
            List<string> errores = new List<string>();
            if (this.txtDesc.Text.Length == 0)
            {
                errores.Add("Debes ingresar una descripción");
            }
            if (this.txtDesc.Text.Length < 1 || this.txtDesc.Text.Length > 30)
            {
                errores.Add("Debes ingresar una descripción de entre 1 y 30 caracteres");
            }  
            if (!Validaciones.esNombreValido(this.txtDesc.Text))
            {
                errores.Add("Sólo se permiten caracteres alfanuméricos");
            }
            if (errores.Count == 0)
            {
                if (el.GetByDescripcion(this.txtDesc.Text).ID != 0)
                {
                    this.Notificar("ERROR", "La especialidad que intenta guardar se encuentra repetida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                return true;
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
                return false;
            }
        }

        public EspecialidadDesktop(int id, ModoForm modo) : this()
        {
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
                if (Modo != ModoForm.Baja)
                {
                    if ( this.Validar())
                    {
                        this.GuardarCambios();
                        this.Close();
                    }
                } else
                {
                    this.GuardarCambios();
                    this.Close();
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
