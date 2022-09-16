
namespace UI.Desktop
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.mnsPrincipal = new System.Windows.Forms.MenuStrip();
            this.mnuArchivo = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSalir = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuComisiones = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuVerComisiones = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCursos = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuVerCursos = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPrintCurso = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEspecialidades = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuVerEspecialidades = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMaterias = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuVerMaterias = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPlanes = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuVerPlanes = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuUsuarios = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuVerUsuarios = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuInscripciones = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuVerInscripciones = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPrintInscripciones = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCargos = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuVerCargos = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPersonas = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAlumnos = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDocentes = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnLogOut = new System.Windows.Forms.Button();
            this.lblBienvenido = new System.Windows.Forms.Label();
            this.mnsPrincipal.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnsPrincipal
            // 
            this.mnsPrincipal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(48)))), ((int)(((byte)(52)))));
            this.mnsPrincipal.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mnsPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuArchivo,
            this.mnuComisiones,
            this.mnuCursos,
            this.mnuEspecialidades,
            this.mnuMaterias,
            this.mnuPlanes,
            this.mnuUsuarios,
            this.mnuInscripciones,
            this.mnuCargos,
            this.mnuPersonas});
            this.mnsPrincipal.Location = new System.Drawing.Point(0, 0);
            this.mnsPrincipal.Name = "mnsPrincipal";
            this.mnsPrincipal.Size = new System.Drawing.Size(860, 28);
            this.mnsPrincipal.TabIndex = 1;
            this.mnsPrincipal.Text = "menuStrip1";
            // 
            // mnuArchivo
            // 
            this.mnuArchivo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(48)))), ((int)(((byte)(52)))));
            this.mnuArchivo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.mnuArchivo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSalir});
            this.mnuArchivo.ForeColor = System.Drawing.Color.White;
            this.mnuArchivo.Name = "mnuArchivo";
            this.mnuArchivo.Size = new System.Drawing.Size(73, 24);
            this.mnuArchivo.Text = "Archivo";
            // 
            // mnuSalir
            // 
            this.mnuSalir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(48)))), ((int)(((byte)(52)))));
            this.mnuSalir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.mnuSalir.ForeColor = System.Drawing.Color.White;
            this.mnuSalir.Name = "mnuSalir";
            this.mnuSalir.Size = new System.Drawing.Size(121, 26);
            this.mnuSalir.Text = "Salir";
            this.mnuSalir.Click += new System.EventHandler(this.mnuSalir_Click);
            // 
            // mnuComisiones
            // 
            this.mnuComisiones.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.mnuComisiones.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuVerComisiones});
            this.mnuComisiones.ForeColor = System.Drawing.Color.White;
            this.mnuComisiones.Name = "mnuComisiones";
            this.mnuComisiones.Size = new System.Drawing.Size(99, 24);
            this.mnuComisiones.Text = "Comisiones";
            // 
            // mnuVerComisiones
            // 
            this.mnuVerComisiones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(48)))), ((int)(((byte)(52)))));
            this.mnuVerComisiones.ForeColor = System.Drawing.Color.White;
            this.mnuVerComisiones.Name = "mnuVerComisiones";
            this.mnuVerComisiones.Size = new System.Drawing.Size(113, 26);
            this.mnuVerComisiones.Text = "Ver";
            this.mnuVerComisiones.Click += new System.EventHandler(this.mnuVerComisiones_Click);
            // 
            // mnuCursos
            // 
            this.mnuCursos.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuVerCursos,
            this.mnuPrintCurso});
            this.mnuCursos.ForeColor = System.Drawing.Color.White;
            this.mnuCursos.Name = "mnuCursos";
            this.mnuCursos.Size = new System.Drawing.Size(66, 24);
            this.mnuCursos.Text = "Cursos";
            // 
            // mnuVerCursos
            // 
            this.mnuVerCursos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(48)))), ((int)(((byte)(52)))));
            this.mnuVerCursos.ForeColor = System.Drawing.Color.White;
            this.mnuVerCursos.Name = "mnuVerCursos";
            this.mnuVerCursos.Size = new System.Drawing.Size(202, 26);
            this.mnuVerCursos.Text = "Ver";
            this.mnuVerCursos.Click += new System.EventHandler(this.mnuVerCursos_Click);
            // 
            // mnuPrintCurso
            // 
            this.mnuPrintCurso.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(48)))), ((int)(((byte)(52)))));
            this.mnuPrintCurso.ForeColor = System.Drawing.Color.White;
            this.mnuPrintCurso.Name = "mnuPrintCurso";
            this.mnuPrintCurso.Size = new System.Drawing.Size(202, 26);
            this.mnuPrintCurso.Text = "Imprimir reporte";
            // 
            // mnuEspecialidades
            // 
            this.mnuEspecialidades.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuVerEspecialidades});
            this.mnuEspecialidades.ForeColor = System.Drawing.Color.White;
            this.mnuEspecialidades.Name = "mnuEspecialidades";
            this.mnuEspecialidades.Size = new System.Drawing.Size(121, 24);
            this.mnuEspecialidades.Text = "Especialidades";
            // 
            // mnuVerEspecialidades
            // 
            this.mnuVerEspecialidades.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(48)))), ((int)(((byte)(52)))));
            this.mnuVerEspecialidades.ForeColor = System.Drawing.Color.White;
            this.mnuVerEspecialidades.Name = "mnuVerEspecialidades";
            this.mnuVerEspecialidades.Size = new System.Drawing.Size(113, 26);
            this.mnuVerEspecialidades.Text = "Ver";
            this.mnuVerEspecialidades.Click += new System.EventHandler(this.mnuVerEspecialidades_Click);
            // 
            // mnuMaterias
            // 
            this.mnuMaterias.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuVerMaterias});
            this.mnuMaterias.ForeColor = System.Drawing.Color.White;
            this.mnuMaterias.Name = "mnuMaterias";
            this.mnuMaterias.Size = new System.Drawing.Size(80, 24);
            this.mnuMaterias.Text = "Materias";
            // 
            // mnuVerMaterias
            // 
            this.mnuVerMaterias.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(48)))), ((int)(((byte)(52)))));
            this.mnuVerMaterias.ForeColor = System.Drawing.Color.White;
            this.mnuVerMaterias.Name = "mnuVerMaterias";
            this.mnuVerMaterias.Size = new System.Drawing.Size(113, 26);
            this.mnuVerMaterias.Text = "Ver";
            this.mnuVerMaterias.Click += new System.EventHandler(this.mnuVerMaterias_Click);
            // 
            // mnuPlanes
            // 
            this.mnuPlanes.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuVerPlanes});
            this.mnuPlanes.ForeColor = System.Drawing.Color.White;
            this.mnuPlanes.Name = "mnuPlanes";
            this.mnuPlanes.Size = new System.Drawing.Size(65, 24);
            this.mnuPlanes.Text = "Planes";
            // 
            // mnuVerPlanes
            // 
            this.mnuVerPlanes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(48)))), ((int)(((byte)(52)))));
            this.mnuVerPlanes.ForeColor = System.Drawing.Color.White;
            this.mnuVerPlanes.Name = "mnuVerPlanes";
            this.mnuVerPlanes.Size = new System.Drawing.Size(113, 26);
            this.mnuVerPlanes.Text = "Ver";
            this.mnuVerPlanes.Click += new System.EventHandler(this.mnuVerPlanes_Click);
            // 
            // mnuUsuarios
            // 
            this.mnuUsuarios.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuVerUsuarios});
            this.mnuUsuarios.ForeColor = System.Drawing.Color.White;
            this.mnuUsuarios.Name = "mnuUsuarios";
            this.mnuUsuarios.Size = new System.Drawing.Size(79, 24);
            this.mnuUsuarios.Text = "Usuarios";
            // 
            // mnuVerUsuarios
            // 
            this.mnuVerUsuarios.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(48)))), ((int)(((byte)(52)))));
            this.mnuVerUsuarios.ForeColor = System.Drawing.Color.White;
            this.mnuVerUsuarios.Name = "mnuVerUsuarios";
            this.mnuVerUsuarios.Size = new System.Drawing.Size(224, 26);
            this.mnuVerUsuarios.Text = "Ver";
            this.mnuVerUsuarios.Click += new System.EventHandler(this.mnuVerUsuarios_Click);
            // 
            // mnuInscripciones
            // 
            this.mnuInscripciones.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuVerInscripciones,
            this.mnuPrintInscripciones});
            this.mnuInscripciones.ForeColor = System.Drawing.Color.White;
            this.mnuInscripciones.Name = "mnuInscripciones";
            this.mnuInscripciones.Size = new System.Drawing.Size(108, 24);
            this.mnuInscripciones.Text = "Inscripciones";
            // 
            // mnuVerInscripciones
            // 
            this.mnuVerInscripciones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(48)))), ((int)(((byte)(52)))));
            this.mnuVerInscripciones.ForeColor = System.Drawing.Color.White;
            this.mnuVerInscripciones.Name = "mnuVerInscripciones";
            this.mnuVerInscripciones.Size = new System.Drawing.Size(224, 26);
            this.mnuVerInscripciones.Text = "Ver";
            this.mnuVerInscripciones.Click += new System.EventHandler(this.mnuVerInscripciones_Click);
            // 
            // mnuPrintInscripciones
            // 
            this.mnuPrintInscripciones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(48)))), ((int)(((byte)(52)))));
            this.mnuPrintInscripciones.ForeColor = System.Drawing.Color.White;
            this.mnuPrintInscripciones.Name = "mnuPrintInscripciones";
            this.mnuPrintInscripciones.Size = new System.Drawing.Size(224, 26);
            this.mnuPrintInscripciones.Text = "Imprimir reporte";
            // 
            // mnuCargos
            // 
            this.mnuCargos.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuVerCargos});
            this.mnuCargos.ForeColor = System.Drawing.Color.White;
            this.mnuCargos.Name = "mnuCargos";
            this.mnuCargos.Size = new System.Drawing.Size(69, 24);
            this.mnuCargos.Text = "Cargos";
            // 
            // mnuVerCargos
            // 
            this.mnuVerCargos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(48)))), ((int)(((byte)(52)))));
            this.mnuVerCargos.ForeColor = System.Drawing.Color.White;
            this.mnuVerCargos.Name = "mnuVerCargos";
            this.mnuVerCargos.Size = new System.Drawing.Size(224, 26);
            this.mnuVerCargos.Text = "Ver";
            this.mnuVerCargos.Click += new System.EventHandler(this.mnuVerCargos_Click);
            // 
            // mnuPersonas
            // 
            this.mnuPersonas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAlumnos,
            this.mnuDocentes});
            this.mnuPersonas.ForeColor = System.Drawing.Color.White;
            this.mnuPersonas.Name = "mnuPersonas";
            this.mnuPersonas.Size = new System.Drawing.Size(80, 24);
            this.mnuPersonas.Text = "Personas";
            // 
            // mnuAlumnos
            // 
            this.mnuAlumnos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(48)))), ((int)(((byte)(52)))));
            this.mnuAlumnos.ForeColor = System.Drawing.Color.White;
            this.mnuAlumnos.Name = "mnuAlumnos";
            this.mnuAlumnos.Size = new System.Drawing.Size(224, 26);
            this.mnuAlumnos.Text = "Ver alumnos";
            this.mnuAlumnos.Click += new System.EventHandler(this.mnuAlumnos_Click);
            // 
            // mnuDocentes
            // 
            this.mnuDocentes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(48)))), ((int)(((byte)(52)))));
            this.mnuDocentes.ForeColor = System.Drawing.Color.White;
            this.mnuDocentes.Name = "mnuDocentes";
            this.mnuDocentes.Size = new System.Drawing.Size(224, 26);
            this.mnuDocentes.Text = "Ver docentes";
            this.mnuDocentes.Click += new System.EventHandler(this.mnuDocentes_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(48)))), ((int)(((byte)(52)))));
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.Controls.Add(this.btnSalir, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnLogOut, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblBienvenido, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 28);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(860, 325);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(48)))), ((int)(((byte)(52)))));
            this.btnSalir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.ForeColor = System.Drawing.Color.Red;
            this.btnSalir.Location = new System.Drawing.Point(720, 263);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(3, 3, 10, 10);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(130, 52);
            this.btnSalir.TabIndex = 6;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            this.btnSalir.MouseEnter += new System.EventHandler(this.btnSalir_MouseEnter);
            this.btnSalir.MouseLeave += new System.EventHandler(this.btnSalir_MouseLeave);
            // 
            // btnLogOut
            // 
            this.btnLogOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLogOut.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(48)))), ((int)(((byte)(52)))));
            this.btnLogOut.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogOut.ForeColor = System.Drawing.Color.FloralWhite;
            this.btnLogOut.Location = new System.Drawing.Point(10, 263);
            this.btnLogOut.Margin = new System.Windows.Forms.Padding(10, 3, 3, 10);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(129, 52);
            this.btnLogOut.TabIndex = 8;
            this.btnLogOut.Text = "Cerrar sesión";
            this.btnLogOut.UseVisualStyleBackColor = false;
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
            this.btnLogOut.MouseEnter += new System.EventHandler(this.btnLogOut_MouseEnter);
            this.btnLogOut.MouseLeave += new System.EventHandler(this.btnLogOut_MouseLeave);
            // 
            // lblBienvenido
            // 
            this.lblBienvenido.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblBienvenido.AutoSize = true;
            this.lblBienvenido.Location = new System.Drawing.Point(347, 60);
            this.lblBienvenido.Margin = new System.Windows.Forms.Padding(3, 60, 3, 0);
            this.lblBienvenido.Name = "lblBienvenido";
            this.lblBienvenido.Size = new System.Drawing.Size(166, 24);
            this.lblBienvenido.TabIndex = 9;
            this.lblBienvenido.Text = "Debes iniciar sesión";
            this.lblBienvenido.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(860, 353);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.mnsPrincipal);
            this.Font = new System.Drawing.Font("Comic Sans MS", 10.2F);
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(700, 400);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SYSACAD";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Main_Shown);
            this.mnsPrincipal.ResumeLayout(false);
            this.mnsPrincipal.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip mnsPrincipal;
        private System.Windows.Forms.ToolStripMenuItem mnuArchivo;
        private System.Windows.Forms.ToolStripMenuItem mnuSalir;
        private System.Windows.Forms.ToolStripMenuItem mnuComisiones;
        private System.Windows.Forms.ToolStripMenuItem mnuVerComisiones;
        private System.Windows.Forms.ToolStripMenuItem mnuCursos;
        private System.Windows.Forms.ToolStripMenuItem mnuVerCursos;
        private System.Windows.Forms.ToolStripMenuItem mnuEspecialidades;
        private System.Windows.Forms.ToolStripMenuItem mnuVerEspecialidades;
        private System.Windows.Forms.ToolStripMenuItem mnuMaterias;
        private System.Windows.Forms.ToolStripMenuItem mnuVerMaterias;
        private System.Windows.Forms.ToolStripMenuItem mnuPlanes;
        private System.Windows.Forms.ToolStripMenuItem mnuVerPlanes;
        private System.Windows.Forms.ToolStripMenuItem mnuUsuarios;
        private System.Windows.Forms.ToolStripMenuItem mnuVerUsuarios;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnLogOut;
        private System.Windows.Forms.Label lblBienvenido;
        private System.Windows.Forms.ToolStripMenuItem mnuPrintCurso;
        private System.Windows.Forms.ToolStripMenuItem mnuInscripciones;
        private System.Windows.Forms.ToolStripMenuItem mnuCargos;
        private System.Windows.Forms.ToolStripMenuItem mnuVerInscripciones;
        private System.Windows.Forms.ToolStripMenuItem mnuPrintInscripciones;
        private System.Windows.Forms.ToolStripMenuItem mnuVerCargos;
        private System.Windows.Forms.ToolStripMenuItem mnuPersonas;
        private System.Windows.Forms.ToolStripMenuItem mnuAlumnos;
        private System.Windows.Forms.ToolStripMenuItem mnuDocentes;
    }
}