
namespace UI.Desktop
{
    partial class CargoDesktop
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
            this.tlCargo = new System.Windows.Forms.TableLayoutPanel();
            this.txtIDDocente = new System.Windows.Forms.TextBox();
            this.lblIDDocente = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.txtID = new System.Windows.Forms.TextBox();
            this.lblCargo = new System.Windows.Forms.Label();
            this.txtCargo = new System.Windows.Forms.TextBox();
            this.lblCurso = new System.Windows.Forms.Label();
            this.comboCursos = new System.Windows.Forms.ComboBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.tlCargo.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlCargo
            // 
            this.tlCargo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(48)))), ((int)(((byte)(52)))));
            this.tlCargo.ColumnCount = 4;
            this.tlCargo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tlCargo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tlCargo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16F));
            this.tlCargo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34F));
            this.tlCargo.Controls.Add(this.txtIDDocente, 3, 0);
            this.tlCargo.Controls.Add(this.lblIDDocente, 2, 0);
            this.tlCargo.Controls.Add(this.lblID, 0, 0);
            this.tlCargo.Controls.Add(this.btnCancelar, 3, 3);
            this.tlCargo.Controls.Add(this.txtID, 1, 0);
            this.tlCargo.Controls.Add(this.lblCargo, 0, 1);
            this.tlCargo.Controls.Add(this.txtCargo, 1, 1);
            this.tlCargo.Controls.Add(this.lblCurso, 0, 2);
            this.tlCargo.Controls.Add(this.comboCursos, 1, 2);
            this.tlCargo.Controls.Add(this.btnAceptar, 0, 3);
            this.tlCargo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlCargo.Font = new System.Drawing.Font("Comic Sans MS", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tlCargo.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.tlCargo.Location = new System.Drawing.Point(0, 0);
            this.tlCargo.Margin = new System.Windows.Forms.Padding(4, 8, 4, 8);
            this.tlCargo.Name = "tlCargo";
            this.tlCargo.RowCount = 4;
            this.tlCargo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlCargo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlCargo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlCargo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlCargo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlCargo.Size = new System.Drawing.Size(889, 451);
            this.tlCargo.TabIndex = 3;
            // 
            // txtIDDocente
            // 
            this.txtIDDocente.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtIDDocente.Cursor = System.Windows.Forms.Cursors.No;
            this.txtIDDocente.Enabled = false;
            this.txtIDDocente.Location = new System.Drawing.Point(590, 40);
            this.txtIDDocente.Margin = new System.Windows.Forms.Padding(4, 8, 4, 8);
            this.txtIDDocente.Name = "txtIDDocente";
            this.txtIDDocente.ReadOnly = true;
            this.txtIDDocente.Size = new System.Drawing.Size(124, 31);
            this.txtIDDocente.TabIndex = 24;
            this.txtIDDocente.TabStop = false;
            // 
            // lblIDDocente
            // 
            this.lblIDDocente.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblIDDocente.AutoSize = true;
            this.lblIDDocente.Font = new System.Drawing.Font("Comic Sans MS", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIDDocente.ForeColor = System.Drawing.Color.White;
            this.lblIDDocente.Location = new System.Drawing.Point(448, 44);
            this.lblIDDocente.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblIDDocente.Name = "lblIDDocente";
            this.lblIDDocente.Size = new System.Drawing.Size(109, 24);
            this.lblIDDocente.TabIndex = 23;
            this.lblIDDocente.Text = "ID Docente:";
            // 
            // lblID
            // 
            this.lblID.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblID.AutoSize = true;
            this.lblID.Font = new System.Drawing.Font("Comic Sans MS", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblID.ForeColor = System.Drawing.Color.White;
            this.lblID.Location = new System.Drawing.Point(4, 44);
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
            this.btnCancelar.Location = new System.Drawing.Point(740, 363);
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
            this.txtID.Location = new System.Drawing.Point(137, 40);
            this.txtID.Margin = new System.Windows.Forms.Padding(4, 8, 4, 8);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(124, 31);
            this.txtID.TabIndex = 0;
            this.txtID.TabStop = false;
            // 
            // lblCargo
            // 
            this.lblCargo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblCargo.AutoSize = true;
            this.lblCargo.Font = new System.Drawing.Font("Comic Sans MS", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCargo.ForeColor = System.Drawing.Color.White;
            this.lblCargo.Location = new System.Drawing.Point(4, 121);
            this.lblCargo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCargo.Name = "lblCargo";
            this.lblCargo.Padding = new System.Windows.Forms.Padding(0, 35, 0, 35);
            this.lblCargo.Size = new System.Drawing.Size(61, 94);
            this.lblCargo.TabIndex = 6;
            this.lblCargo.Text = "Cargo:";
            // 
            // txtCargo
            // 
            this.txtCargo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtCargo.BackColor = System.Drawing.Color.White;
            this.txtCargo.ForeColor = System.Drawing.Color.Black;
            this.txtCargo.Location = new System.Drawing.Point(137, 152);
            this.txtCargo.Margin = new System.Windows.Forms.Padding(4, 8, 4, 8);
            this.txtCargo.Name = "txtCargo";
            this.txtCargo.Size = new System.Drawing.Size(270, 31);
            this.txtCargo.TabIndex = 2;
            // 
            // lblCurso
            // 
            this.lblCurso.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblCurso.AutoSize = true;
            this.lblCurso.Font = new System.Drawing.Font("Comic Sans MS", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurso.ForeColor = System.Drawing.Color.White;
            this.lblCurso.Location = new System.Drawing.Point(4, 268);
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
            this.comboCursos.Location = new System.Drawing.Point(137, 267);
            this.comboCursos.Margin = new System.Windows.Forms.Padding(4);
            this.comboCursos.Name = "comboCursos";
            this.comboCursos.Size = new System.Drawing.Size(269, 32);
            this.comboCursos.TabIndex = 8;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnAceptar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(48)))), ((int)(((byte)(52)))));
            this.tlCargo.SetColumnSpan(this.btnAceptar, 2);
            this.btnAceptar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAceptar.ForeColor = System.Drawing.Color.Green;
            this.btnAceptar.Location = new System.Drawing.Point(25, 365);
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
            // CargoDesktop
            // 
            this.AcceptButton = this.btnAceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(889, 451);
            this.Controls.Add(this.tlCargo);
            this.Font = new System.Drawing.Font("Comic Sans MS", 10.2F);
            this.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CargoDesktop";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Datos del cargo";
            this.tlCargo.ResumeLayout(false);
            this.tlCargo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlCargo;
        private System.Windows.Forms.TextBox txtIDDocente;
        private System.Windows.Forms.Label lblIDDocente;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label lblCargo;
        private System.Windows.Forms.TextBox txtCargo;
        private System.Windows.Forms.Label lblCurso;
        private System.Windows.Forms.ComboBox comboCursos;
        private System.Windows.Forms.Button btnAceptar;
    }
}