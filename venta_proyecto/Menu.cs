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
        DataTable dt;
        MySqlDataAdapter da;
        public string NombreUsuario { get; set; }
        public string Rol { get; set; }
        public string fecha_entrada;
        public string fecha_salida;
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
            fecha_salida = Convert.ToString(DateTime.Now.ToString("s"));
            EnviarBitacora();
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

        public void EnviarBitacora()
        {
            try
            {
                Conectar();
                cmd = new MySqlCommand("AddBitacora", cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                MySqlParameter _usuario = new MySqlParameter("usuario", MySqlDbType.VarChar, 50);
                _usuario.Value = lblstatus1.Text;
                cmd.Parameters.Add(_usuario);

                MySqlParameter _fecha_e = new MySqlParameter("fecha_e", MySqlDbType.DateTime);
                _fecha_e.Value = Convert.ToDateTime(fecha_entrada);
                cmd.Parameters.Add(_fecha_e);

                MySqlParameter _fecha_s = new MySqlParameter("fecha_s", MySqlDbType.DateTime);
                _fecha_s.Value = Convert.ToDateTime(fecha_salida);
                cmd.Parameters.Add(_fecha_s);

                cmd.ExecuteNonQuery();
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

        public void ConsultasProductosVendidos()
        {
            try
            {
                Conectar();

                cmd = cnn.CreateCommand();
                cmd.CommandType = CommandType.Text;
              
                cmd.CommandText = "SELECT * FROM detalle_venta Where (" + Cb1.Text + ") Like ('" + textBox1.Text + "%')";
                cmd.ExecuteNonQuery();

                dt = new DataTable();
                da = new MySqlDataAdapter(cmd);

                da.Fill(dt);
                dataGridView1.DataSource = dt;

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

        public void ConsultaVentas()
        {
            try
            {
                Conectar();

                cmd = cnn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM venta Where (" + cbo2.Text + ") Like ('" + textBox2.Text + "%')";
                cmd.ExecuteNonQuery();

                dt = new DataTable();
                da = new MySqlDataAdapter(cmd);

                da.Fill(dt);
                dataGridView2.DataSource = dt;

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

        public void ConsultasCorte()
        {
            try
            {
                Conectar();

                cmd = cnn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM corte_caja Where (" + comboBox3.Text + ") Like ('" + textBox3.Text + "%')";
                cmd.ExecuteNonQuery();

                dt = new DataTable();
                da = new MySqlDataAdapter(cmd);

                da.Fill(dt);
                dataGridView3.DataSource = dt;

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

        private void Menu_Load(object sender, EventArgs e)
        {
            lblstatus1.Text = NombreUsuario.ToString();
            fecha_entrada = Convert.ToString(DateTime.Now.ToString("G"));
            ConsultarTipoDeUser();
            if (LabelRol.Text == "Vendedor")
            {
                BtnCategorias.Enabled = false;
                BtnProductos.Enabled = false;
                BtnClientes.Enabled = false;
                BtnProveedores.Enabled = false;
                BtnUsuarios.Enabled = false;
                hISTORIALDELASVENTASToolStripMenuItem.Enabled = false;
                BtnLog.Enabled = false;
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

        private void button1_Click(object sender, EventArgs e)
        {
            Bitacora x = new Bitacora();
            x.Show();
        }

        Cargar_Dgv cargar = new Cargar_Dgv();
        private void hISTORIALDELASVENTASToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cargar.DgvCompras(dataGridView1);
            cargar.DgvVentas(dataGridView2);
            cargar.DgvCortes(dataGridView3);

            if (tabControl1.Visible == false)
            {
                tabControl1.Visible = true;
            }
            else
            {
                tabControl1.Visible = false;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox3.Clear();
            cargar.DgvCortes(dataGridView3);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            textBox2.Clear();
            cargar.DgvVentas(dataGridView2);
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            cargar.DgvCompras(dataGridView1);
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (Cb1.SelectedIndex < 0)
            {
                MessageBox.Show("Selecciona por que quieres consultar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                ConsultasProductosVendidos();
            }
        }

        private void textBox2_KeyUp(object sender, KeyEventArgs e)
        {
            if (cbo2.SelectedIndex < 0)
            {
                MessageBox.Show("Selecciona por que quieres consultar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                ConsultaVentas();
            }
        }

        private void textBox3_KeyUp(object sender, KeyEventArgs e)
        {
            if (comboBox3.SelectedIndex < 0)
            {
                MessageBox.Show("Selecciona por que quieres consultar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                ConsultasCorte();
            }
        }
    }
}
