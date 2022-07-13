
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblCursos = new System.Windows.Forms.Label();
            this.lblEspecialidades = new System.Windows.Forms.Label();
            this.lblUsuarios = new System.Windows.Forms.Label();
            this.lblComisiones = new System.Windows.Forms.Label();
            this.btnUsuarios = new System.Windows.Forms.Button();
            this.btnComisiones = new System.Windows.Forms.Button();
            this.btnCursos = new System.Windows.Forms.Button();
            this.btnEspecialidades = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.lblPlanes = new System.Windows.Forms.Label();
            this.btnPlanes = new System.Windows.Forms.Button();
            this.mnsPrincipal = new System.Windows.Forms.MenuStrip();
            this.mnuArchivo = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSalir = new System.Windows.Forms.ToolStripMenuItem();
            this.lblMaterias = new System.Windows.Forms.Label();
            this.btnMaterias = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.mnsPrincipal.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(48)))), ((int)(((byte)(52)))));
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.Controls.Add(this.lblCursos, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblEspecialidades, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblUsuarios, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblComisiones, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnUsuarios, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnComisiones, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnCursos, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnEspecialidades, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnSalir, 4, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblPlanes, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnPlanes, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblMaterias, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnMaterias, 4, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 28);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(732, 425);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lblCursos
            // 
            this.lblCursos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCursos.AutoSize = true;
            this.lblCursos.ForeColor = System.Drawing.Color.White;
            this.lblCursos.Location = new System.Drawing.Point(0, 48);
            this.lblCursos.Margin = new System.Windows.Forms.Padding(0);
            this.lblCursos.Name = "lblCursos";
            this.lblCursos.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.lblCursos.Size = new System.Drawing.Size(109, 30);
            this.lblCursos.TabIndex = 0;
            this.lblCursos.Text = "Cursos:";
            this.lblCursos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblEspecialidades
            // 
            this.lblEspecialidades.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEspecialidades.AutoSize = true;
            this.lblEspecialidades.ForeColor = System.Drawing.Color.White;
            this.lblEspecialidades.Location = new System.Drawing.Point(478, 48);
            this.lblEspecialidades.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEspecialidades.Name = "lblEspecialidades";
            this.lblEspecialidades.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.lblEspecialidades.Size = new System.Drawing.Size(138, 30);
            this.lblEspecialidades.TabIndex = 1;
            this.lblEspecialidades.Text = "Especialidades:";
            this.lblEspecialidades.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblUsuarios
            // 
            this.lblUsuarios.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUsuarios.AutoSize = true;
            this.lblUsuarios.ForeColor = System.Drawing.Color.White;
            this.lblUsuarios.Location = new System.Drawing.Point(4, 175);
            this.lblUsuarios.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUsuarios.Name = "lblUsuarios";
            this.lblUsuarios.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.lblUsuarios.Size = new System.Drawing.Size(101, 30);
            this.lblUsuarios.TabIndex = 2;
            this.lblUsuarios.Text = "Usuarios:";
            this.lblUsuarios.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblComisiones
            // 
            this.lblComisiones.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblComisiones.AutoSize = true;
            this.lblComisiones.ForeColor = System.Drawing.Color.White;
            this.lblComisiones.Location = new System.Drawing.Point(478, 175);
            this.lblComisiones.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblComisiones.Name = "lblComisiones";
            this.lblComisiones.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.lblComisiones.Size = new System.Drawing.Size(138, 30);
            this.lblComisiones.TabIndex = 3;
            this.lblComisiones.Text = "Comisiones:";
            this.lblComisiones.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnUsuarios
            // 
            this.btnUsuarios.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnUsuarios.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(48)))), ((int)(((byte)(52)))));
            this.btnUsuarios.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUsuarios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUsuarios.ForeColor = System.Drawing.Color.White;
            this.btnUsuarios.Location = new System.Drawing.Point(113, 165);
            this.btnUsuarios.Margin = new System.Windows.Forms.Padding(4);
            this.btnUsuarios.Name = "btnUsuarios";
            this.btnUsuarios.Size = new System.Drawing.Size(101, 50);
            this.btnUsuarios.TabIndex = 2;
            this.btnUsuarios.Text = "Ver";
            this.btnUsuarios.UseVisualStyleBackColor = false;
            this.btnUsuarios.Click += new System.EventHandler(this.btnUsuarios_Click);
            this.btnUsuarios.MouseEnter += new System.EventHandler(this.btnUsuarios_MouseEnter);
            this.btnUsuarios.MouseLeave += new System.EventHandler(this.btnUsuarios_MouseLeave);
            // 
            // btnComisiones
            // 
            this.btnComisiones.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnComisiones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(48)))), ((int)(((byte)(52)))));
            this.btnComisiones.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnComisiones.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnComisiones.ForeColor = System.Drawing.Color.White;
            this.btnComisiones.Location = new System.Drawing.Point(624, 165);
            this.btnComisiones.Margin = new System.Windows.Forms.Padding(4);
            this.btnComisiones.Name = "btnComisiones";
            this.btnComisiones.Size = new System.Drawing.Size(104, 50);
            this.btnComisiones.TabIndex = 5;
            this.btnComisiones.Text = "Ver";
            this.btnComisiones.UseVisualStyleBackColor = false;
            this.btnComisiones.Click += new System.EventHandler(this.btnComisiones_Click);
            this.btnComisiones.MouseEnter += new System.EventHandler(this.btnComisiones_MouseEnter);
            this.btnComisiones.MouseLeave += new System.EventHandler(this.btnComisiones_MouseLeave);
            // 
            // btnCursos
            // 
            this.btnCursos.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnCursos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(48)))), ((int)(((byte)(52)))));
            this.btnCursos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCursos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCursos.ForeColor = System.Drawing.Color.White;
            this.btnCursos.Location = new System.Drawing.Point(113, 38);
            this.btnCursos.Margin = new System.Windows.Forms.Padding(4);
            this.btnCursos.Name = "btnCursos";
            this.btnCursos.Size = new System.Drawing.Size(101, 50);
            this.btnCursos.TabIndex = 1;
            this.btnCursos.Text = "Ver";
            this.btnCursos.UseVisualStyleBackColor = false;
            this.btnCursos.Click += new System.EventHandler(this.btnCursos_Click);
            this.btnCursos.MouseEnter += new System.EventHandler(this.btnCursos_MouseEnter);
            this.btnCursos.MouseLeave += new System.EventHandler(this.btnCursos_MouseLeave);
            // 
            // btnEspecialidades
            // 
            this.btnEspecialidades.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnEspecialidades.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(48)))), ((int)(((byte)(52)))));
            this.btnEspecialidades.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEspecialidades.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEspecialidades.ForeColor = System.Drawing.Color.White;
            this.btnEspecialidades.Location = new System.Drawing.Point(624, 38);
            this.btnEspecialidades.Margin = new System.Windows.Forms.Padding(4);
            this.btnEspecialidades.Name = "btnEspecialidades";
            this.btnEspecialidades.Size = new System.Drawing.Size(104, 50);
            this.btnEspecialidades.TabIndex = 4;
            this.btnEspecialidades.Text = "Ver";
            this.btnEspecialidades.UseVisualStyleBackColor = false;
            this.btnEspecialidades.Click += new System.EventHandler(this.btnEspecialidades_Click);
            this.btnEspecialidades.MouseEnter += new System.EventHandler(this.btnEspecialidades_MouseEnter);
            this.btnEspecialidades.MouseLeave += new System.EventHandler(this.btnEspecialidades_MouseLeave);
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(48)))), ((int)(((byte)(52)))));
            this.btnSalir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.ForeColor = System.Drawing.Color.Red;
            this.btnSalir.Location = new System.Drawing.Point(629, 384);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(100, 38);
            this.btnSalir.TabIndex = 6;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            this.btnSalir.MouseEnter += new System.EventHandler(this.btnSalir_MouseEnter);
            this.btnSalir.MouseLeave += new System.EventHandler(this.btnSalir_MouseLeave);
            // 
            // lblPlanes
            // 
            this.lblPlanes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPlanes.AutoSize = true;
            this.lblPlanes.ForeColor = System.Drawing.Color.White;
            this.lblPlanes.Location = new System.Drawing.Point(4, 302);
            this.lblPlanes.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPlanes.Name = "lblPlanes";
            this.lblPlanes.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.lblPlanes.Size = new System.Drawing.Size(101, 30);
            this.lblPlanes.TabIndex = 5;
            this.lblPlanes.Text = "Planes:";
            this.lblPlanes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnPlanes
            // 
            this.btnPlanes.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnPlanes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(48)))), ((int)(((byte)(52)))));
            this.btnPlanes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPlanes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlanes.ForeColor = System.Drawing.Color.White;
            this.btnPlanes.Location = new System.Drawing.Point(113, 292);
            this.btnPlanes.Margin = new System.Windows.Forms.Padding(4);
            this.btnPlanes.Name = "btnPlanes";
            this.btnPlanes.Size = new System.Drawing.Size(101, 50);
            this.btnPlanes.TabIndex = 3;
            this.btnPlanes.Text = "Ver";
            this.btnPlanes.UseVisualStyleBackColor = false;
            this.btnPlanes.Click += new System.EventHandler(this.btnPlanes_Click);
            this.btnPlanes.MouseEnter += new System.EventHandler(this.btnPlanes_MouseEnter);
            this.btnPlanes.MouseLeave += new System.EventHandler(this.btnPlanes_MouseLeave);
            // 
            // mnsPrincipal
            // 
            this.mnsPrincipal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(48)))), ((int)(((byte)(52)))));
            this.mnsPrincipal.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mnsPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuArchivo});
            this.mnsPrincipal.Location = new System.Drawing.Point(0, 0);
            this.mnsPrincipal.Name = "mnsPrincipal";
            this.mnsPrincipal.Size = new System.Drawing.Size(732, 28);
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
            this.mnuArchivo.CheckStateChanged += new System.EventHandler(this.mnuArchivo_CheckStateChanged);
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
            // lblMaterias
            // 
            this.lblMaterias.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblMaterias.AutoSize = true;
            this.lblMaterias.ForeColor = System.Drawing.Color.White;
            this.lblMaterias.Location = new System.Drawing.Point(477, 305);
            this.lblMaterias.Name = "lblMaterias";
            this.lblMaterias.Size = new System.Drawing.Size(86, 24);
            this.lblMaterias.TabIndex = 7;
            this.lblMaterias.Text = "Materias:";
            // 
            // btnMaterias
            // 
            this.btnMaterias.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnMaterias.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(48)))), ((int)(((byte)(52)))));
            this.btnMaterias.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMaterias.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMaterias.ForeColor = System.Drawing.Color.White;
            this.btnMaterias.Location = new System.Drawing.Point(624, 292);
            this.btnMaterias.Margin = new System.Windows.Forms.Padding(4);
            this.btnMaterias.Name = "btnMaterias";
            this.btnMaterias.Size = new System.Drawing.Size(104, 50);
            this.btnMaterias.TabIndex = 8;
            this.btnMaterias.Text = "Ver";
            this.btnMaterias.UseVisualStyleBackColor = false;
            this.btnMaterias.Click += new System.EventHandler(this.btnMaterias_Click);
            this.btnMaterias.MouseEnter += new System.EventHandler(this.btnMaterias_MouseEnter);
            this.btnMaterias.MouseLeave += new System.EventHandler(this.btnMaterias_MouseLeave);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(732, 453);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.mnsPrincipal);
            this.Font = new System.Drawing.Font("Comic Sans MS", 10.2F);
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(750, 500);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SYSACAD";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Main_Shown);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.mnsPrincipal.ResumeLayout(false);
            this.mnsPrincipal.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblCursos;
        private System.Windows.Forms.Label lblEspecialidades;
        private System.Windows.Forms.Label lblUsuarios;
        private System.Windows.Forms.Label lblComisiones;
        private System.Windows.Forms.Button btnUsuarios;
        private System.Windows.Forms.Button btnComisiones;
        private System.Windows.Forms.Button btnCursos;
        private System.Windows.Forms.Button btnEspecialidades;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.MenuStrip mnsPrincipal;
        private System.Windows.Forms.ToolStripMenuItem mnuArchivo;
        private System.Windows.Forms.ToolStripMenuItem mnuSalir;
        private System.Windows.Forms.Label lblPlanes;
        private System.Windows.Forms.Button btnPlanes;
        private System.Windows.Forms.Label lblMaterias;
        private System.Windows.Forms.Button btnMaterias;
    }
}