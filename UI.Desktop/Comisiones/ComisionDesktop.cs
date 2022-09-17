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
            this.ListarCombo();
        }
        public ComisionDesktop(int id, ModoForm modo) : this()
        {
            ComisionLogic cl = new ComisionLogic();
            ComisionActual = cl.GetOne(id);
            Modo = modo;
            this.ListarCombo();
            this.MapearDeDatos();
        }
        public override void MapearDeDatos()
        {
            this.txtID.Text = this.ComisionActual.ID.ToString();
            this.txtDescripcion.Text = this.ComisionActual.Descripcion;
            this.txtAnio.Text = this.ComisionActual.AnioEspecialidad.ToString();
            this.comboPlan.SelectedValue = this.ComisionActual.IDPlan;
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
                Comision comision = new Comision();
                ComisionActual = comision;
            }
            if (this.Modo == ModoForm.Alta || this.Modo == ModoForm.Modificacion)
            {
                this.ComisionActual.Descripcion = this.txtDescripcion.Text;
                this.ComisionActual.AnioEspecialidad = int.Parse(this.txtAnio.Text);
                this.ComisionActual.IDPlan = int.Parse(this.comboPlan.SelectedValue.ToString());
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
            if (this.txtDescripcion.Text.Length == 0 || this.txtAnio.Text.Length == 0)
            {
                this.Notificar("ERROR", "Complete todos los campos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            } 
            else if (int.Parse(this.txtAnio.Text) < 1980 || int.Parse(this.txtAnio.Text) > System.DateTime.Now.Year)
            {
                this.Notificar("ERROR", "Complete con un año entre 1980 y " + System.DateTime.Now.Year, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (this.comboPlan.SelectedValue.ToString() == "0")
            {
                this.Notificar("ERROR", "Debes seleccionar un plan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            } else if (this.txtDescripcion.Text.Length < 3 || this.txtDescripcion.Text.Length > 30)
            {
                this.Notificar("ERROR", "Debes ingresar una descripción entre 3 y 30 caracteres", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            } else if (!Validaciones.esNombreValido(this.txtDescripcion.Text)) {
                this.Notificar("ERROR", "Sólo se permite una descripción con caracteres alfanuméricos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
