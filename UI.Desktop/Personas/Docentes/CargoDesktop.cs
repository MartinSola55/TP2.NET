﻿using Business.Entities;
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
            this.ListarCombos();
        }
        public CargoDesktop(int id, ModoForm modo) : this()
        {
            CargoActual = pl.GetInscripcionDocente(id);
            Modo = modo;
            this.txtIDDocente.Text = this.CargoActual.IDDocente.ToString();
            this.ListarCombos();
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
            this.comboCargos.SelectedValue = this.CargoActual.IDCargo;
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
                        comboCargos.Enabled = false;
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
                this.CargoActual.IDCargo = int.Parse(this.comboCargos.SelectedValue.ToString());
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
            List<string> errores = new List<string>();
            if (this.comboCargos.SelectedValue.ToString() == "0")
            {
                errores.Add("Debes ingresar un cargo");
            }
            if (this.comboCursos.SelectedValue.ToString() == "0")
            {
                errores.Add("Debes seleccionar un curso");
            }

            if (errores.Count == 0)
            {
                DocenteCurso dc = new DocenteCurso
                {
                    ID = this.txtID.Text != "" ? int.Parse(this.txtID.Text) : 0,
                    IDCurso = int.Parse(this.comboCursos.SelectedValue.ToString()),
                    IDDocente = int.Parse(this.txtIDDocente.Text)
                };
                if (pl.EsInscripcionRepetida(dc))
                {
                    this.Notificar("ERROR", "El docente ya cuenta con un cargo en este curso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
        public override void GuardarCambios()
        {
            this.MapearADatos();
            pl.SaveIns(CargoActual);
        }
        private void ListarCombos()
        {
            CursoLogic cl = new CursoLogic();
            CargoLogic carl = new CargoLogic();
            List<Curso> cursos = cl.GetAll();
            List<Cargo> cargos = carl.GetAll();
            Dictionary<int, string> comboSource = new Dictionary<int, string>();
            Dictionary<int, string> comboSourceCargos = new Dictionary<int, string>();
            comboSource.Add(0, "-- Seleccione un curso --");
            comboSourceCargos.Add(0, "-- Seleccione un cargo --");
            foreach (Curso c in cursos)
            {
                comboSource.Add(c.ID, c.AnioCalendario + " - " + c.ComisionDesc + " - " + c.MateriaDesc);
            }
            foreach (Cargo c in cargos)
            {
                comboSourceCargos.Add(c.ID, c.Descripcion);
            }
            this.comboCursos.DataSource = new BindingSource(comboSource, null);
            this.comboCargos.DataSource = new BindingSource(comboSourceCargos, null);
            this.comboCursos.DisplayMember = "Value";
            this.comboCargos.DisplayMember = "Value";
            this.comboCursos.ValueMember = "Key";
            this.comboCargos.ValueMember = "Key";
            this.comboCursos.SelectedValue = 0;
            this.comboCargos.SelectedValue = 0;
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
