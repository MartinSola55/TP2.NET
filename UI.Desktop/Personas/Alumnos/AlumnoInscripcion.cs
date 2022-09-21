using Business.Entities;
using Business.Logic;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
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

namespace UI.Desktop
{
    public partial class AlumnoInscripcion : ApplicationForm
    {
        private int IDAlumno;
        public Business.Entities.Persona AlumnoActual
        {
            get;
            set;
        }
        public AlumnoInscripcion(int id)
        {
            InitializeComponent();
            this.IDAlumno = id;
            this.dgvAlumnoInscripcion.AutoGenerateColumns = false;
            PersonaLogic pl = new PersonaLogic();
            AlumnoActual = pl.GetOne(IDAlumno);
            this.Text = "Inscripciones de " + AlumnoActual.Apellido + ", " + AlumnoActual.Nombre;
            this.MapearDeDatos();
        }
        public override void MapearDeDatos()
        {
            this.txtNombre.Text = this.AlumnoActual.Nombre;
            this.txtApellido.Text = this.AlumnoActual.Apellido;
            this.txtPlan.Text = this.AlumnoActual.DescPlan;
            this.txtLegajo.Text = this.AlumnoActual.Legajo.ToString();
            this.txtEmail.Text = this.AlumnoActual.Email;
            this.txtUsuario.Text = this.AlumnoActual.NombreUsuario;
        }
        public void Listar()
        {
            try
            {
                PersonaLogic pl = new PersonaLogic();
                this.dgvAlumnoInscripcion.DataSource = pl.GetInscripcionesAlumnno(IDAlumno);
            }
            catch (Exception exceptionManejada)
            {
                MessageBox.Show(exceptionManejada.Message, "ERROR AL RECUPERAR DATOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AlumnoInscripcion_Load(object sender, EventArgs e)
        {
            if (LoginInfo.TipoPersona != 3)
            {
                this.tsbEditar.Visible = false;
                this.tsbEliminar.Visible = false;
                this.toolStripSeparator1.Visible = false;
                this.toolStripSeparator2.Visible = false;
            }
            else
            {
                this.tsbEditar.Visible = true;
                this.tsbEliminar.Visible = true;
                this.toolStripSeparator1.Visible = true;
                this.toolStripSeparator2.Visible = true;
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
            InscripcionDesktop insd = new InscripcionDesktop(ApplicationForm.ModoForm.Alta, AlumnoActual.ID);
            insd.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvAlumnoInscripcion.SelectedRows != null)
                {
                    int ID = ((Business.Entities.AlumnoInscripcion)this.dgvAlumnoInscripcion.SelectedRows[0].DataBoundItem).ID;
                    InscripcionDesktop insd = new InscripcionDesktop(ID, ApplicationForm.ModoForm.Modificacion);
                    insd.ShowDialog();
                    this.Listar();
                }
            }
            catch (Exception exceptionManejada)
            {
                MessageBox.Show(exceptionManejada.Message, "ERROR AL EDITAR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                int ID = ((Business.Entities.AlumnoInscripcion)this.dgvAlumnoInscripcion.SelectedRows[0].DataBoundItem).ID;
                InscripcionDesktop insd = new InscripcionDesktop(ID, ApplicationForm.ModoForm.Baja);
                insd.ShowDialog();
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

        private void tsAlumnoInscripcion_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            try
            {
                SaveFileDialog save = new SaveFileDialog();
                save.FileName = "Condición alumno.pdf";
                string html = Properties.Resources.Condicion_alumno.ToString();

                double? notas = 0;
                int total = 0;

                string filas = string.Empty;
                int i = 0;

                foreach (DataGridViewRow row in dgvAlumnoInscripcion.Rows)
                {
                    i++;
                    if (i % 2 == 0)
                    {
                        filas += "<tr>";
                        filas += "<td style='text-align: center;'>" + row.Cells["DescripcionPlan"].Value.ToString() + "</td>";
                        filas += "<td>" + row.Cells["DescripcionMateria"].Value.ToString() + "</td>";
                        filas += "<td>" + row.Cells["DescripcionCondicion"].Value.ToString() + "</td>";
                        if (row.Cells["nota"].Value != null)
                        {
                            filas += "<td style='text-align: center;'>" + row.Cells["nota"].Value.ToString() + "</td>";
                        } else
                        {
                            filas += "<td></td>";
                        }
                        filas += "</tr>";
                    }
                    else
                    {
                        filas += "<tr style='background-color: #E0E0E0'>";
                        filas += "<td style='text-align: center;'>" + row.Cells["DescripcionPlan"].Value.ToString() + "</td>";
                        filas += "<td>" + row.Cells["DescripcionMateria"].Value.ToString() + "</td>";
                        filas += "<td>" + row.Cells["DescripcionCondicion"].Value.ToString() + "</td>";
                        if (row.Cells["nota"].Value != null)
                        {
                            filas += "<td style='text-align: center;'>" + row.Cells["nota"].Value.ToString() + "</td>";
                        }
                        else
                        {
                            filas += "<td></td>";
                        }
                        filas += "</tr>";
                    }
                    if (row.Cells["nota"].Value != null)
                    {
                        notas += int.Parse(row.Cells["nota"].Value.ToString());
                        total++;
                    }
                }

                double? prom = notas / total;

                html = html.Replace("@FECHA", DateTime.Now.ToShortDateString() + " - " + DateTime.Now.ToShortTimeString() + " hs.");
                html = html.Replace("@FILAS", filas);
                html = html.Replace("@NOMBRE", this.txtApellido.Text + ", " + this.txtNombre.Text);
                html = html.Replace("@PROMEDIO", Math.Round(prom ?? 0, 2).ToString());

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
            }
            catch (Exception)
            {
                MessageBox.Show("Ocurrió un error al intentar generar el reporte del alumno", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            };
        }
    }
}
