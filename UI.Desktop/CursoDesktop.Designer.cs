
namespace UI.Desktop
{
    partial class CursoDesktop
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
            this.tlCurso = new System.Windows.Forms.TableLayoutPanel();
            this.lblID = new System.Windows.Forms.Label();
            this.lblMateria = new System.Windows.Forms.Label();
            this.lblCurso = new System.Windows.Forms.Label();
            this.lblAnio = new System.Windows.Forms.Label();
            this.lblCupo = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtAnio = new System.Windows.Forms.TextBox();
            this.txtCupo = new System.Windows.Forms.TextBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.comboMateria = new System.Windows.Forms.ComboBox();
            this.comboComision = new System.Windows.Forms.ComboBox();
            this.tlCurso.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlCurso
            // 
            this.tlCurso.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(48)))), ((int)(((byte)(52)))));
            this.tlCurso.ColumnCount = 2;
            this.tlCurso.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tlCurso.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tlCurso.Controls.Add(this.lblID, 0, 0);
            this.tlCurso.Controls.Add(this.lblMateria, 0, 1);
            this.tlCurso.Controls.Add(this.lblCurso, 0, 2);
            this.tlCurso.Controls.Add(this.lblAnio, 0, 3);
            this.tlCurso.Controls.Add(this.lblCupo, 0, 4);
            this.tlCurso.Controls.Add(this.txtID, 1, 0);
            this.tlCurso.Controls.Add(this.txtAnio, 1, 3);
            this.tlCurso.Controls.Add(this.txtCupo, 1, 4);
            this.tlCurso.Controls.Add(this.btnCancelar, 1, 5);
            this.tlCurso.Controls.Add(this.btnAceptar, 0, 5);
            this.tlCurso.Controls.Add(this.comboMateria, 1, 1);
            this.tlCurso.Controls.Add(this.comboComision, 1, 2);
            this.tlCurso.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlCurso.Location = new System.Drawing.Point(0, 0);
            this.tlCurso.Margin = new System.Windows.Forms.Padding(4);
            this.tlCurso.Name = "tlCurso";
            this.tlCurso.RowCount = 6;
            this.tlCurso.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tlCurso.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tlCurso.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tlCurso.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tlCurso.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tlCurso.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlCurso.Size = new System.Drawing.Size(445, 609);
            this.tlCurso.TabIndex = 0;
            // 
            // lblID
            // 
            this.lblID.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblID.AutoSize = true;
            this.lblID.ForeColor = System.Drawing.Color.White;
            this.lblID.Location = new System.Drawing.Point(4, 33);
            this.lblID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(36, 24);
            this.lblID.TabIndex = 0;
            this.lblID.Text = "ID:";
            // 
            // lblMateria
            // 
            this.lblMateria.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblMateria.AutoSize = true;
            this.lblMateria.ForeColor = System.Drawing.Color.White;
            this.lblMateria.Location = new System.Drawing.Point(4, 124);
            this.lblMateria.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMateria.Name = "lblMateria";
            this.lblMateria.Size = new System.Drawing.Size(78, 24);
            this.lblMateria.TabIndex = 1;
            this.lblMateria.Text = "Materia:";
            // 
            // lblCurso
            // 
            this.lblCurso.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblCurso.AutoSize = true;
            this.lblCurso.ForeColor = System.Drawing.Color.White;
            this.lblCurso.Location = new System.Drawing.Point(4, 215);
            this.lblCurso.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCurso.Name = "lblCurso";
            this.lblCurso.Size = new System.Drawing.Size(83, 24);
            this.lblCurso.TabIndex = 2;
            this.lblCurso.Text = "Comisión:";
            // 
            // lblAnio
            // 
            this.lblAnio.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblAnio.AutoSize = true;
            this.lblAnio.ForeColor = System.Drawing.Color.White;
            this.lblAnio.Location = new System.Drawing.Point(4, 306);
            this.lblAnio.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAnio.Name = "lblAnio";
            this.lblAnio.Size = new System.Drawing.Size(134, 24);
            this.lblAnio.TabIndex = 3;
            this.lblAnio.Text = "Año calendario:";
            // 
            // lblCupo
            // 
            this.lblCupo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblCupo.AutoSize = true;
            this.lblCupo.ForeColor = System.Drawing.Color.White;
            this.lblCupo.Location = new System.Drawing.Point(4, 397);
            this.lblCupo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCupo.Name = "lblCupo";
            this.lblCupo.Size = new System.Drawing.Size(53, 24);
            this.lblCupo.TabIndex = 4;
            this.lblCupo.Text = "Cupo:";
            // 
            // txtID
            // 
            this.txtID.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtID.BackColor = System.Drawing.Color.White;
            this.txtID.Enabled = false;
            this.txtID.ForeColor = System.Drawing.Color.Black;
            this.txtID.Location = new System.Drawing.Point(182, 30);
            this.txtID.Margin = new System.Windows.Forms.Padding(4);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(75, 31);
            this.txtID.TabIndex = 5;
            // 
            // txtAnio
            // 
            this.txtAnio.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtAnio.BackColor = System.Drawing.Color.White;
            this.txtAnio.ForeColor = System.Drawing.Color.Black;
            this.txtAnio.Location = new System.Drawing.Point(182, 303);
            this.txtAnio.Margin = new System.Windows.Forms.Padding(4);
            this.txtAnio.Name = "txtAnio";
            this.txtAnio.Size = new System.Drawing.Size(194, 31);
            this.txtAnio.TabIndex = 3;
            // 
            // txtCupo
            // 
            this.txtCupo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtCupo.BackColor = System.Drawing.Color.White;
            this.txtCupo.ForeColor = System.Drawing.Color.Black;
            this.txtCupo.Location = new System.Drawing.Point(182, 394);
            this.txtCupo.Margin = new System.Windows.Forms.Padding(4);
            this.txtCupo.Name = "txtCupo";
            this.txtCupo.Size = new System.Drawing.Size(194, 31);
            this.txtCupo.TabIndex = 4;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(48)))), ((int)(((byte)(52)))));
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.ForeColor = System.Drawing.Color.Red;
            this.btnCancelar.Location = new System.Drawing.Point(305, 507);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4, 4, 20, 4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(120, 50);
            this.btnCancelar.TabIndex = 6;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            this.btnCancelar.MouseEnter += new System.EventHandler(this.btnCancelar_MouseEnter);
            this.btnCancelar.MouseLeave += new System.EventHandler(this.btnCancelar_MouseLeave);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnAceptar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(48)))), ((int)(((byte)(52)))));
            this.btnAceptar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAceptar.ForeColor = System.Drawing.Color.Green;
            this.btnAceptar.Location = new System.Drawing.Point(20, 507);
            this.btnAceptar.Margin = new System.Windows.Forms.Padding(20, 4, 4, 4);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(120, 50);
            this.btnAceptar.TabIndex = 5;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = false;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            this.btnAceptar.MouseEnter += new System.EventHandler(this.btnAceptar_MouseEnter);
            this.btnAceptar.MouseLeave += new System.EventHandler(this.btnAceptar_MouseLeave);
            // 
            // comboMateria
            // 
            this.comboMateria.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.comboMateria.BackColor = System.Drawing.Color.White;
            this.comboMateria.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboMateria.ForeColor = System.Drawing.Color.Black;
            this.comboMateria.FormattingEnabled = true;
            this.comboMateria.Location = new System.Drawing.Point(181, 120);
            this.comboMateria.Name = "comboMateria";
            this.comboMateria.Size = new System.Drawing.Size(195, 32);
            this.comboMateria.TabIndex = 7;
            // 
            // comboComision
            // 
            this.comboComision.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.comboComision.BackColor = System.Drawing.Color.White;
            this.comboComision.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboComision.ForeColor = System.Drawing.Color.Black;
            this.comboComision.FormattingEnabled = true;
            this.comboComision.Location = new System.Drawing.Point(181, 215);
            this.comboComision.Name = "comboComision";
            this.comboComision.Size = new System.Drawing.Size(195, 32);
            this.comboComision.TabIndex = 8;
            // 
            // CursoDesktop
            // 
            this.AcceptButton = this.btnAceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(445, 609);
            this.Controls.Add(this.tlCurso);
            this.Font = new System.Drawing.Font("Comic Sans MS", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CursoDesktop";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "CursoDesktop";
            this.Load += new System.EventHandler(this.CursoDesktop_Load);
            this.tlCurso.ResumeLayout(false);
            this.tlCurso.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlCurso;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label lblMateria;
        private System.Windows.Forms.Label lblCurso;
        private System.Windows.Forms.Label lblAnio;
        private System.Windows.Forms.Label lblCupo;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtAnio;
        private System.Windows.Forms.TextBox txtCupo;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.ComboBox comboMateria;
        private System.Windows.Forms.ComboBox comboComision;
    }
}