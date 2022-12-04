using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using MySql.Data.MySqlClient;

namespace venta_proyecto
{
    internal class Cargar_Dgv
    {
        MySqlConnection cnn = new MySqlConnection();
        MySqlDataAdapter da;
        DataTable dt;
        string ruta_DB = "Server = localhost; Database = ventahardware; user = root; password = root";

        public void Conectar()
        {
            cnn.ConnectionString = ruta_DB;
            cnn.Open();
        }

        public void Desconectar()
        {
            cnn.Close();
        }

        public void DgvCategoria(DataGridView dgv)
        {
            try
            {
                Conectar();
                da = new MySqlDataAdapter("dgvCategorias", cnn);
                dt = new DataTable();
                da.Fill(dt);
                dgv.DataSource = dt;
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

        public void DgvProveedor(DataGridView dgv)
        {
            try
            {
                Conectar();
                da = new MySqlDataAdapter("dgvProveedores", cnn);
                dt = new DataTable();
                da.Fill(dt);
                dgv.DataSource = dt;
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

        public void DgvCliente(DataGridView dgv)
        {
            try
            {
                Conectar();
                da = new MySqlDataAdapter("dgvCliente", cnn);
                dt = new DataTable();
                da.Fill(dt);
                dgv.DataSource = dt;
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

        public void DgvTelefono_cliente(DataGridView dgv)
        {
            try
            {
                Conectar();
                da = new MySqlDataAdapter("dgvTelefono_cliente", cnn);
                dt = new DataTable();
                da.Fill(dt);
                dgv.DataSource = dt;
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

        public void DgvProductos(DataGridView dgv)
        {
            try
            {
                Conectar();
                da = new MySqlDataAdapter("dgvProductos", cnn);
                dt = new DataTable();
                da.Fill(dt);
                dgv.DataSource = dt;
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

        public void DgvUsuarios(DataGridView dgv)
        {
            try
            {
                Conectar();
                da = new MySqlDataAdapter("dgvUsuarios", cnn);
                dt = new DataTable();
                da.Fill(dt);
                dgv.DataSource = dt;
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
    }
}
