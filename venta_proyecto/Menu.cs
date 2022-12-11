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
    public partial class Menu : Form
    {
        MySqlConnection cnn = new MySqlConnection();
        MySqlCommand cmd = new MySqlCommand();
        MySqlDataReader rd;
        public string NombreUsuario { get; set; }
        public string Rol { get; set; }
        public Menu()
        {
            InitializeComponent();
        }

        public void Conectar()
        {
            cnn.ConnectionString = "Server = localhost; Database = ventahardware; user = root; password = root";
            cnn.Open();
        }

        public void Desconectar()
        {
            cnn.Close();
        }

        public void ConsultarTipoDeUser()
        {
            
            try
            {
                Conectar();
                string query = "Select Rol_usuario From users Where Usuario = ('" + lblstatus1.Text + "'); ";
                cmd = new MySqlCommand(query, cnn);
                cmd.CommandType = CommandType.Text;
                rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    LabelRol.Text = rd[0].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }

        private void BtnProveedores_Click(object sender, EventArgs e)
        {
            Proveedor x = new Proveedor();
            x.NombreUsuario = lblstatus1.Text;
            this.Hide();
            x.Show();
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            LOGIN x = new LOGIN();
            this.Hide();
            x.Show();
        }

        private void BtnCategorias_Click(object sender, EventArgs e)
        {
            Categoria x = new Categoria();
            x.NombreUsuario = lblstatus1.Text;
            this.Hide();
            x.Show();
        }

        private void BtnClientes_Click(object sender, EventArgs e)
        {
            Cliente x = new Cliente();
            x.NombreUsuario = lblstatus1.Text;
            this.Hide();
            x.Show();
        }

        private void BtnProductos_Click(object sender, EventArgs e)
        {
            Almacen x = new Almacen();
            x.NombreUsuario = lblstatus1.Text;
            this.Hide();
            x.Show();
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            lblstatus1.Text = string.Format("{0}", NombreUsuario);
            ConsultarTipoDeUser();
            if (LabelRol.Text == "Vendedor")
            {
                BtnCategorias.Enabled = false;
                BtnProductos.Enabled = false;
                BtnClientes.Enabled = false;
                BtnProveedores.Enabled = false;
                BtnUsuarios.Enabled = false;
            }

            if (LabelRol.Text == "Administrador")
            {
                BtnUsuarios.Enabled = false;
            }

        }

        private void BtnCerrarPrograma_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnUsuarios_Click(object sender, EventArgs e)
        {
            Registro_usuario x = new Registro_usuario();
            x.NombreUsuario = lblstatus1.Text;
            this.Hide();
            x.Show();
        }

        private void BtnVentas_Click(object sender, EventArgs e)
        {
            Ventas x = new Ventas();
            x.NombreUsuario = lblstatus1.Text;
            this.Hide();
            x.Show();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            lblstatus2.Text = DateTime.Now.ToString("F");
        }

        private void BtnSeccion_Consultas_Click(object sender, EventArgs e)
        {
            Seccion_de_Consultas x = new Seccion_de_Consultas();
            x.nombreUsuario = lblstatus1.Text;
            this.Hide();
            x.Show();
        }
    }
}
