using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Entities;
using Business.Logic;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;

namespace UI.Desktop
{
    public partial class Cursos : ApplicationForm
    {
        public Cursos()
        {
            InitializeComponent();
            this.dgvCursos.AutoGenerateColumns = false;
        }
        public void Listar()
        {
            try
            {
                CursoLogic cl = new CursoLogic();
                this.dgvCursos.DataSource = cl.GetAll();
            } catch (Exception exceptionManejada)
            {
                MessageBox.Show(exceptionManejada.Message, "ERROR AL RECUPERAR CURSOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Cursos_Load(object sender, EventArgs e)
        {
            if (LoginInfo.TipoPersona != 3)
            {
                this.tsbNuevo.Visible = false;
                this.tsbEditar.Visible = false;
                this.tsbEliminar.Visible = false;
                this.toolStripSeparator1.Visible = false;
                this.toolStripSeparator2.Visible = false;
                this.toolStripSeparator3.Visible = false;
            }
            else
            {
                this.tsbNuevo.Visible = true;
                this.tsbEditar.Visible = true;
                this.tsbEliminar.Visible = true;
                this.toolStripSeparator1.Visible = true;
                this.toolStripSeparator2.Visible = true;
                this.toolStripSeparator3.Visible = true;
            }
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
            CursoDesktop cd = new CursoDesktop(ApplicationForm.ModoForm.Alta);
            cd.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvCursos.SelectedRows != null)
                {
                    int ID = ((Curso)this.dgvCursos.SelectedRows[0].DataBoundItem).ID;
                    CursoDesktop cd = new CursoDesktop(ID, ApplicationForm.ModoForm.Modificacion);
                    cd.ShowDialog();
                    this.Listar();
                }
            } catch (Exception exceptionManejada)
            {
                MessageBox.Show(exceptionManejada.Message, "ERROR AL EDITAR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                int ID = ((Curso)this.dgvCursos.SelectedRows[0].DataBoundItem).ID;
                CursoDesktop cd = new CursoDesktop(ID, ApplicationForm.ModoForm.Baja);
                cd.ShowDialog();
                this.Listar();
            }
            catch (Exception exceptionManejada)
            {
                MessageBox.Show(exceptionManejada.Message, "ERROR AL ELIMINAR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnActualizar_MouseEnter(object sender, EventArgs e)
        {
            this.btnActualizar.BackColor = Color.White;
            this.btnActualizar.ForeColor = Color.FromArgb(44, 48, 52);
        }

        private void btnActualizar_MouseLeave(object sender, EventArgs e)
        {
            this.btnActualizar.BackColor = Color.FromArgb(44, 48, 52);
            this.btnActualizar.ForeColor = Color.White;
        }

        private void btnSalir_MouseEnter(object sender, EventArgs e)
        {
            this.btnSalir.BackColor = Color.Red;
            this.btnSalir.ForeColor = Color.FromArgb(44, 48, 52);
        }

        private void btnSalir_MouseLeave(object sender, EventArgs e)
        {
            this.btnSalir.BackColor = Color.FromArgb(44, 48, 52);
            this.btnSalir.ForeColor = Color.Red;
        }

        private void tsbEditar_MouseEnter(object sender, EventArgs e)
        {
            this.tsbEditar.ForeColor = Color.Black;
        }

        private void tsbEditar_MouseLeave(object sender, EventArgs e)
        {
            this.tsbEditar.ForeColor = Color.White;
        }

        private void tsbImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog save = new SaveFileDialog();
                save.FileName = "Reporte cursos.pdf";
                string html = Properties.Resources.Reporte_cursos.ToString();

                string filas = string.Empty;
                int i = 0;

                foreach (DataGridViewRow row in dgvCursos.Rows)
                {
                    i++;
                    if (i % 2 == 0)
                    {
                        filas += "<tr>";
                        filas += "<td style='text-align: center;'>" + row.Cells["ComisionDesc"].Value.ToString() + "</td>";
                        filas += "<td>" + row.Cells["MateriaDesc"].Value.ToString() + "</td>";
                        filas += "<td style='text-align: center;'>" + row.Cells["AnioCalendario"].Value.ToString() + "</td>";
                        filas += "<td style='text-align: center;'>" + row.Cells["cupo"].Value.ToString() + "</td>";
                        filas += "</tr>";
                    } else
                    {
                        filas += "<tr style='background-color: #E0E0E0'>";
                        filas += "<td style='text-align: center;'>" + row.Cells["ComisionDesc"].Value.ToString() + "</td>";
                        filas += "<td>" + row.Cells["MateriaDesc"].Value.ToString() + "</td>";
                        filas += "<td style='text-align: center;'>" + row.Cells["AnioCalendario"].Value.ToString() + "</td>";
                        filas += "<td style='text-align: center;'>" + row.Cells["cupo"].Value.ToString() + "</td>";
                        filas += "</tr>";
                    }
                
                }

                html = html.Replace("@FECHA", DateTime.Now.ToShortDateString() + " - " + DateTime.Now.ToShortTimeString() + " hs.");
                html = html.Replace("@FILAS", filas);

                if (save.ShowDialog() == DialogResult.OK)
                {
                    using (FileStream fs = new FileStream(save.FileName, FileMode.Create))
                    {
                        Document pdf = new Document(PageSize.A4, 25, 25, 25, 25);
                        PdfWriter pw = PdfWriter.GetInstance(pdf, fs);
                        pdf.Open();
                        pdf.Add(new Phrase(""));

                        iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(Properties.Resources.logoUTN_Negro, System.Drawing.Imaging.ImageFormat.Png);
                        img.ScaleToFit(200, 70);
                        img.Alignment = iTextSharp.text.Image.UNDERLYING;
                        img.SetAbsolutePosition(pdf.LeftMargin, pdf.Top - 40);
                        pdf.Add(img);

                        using (StringReader sr = new StringReader(html))
                        {
                            XMLWorkerHelper.GetInstance().ParseXHtml(pw, pdf, sr);
                        }

                        pdf.Close();

                        fs.Close();
                    }
                }
            } catch (Exception)
            {
                MessageBox.Show("Ocurrió un error al intentar generar el reporte de cursos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            };
        }
    }
}
