namespace venta_proyecto
{
    partial class Seccion_de_Consultas
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.Cbo = new System.Windows.Forms.ComboBox();
            this.BtnEjecutar = new System.Windows.Forms.Button();
            this.Dgv = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.BtnCerrar = new System.Windows.Forms.Button();
            this.BtnSalir = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblstatus1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblstatus2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.Dgv)).BeginInit();
            this.panel2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(78, 128);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "CONSULTAS";
            // 
            // Cbo
            // 
            this.Cbo.DropDownHeight = 100;
            this.Cbo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cbo.DropDownWidth = 750;
            this.Cbo.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cbo.FormattingEnabled = true;
            this.Cbo.IntegralHeight = false;
            this.Cbo.ItemHeight = 20;
            this.Cbo.Items.AddRange(new object[] {
            "0 Mostrar el nombre y telefono del proveedor que su pagina web es \'www.TecnoEUDIO" +
                ".web\' ",
            "1 Mostrar el nombre de la categoria que contenga \'unidades de estado solido\'",
            "2 Mostrar el nombre de los clientes que contegan \'hotmail\' en su correo",
            "3 Mostrar los productos que tienen un precio mayor a 5000",
            "4 Mostrar todos los productos cuya categoria pertenecen a \'3\' y \'1\'",
            "5 Mostrar los productos cuya cantidad almacenada es menor de 30",
            "6 Mostrar el nombre y el precio productos que no pertenecen a la categoria 1 y 2",
            "7 Mostrar la cantidad de categorias",
            "8 Mostrar la cantidad de productos agrupados por categoria",
            "9 Mostrar el precio maximo y precio minimo de los productos agrupados por Categor" +
                "ia",
            "10 Mostrar el promedio de los precios de los productos agrupados por categoria",
            "11. Mostrar la cantidad de productos agrupados por proveedor",
            "12. Mostrar la Suma de los precios de los productos cuya categoria sea igual a 3",
            "13. Que nos muestre el total de los clientes agrupados por Ciudad a excepcion de " +
                "aquellos que estan en queretaro",
            "14. Que nos muestre el total  los clientes agrupados por comunidad a excepcion de" +
                " aquellos que se ubican en fuentes villa nueva",
            "15 Que nos muestre el tota de los numeros telefonicos de los clientes agrupados p" +
                "or nombre del cliente a excepcion del cliente grupoVentura",
            "16 Mostrar la cantidad de los productos que se encuentran en la categoria Audio",
            "17 Mostrar el nombre y el precio de los productos que abastecio el proveedor \'Tec" +
                "noAUDIO\' y el telefono y la pagina web del mismo",
            "18 Mostrar el nombre de los productos que se le vendieron al cliente Siemens y la" +
                " cantidad que se llevo de cada uno",
            "19 Mostrar el nombre del cliente que se le hizo una venta con el monto menor a 10" +
                "000 y  mostrar el monto final",
            "20 Mostrar el telefono de los clientes que se le hizo una venta con un monto entr" +
                "e 100,000 y 10,000 y su monto fue de 23,150",
            "21 Mostrar el nombre y el precio de los productos que se agregaron al numero de f" +
                "actura 5",
            "22 Mostrar el monto total de los productos que se agregaron al numero de factura " +
                "5",
            "23 Mostrar los nombres de los productos que no pertenecen a la categoria de AUDIO" +
                "",
            "24 Mostrar los datos de los productos que si pertenecen a la categoria de Almacen" +
                "amiento",
            "25 Mostrar el codigo y el nombre del producto que han sido vendidos",
            "26 Mostrar todos los datos de los producto que no han sido vendidos",
            "27 Mostrar la cantidad de productos que se adjuntaron al numero de factura = 5 ag" +
                "rupados por nombre",
            "28 Mostrar el nombre , precio y cantidad de los productos que se le vendieron al " +
                "cliente con el ID = 43579",
            "29 Mostrar el nombre y el precio de los productos y el ID y el nombre del departa" +
                "mento al que pertenecen en una vista general",
            "30  Mostrar los nombres de los clientes y su numero de telefono en una vista gene" +
                "ral"});
            this.Cbo.Location = new System.Drawing.Point(237, 125);
            this.Cbo.Name = "Cbo";
            this.Cbo.Size = new System.Drawing.Size(336, 28);
            this.Cbo.TabIndex = 1;
            // 
            // BtnEjecutar
            // 
            this.BtnEjecutar.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnEjecutar.Location = new System.Drawing.Point(630, 120);
            this.BtnEjecutar.Name = "BtnEjecutar";
            this.BtnEjecutar.Size = new System.Drawing.Size(104, 28);
            this.BtnEjecutar.TabIndex = 2;
            this.BtnEjecutar.Text = "EJECUTAR";
            this.BtnEjecutar.UseVisualStyleBackColor = true;
            this.BtnEjecutar.Click += new System.EventHandler(this.BtnEjecutar_Click);
            // 
            // Dgv
            // 
            this.Dgv.AllowUserToAddRows = false;
            this.Dgv.AllowUserToDeleteRows = false;
            this.Dgv.AllowUserToResizeColumns = false;
            this.Dgv.AllowUserToResizeRows = false;
            this.Dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.Dgv.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Dgv.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dgv.Location = new System.Drawing.Point(71, 173);
            this.Dgv.Name = "Dgv";
            this.Dgv.Size = new System.Drawing.Size(663, 220);
            this.Dgv.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Black;
            this.panel2.Controls.Add(this.BtnCerrar);
            this.panel2.Controls.Add(this.BtnSalir);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(800, 67);
            this.panel2.TabIndex = 125;
            // 
            // BtnCerrar
            // 
            this.BtnCerrar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.BtnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCerrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCerrar.ForeColor = System.Drawing.Color.White;
            this.BtnCerrar.Location = new System.Drawing.Point(702, 12);
            this.BtnCerrar.Name = "BtnCerrar";
            this.BtnCerrar.Size = new System.Drawing.Size(70, 42);
            this.BtnCerrar.TabIndex = 5;
            this.BtnCerrar.Text = "Salir";
            this.BtnCerrar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnCerrar.UseVisualStyleBackColor = true;
            this.BtnCerrar.Click += new System.EventHandler(this.BtnCerrar_Click);
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
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(12, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(287, 24);
            this.label2.TabIndex = 0;
            this.label2.Text = "CONSULTAS PREDEFINIDAS";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Dock = System.Windows.Forms.DockStyle.Top;
            this.statusStrip1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel2,
            this.lblstatus1,
            this.toolStripStatusLabel1,
            this.lblstatus2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 67);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.statusStrip1.Size = new System.Drawing.Size(800, 25);
            this.statusStrip1.TabIndex = 126;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.BackColor = System.Drawing.SystemColors.Control;
            this.toolStripStatusLabel2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabel2.Margin = new System.Windows.Forms.Padding(6, 3, 0, 2);
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(67, 20);
            this.toolStripStatusLabel2.Text = "Usuario:";
            // 
            // lblstatus1
            // 
            this.lblstatus1.BackColor = System.Drawing.SystemColors.Control;
            this.lblstatus1.Name = "lblstatus1";
            this.lblstatus1.Size = new System.Drawing.Size(151, 20);
            this.lblstatus1.Text = "toolStripStatusLabel1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.BackColor = System.Drawing.SystemColors.Control;
            this.toolStripStatusLabel1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabel1.Margin = new System.Windows.Forms.Padding(30, 3, 0, 2);
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(102, 20);
            this.toolStripStatusLabel1.Text = "Fecha / Hora:";
            // 
            // lblstatus2
            // 
            this.lblstatus2.BackColor = System.Drawing.SystemColors.Control;
            this.lblstatus2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.lblstatus2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblstatus2.Name = "lblstatus2";
            this.lblstatus2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblstatus2.Size = new System.Drawing.Size(151, 20);
            this.lblstatus2.Text = "toolStripStatusLabel1";
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // Seccion_de_Consultas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.Dgv);
            this.Controls.Add(this.BtnEjecutar);
            this.Controls.Add(this.Cbo);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Seccion_de_Consultas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Seccion_de_Consultas";
            this.Load += new System.EventHandler(this.Seccion_de_Consultas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Dgv)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox Cbo;
        private System.Windows.Forms.Button BtnEjecutar;
        private System.Windows.Forms.DataGridView Dgv;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button BtnCerrar;
        private System.Windows.Forms.Button BtnSalir;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel lblstatus1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel lblstatus2;
        private System.Windows.Forms.Timer timer;
    }
}