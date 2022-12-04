namespace venta_proyecto
{
    partial class Proveedor
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.BtnSalir = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnLimpiarTxtBuscar = new System.Windows.Forms.Button();
            this.Txtbuscar = new System.Windows.Forms.TextBox();
            this.CboBuscarPor = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.Dgv = new System.Windows.Forms.DataGridView();
            this.BtnLimpiar = new System.Windows.Forms.Button();
            this.BtnActualizar = new System.Windows.Forms.Button();
            this.BtnEliminar = new System.Windows.Forms.Button();
            this.BtnAgregar = new System.Windows.Forms.Button();
            this.TxtPaginaWeb = new System.Windows.Forms.TextBox();
            this.TxtRFC = new System.Windows.Forms.TextBox();
            this.TxtNombre = new System.Windows.Forms.TextBox();
            this.TxtID = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.MkdTelefono = new System.Windows.Forms.MaskedTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblstatus1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblstatus2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.BtnNuevoTelefono = new System.Windows.Forms.Button();
            this.BtnNuevoRFC = new System.Windows.Forms.Button();
            this.TxtDireccion = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Black;
            this.panel2.Controls.Add(this.BtnSalir);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1061, 67);
            this.panel2.TabIndex = 20;
            // 
            // BtnSalir
            // 
            this.BtnSalir.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.BtnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSalir.ForeColor = System.Drawing.Color.White;
            this.BtnSalir.Location = new System.Drawing.Point(969, 12);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(70, 42);
            this.BtnSalir.TabIndex = 2;
            this.BtnSalir.Text = "Salir";
            this.BtnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnSalir.UseVisualStyleBackColor = true;
            this.BtnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(310, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "REGISTRO DE PROVEEDORES";
            // 
            // BtnLimpiarTxtBuscar
            // 
            this.BtnLimpiarTxtBuscar.Location = new System.Drawing.Point(965, 154);
            this.BtnLimpiarTxtBuscar.Name = "BtnLimpiarTxtBuscar";
            this.BtnLimpiarTxtBuscar.Size = new System.Drawing.Size(70, 28);
            this.BtnLimpiarTxtBuscar.TabIndex = 70;
            this.BtnLimpiarTxtBuscar.Text = "Refresh";
            this.BtnLimpiarTxtBuscar.UseVisualStyleBackColor = true;
            this.BtnLimpiarTxtBuscar.Click += new System.EventHandler(this.BtnLimpiarTxtBuscar_Click);
            // 
            // Txtbuscar
            // 
            this.Txtbuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txtbuscar.Location = new System.Drawing.Point(759, 156);
            this.Txtbuscar.Multiline = true;
            this.Txtbuscar.Name = "Txtbuscar";
            this.Txtbuscar.Size = new System.Drawing.Size(170, 26);
            this.Txtbuscar.TabIndex = 69;
            this.Txtbuscar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Txtbuscar_KeyPress);
            this.Txtbuscar.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Txtbuscar_KeyUp);
            // 
            // CboBuscarPor
            // 
            this.CboBuscarPor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CboBuscarPor.FormattingEnabled = true;
            this.CboBuscarPor.Items.AddRange(new object[] {
            "ID",
            "Nombre",
            "RFC",
            "Telefono",
            "Pagina_Web"});
            this.CboBuscarPor.Location = new System.Drawing.Point(641, 155);
            this.CboBuscarPor.Name = "CboBuscarPor";
            this.CboBuscarPor.Size = new System.Drawing.Size(97, 24);
            this.CboBuscarPor.TabIndex = 68;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(532, 157);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(103, 20);
            this.label7.TabIndex = 67;
            this.label7.Text = "Consular por:";
            // 
            // Dgv
            // 
            this.Dgv.AllowUserToAddRows = false;
            this.Dgv.AllowUserToDeleteRows = false;
            this.Dgv.AllowUserToResizeColumns = false;
            this.Dgv.AllowUserToResizeRows = false;
            this.Dgv.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.Dgv.ColumnHeadersHeight = 30;
            this.Dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.Dgv.Location = new System.Drawing.Point(338, 203);
            this.Dgv.MultiSelect = false;
            this.Dgv.Name = "Dgv";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.Dgv.RowHeadersWidth = 30;
            this.Dgv.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.Dgv.Size = new System.Drawing.Size(690, 338);
            this.Dgv.TabIndex = 66;
            this.Dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dgv_CellClick);
            // 
            // BtnLimpiar
            // 
            this.BtnLimpiar.Location = new System.Drawing.Point(223, 391);
            this.BtnLimpiar.Name = "BtnLimpiar";
            this.BtnLimpiar.Size = new System.Drawing.Size(83, 35);
            this.BtnLimpiar.TabIndex = 65;
            this.BtnLimpiar.Text = "Refresh";
            this.BtnLimpiar.UseVisualStyleBackColor = true;
            this.BtnLimpiar.Click += new System.EventHandler(this.BtnLimpiar_Click);
            // 
            // BtnActualizar
            // 
            this.BtnActualizar.Location = new System.Drawing.Point(223, 340);
            this.BtnActualizar.Name = "BtnActualizar";
            this.BtnActualizar.Size = new System.Drawing.Size(83, 37);
            this.BtnActualizar.TabIndex = 64;
            this.BtnActualizar.Text = "Actualizar";
            this.BtnActualizar.UseVisualStyleBackColor = true;
            this.BtnActualizar.Click += new System.EventHandler(this.BtnActualizar_Click);
            // 
            // BtnEliminar
            // 
            this.BtnEliminar.Location = new System.Drawing.Point(223, 297);
            this.BtnEliminar.Name = "BtnEliminar";
            this.BtnEliminar.Size = new System.Drawing.Size(83, 35);
            this.BtnEliminar.TabIndex = 63;
            this.BtnEliminar.Text = "Eliminar";
            this.BtnEliminar.UseVisualStyleBackColor = true;
            this.BtnEliminar.Click += new System.EventHandler(this.BtnEliminar_Click);
            // 
            // BtnAgregar
            // 
            this.BtnAgregar.Location = new System.Drawing.Point(223, 245);
            this.BtnAgregar.Name = "BtnAgregar";
            this.BtnAgregar.Size = new System.Drawing.Size(83, 35);
            this.BtnAgregar.TabIndex = 62;
            this.BtnAgregar.Text = "Agregar";
            this.BtnAgregar.UseVisualStyleBackColor = true;
            this.BtnAgregar.Click += new System.EventHandler(this.BtnAgregar_Click);
            // 
            // TxtPaginaWeb
            // 
            this.TxtPaginaWeb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtPaginaWeb.Location = new System.Drawing.Point(16, 504);
            this.TxtPaginaWeb.MaxLength = 40;
            this.TxtPaginaWeb.Multiline = true;
            this.TxtPaginaWeb.Name = "TxtPaginaWeb";
            this.TxtPaginaWeb.Size = new System.Drawing.Size(188, 55);
            this.TxtPaginaWeb.TabIndex = 61;
            this.TxtPaginaWeb.TextChanged += new System.EventHandler(this.TxtPaginaWeb_TextChanged);
            // 
            // TxtRFC
            // 
            this.TxtRFC.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtRFC.Location = new System.Drawing.Point(16, 303);
            this.TxtRFC.MaxLength = 10;
            this.TxtRFC.Name = "TxtRFC";
            this.TxtRFC.Size = new System.Drawing.Size(103, 22);
            this.TxtRFC.TabIndex = 60;
            this.TxtRFC.TextChanged += new System.EventHandler(this.TxtRFC_TextChanged);
            this.TxtRFC.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtRFC_KeyPress);
            // 
            // TxtNombre
            // 
            this.TxtNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtNombre.Location = new System.Drawing.Point(16, 258);
            this.TxtNombre.MaxLength = 30;
            this.TxtNombre.Name = "TxtNombre";
            this.TxtNombre.Size = new System.Drawing.Size(188, 22);
            this.TxtNombre.TabIndex = 59;
            this.TxtNombre.TextChanged += new System.EventHandler(this.TxtNombre_TextChanged);
            this.TxtNombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtNombre_KeyPress);
            // 
            // TxtID
            // 
            this.TxtID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtID.Location = new System.Drawing.Point(16, 203);
            this.TxtID.MaxLength = 5;
            this.TxtID.Name = "TxtID";
            this.TxtID.Size = new System.Drawing.Size(188, 22);
            this.TxtID.TabIndex = 58;
            this.TxtID.TextChanged += new System.EventHandler(this.TxtID_TextChanged);
            this.TxtID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtID_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(13, 485);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 16);
            this.label6.TabIndex = 57;
            this.label6.Text = "Pagina Web";
            // 
            // MkdTelefono
            // 
            this.MkdTelefono.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MkdTelefono.Location = new System.Drawing.Point(16, 347);
            this.MkdTelefono.Mask = "0000000000";
            this.MkdTelefono.Name = "MkdTelefono";
            this.MkdTelefono.Size = new System.Drawing.Size(83, 22);
            this.MkdTelefono.TabIndex = 56;
            this.MkdTelefono.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.MkdTelefono_MaskInputRejected);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(13, 328);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 16);
            this.label5.TabIndex = 55;
            this.label5.Text = "Telefono";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(13, 284);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 16);
            this.label4.TabIndex = 54;
            this.label4.Text = "RFC";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 240);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 16);
            this.label3.TabIndex = 53;
            this.label3.Text = "Nombre";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 184);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 16);
            this.label2.TabIndex = 52;
            this.label2.Text = "ID proveedor";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Location = new System.Drawing.Point(312, 145);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(10, 496);
            this.panel1.TabIndex = 51;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.LinkColor = System.Drawing.Color.Black;
            this.linkLabel1.Location = new System.Drawing.Point(335, 145);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(155, 16);
            this.linkLabel1.TabIndex = 50;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Lista de proveedores";
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel2.LinkColor = System.Drawing.Color.Black;
            this.linkLabel2.Location = new System.Drawing.Point(34, 145);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(150, 16);
            this.linkLabel2.TabIndex = 49;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "Detalle proveedores";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Dock = System.Windows.Forms.DockStyle.Top;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel2,
            this.lblstatus1,
            this.toolStripStatusLabel1,
            this.lblstatus2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 67);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.statusStrip1.Size = new System.Drawing.Size(1061, 22);
            this.statusStrip1.TabIndex = 71;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.BackColor = System.Drawing.SystemColors.Control;
            this.toolStripStatusLabel2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.toolStripStatusLabel2.Margin = new System.Windows.Forms.Padding(6, 3, 0, 2);
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(101, 17);
            this.toolStripStatusLabel2.Text = "Nombre Usuario:";
            // 
            // lblstatus1
            // 
            this.lblstatus1.BackColor = System.Drawing.SystemColors.Control;
            this.lblstatus1.Name = "lblstatus1";
            this.lblstatus1.Size = new System.Drawing.Size(118, 17);
            this.lblstatus1.Text = "toolStripStatusLabel1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.BackColor = System.Drawing.SystemColors.Control;
            this.toolStripStatusLabel1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.toolStripStatusLabel1.Margin = new System.Windows.Forms.Padding(30, 3, 0, 2);
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(80, 17);
            this.toolStripStatusLabel1.Text = "Fecha / Hora:";
            // 
            // lblstatus2
            // 
            this.lblstatus2.BackColor = System.Drawing.SystemColors.Control;
            this.lblstatus2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.lblstatus2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblstatus2.Name = "lblstatus2";
            this.lblstatus2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblstatus2.Size = new System.Drawing.Size(118, 17);
            this.lblstatus2.Text = "toolStripStatusLabel1";
            // 
            // BtnNuevoTelefono
            // 
            this.BtnNuevoTelefono.Location = new System.Drawing.Point(129, 347);
            this.BtnNuevoTelefono.Name = "BtnNuevoTelefono";
            this.BtnNuevoTelefono.Size = new System.Drawing.Size(75, 22);
            this.BtnNuevoTelefono.TabIndex = 72;
            this.BtnNuevoTelefono.Text = "Nuevo";
            this.BtnNuevoTelefono.UseVisualStyleBackColor = true;
            this.BtnNuevoTelefono.Click += new System.EventHandler(this.BtnNuevoTelefono_Click);
            // 
            // BtnNuevoRFC
            // 
            this.BtnNuevoRFC.Location = new System.Drawing.Point(129, 303);
            this.BtnNuevoRFC.Name = "BtnNuevoRFC";
            this.BtnNuevoRFC.Size = new System.Drawing.Size(75, 23);
            this.BtnNuevoRFC.TabIndex = 73;
            this.BtnNuevoRFC.Text = "Nuevo";
            this.BtnNuevoRFC.UseVisualStyleBackColor = true;
            this.BtnNuevoRFC.Click += new System.EventHandler(this.BtnNuevoRFC_Click);
            // 
            // TxtDireccion
            // 
            this.TxtDireccion.Location = new System.Drawing.Point(19, 399);
            this.TxtDireccion.Multiline = true;
            this.TxtDireccion.Name = "TxtDireccion";
            this.TxtDireccion.Size = new System.Drawing.Size(185, 65);
            this.TxtDireccion.TabIndex = 74;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(16, 380);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 16);
            this.label8.TabIndex = 75;
            this.label8.Text = "Direccion";
            // 
            // Proveedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1061, 678);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.TxtDireccion);
            this.Controls.Add(this.BtnNuevoRFC);
            this.Controls.Add(this.BtnNuevoTelefono);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.BtnLimpiarTxtBuscar);
            this.Controls.Add(this.Txtbuscar);
            this.Controls.Add(this.CboBuscarPor);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.Dgv);
            this.Controls.Add(this.BtnLimpiar);
            this.Controls.Add(this.BtnActualizar);
            this.Controls.Add(this.BtnEliminar);
            this.Controls.Add(this.BtnAgregar);
            this.Controls.Add(this.TxtPaginaWeb);
            this.Controls.Add(this.TxtRFC);
            this.Controls.Add(this.TxtNombre);
            this.Controls.Add(this.TxtID);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.MkdTelefono);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.linkLabel2);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Proveedor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Proveedor";
            this.Load += new System.EventHandler(this.Proveedor_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button BtnSalir;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnLimpiarTxtBuscar;
        private System.Windows.Forms.TextBox Txtbuscar;
        private System.Windows.Forms.ComboBox CboBuscarPor;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView Dgv;
        private System.Windows.Forms.Button BtnLimpiar;
        private System.Windows.Forms.Button BtnActualizar;
        private System.Windows.Forms.Button BtnEliminar;
        private System.Windows.Forms.Button BtnAgregar;
        private System.Windows.Forms.TextBox TxtPaginaWeb;
        private System.Windows.Forms.TextBox TxtRFC;
        private System.Windows.Forms.TextBox TxtNombre;
        private System.Windows.Forms.TextBox TxtID;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.MaskedTextBox MkdTelefono;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel lblstatus1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel lblstatus2;
        private System.Windows.Forms.Button BtnNuevoTelefono;
        private System.Windows.Forms.Button BtnNuevoRFC;
        private System.Windows.Forms.TextBox TxtDireccion;
        private System.Windows.Forms.Label label8;
    }
}