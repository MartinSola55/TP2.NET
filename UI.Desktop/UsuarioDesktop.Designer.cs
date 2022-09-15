
namespace UI.Desktop
{
    partial class UsuarioDesktop
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
            this.tlUsuario = new System.Windows.Forms.TableLayoutPanel();
            this.lblID = new System.Windows.Forms.Label();
            this.txtConfimarClave = new System.Windows.Forms.TextBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.txtID = new System.Windows.Forms.TextBox();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.chkHabilitado = new System.Windows.Forms.CheckBox();
            this.lblClave = new System.Windows.Forms.Label();
            this.txtClave = new System.Windows.Forms.TextBox();
            this.lblConfirmarClave = new System.Windows.Forms.Label();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.tlUsuario.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlUsuario
            // 
            this.tlUsuario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(48)))), ((int)(((byte)(52)))));
            this.tlUsuario.ColumnCount = 4;
            this.tlUsuario.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tlUsuario.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tlUsuario.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16F));
            this.tlUsuario.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34F));
            this.tlUsuario.Controls.Add(this.lblID, 0, 0);
            this.tlUsuario.Controls.Add(this.txtConfimarClave, 3, 2);
            this.tlUsuario.Controls.Add(this.btnCancelar, 3, 3);
            this.tlUsuario.Controls.Add(this.txtID, 1, 0);
            this.tlUsuario.Controls.Add(this.lblUsuario, 0, 1);
            this.tlUsuario.Controls.Add(this.txtUsuario, 1, 1);
            this.tlUsuario.Controls.Add(this.chkHabilitado, 2, 1);
            this.tlUsuario.Controls.Add(this.lblClave, 0, 2);
            this.tlUsuario.Controls.Add(this.txtClave, 1, 2);
            this.tlUsuario.Controls.Add(this.lblConfirmarClave, 2, 2);
            this.tlUsuario.Controls.Add(this.btnAceptar, 0, 3);
            this.tlUsuario.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlUsuario.Font = new System.Drawing.Font("Comic Sans MS", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tlUsuario.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.tlUsuario.Location = new System.Drawing.Point(0, 0);
            this.tlUsuario.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.tlUsuario.Name = "tlUsuario";
            this.tlUsuario.RowCount = 4;
            this.tlUsuario.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlUsuario.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlUsuario.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlUsuario.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlUsuario.Size = new System.Drawing.Size(956, 502);
            this.tlUsuario.TabIndex = 0;
            this.tlUsuario.Paint += new System.Windows.Forms.PaintEventHandler(this.tlUsuario_Paint);
            // 
            // lblID
            // 
            this.lblID.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblID.AutoSize = true;
            this.lblID.Font = new System.Drawing.Font("Comic Sans MS", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblID.ForeColor = System.Drawing.Color.White;
            this.lblID.Location = new System.Drawing.Point(3, 50);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(36, 24);
            this.lblID.TabIndex = 0;
            this.lblID.Text = "ID:";
            // 
            // txtConfimarClave
            // 
            this.txtConfimarClave.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtConfimarClave.BackColor = System.Drawing.Color.White;
            this.txtConfimarClave.ForeColor = System.Drawing.Color.Black;
            this.txtConfimarClave.Location = new System.Drawing.Point(632, 297);
            this.txtConfimarClave.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtConfimarClave.Name = "txtConfimarClave";
            this.txtConfimarClave.Size = new System.Drawing.Size(290, 31);
            this.txtConfimarClave.TabIndex = 7;
            this.txtConfimarClave.UseSystemPasswordChar = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(48)))), ((int)(((byte)(52)))));
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.ForeColor = System.Drawing.Color.Red;
            this.btnCancelar.Location = new System.Drawing.Point(816, 413);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4, 4, 20, 4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(120, 50);
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
            this.txtID.Location = new System.Drawing.Point(146, 47);
            this.txtID.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(80, 31);
            this.txtID.TabIndex = 0;
            this.txtID.TabStop = false;
            // 
            // lblUsuario
            // 
            this.lblUsuario.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Comic Sans MS", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.ForeColor = System.Drawing.Color.White;
            this.lblUsuario.Location = new System.Drawing.Point(3, 175);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(76, 24);
            this.lblUsuario.TabIndex = 6;
            this.lblUsuario.Text = "Usuario:";
            // 
            // txtUsuario
            // 
            this.txtUsuario.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtUsuario.BackColor = System.Drawing.Color.White;
            this.txtUsuario.ForeColor = System.Drawing.Color.Black;
            this.txtUsuario.Location = new System.Drawing.Point(146, 172);
            this.txtUsuario.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(290, 31);
            this.txtUsuario.TabIndex = 5;
            // 
            // chkHabilitado
            // 
            this.chkHabilitado.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chkHabilitado.AutoSize = true;
            this.chkHabilitado.Font = new System.Drawing.Font("Comic Sans MS", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkHabilitado.ForeColor = System.Drawing.Color.White;
            this.chkHabilitado.Location = new System.Drawing.Point(480, 173);
            this.chkHabilitado.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.chkHabilitado.Name = "chkHabilitado";
            this.chkHabilitado.Size = new System.Drawing.Size(114, 28);
            this.chkHabilitado.TabIndex = 1;
            this.chkHabilitado.Text = "Habilitado";
            this.chkHabilitado.UseVisualStyleBackColor = true;
            // 
            // lblClave
            // 
            this.lblClave.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblClave.AutoSize = true;
            this.lblClave.Font = new System.Drawing.Font("Comic Sans MS", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClave.ForeColor = System.Drawing.Color.White;
            this.lblClave.Location = new System.Drawing.Point(3, 300);
            this.lblClave.Name = "lblClave";
            this.lblClave.Size = new System.Drawing.Size(57, 24);
            this.lblClave.TabIndex = 3;
            this.lblClave.Text = "Clave:";
            // 
            // txtClave
            // 
            this.txtClave.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtClave.BackColor = System.Drawing.Color.White;
            this.txtClave.ForeColor = System.Drawing.Color.Black;
            this.txtClave.Location = new System.Drawing.Point(146, 297);
            this.txtClave.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtClave.Name = "txtClave";
            this.txtClave.Size = new System.Drawing.Size(290, 31);
            this.txtClave.TabIndex = 6;
            this.txtClave.UseSystemPasswordChar = true;
            // 
            // lblConfirmarClave
            // 
            this.lblConfirmarClave.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblConfirmarClave.AutoSize = true;
            this.lblConfirmarClave.Font = new System.Drawing.Font("Comic Sans MS", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConfirmarClave.ForeColor = System.Drawing.Color.White;
            this.lblConfirmarClave.Location = new System.Drawing.Point(480, 300);
            this.lblConfirmarClave.Name = "lblConfirmarClave";
            this.lblConfirmarClave.Size = new System.Drawing.Size(141, 24);
            this.lblConfirmarClave.TabIndex = 7;
            this.lblConfirmarClave.Text = "Confirmar clave:";
            // 
            // btnAceptar
            // 
            this.btnAceptar.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnAceptar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(48)))), ((int)(((byte)(52)))));
            this.btnAceptar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAceptar.ForeColor = System.Drawing.Color.Green;
            this.btnAceptar.Location = new System.Drawing.Point(20, 413);
            this.btnAceptar.Margin = new System.Windows.Forms.Padding(20, 4, 4, 4);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(119, 50);
            this.btnAceptar.TabIndex = 8;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = false;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            this.btnAceptar.MouseEnter += new System.EventHandler(this.btnAceptar_MouseEnter);
            this.btnAceptar.MouseLeave += new System.EventHandler(this.btnAceptar_MouseLeave);
            // 
            // UsuarioDesktop
            // 
            this.AcceptButton = this.btnAceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(956, 502);
            this.Controls.Add(this.tlUsuario);
            this.Font = new System.Drawing.Font("Comic Sans MS", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UsuarioDesktop";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Datos del usuario";
            this.Load += new System.EventHandler(this.UsuarioDesktop_Load);
            this.tlUsuario.ResumeLayout(false);
            this.tlUsuario.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlUsuario;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label lblClave;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Label lblConfirmarClave;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtClave;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.TextBox txtConfimarClave;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.CheckBox chkHabilitado;
    }
}