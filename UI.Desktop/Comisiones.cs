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
    public partial class Comisiones : ApplicationForm
    {
        public Comisiones()
        {
            InitializeComponent();
            this.dgvComisiones.AutoGenerateColumns = false;
        }

        public void Listar()
        {
            try
            {
                ComisionLogic cl = new ComisionLogic();
                this.dgvComisiones.DataSource = cl.GetAll();
            } catch (Exception exceptionManejada)
            {
                MessageBox.Show(exceptionManejada.Message, "ERROR AL RECUPERAR COMISIONES", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Comisiones_Load(object sender, EventArgs e)
        {
            this.Listar();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            this.Listar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            ComisionDesktop cd = new ComisionDesktop(ApplicationForm.ModoForm.Alta);
            cd.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvComisiones.SelectedRows != null)
                {
                    int ID = ((Comision)this.dgvComisiones.SelectedRows[0].DataBoundItem).ID;
                    ComisionDesktop cd = new ComisionDesktop(ID, ApplicationForm.ModoForm.Modificacion);
                    cd.ShowDialog();
                    this.Listar();
                }
            } catch (Exception exceptionManejada)
            {
                MessageBox.Show(exceptionManejada.Message, "ERROR AL EDITAR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsbEliminnar_Click(object sender, EventArgs e)
        {
            try
            {
                int ID = ((Comision)this.dgvComisiones.SelectedRows[0].DataBoundItem).ID;
                ComisionDesktop cd = new ComisionDesktop(ID, ApplicationForm.ModoForm.Baja);
                cd.ShowDialog();
                this.Listar();
            } catch (Exception exceptionManejada)
            {
                MessageBox.Show(exceptionManejada.Message, "ERROR AL ELIMINAR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
