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

namespace UI.Desktop.Personas.Docentes
{
    public partial class CondicionesDesktop : ApplicationForm
    {
        private PersonaLogic pl = new PersonaLogic();
        public CondicionesDesktop()
        {
            InitializeComponent();
        }
        public Business.Entities.AlumnoInscripcion CondicionActual
        {
            get;
            set;
        }
        public CondicionesDesktop(int id) : this()
        {
            CondicionActual = pl.GetInscripcionAlumnno(id);
            Modo = ModoForm.Modificacion;
            this.MapearDeDatos();
        }
        public override void MapearDeDatos()
        {
            this.txtID.Text = this.CondicionActual.ID.ToString();
            this.txtAlumno.Text = this.CondicionActual.NombreApellido;
            this.txtCondicion.Text = this.CondicionActual.Condicion;
            this.txtNota.Text = this.CondicionActual.Nota.ToString();
        }
        public override void MapearADatos()
        {
            this.CondicionActual.Condicion = this.txtCondicion.Text;
            this.CondicionActual.State = BusinessEntity.States.Modified;
            if (this.txtNota.Text != "")
            {
                this.CondicionActual.Nota = int.Parse(this.txtNota.Text);
            } else
            {
                this.CondicionActual.Nota = null;
            }
        }
        public override bool Validar()
        {
            if (txtCondicion.Text.Length == 0)
            {
                this.Notificar("ERROR", "Debes ingresar una condición", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (txtNota.Text != "")
            {
                if (int.Parse(txtNota.Text) < 0 || int.Parse(txtNota.Text) > 10)
                {
                    this.Notificar("ERROR", "Debes ingresar una nota entre 1 y 10", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            return true;
        }
        public override void GuardarCambios()
        {
            this.MapearADatos();
            pl.UpdateCondicion(CondicionActual);
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.Validar())
                {
                    this.GuardarCambios();
                    this.Close();
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Alguno de los campos ingresados no tiene el formato adecuado", "ERROR AL GUARDAR LA CONDICIÓN", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception exceptionManejada)
            {
                MessageBox.Show(exceptionManejada.Message, "ERROR AL GUARDAR LA CONDICIÓN", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
