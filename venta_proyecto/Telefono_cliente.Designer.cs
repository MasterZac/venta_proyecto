namespace venta_proyecto
{
    partial class Telefono_cliente
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BtnAgregar = new System.Windows.Forms.Button();
            this.BtnLimpiar = new System.Windows.Forms.Button();
            this.Dgv = new System.Windows.Forms.DataGridView();
            this.MkdTelefono = new System.Windows.Forms.MaskedTextBox();
            this.BtnLimpiarTxtBuscar = new System.Windows.Forms.Button();
            this.Txtbuscar = new System.Windows.Forms.TextBox();
            this.CboBuscarPor = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.BtnNuevoNumero = new System.Windows.Forms.Button();
            this.CmbNombreClienteTelefono = new System.Windows.Forms.ComboBox();
            this.TxtID_cliente = new System.Windows.Forms.TextBox();
            this.BtnEliminar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(23, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID_Cliente";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(23, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Telefono";
            // 
            // BtnAgregar
            // 
            this.BtnAgregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAgregar.Location = new System.Drawing.Point(26, 195);
            this.BtnAgregar.Name = "BtnAgregar";
            this.BtnAgregar.Size = new System.Drawing.Size(140, 30);
            this.BtnAgregar.TabIndex = 4;
            this.BtnAgregar.Text = "Agregar";
            this.BtnAgregar.UseVisualStyleBackColor = true;
            this.BtnAgregar.Click += new System.EventHandler(this.BtnAgregar_Click);
            // 
            // BtnLimpiar
            // 
            this.BtnLimpiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnLimpiar.Location = new System.Drawing.Point(26, 267);
            this.BtnLimpiar.Name = "BtnLimpiar";
            this.BtnLimpiar.Size = new System.Drawing.Size(140, 30);
            this.BtnLimpiar.TabIndex = 7;
            this.BtnLimpiar.Text = "Limpiar";
            this.BtnLimpiar.UseVisualStyleBackColor = true;
            this.BtnLimpiar.Click += new System.EventHandler(this.BtnLimpiar_Click);
            // 
            // Dgv
            // 
            this.Dgv.BackgroundColor = System.Drawing.SystemColors.Control;
            this.Dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dgv.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Dgv.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Dgv.Location = new System.Drawing.Point(275, 93);
            this.Dgv.MultiSelect = false;
            this.Dgv.Name = "Dgv";
            this.Dgv.ReadOnly = true;
            this.Dgv.Size = new System.Drawing.Size(393, 219);
            this.Dgv.TabIndex = 8;
            this.Dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dgv_CellClick);
            // 
            // MkdTelefono
            // 
            this.MkdTelefono.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MkdTelefono.Location = new System.Drawing.Point(26, 146);
            this.MkdTelefono.Mask = "0000000000";
            this.MkdTelefono.Name = "MkdTelefono";
            this.MkdTelefono.Size = new System.Drawing.Size(140, 24);
            this.MkdTelefono.TabIndex = 9;
            this.MkdTelefono.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.MkdTelefono_MaskInputRejected);
            // 
            // BtnLimpiarTxtBuscar
            // 
            this.BtnLimpiarTxtBuscar.Location = new System.Drawing.Point(642, 38);
            this.BtnLimpiarTxtBuscar.Name = "BtnLimpiarTxtBuscar";
            this.BtnLimpiarTxtBuscar.Size = new System.Drawing.Size(70, 28);
            this.BtnLimpiarTxtBuscar.TabIndex = 78;
            this.BtnLimpiarTxtBuscar.Text = "Limpiar";
            this.BtnLimpiarTxtBuscar.UseVisualStyleBackColor = true;
            // 
            // Txtbuscar
            // 
            this.Txtbuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txtbuscar.Location = new System.Drawing.Point(453, 40);
            this.Txtbuscar.Multiline = true;
            this.Txtbuscar.Name = "Txtbuscar";
            this.Txtbuscar.Size = new System.Drawing.Size(170, 26);
            this.Txtbuscar.TabIndex = 77;
            this.Txtbuscar.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Txtbuscar_KeyUp);
            // 
            // CboBuscarPor
            // 
            this.CboBuscarPor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CboBuscarPor.FormattingEnabled = true;
            this.CboBuscarPor.Items.AddRange(new object[] {
            "ID_cliente",
            "Nombre",
            "Telefono"});
            this.CboBuscarPor.Location = new System.Drawing.Point(335, 39);
            this.CboBuscarPor.Name = "CboBuscarPor";
            this.CboBuscarPor.Size = new System.Drawing.Size(97, 24);
            this.CboBuscarPor.TabIndex = 76;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(226, 41);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(103, 20);
            this.label9.TabIndex = 75;
            this.label9.Text = "Consular por:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(23, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 16);
            this.label3.TabIndex = 79;
            this.label3.Text = "Nombre";
            // 
            // BtnNuevoNumero
            // 
            this.BtnNuevoNumero.Location = new System.Drawing.Point(172, 146);
            this.BtnNuevoNumero.Name = "BtnNuevoNumero";
            this.BtnNuevoNumero.Size = new System.Drawing.Size(62, 25);
            this.BtnNuevoNumero.TabIndex = 81;
            this.BtnNuevoNumero.Text = "Nuevo";
            this.BtnNuevoNumero.UseVisualStyleBackColor = true;
            this.BtnNuevoNumero.Click += new System.EventHandler(this.BtnNuevoNumero_Click);
            // 
            // CmbNombreClienteTelefono
            // 
            this.CmbNombreClienteTelefono.FormattingEnabled = true;
            this.CmbNombreClienteTelefono.Location = new System.Drawing.Point(26, 103);
            this.CmbNombreClienteTelefono.Name = "CmbNombreClienteTelefono";
            this.CmbNombreClienteTelefono.Size = new System.Drawing.Size(140, 21);
            this.CmbNombreClienteTelefono.TabIndex = 83;
            this.CmbNombreClienteTelefono.SelectedIndexChanged += new System.EventHandler(this.CmbNombreClienteTelefono_SelectedIndexChanged);
            // 
            // TxtID_cliente
            // 
            this.TxtID_cliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtID_cliente.Location = new System.Drawing.Point(26, 49);
            this.TxtID_cliente.Name = "TxtID_cliente";
            this.TxtID_cliente.ReadOnly = true;
            this.TxtID_cliente.Size = new System.Drawing.Size(140, 22);
            this.TxtID_cliente.TabIndex = 84;
            this.TxtID_cliente.Text = "Automatico";
            // 
            // BtnEliminar
            // 
            this.BtnEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnEliminar.Location = new System.Drawing.Point(26, 231);
            this.BtnEliminar.Name = "BtnEliminar";
            this.BtnEliminar.Size = new System.Drawing.Size(140, 30);
            this.BtnEliminar.TabIndex = 5;
            this.BtnEliminar.Text = "Eliminar";
            this.BtnEliminar.UseVisualStyleBackColor = true;
            this.BtnEliminar.Click += new System.EventHandler(this.BtnEliminar_Click);
            // 
            // Telefono_cliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(735, 378);
            this.Controls.Add(this.TxtID_cliente);
            this.Controls.Add(this.CmbNombreClienteTelefono);
            this.Controls.Add(this.BtnNuevoNumero);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.BtnLimpiarTxtBuscar);
            this.Controls.Add(this.Txtbuscar);
            this.Controls.Add(this.CboBuscarPor);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.MkdTelefono);
            this.Controls.Add(this.Dgv);
            this.Controls.Add(this.BtnLimpiar);
            this.Controls.Add(this.BtnEliminar);
            this.Controls.Add(this.BtnAgregar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Telefono_cliente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Telefono_cliente";
            this.Load += new System.EventHandler(this.Telefono_cliente_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BtnAgregar;
        private System.Windows.Forms.Button BtnLimpiar;
        private System.Windows.Forms.DataGridView Dgv;
        private System.Windows.Forms.MaskedTextBox MkdTelefono;
        private System.Windows.Forms.Button BtnLimpiarTxtBuscar;
        private System.Windows.Forms.TextBox Txtbuscar;
        private System.Windows.Forms.ComboBox CboBuscarPor;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button BtnNuevoNumero;
        private System.Windows.Forms.ComboBox CmbNombreClienteTelefono;
        private System.Windows.Forms.TextBox TxtID_cliente;
        private System.Windows.Forms.Button BtnEliminar;
    }
}