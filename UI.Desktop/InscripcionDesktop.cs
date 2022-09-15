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
    public partial class InscripcionDesktop : ApplicationForm
    {
        private PersonaLogic pl = new PersonaLogic();
        public InscripcionDesktop()
        {
            InitializeComponent();
        }
        public Business.Entities.AlumnoInscripcion InscripcionActual
        {
            get;
            set;
        }
        public InscripcionDesktop(ModoForm modo, int IDAlumno) : this()
        {
            this.ValidaUsuario();
            this.txtIDAlumno.Text = IDAlumno.ToString();
            Modo = modo;
            if (modo == ModoForm.Alta)
            {
                btnAceptar.Text = "Guardar";
            }
            this.ListarCombo();
        }
        public InscripcionDesktop(int id, ModoForm modo) : this()
        {
            this.ValidaUsuario();
            InscripcionActual = pl.GetInscripcionAlumnno(id);
            Modo = modo;
            this.txtIDAlumno.Text = this.InscripcionActual.IDAlumno.ToString();
            this.ListarCombo();
            if (modo == ModoForm.Alta)
            {
                btnAceptar.Text = "Guardar";
            } else
            {
                this.MapearDeDatos();
            }
        }
        public void ValidaUsuario()
        {
            if (LoginInfo.TipoPersona != 3)
            {
                this.lblCondicion.Visible = false;
                this.txtCondicion.Visible = false;
                this.lblNota.Visible = false;
                this.txtNota.Visible = false;
            } else
            {
                this.lblCondicion.Visible = true;
                this.txtCondicion.Visible = true;
                this.lblNota.Visible = true;
                this.txtNota.Visible = true;
            }
        }
        public override void MapearDeDatos()
        {
            this.txtID.Text = this.InscripcionActual.ID.ToString();
            this.txtIDAlumno.Text = this.InscripcionActual.IDAlumno.ToString();
            this.txtCondicion.Text = this.InscripcionActual.Condicion;
            this.txtNota.Text = this.InscripcionActual.Nota.ToString();
            this.comboCursos.SelectedValue = this.InscripcionActual.IDCurso;
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
                        txtCondicion.Enabled = false;
                        txtNota.Enabled = false;
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
                Business.Entities.AlumnoInscripcion inscripcion = new Business.Entities.AlumnoInscripcion();
                InscripcionActual = inscripcion;
            }
            InscripcionActual.IDAlumno = int.Parse(this.txtIDAlumno.Text);
            if (this.Modo == ModoForm.Alta || this.Modo == ModoForm.Modificacion)
            {
                this.InscripcionActual.Condicion = this.txtCondicion.Text;
                if (this.txtNota.Text != "")
                {
                    this.InscripcionActual.Nota = int.Parse(this.txtNota.Text);
                } else
                {
                    this.InscripcionActual.Nota = null;
                }
                this.InscripcionActual.IDCurso = int.Parse(this.comboCursos.SelectedValue.ToString());
                if (this.Modo == ModoForm.Alta)
                {
                    this.InscripcionActual.State = BusinessEntity.States.New;
                }
                else
                {
                    this.InscripcionActual.State = BusinessEntity.States.Modified;
                }
            }
            if (this.Modo == ModoForm.Baja)
            {
                this.InscripcionActual.State = BusinessEntity.States.Deleted;
            }
        }
        public override bool Validar()
        {
            if (LoginInfo.TipoPersona == 3)
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
                else if (this.comboCursos.SelectedValue.ToString() == "0")
                {
                    this.Notificar("ERROR", "Debes seleccionar un curso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                } else if (pl.EsInscripcionRepetida(int.Parse(this.txtIDAlumno.Text), int.Parse(comboCursos.SelectedValue.ToString())))
                {
                    this.Notificar("ERROR", "El alumno ya se encuentra inscripto a esta materia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            } else if (LoginInfo.TipoPersona != 3)
            {
                if (this.comboCursos.SelectedValue.ToString() == "0")
                {
                    this.Notificar("ERROR", "Debes seleccionar un curso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                else if (pl.EsInscripcionRepetida(int.Parse(this.txtIDAlumno.Text), int.Parse(comboCursos.SelectedValue.ToString())))
                {
                    this.Notificar("ERROR", "Ya se encuentras inscripto a esta materia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            return true;
        }
        public override void GuardarCambios()
        {
            this.MapearADatos();
            pl.SaveIns(InscripcionActual);
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
                if (this.Validar())
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
