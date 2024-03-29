﻿
namespace UI.Desktop
{
    partial class CargosDocentes
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CargosDocentes));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tcCargosDocente = new System.Windows.Forms.ToolStripContainer();
            this.tlCargosDocente = new System.Windows.Forms.TableLayoutPanel();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.dgvCargosDocente = new System.Windows.Forms.DataGridView();
            this.lblPlan = new System.Windows.Forms.Label();
            this.lblLegajo = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblApellido = new System.Windows.Forms.Label();
            this.txtLegajo = new System.Windows.Forms.TextBox();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.lblNombre = new System.Windows.Forms.Label();
            this.btnSalir = new System.Windows.Forms.Button();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtPlan = new System.Windows.Forms.TextBox();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.tsCargosDocente = new System.Windows.Forms.ToolStrip();
            this.tsbNotas = new System.Windows.Forms.ToolStripButton();
            this.tsbNuevo = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbEditar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbEliminar = new System.Windows.Forms.ToolStripButton();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DescripcionCurso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cargo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tcCargosDocente.ContentPanel.SuspendLayout();
            this.tcCargosDocente.TopToolStripPanel.SuspendLayout();
            this.tcCargosDocente.SuspendLayout();
            this.tlCargosDocente.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCargosDocente)).BeginInit();
            this.tsCargosDocente.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcCargosDocente
            // 
            // 
            // tcCargosDocente.ContentPanel
            // 
            this.tcCargosDocente.ContentPanel.Controls.Add(this.tlCargosDocente);
            this.tcCargosDocente.ContentPanel.Margin = new System.Windows.Forms.Padding(4);
            this.tcCargosDocente.ContentPanel.Size = new System.Drawing.Size(1142, 658);
            this.tcCargosDocente.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcCargosDocente.Location = new System.Drawing.Point(0, 0);
            this.tcCargosDocente.Margin = new System.Windows.Forms.Padding(4);
            this.tcCargosDocente.Name = "tcCargosDocente";
            this.tcCargosDocente.Size = new System.Drawing.Size(1142, 694);
            this.tcCargosDocente.TabIndex = 1;
            this.tcCargosDocente.Text = "toolStripContainer1";
            // 
            // tcCargosDocente.TopToolStripPanel
            // 
            this.tcCargosDocente.TopToolStripPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(48)))), ((int)(((byte)(52)))));
            this.tcCargosDocente.TopToolStripPanel.Controls.Add(this.tsCargosDocente);
            // 
            // tlCargosDocente
            // 
            this.tlCargosDocente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(48)))), ((int)(((byte)(52)))));
            this.tlCargosDocente.ColumnCount = 4;
            this.tlCargosDocente.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlCargosDocente.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlCargosDocente.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlCargosDocente.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlCargosDocente.Controls.Add(this.lblUsuario, 2, 2);
            this.tlCargosDocente.Controls.Add(this.dgvCargosDocente, 0, 3);
            this.tlCargosDocente.Controls.Add(this.lblPlan, 0, 2);
            this.tlCargosDocente.Controls.Add(this.lblLegajo, 2, 1);
            this.tlCargosDocente.Controls.Add(this.lblEmail, 0, 1);
            this.tlCargosDocente.Controls.Add(this.lblApellido, 2, 0);
            this.tlCargosDocente.Controls.Add(this.txtLegajo, 3, 1);
            this.tlCargosDocente.Controls.Add(this.txtApellido, 3, 0);
            this.tlCargosDocente.Controls.Add(this.txtNombre, 1, 0);
            this.tlCargosDocente.Controls.Add(this.btnActualizar, 0, 4);
            this.tlCargosDocente.Controls.Add(this.lblNombre, 0, 0);
            this.tlCargosDocente.Controls.Add(this.btnSalir, 3, 4);
            this.tlCargosDocente.Controls.Add(this.txtEmail, 1, 1);
            this.tlCargosDocente.Controls.Add(this.txtPlan, 1, 2);
            this.tlCargosDocente.Controls.Add(this.txtUsuario, 3, 2);
            this.tlCargosDocente.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlCargosDocente.Location = new System.Drawing.Point(0, 0);
            this.tlCargosDocente.Margin = new System.Windows.Forms.Padding(4);
            this.tlCargosDocente.Name = "tlCargosDocente";
            this.tlCargosDocente.RowCount = 5;
            this.tlCargosDocente.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlCargosDocente.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlCargosDocente.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlCargosDocente.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tlCargosDocente.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlCargosDocente.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlCargosDocente.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlCargosDocente.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlCargosDocente.Size = new System.Drawing.Size(1142, 658);
            this.tlCargosDocente.TabIndex = 1;
            // 
            // lblUsuario
            // 
            this.lblUsuario.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.ForeColor = System.Drawing.Color.White;
            this.lblUsuario.Location = new System.Drawing.Point(574, 150);
            this.lblUsuario.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(76, 24);
            this.lblUsuario.TabIndex = 26;
            this.lblUsuario.Text = "Usuario:";
            // 
            // dgvCargosDocente
            // 
            this.dgvCargosDocente.AllowUserToAddRows = false;
            this.dgvCargosDocente.AllowUserToDeleteRows = false;
            this.dgvCargosDocente.AllowUserToResizeColumns = false;
            this.dgvCargosDocente.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(48)))), ((int)(((byte)(52)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            this.dgvCargosDocente.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCargosDocente.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCargosDocente.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvCargosDocente.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(48)))), ((int)(((byte)(52)))));
            this.dgvCargosDocente.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCargosDocente.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(53)))), ((int)(((byte)(74)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Comic Sans MS", 10.2F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(53)))), ((int)(((byte)(74)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCargosDocente.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCargosDocente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCargosDocente.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.DescripcionCurso,
            this.cargo});
            this.tlCargosDocente.SetColumnSpan(this.dgvCargosDocente, 4);
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Comic Sans MS", 10.2F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(54)))), ((int)(((byte)(90)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCargosDocente.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvCargosDocente.EnableHeadersVisualStyles = false;
            this.dgvCargosDocente.Location = new System.Drawing.Point(5, 201);
            this.dgvCargosDocente.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.dgvCargosDocente.MultiSelect = false;
            this.dgvCargosDocente.Name = "dgvCargosDocente";
            this.dgvCargosDocente.ReadOnly = true;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(53)))), ((int)(((byte)(74)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Comic Sans MS", 10.2F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(54)))), ((int)(((byte)(90)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCargosDocente.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvCargosDocente.RowHeadersWidth = 51;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.White;
            this.dgvCargosDocente.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvCargosDocente.RowTemplate.Height = 24;
            this.dgvCargosDocente.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCargosDocente.Size = new System.Drawing.Size(1132, 382);
            this.dgvCargosDocente.TabIndex = 25;
            // 
            // lblPlan
            // 
            this.lblPlan.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblPlan.AutoSize = true;
            this.lblPlan.ForeColor = System.Drawing.Color.White;
            this.lblPlan.Location = new System.Drawing.Point(4, 150);
            this.lblPlan.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPlan.Name = "lblPlan";
            this.lblPlan.Size = new System.Drawing.Size(47, 24);
            this.lblPlan.TabIndex = 23;
            this.lblPlan.Text = "Plan:";
            // 
            // lblLegajo
            // 
            this.lblLegajo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblLegajo.AutoSize = true;
            this.lblLegajo.ForeColor = System.Drawing.Color.White;
            this.lblLegajo.Location = new System.Drawing.Point(574, 85);
            this.lblLegajo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLegajo.Name = "lblLegajo";
            this.lblLegajo.Size = new System.Drawing.Size(64, 24);
            this.lblLegajo.TabIndex = 22;
            this.lblLegajo.Text = "Legajo";
            // 
            // lblEmail
            // 
            this.lblEmail.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblEmail.AutoSize = true;
            this.lblEmail.ForeColor = System.Drawing.Color.White;
            this.lblEmail.Location = new System.Drawing.Point(4, 85);
            this.lblEmail.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(57, 24);
            this.lblEmail.TabIndex = 21;
            this.lblEmail.Text = "Email:";
            // 
            // lblApellido
            // 
            this.lblApellido.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblApellido.AutoSize = true;
            this.lblApellido.ForeColor = System.Drawing.Color.White;
            this.lblApellido.Location = new System.Drawing.Point(574, 20);
            this.lblApellido.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(80, 24);
            this.lblApellido.TabIndex = 20;
            this.lblApellido.Text = "Apellido:";
            // 
            // txtLegajo
            // 
            this.txtLegajo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtLegajo.BackColor = System.Drawing.SystemColors.Control;
            this.txtLegajo.Cursor = System.Windows.Forms.Cursors.No;
            this.txtLegajo.Enabled = false;
            this.txtLegajo.ForeColor = System.Drawing.Color.Black;
            this.txtLegajo.Location = new System.Drawing.Point(764, 82);
            this.txtLegajo.Margin = new System.Windows.Forms.Padding(4, 8, 4, 8);
            this.txtLegajo.Name = "txtLegajo";
            this.txtLegajo.ReadOnly = true;
            this.txtLegajo.Size = new System.Drawing.Size(303, 31);
            this.txtLegajo.TabIndex = 19;
            this.txtLegajo.TabStop = false;
            // 
            // txtApellido
            // 
            this.txtApellido.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtApellido.BackColor = System.Drawing.SystemColors.Control;
            this.txtApellido.Cursor = System.Windows.Forms.Cursors.No;
            this.txtApellido.Enabled = false;
            this.txtApellido.ForeColor = System.Drawing.Color.Black;
            this.txtApellido.Location = new System.Drawing.Point(764, 17);
            this.txtApellido.Margin = new System.Windows.Forms.Padding(4, 8, 4, 8);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.ReadOnly = true;
            this.txtApellido.Size = new System.Drawing.Size(303, 31);
            this.txtApellido.TabIndex = 16;
            this.txtApellido.TabStop = false;
            // 
            // txtNombre
            // 
            this.txtNombre.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtNombre.BackColor = System.Drawing.SystemColors.Control;
            this.txtNombre.Cursor = System.Windows.Forms.Cursors.No;
            this.txtNombre.Enabled = false;
            this.txtNombre.ForeColor = System.Drawing.Color.Black;
            this.txtNombre.Location = new System.Drawing.Point(194, 17);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(4, 8, 4, 8);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.ReadOnly = true;
            this.txtNombre.Size = new System.Drawing.Size(300, 31);
            this.txtNombre.TabIndex = 12;
            this.txtNombre.TabStop = false;
            // 
            // btnActualizar
            // 
            this.btnActualizar.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnActualizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(48)))), ((int)(((byte)(52)))));
            this.btnActualizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizar.ForeColor = System.Drawing.Color.White;
            this.btnActualizar.Location = new System.Drawing.Point(25, 599);
            this.btnActualizar.Margin = new System.Windows.Forms.Padding(25, 6, 5, 6);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(153, 49);
            this.btnActualizar.TabIndex = 11;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = false;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            this.btnActualizar.MouseEnter += new System.EventHandler(this.btnActualizar_MouseEnter);
            this.btnActualizar.MouseLeave += new System.EventHandler(this.btnActualizar_MouseLeave);
            // 
            // lblNombre
            // 
            this.lblNombre.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblNombre.AutoSize = true;
            this.lblNombre.ForeColor = System.Drawing.Color.White;
            this.lblNombre.Location = new System.Drawing.Point(4, 20);
            this.lblNombre.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(80, 24);
            this.lblNombre.TabIndex = 7;
            this.lblNombre.Text = "Nombre:";
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnSalir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(48)))), ((int)(((byte)(52)))));
            this.btnSalir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.ForeColor = System.Drawing.Color.Red;
            this.btnSalir.Location = new System.Drawing.Point(929, 599);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(5, 6, 25, 6);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(188, 49);
            this.btnSalir.TabIndex = 10;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            this.btnSalir.MouseEnter += new System.EventHandler(this.btnSalir_MouseEnter);
            this.btnSalir.MouseLeave += new System.EventHandler(this.btnSalir_MouseLeave);
            // 
            // txtEmail
            // 
            this.txtEmail.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtEmail.BackColor = System.Drawing.SystemColors.Control;
            this.txtEmail.Cursor = System.Windows.Forms.Cursors.No;
            this.txtEmail.Enabled = false;
            this.txtEmail.ForeColor = System.Drawing.Color.Black;
            this.txtEmail.Location = new System.Drawing.Point(194, 82);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(4, 8, 4, 8);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.ReadOnly = true;
            this.txtEmail.Size = new System.Drawing.Size(300, 31);
            this.txtEmail.TabIndex = 13;
            this.txtEmail.TabStop = false;
            // 
            // txtPlan
            // 
            this.txtPlan.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtPlan.BackColor = System.Drawing.SystemColors.Control;
            this.txtPlan.Cursor = System.Windows.Forms.Cursors.No;
            this.txtPlan.Enabled = false;
            this.txtPlan.ForeColor = System.Drawing.Color.Black;
            this.txtPlan.Location = new System.Drawing.Point(194, 147);
            this.txtPlan.Margin = new System.Windows.Forms.Padding(4, 8, 4, 8);
            this.txtPlan.Name = "txtPlan";
            this.txtPlan.ReadOnly = true;
            this.txtPlan.Size = new System.Drawing.Size(300, 31);
            this.txtPlan.TabIndex = 14;
            this.txtPlan.TabStop = false;
            // 
            // txtUsuario
            // 
            this.txtUsuario.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtUsuario.BackColor = System.Drawing.SystemColors.Control;
            this.txtUsuario.Cursor = System.Windows.Forms.Cursors.No;
            this.txtUsuario.Enabled = false;
            this.txtUsuario.ForeColor = System.Drawing.Color.Black;
            this.txtUsuario.Location = new System.Drawing.Point(764, 147);
            this.txtUsuario.Margin = new System.Windows.Forms.Padding(4, 8, 4, 8);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.ReadOnly = true;
            this.txtUsuario.Size = new System.Drawing.Size(303, 31);
            this.txtUsuario.TabIndex = 24;
            this.txtUsuario.TabStop = false;
            // 
            // tsCargosDocente
            // 
            this.tsCargosDocente.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tsCargosDocente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(48)))), ((int)(((byte)(52)))));
            this.tsCargosDocente.Dock = System.Windows.Forms.DockStyle.None;
            this.tsCargosDocente.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsCargosDocente.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.tsCargosDocente.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbNotas,
            this.tsbNuevo,
            this.toolStripSeparator1,
            this.tsbEditar,
            this.toolStripSeparator2,
            this.tsbEliminar});
            this.tsCargosDocente.Location = new System.Drawing.Point(4, 0);
            this.tsCargosDocente.MinimumSize = new System.Drawing.Size(0, 36);
            this.tsCargosDocente.Name = "tsCargosDocente";
            this.tsCargosDocente.Size = new System.Drawing.Size(318, 36);
            this.tsCargosDocente.TabIndex = 1;
            // 
            // tsbNotas
            // 
            this.tsbNotas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(48)))), ((int)(((byte)(52)))));
            this.tsbNotas.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbNotas.Font = new System.Drawing.Font("Comic Sans MS", 9F);
            this.tsbNotas.ForeColor = System.Drawing.Color.White;
            this.tsbNotas.Image = ((System.Drawing.Image)(resources.GetObject("tsbNotas.Image")));
            this.tsbNotas.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNotas.Name = "tsbNotas";
            this.tsbNotas.Size = new System.Drawing.Size(122, 33);
            this.tsbNotas.Text = "Notas del curso";
            this.tsbNotas.Click += new System.EventHandler(this.tsbNotas_Click);
            this.tsbNotas.MouseEnter += new System.EventHandler(this.tsbNotas_MouseEnter);
            this.tsbNotas.MouseLeave += new System.EventHandler(this.tsbNotas_MouseLeave);
            // 
            // tsbNuevo
            // 
            this.tsbNuevo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(48)))), ((int)(((byte)(52)))));
            this.tsbNuevo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbNuevo.Font = new System.Drawing.Font("Comic Sans MS", 9F);
            this.tsbNuevo.ForeColor = System.Drawing.Color.Green;
            this.tsbNuevo.Image = ((System.Drawing.Image)(resources.GetObject("tsbNuevo.Image")));
            this.tsbNuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNuevo.Name = "tsbNuevo";
            this.tsbNuevo.Size = new System.Drawing.Size(56, 33);
            this.tsbNuevo.Text = "Nuevo";
            this.tsbNuevo.Click += new System.EventHandler(this.tsbNuevo_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 36);
            // 
            // tsbEditar
            // 
            this.tsbEditar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(48)))), ((int)(((byte)(52)))));
            this.tsbEditar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbEditar.Font = new System.Drawing.Font("Comic Sans MS", 9F);
            this.tsbEditar.ForeColor = System.Drawing.Color.White;
            this.tsbEditar.Image = ((System.Drawing.Image)(resources.GetObject("tsbEditar.Image")));
            this.tsbEditar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEditar.Name = "tsbEditar";
            this.tsbEditar.Size = new System.Drawing.Size(57, 33);
            this.tsbEditar.Text = "Editar";
            this.tsbEditar.Click += new System.EventHandler(this.tsbEditar_Click);
            this.tsbEditar.MouseEnter += new System.EventHandler(this.tsbEditar_MouseEnter);
            this.tsbEditar.MouseLeave += new System.EventHandler(this.tsbEditar_MouseLeave);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 36);
            // 
            // tsbEliminar
            // 
            this.tsbEliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(48)))), ((int)(((byte)(52)))));
            this.tsbEliminar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbEliminar.Font = new System.Drawing.Font("Comic Sans MS", 9F);
            this.tsbEliminar.ForeColor = System.Drawing.Color.Red;
            this.tsbEliminar.Image = ((System.Drawing.Image)(resources.GetObject("tsbEliminar.Image")));
            this.tsbEliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEliminar.Name = "tsbEliminar";
            this.tsbEliminar.Size = new System.Drawing.Size(68, 33);
            this.tsbEliminar.Text = "Eliminar";
            this.tsbEliminar.Click += new System.EventHandler(this.tsbEliminar_Click);
            // 
            // id
            // 
            this.id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.id.DataPropertyName = "ID";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(53)))), ((int)(((byte)(74)))));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            this.id.DefaultCellStyle = dataGridViewCellStyle3;
            this.id.HeaderText = "ID";
            this.id.MinimumWidth = 6;
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Width = 59;
            // 
            // DescripcionCurso
            // 
            this.DescripcionCurso.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DescripcionCurso.DataPropertyName = "DescripcionCurso";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(53)))), ((int)(((byte)(74)))));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            this.DescripcionCurso.DefaultCellStyle = dataGridViewCellStyle4;
            this.DescripcionCurso.HeaderText = "Curso";
            this.DescripcionCurso.MinimumWidth = 6;
            this.DescripcionCurso.Name = "DescripcionCurso";
            this.DescripcionCurso.ReadOnly = true;
            // 
            // cargo
            // 
            this.cargo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cargo.DataPropertyName = "DescripcionCargo";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(53)))), ((int)(((byte)(74)))));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            this.cargo.DefaultCellStyle = dataGridViewCellStyle5;
            this.cargo.HeaderText = "Cargo";
            this.cargo.MinimumWidth = 6;
            this.cargo.Name = "cargo";
            this.cargo.ReadOnly = true;
            // 
            // CargosDocentes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1142, 694);
            this.Controls.Add(this.tcCargosDocente);
            this.Font = new System.Drawing.Font("Comic Sans MS", 10.2F);
            this.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "CargosDocentes";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Docentes";
            this.Load += new System.EventHandler(this.CargosDocentes_Load);
            this.tcCargosDocente.ContentPanel.ResumeLayout(false);
            this.tcCargosDocente.TopToolStripPanel.ResumeLayout(false);
            this.tcCargosDocente.TopToolStripPanel.PerformLayout();
            this.tcCargosDocente.ResumeLayout(false);
            this.tcCargosDocente.PerformLayout();
            this.tlCargosDocente.ResumeLayout(false);
            this.tlCargosDocente.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCargosDocente)).EndInit();
            this.tsCargosDocente.ResumeLayout(false);
            this.tsCargosDocente.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer tcCargosDocente;
        private System.Windows.Forms.TableLayoutPanel tlCargosDocente;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.DataGridView dgvCargosDocente;
        private System.Windows.Forms.Label lblPlan;
        private System.Windows.Forms.Label lblLegajo;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.TextBox txtLegajo;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtPlan;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.ToolStrip tsCargosDocente;
        private System.Windows.Forms.ToolStripButton tsbNuevo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbEditar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsbEliminar;
        private System.Windows.Forms.ToolStripButton tsbNotas;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn DescripcionCurso;
        private System.Windows.Forms.DataGridViewTextBoxColumn cargo;
    }
}