
namespace UI.Desktop
{
    partial class Menu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblCursos = new System.Windows.Forms.Label();
            this.lblEspecialidades = new System.Windows.Forms.Label();
            this.lblUsuarios = new System.Windows.Forms.Label();
            this.lblComisiones = new System.Windows.Forms.Label();
            this.btnUsuarios = new System.Windows.Forms.Button();
            this.btnComisiones = new System.Windows.Forms.Button();
            this.btnCursos = new System.Windows.Forms.Button();
            this.btnEspecialidades = new System.Windows.Forms.Button();
            this.txtSalir = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
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
            this.tableLayoutPanel1.Controls.Add(this.txtSalir, 4, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(762, 377);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lblCursos
            // 
            this.lblCursos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCursos.AutoSize = true;
            this.lblCursos.Location = new System.Drawing.Point(0, 60);
            this.lblCursos.Margin = new System.Windows.Forms.Padding(0);
            this.lblCursos.Name = "lblCursos";
            this.lblCursos.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.lblCursos.Size = new System.Drawing.Size(114, 30);
            this.lblCursos.TabIndex = 0;
            this.lblCursos.Text = "Cursos";
            this.lblCursos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblEspecialidades
            // 
            this.lblEspecialidades.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEspecialidades.AutoSize = true;
            this.lblEspecialidades.Location = new System.Drawing.Point(498, 60);
            this.lblEspecialidades.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEspecialidades.Name = "lblEspecialidades";
            this.lblEspecialidades.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.lblEspecialidades.Size = new System.Drawing.Size(144, 30);
            this.lblEspecialidades.TabIndex = 1;
            this.lblEspecialidades.Text = "Especialidades";
            this.lblEspecialidades.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblUsuarios
            // 
            this.lblUsuarios.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUsuarios.AutoSize = true;
            this.lblUsuarios.Location = new System.Drawing.Point(4, 210);
            this.lblUsuarios.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUsuarios.Name = "lblUsuarios";
            this.lblUsuarios.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.lblUsuarios.Size = new System.Drawing.Size(106, 30);
            this.lblUsuarios.TabIndex = 2;
            this.lblUsuarios.Text = "Usuarios";
            this.lblUsuarios.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblComisiones
            // 
            this.lblComisiones.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblComisiones.AutoSize = true;
            this.lblComisiones.Location = new System.Drawing.Point(498, 210);
            this.lblComisiones.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblComisiones.Name = "lblComisiones";
            this.lblComisiones.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.lblComisiones.Size = new System.Drawing.Size(144, 30);
            this.lblComisiones.TabIndex = 3;
            this.lblComisiones.Text = "Comisiones";
            this.lblComisiones.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnUsuarios
            // 
            this.btnUsuarios.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnUsuarios.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUsuarios.Location = new System.Drawing.Point(118, 200);
            this.btnUsuarios.Margin = new System.Windows.Forms.Padding(4);
            this.btnUsuarios.Name = "btnUsuarios";
            this.btnUsuarios.Size = new System.Drawing.Size(100, 50);
            this.btnUsuarios.TabIndex = 5;
            this.btnUsuarios.Text = "Ver";
            this.btnUsuarios.UseVisualStyleBackColor = true;
            this.btnUsuarios.Click += new System.EventHandler(this.btnUsuarios_Click);
            // 
            // btnComisiones
            // 
            this.btnComisiones.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnComisiones.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnComisiones.Location = new System.Drawing.Point(650, 200);
            this.btnComisiones.Margin = new System.Windows.Forms.Padding(4);
            this.btnComisiones.Name = "btnComisiones";
            this.btnComisiones.Size = new System.Drawing.Size(100, 50);
            this.btnComisiones.TabIndex = 6;
            this.btnComisiones.Text = "Ver";
            this.btnComisiones.UseVisualStyleBackColor = true;
            this.btnComisiones.Click += new System.EventHandler(this.btnComisiones_Click);
            // 
            // btnCursos
            // 
            this.btnCursos.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnCursos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCursos.Location = new System.Drawing.Point(118, 50);
            this.btnCursos.Margin = new System.Windows.Forms.Padding(4);
            this.btnCursos.Name = "btnCursos";
            this.btnCursos.Size = new System.Drawing.Size(100, 50);
            this.btnCursos.TabIndex = 4;
            this.btnCursos.Text = "Ver";
            this.btnCursos.UseVisualStyleBackColor = true;
            this.btnCursos.Click += new System.EventHandler(this.btnCursos_Click);
            // 
            // btnEspecialidades
            // 
            this.btnEspecialidades.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnEspecialidades.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEspecialidades.Location = new System.Drawing.Point(650, 50);
            this.btnEspecialidades.Margin = new System.Windows.Forms.Padding(4);
            this.btnEspecialidades.Name = "btnEspecialidades";
            this.btnEspecialidades.Size = new System.Drawing.Size(100, 50);
            this.btnEspecialidades.TabIndex = 7;
            this.btnEspecialidades.Text = "Ver";
            this.btnEspecialidades.UseVisualStyleBackColor = true;
            this.btnEspecialidades.Click += new System.EventHandler(this.btnEspecialidades_Click);
            // 
            // txtSalir
            // 
            this.txtSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSalir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtSalir.ForeColor = System.Drawing.Color.Crimson;
            this.txtSalir.Location = new System.Drawing.Point(659, 324);
            this.txtSalir.Name = "txtSalir";
            this.txtSalir.Size = new System.Drawing.Size(100, 50);
            this.txtSalir.TabIndex = 8;
            this.txtSalir.Text = "Salir";
            this.txtSalir.UseVisualStyleBackColor = true;
            this.txtSalir.Click += new System.EventHandler(this.txtSalir_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(762, 377);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Comic Sans MS", 10.2F);
            this.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "Menu";
            this.Text = "SYSACAD";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

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
        private System.Windows.Forms.Button txtSalir;
    }
}