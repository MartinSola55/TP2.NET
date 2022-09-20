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

namespace UI.Desktop
{
    public partial class CargoDesktop : ApplicationForm
    {
        private PersonaLogic pl = new PersonaLogic();
        public CargoDesktop()
        {
            InitializeComponent();
        }
        public Business.Entities.DocenteCurso CargoActual
        {
            get;
            set;
        }
        public CargoDesktop(ModoForm modo, int IDDocente) : this()
        {
            this.txtIDDocente.Text = IDDocente.ToString();
            Modo = modo;
            if (modo == ModoForm.Alta)
            {
                btnAceptar.Text = "Guardar";
            }
            this.ListarCombo();
        }
        public CargoDesktop(int id, ModoForm modo) : this()
        {
            CargoActual = pl.GetInscripcionDocente(id);
            Modo = modo;
            this.txtIDDocente.Text = this.CargoActual.IDDocente.ToString();
            this.ListarCombo();
            if (modo == ModoForm.Alta)
            {
                btnAceptar.Text = "Guardar";
            }
            else
            {
                this.MapearDeDatos();
            }
        }
        public override void MapearDeDatos()
        {
            this.txtID.Text = this.CargoActual.ID.ToString();
            this.txtIDDocente.Text = this.CargoActual.IDDocente.ToString();
            this.txtCargo.Text = this.CargoActual.Cargo;
            this.comboCursos.SelectedValue = this.CargoActual.IDCurso;
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
                        txtCargo.Enabled = false;
                        comboCursos.Enabled = false;
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
                Business.Entities.DocenteCurso cargo = new Business.Entities.DocenteCurso();
                CargoActual = cargo;
            }
            CargoActual.IDDocente = int.Parse(this.txtIDDocente.Text);
            if (this.Modo == ModoForm.Alta || this.Modo == ModoForm.Modificacion)
            {
                this.CargoActual.Cargo = this.txtCargo.Text;
                this.CargoActual.IDCurso = int.Parse(this.comboCursos.SelectedValue.ToString());
                if (this.Modo == ModoForm.Alta)
                {
                    this.CargoActual.State = BusinessEntity.States.New;
                }
                else
                {
                    this.CargoActual.State = BusinessEntity.States.Modified;
                }
            }
            if (this.Modo == ModoForm.Baja)
            {
                this.CargoActual.State = BusinessEntity.States.Deleted;
            }
        }
        public override bool Validar()
        {
            DocenteCurso dc = new DocenteCurso
            {
                ID = this.txtID.Text != "" ? int.Parse(this.txtID.Text) : 0,
                IDCurso = int.Parse(this.comboCursos.SelectedValue.ToString()),
                IDDocente = int.Parse(this.txtIDDocente.Text)
            };
            if (txtCargo.Text.Length == 0)
            {
                this.Notificar("ERROR", "Debes ingresar un cargo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (this.comboCursos.SelectedValue.ToString() == "0")
            {
                this.Notificar("ERROR", "Debes seleccionar un curso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (!Validaciones.esDireccionValida(this.txtCargo.Text))
            {
                this.Notificar("ERROR", "Sólo se permite un cargo con caracteres alfanuméricos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (pl.EsInscripcionRepetida(dc))
            {
                this.Notificar("ERROR", "El docente ya cuenta con un cargo en este curso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
        public override void GuardarCambios()
        {
            this.MapearADatos();
            pl.SaveIns(CargoActual);
        }
        private void ListarCombo()
        {
            CursoLogic cl = new CursoLogic();
            List<Curso> cursos = cl.GetAll();
            Dictionary<int, string> comboSource = new Dictionary<int, string>();
            comboSource.Add(0, "-- Seleccione un curso --");
            foreach (Curso c in cursos)
            {
                comboSource.Add(c.ID, c.AnioCalendario + " - " + c.ComisionDesc + " - " + c.MateriaDesc);
            }
            this.comboCursos.DataSource = new BindingSource(comboSource, null);
            this.comboCursos.DisplayMember = "Value";
            this.comboCursos.ValueMember = "Key";
            this.comboCursos.SelectedValue = 0;
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
                MessageBox.Show("Alguno de los campos ingresados no tiene el formato adecuado", "ERROR AL GUARDAR LA INSCRIPCIÓN", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception exceptionManejada)
            {
                MessageBox.Show(exceptionManejada.Message, "ERROR AL GUARDAR LA INSCRIPCIÓN", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
