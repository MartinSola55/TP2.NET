
namespace UI.Desktop
{
    partial class InscripcionDesktop
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
            this.tllnscripcion = new System.Windows.Forms.TableLayoutPanel();
            this.comboCondiciones = new System.Windows.Forms.ComboBox();
            this.txtIDAlumno = new System.Windows.Forms.TextBox();
            this.lblIDAlumno = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.txtID = new System.Windows.Forms.TextBox();
            this.lblCondicion = new System.Windows.Forms.Label();
            this.lblNota = new System.Windows.Forms.Label();
            this.txtNota = new System.Windows.Forms.TextBox();
            this.lblCurso = new System.Windows.Forms.Label();
            this.comboCursos = new System.Windows.Forms.ComboBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.tllnscripcion.SuspendLayout();
            this.SuspendLayout();
            // 
            // tllnscripcion
            // 
            this.tllnscripcion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(48)))), ((int)(((byte)(52)))));
            this.tllnscripcion.ColumnCount = 4;
            this.tllnscripcion.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tllnscripcion.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tllnscripcion.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16F));
            this.tllnscripcion.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34F));
            this.tllnscripcion.Controls.Add(this.comboCondiciones, 1, 1);
            this.tllnscripcion.Controls.Add(this.txtIDAlumno, 3, 0);
            this.tllnscripcion.Controls.Add(this.lblIDAlumno, 2, 0);
            this.tllnscripcion.Controls.Add(this.lblID, 0, 0);
            this.tllnscripcion.Controls.Add(this.btnCancelar, 3, 4);
            this.tllnscripcion.Controls.Add(this.txtID, 1, 0);
            this.tllnscripcion.Controls.Add(this.lblCondicion, 0, 1);
            this.tllnscripcion.Controls.Add(this.lblNota, 0, 2);
            this.tllnscripcion.Controls.Add(this.txtNota, 1, 2);
            this.tllnscripcion.Controls.Add(this.lblCurso, 0, 3);
            this.tllnscripcion.Controls.Add(this.comboCursos, 1, 3);
            this.tllnscripcion.Controls.Add(this.btnAceptar, 0, 4);
            this.tllnscripcion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tllnscripcion.Font = new System.Drawing.Font("Comic Sans MS", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tllnscripcion.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.tllnscripcion.Location = new System.Drawing.Point(0, 0);
            this.tllnscripcion.Margin = new System.Windows.Forms.Padding(4, 8, 4, 8);
            this.tllnscripcion.Name = "tllnscripcion";
            this.tllnscripcion.RowCount = 5;
            this.tllnscripcion.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tllnscripcion.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tllnscripcion.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tllnscripcion.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tllnscripcion.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tllnscripcion.Size = new System.Drawing.Size(830, 446);
            this.tllnscripcion.TabIndex = 2;
            // 
            // comboCondiciones
            // 
            this.comboCondiciones.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.comboCondiciones.BackColor = System.Drawing.Color.White;
            this.comboCondiciones.Cursor = System.Windows.Forms.Cursors.Hand;
            this.comboCondiciones.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboCondiciones.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboCondiciones.ForeColor = System.Drawing.Color.Black;
            this.comboCondiciones.Location = new System.Drawing.Point(128, 114);
            this.comboCondiciones.Margin = new System.Windows.Forms.Padding(4);
            this.comboCondiciones.Name = "comboCondiciones";
            this.comboCondiciones.Size = new System.Drawing.Size(269, 32);
            this.comboCondiciones.TabIndex = 25;
            // 
            // txtIDAlumno
            // 
            this.txtIDAlumno.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtIDAlumno.Cursor = System.Windows.Forms.Cursors.No;
            this.txtIDAlumno.Enabled = false;
            this.txtIDAlumno.Location = new System.Drawing.Point(550, 24);
            this.txtIDAlumno.Margin = new System.Windows.Forms.Padding(4, 8, 4, 8);
            this.txtIDAlumno.Name = "txtIDAlumno";
            this.txtIDAlumno.ReadOnly = true;
            this.txtIDAlumno.Size = new System.Drawing.Size(124, 31);
            this.txtIDAlumno.TabIndex = 24;
            this.txtIDAlumno.TabStop = false;
            // 
            // lblIDAlumno
            // 
            this.lblIDAlumno.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblIDAlumno.AutoSize = true;
            this.lblIDAlumno.Font = new System.Drawing.Font("Comic Sans MS", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIDAlumno.ForeColor = System.Drawing.Color.White;
            this.lblIDAlumno.Location = new System.Drawing.Point(418, 28);
            this.lblIDAlumno.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblIDAlumno.Name = "lblIDAlumno";
            this.lblIDAlumno.Size = new System.Drawing.Size(99, 24);
            this.lblIDAlumno.TabIndex = 23;
            this.lblIDAlumno.Text = "ID Alumno:";
            // 
            // lblID
            // 
            this.lblID.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblID.AutoSize = true;
            this.lblID.Font = new System.Drawing.Font("Comic Sans MS", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblID.ForeColor = System.Drawing.Color.White;
            this.lblID.Location = new System.Drawing.Point(4, 28);
            this.lblID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(36, 24);
            this.lblID.TabIndex = 0;
            this.lblID.Text = "ID:";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(48)))), ((int)(((byte)(52)))));
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.ForeColor = System.Drawing.Color.Red;
            this.btnCancelar.Location = new System.Drawing.Point(681, 366);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(5, 6, 25, 6);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(124, 61);
            this.btnCancelar.TabIndex = 9;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            this.btnCancelar.MouseEnter += new System.EventHandler(this.btnCancelar_MouseEnter);
            this.btnCancelar.MouseLeave += new System.EventHandler(this.btnCancelar_MouseLeave);
            // 
            // txtID
            // 
            this.txtID.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtID.Cursor = System.Windows.Forms.Cursors.No;
            this.txtID.Enabled = false;
            this.txtID.Location = new System.Drawing.Point(128, 24);
            this.txtID.Margin = new System.Windows.Forms.Padding(4, 8, 4, 8);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(124, 31);
            this.txtID.TabIndex = 0;
            this.txtID.TabStop = false;
            // 
            // lblCondicion
            // 
            this.lblCondicion.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblCondicion.AutoSize = true;
            this.lblCondicion.Font = new System.Drawing.Font("Comic Sans MS", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCondicion.ForeColor = System.Drawing.Color.White;
            this.lblCondicion.Location = new System.Drawing.Point(4, 80);
            this.lblCondicion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCondicion.Name = "lblCondicion";
            this.lblCondicion.Padding = new System.Windows.Forms.Padding(0, 35, 0, 35);
            this.lblCondicion.Size = new System.Drawing.Size(90, 94);
            this.lblCondicion.TabIndex = 6;
            this.lblCondicion.Text = "Condición:";
            // 
            // lblNota
            // 
            this.lblNota.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblNota.AutoSize = true;
            this.lblNota.Font = new System.Drawing.Font("Comic Sans MS", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNota.ForeColor = System.Drawing.Color.White;
            this.lblNota.Location = new System.Drawing.Point(4, 174);
            this.lblNota.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNota.Name = "lblNota";
            this.lblNota.Padding = new System.Windows.Forms.Padding(0, 35, 0, 35);
            this.lblNota.Size = new System.Drawing.Size(56, 94);
            this.lblNota.TabIndex = 3;
            this.lblNota.Text = "Nota:";
            // 
            // txtNota
            // 
            this.txtNota.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtNota.BackColor = System.Drawing.Color.White;
            this.txtNota.ForeColor = System.Drawing.Color.Black;
            this.txtNota.Location = new System.Drawing.Point(128, 205);
            this.txtNota.Margin = new System.Windows.Forms.Padding(4, 8, 4, 8);
            this.txtNota.Name = "txtNota";
            this.txtNota.Size = new System.Drawing.Size(124, 31);
            this.txtNota.TabIndex = 4;
            // 
            // lblCurso
            // 
            this.lblCurso.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblCurso.AutoSize = true;
            this.lblCurso.Font = new System.Drawing.Font("Comic Sans MS", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurso.ForeColor = System.Drawing.Color.White;
            this.lblCurso.Location = new System.Drawing.Point(4, 296);
            this.lblCurso.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCurso.Name = "lblCurso";
            this.lblCurso.Size = new System.Drawing.Size(60, 24);
            this.lblCurso.TabIndex = 12;
            this.lblCurso.Text = "Curso:";
            // 
            // comboCursos
            // 
            this.comboCursos.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.comboCursos.BackColor = System.Drawing.Color.White;
            this.comboCursos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.comboCursos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboCursos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboCursos.ForeColor = System.Drawing.Color.Black;
            this.comboCursos.Location = new System.Drawing.Point(128, 295);
            this.comboCursos.Margin = new System.Windows.Forms.Padding(4);
            this.comboCursos.Name = "comboCursos";
            this.comboCursos.Size = new System.Drawing.Size(269, 32);
            this.comboCursos.TabIndex = 8;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnAceptar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(48)))), ((int)(((byte)(52)))));
            this.tllnscripcion.SetColumnSpan(this.btnAceptar, 2);
            this.btnAceptar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAceptar.ForeColor = System.Drawing.Color.Green;
            this.btnAceptar.Location = new System.Drawing.Point(25, 369);
            this.btnAceptar.Margin = new System.Windows.Forms.Padding(25, 6, 5, 6);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(145, 56);
            this.btnAceptar.TabIndex = 8;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = false;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            this.btnAceptar.MouseEnter += new System.EventHandler(this.btnAceptar_MouseEnter);
            this.btnAceptar.MouseLeave += new System.EventHandler(this.btnAceptar_MouseLeave);
            // 
            // InscripcionDesktop
            // 
            this.AcceptButton = this.btnAceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(830, 446);
            this.Controls.Add(this.tllnscripcion);
            this.Font = new System.Drawing.Font("Comic Sans MS", 10.2F);
            this.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InscripcionDesktop";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Datos de la inscripción";
            this.tllnscripcion.ResumeLayout(false);
            this.tllnscripcion.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tllnscripcion;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label lblCondicion;
        private System.Windows.Forms.Label lblNota;
        private System.Windows.Forms.TextBox txtNota;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Label lblCurso;
        private System.Windows.Forms.ComboBox comboCursos;
        private System.Windows.Forms.TextBox txtIDAlumno;
        private System.Windows.Forms.Label lblIDAlumno;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.ComboBox comboCondiciones;
    }
}