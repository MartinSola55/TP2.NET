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
    public partial class MateriaDesktop : ApplicationForm
    {
        private MateriaLogic ml = new MateriaLogic();
        public MateriaDesktop()
        {
            InitializeComponent();
        }

        public Materia MateriaActual
        {
            get;
            set;
        }
        public MateriaDesktop(ModoForm modo) : this()
        {
            Modo = modo;
            if (modo == ModoForm.Alta)
            {
                btnAceptar.Text = "Guardar";
            }
            this.ListarCombo();
        }
        public MateriaDesktop(int id, ModoForm modo) : this()
        {
            MateriaActual = ml.GetOne(id);
            Modo = modo;
            this.ListarCombo();
            this.MapearDeDatos();
        }
        public override void MapearDeDatos()
        {
            this.txtID.Text = this.MateriaActual.ID.ToString();
            this.txtDescripcion.Text = this.MateriaActual.Descripcion.ToString();
            this.txtHSSemanales.Text = this.MateriaActual.HSSemanales.ToString();
            this.txtHSTotales.Text = this.MateriaActual.HSTotales.ToString();
            this.comboPlan.SelectedValue = this.MateriaActual.IDPlan;
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
                        txtHSSemanales.Enabled = false;
                        txtHSTotales.Enabled = false;
                        comboPlan.Enabled = false;
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
                Materia materia = new Materia();
                MateriaActual = materia;
            }
            if (this.Modo == ModoForm.Alta || this.Modo == ModoForm.Modificacion)
            {
                this.MateriaActual.Descripcion = this.txtDescripcion.Text;
                this.MateriaActual.HSSemanales = int.Parse(this.txtHSSemanales.Text);
                this.MateriaActual.HSTotales = int.Parse(this.txtHSTotales.Text);
                this.MateriaActual.IDPlan = int.Parse(this.comboPlan.SelectedValue.ToString());
                if (this.Modo == ModoForm.Alta)
                {
                    this.MateriaActual.State = BusinessEntity.States.New;
                }
                else
                {
                    this.MateriaActual.State = BusinessEntity.States.Modified;
                }
            }
            if (this.Modo == ModoForm.Baja)
            {
                this.MateriaActual.State = BusinessEntity.States.Deleted;
            }
        }
        public override bool Validar()
        {
            if (txtDescripcion.Text.Length == 0 || txtHSSemanales.Text.Length == 0 || txtHSTotales.Text.Length == 0)
            {
                this.Notificar("ERROR", "Debes completar todos los campos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (int.Parse(txtHSSemanales.Text) < 1 || int.Parse(txtHSSemanales.Text) > 20)
            {
                this.Notificar("ERROR", "Ingrese entre 1 y 20 horas semanales", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (int.Parse(txtHSTotales.Text) < 1 || int.Parse(txtHSTotales.Text) > 500)
            {
                this.Notificar("ERROR", "Ingrese entre 1 y 500 horas totales", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            } else if (int.Parse(txtHSTotales.Text) <= int.Parse(txtHSSemanales.Text))
            {
                this.Notificar("ERROR", "Debes ingresar una cantidad de horas totales mayor a las semanales", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            } 
            else if (this.comboPlan.SelectedValue.ToString() == "0")
            {
                this.Notificar("ERROR", "Debes seleccionar un plan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            } else if (this.txtDescripcion.Text.Length < 3 || this.txtDescripcion.Text.Length > 50)
            {
                this.Notificar("ERROR", "Ingrese una descripción de entre 3 y 50 caracteres", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            } else if (!Validaciones.esDireccionValida(this.txtDescripcion.Text))
            {
                this.Notificar("ERROR", "Sólo se permite una descripción con caracteres alfanuméricos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            Materia mat = new Materia
            {
                Descripcion = this.txtDescripcion.Text,
                IDPlan = int.Parse(this.comboPlan.SelectedValue.ToString())
            };
            mat.ID = this.txtID.Text != "" ? int.Parse(this.txtID.Text) : 0;
            if (ml.GetRepetido(mat).ID != 0)
            {
                this.Notificar("ERROR", "La materia que deseas guardar ya existe", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
        public override void GuardarCambios()
        {
            this.MapearADatos();
            ml.Save(MateriaActual);
        }
        private void ListarCombo()
        {
            PlanLogic pl = new PlanLogic();
            List<Plan> planes = pl.GetAll();
            Dictionary<int, string> comboSource = new Dictionary<int, string>();
            comboSource.Add(0, "-- Seleccione un plan --");
            foreach (Plan p in planes)
            {
                comboSource.Add(p.ID, p.Descripcion + " - " + p.DescripcionEsp);
            }
            this.comboPlan.DataSource = new BindingSource(comboSource, null);
            this.comboPlan.DisplayMember = "Value";
            this.comboPlan.ValueMember = "Key";
            this.comboPlan.SelectedValue = 0;
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Modo != ModoForm.Baja)
                {
                    if (this.Validar())
                    {
                        this.GuardarCambios();
                        this.Close();
                    }
                }
                else
                {
                    this.GuardarCambios();
                    this.Close();
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Alguno de los campos ingresados no tiene el formato adecuado", "ERROR AL GUARDAR LA MATERIA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception exceptionManejada)
            {
                MessageBox.Show(exceptionManejada.Message, "ERROR AL GUARDAR LA MATERIA", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
