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
    public partial class ComisionDesktop : ApplicationForm
    {
        public ComisionDesktop()
        {
            InitializeComponent();
        }

        private void ComisionDesktop_Load(object sender, EventArgs e)
        {

        }
        public Comision ComisionActual
        {
            get;
            set;
        }
        public ComisionDesktop(ModoForm modo) : this()
        {
            Modo = modo;
            if (modo == ModoForm.Alta)
            {
                btnAceptar.Text = "Guardar";
            }

        }
        public ComisionDesktop(int id, ModoForm modo) : this()
        {
            ComisionLogic cl = new ComisionLogic();
            ComisionActual = cl.GetOne(id);
            Modo = modo;
            this.MapearDeDatos();
        }
        public override void MapearDeDatos()
        {
            this.txtID.Text = this.ComisionActual.ID.ToString();
            this.txtDescripcion.Text = this.ComisionActual.Descripcion;
            this.txtAnio.Text = this.ComisionActual.AnioEspecialidad.ToString();
            this.txtIDPlan.Text = this.ComisionActual.IDPlan.ToString();
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
                        txtDescripcion.Enabled = false;
                        txtAnio.Enabled = false;
                        txtIDPlan.Enabled = false;
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
                Comision comision = new Comision();
                ComisionActual = comision;
            }
            if (this.Modo == ModoForm.Alta || this.Modo == ModoForm.Modificacion)
            {
                this.ComisionActual.Descripcion = this.txtDescripcion.Text;
                this.ComisionActual.AnioEspecialidad = int.Parse(this.txtAnio.Text);
                this.ComisionActual.IDPlan = int.Parse(this.txtIDPlan.Text);
                if (this.Modo == ModoForm.Alta)
                {
                    this.ComisionActual.State = BusinessEntity.States.New;
                }
                else
                {
                    this.ComisionActual.State = BusinessEntity.States.Modified;
                }
            }
            if (this.Modo == ModoForm.Baja)
            {
                this.ComisionActual.State = BusinessEntity.States.Deleted;
            }
        }
        public override bool Validar()
        {
            if (this.txtDescripcion.Text.Length == 0 || this.txtAnio.Text.Length == 0 || this.txtIDPlan.Text.Length == 0)
            {
                this.Notificar("ERROR", "Debes completar todos los campos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            } else if (int.Parse(this.txtAnio.Text) < 1980 || int.Parse(this.txtAnio.Text) > System.DateTime.Now.Year)
            {
                this.Notificar("ERROR", "Debes añadir un año válido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
        public override void GuardarCambios()
        {
            this.MapearADatos();
            ComisionLogic cl = new ComisionLogic();
            cl.Save(ComisionActual);
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
            } catch (FormatException)
            {
                MessageBox.Show("El formato del año o el ID no son válidos", "ERROR AL GUARDAR LA COMISIÓN", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } catch (Exception exceptionManejada)
            {
                MessageBox.Show(exceptionManejada.Message, "ERROR AL GUARDAR LA COMISIÓN", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
