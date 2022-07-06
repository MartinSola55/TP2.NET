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
    public partial class CursoDesktop : ApplicationForm
    {
        public CursoDesktop()
        {
            InitializeComponent();
        }
        private void CursoDesktop_Load(object sender, EventArgs e)
        {

        }
        public Curso CursoActual
        {
            get;
            set;
        }
        public CursoDesktop(ModoForm modo) : this()
        {
            Modo = modo;
            if (modo == ModoForm.Alta)
            {
                btnAceptar.Text = "Guardar";
            }

        }
        public CursoDesktop(int id, ModoForm modo) : this()
        {
            CursoLogic cl = new CursoLogic();
            CursoActual = cl.GetOne(id);
            Modo = modo;
            this.MapearDeDatos();
        }
        public override void MapearDeDatos()
        {
            this.txtID.Text = this.CursoActual.ID.ToString();
            this.txtMateria.Text = this.CursoActual.IDMateria.ToString();
            this.txtComision.Text = this.CursoActual.IDComision.ToString();
            this.txtAnio.Text = this.CursoActual.AnioCalendario.ToString();
            this.txtCupo.Text = this.CursoActual.Cupo.ToString();
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
                        txtMateria.Enabled = false;
                        txtComision.Enabled = false;
                        txtAnio.Enabled = false;
                        txtCupo.Enabled = false;
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
                Curso curso = new Curso();
                CursoActual = curso;
            }
            if (this.Modo == ModoForm.Alta || this.Modo == ModoForm.Modificacion)
            {
                this.CursoActual.IDMateria = int.Parse(this.txtMateria.Text);
                this.CursoActual.IDComision = int.Parse(this.txtComision.Text);
                this.CursoActual.AnioCalendario = int.Parse(this.txtAnio.Text);
                this.CursoActual.Cupo = int.Parse(this.txtCupo.Text);
                if (this.Modo == ModoForm.Alta)
                {
                    this.CursoActual.State = BusinessEntity.States.New;
                }
                else
                {
                    this.CursoActual.State = BusinessEntity.States.Modified;
                }
            }
            if (this.Modo == ModoForm.Baja)
            {
                this.CursoActual.State = BusinessEntity.States.Deleted;
            }
        }
        public override bool Validar()
        {
            if (txtMateria.Text.Length == 0 || txtComision.Text.Length == 0 || txtAnio.Text.Length == 0 || txtCupo.Text.Length == 0)
            {
                this.Notificar("ERROR", "Debes completar todos los campos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (int.Parse(txtAnio.Text) < 1980 || int.Parse(txtAnio.Text) > System.DateTime.Now.Year)
            {
                this.Notificar("ERROR", "Debes ingresar un año válido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (int.Parse(txtCupo.Text) <= 0 || int.Parse(txtCupo.Text) > 500)
            {
                this.Notificar("ERROR", "El cupo debe ser estar entre 1 y 500", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
        public override void GuardarCambios()
        {
            this.MapearADatos();
            CursoLogic cl = new CursoLogic();
            cl.Save(CursoActual);
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
                MessageBox.Show("Alguno de los campos ingresados no tiene el formato adecuado", "ERROR AL GUARDAR EL CURSO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } catch (Exception exceptionManejada)
            {
                MessageBox.Show(exceptionManejada.Message, "ERROR AL GUARDAR EL CURSO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
