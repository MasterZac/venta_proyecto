using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace venta_proyecto
{
    public partial class Respaldos : Form
    {
        public Respaldos()
        {
            InitializeComponent();
        }

        private void BtnGenerar_Click(object sender, EventArgs e)
        {
            SaveFileDialog seleccionar = new SaveFileDialog();
            seleccionar.Filter = "Archivo SQL (*.sql)|*.sql";
            seleccionar.InitialDirectory = @"C:\Users\zacar\Documents\MATERIAS 5 SEMESTRE\Taller de base de datos\venta_proyecto\venta_proyecto\bin\Respaldo";
            seleccionar.Title = "Seleccionar archivo de respaldo";
            if (seleccionar.ShowDialog() == DialogResult.OK)
            {
                string ruta = seleccionar.FileName;
                string cadena_conexion = "Server = localhost; Database = ventahardware; user = root; password = root;";
                cadena_conexion += "charset=utf8; convertzerodatetime=true";

                MySqlConnection conexion = new MySqlConnection(cadena_conexion);
                MySqlCommand cmd = new MySqlCommand();
                MySqlBackup backup = new MySqlBackup(cmd);

                try
                {
                    cmd.Connection = conexion;
                    conexion.Open();
                    backup.ExportToFile(ruta);
                    MessageBox.Show("Respaldo generado");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    conexion.Close();
                }
                
            }
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
