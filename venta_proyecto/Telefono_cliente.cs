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
    public partial class Telefono_cliente : Form
    {
        MySqlConnection cnn = new MySqlConnection();
        MySqlCommand cmd = new MySqlCommand();
        Cargar_Dgv cargar = new Cargar_Dgv();
        MySqlDataAdapter da;
        MySqlDataReader rd;
        DataTable dt;
        public Telefono_cliente()
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

        public void ConsultaComboNombreCliente()
        {
            try
            {
                Conectar();
                string query = "Select Nombre From cliente Group by Nombre; ";
                cmd = new MySqlCommand(query, cnn);
                cmd.CommandType = CommandType.Text;
                rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    CmbNombreClienteTelefono.Items.Add(rd[0].ToString());
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

        public void ConsultaIdCliente()
        {
            try
            {
                Conectar();
                string query = "Select ID From cliente Where Nombre  = ('"+ CmbNombreClienteTelefono.Text+"'); ";
                cmd = new MySqlCommand(query, cnn);
                cmd.CommandType = CommandType.Text;
                rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    TxtID_cliente.Text = rd[0].ToString();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }

        public void Consultas()
        {
            try
            {
                Conectar();

                cmd = cnn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT telefono_cliente.ID_cliente, " +
                    "cliente.Nombre, telefono_cliente.Telefono FROM telefono_cliente, " +
                    "cliente Where telefono_cliente.ID_cliente = cliente.ID " +
                    "AND (" + CboBuscarPor.Text + ") " +
                    "Like ('" + Txtbuscar.Text + "%')";
                cmd.ExecuteNonQuery();

                dt = new DataTable();
                da = new MySqlDataAdapter(cmd);

                da.Fill(dt);
                Dgv.DataSource = dt;

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

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Telefono_cliente_Load(object sender, EventArgs e)
        {
            ConsultaComboNombreCliente();
            cargar.DgvTelefono_cliente(Dgv);
            
        }

        public void Limpiar()
        {
            TxtID_cliente.Text = "Automatico";
            CmbNombreClienteTelefono.Text = "";
            MkdTelefono.Clear();
            CmbNombreClienteTelefono.Focus();
        }
        private void Dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (Dgv.SelectedRows.Count > 0)
                {
                    
                    TxtID_cliente.Text = Dgv.SelectedCells[0].Value.ToString();
                    CmbNombreClienteTelefono.Text = Dgv.SelectedCells[1].Value.ToString();
                    MkdTelefono.Text = Dgv.SelectedCells[2].Value.ToString();
                    Dgv.ClearSelection();
                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            bool existe = false;
            
            if (TxtID_cliente.Text == "" || MkdTelefono.Text == "")
            {
                
                MessageBox.Show("HAY CAMPOS VACIOS");
            }
            else
            {
               
                try
                {
                    Conectar();
                    string query = "Select Telefono From telefono_cliente Where Telefono = ('" + MkdTelefono.Text + "'); ";
                    cmd = new MySqlCommand(query, cnn);
                    cmd.CommandType = CommandType.Text;
                    rd = cmd.ExecuteReader();
                    if (rd.Read())
                    {
                        existe = true;
                        MessageBox.Show("YA EXISTE ESE NUMERO TELEFONICO");
                        MkdTelefono.Clear();
                        MkdTelefono.Focus();
                        
                    }
                    else
                    {
                        existe = false;
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

                if (existe == false)
                {
                    try
                    {
                        Conectar();
                        cmd = new MySqlCommand("AddTelefono_cliente", cnn);
                        cmd.CommandType = CommandType.StoredProcedure;

                        MySqlParameter _id = new MySqlParameter("_id_cliente", MySqlDbType.VarChar, 5);
                        _id.Value = TxtID_cliente.Text;
                        cmd.Parameters.Add(_id);

                        MySqlParameter _telefono = new MySqlParameter("_telefono", MySqlDbType.VarChar, 10);
                        _telefono.Value = MkdTelefono.Text;
                        cmd.Parameters.Add(_telefono);

                        cmd.ExecuteNonQuery();
                        cargar.DgvTelefono_cliente(Dgv);
                        MessageBox.Show("SE AGREGO EL NUMERO TELEFONICO: " + MkdTelefono.Text + " AL CLIENTE: " + CmbNombreClienteTelefono.Text);
                        Limpiar();
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

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
           
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            bool existe = false;

            if (TxtID_cliente.Text == "" || MkdTelefono.Text == "")
            {
                MessageBox.Show("HAY CAMPOS VACIOS");
            }
            else
            {
                try
                {
                    Conectar();
                    string query = "Select * From telefono_cliente Where Telefono = ('" + MkdTelefono.Text + "'); ";
                    cmd = new MySqlCommand(query, cnn);
                    cmd.CommandType = CommandType.Text;
                    rd = cmd.ExecuteReader();
                    if (rd.Read())
                    {
                        existe = true;
                    }
                    else
                    {
                        existe = false;
                        MessageBox.Show("NO EXISTE ESE NUMERO TELEFONICO");
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

                if (existe == true)
                {
                    try
                    {
                        Conectar();
                        cmd = new MySqlCommand("DeleteTelefono_cliente", cnn);
                        cmd.CommandType = CommandType.StoredProcedure;

                        MySqlParameter _id_cliente = new MySqlParameter("_id_cliente", MySqlDbType.VarChar, 5);
                        _id_cliente.Value = TxtID_cliente.Text;
                        cmd.Parameters.Add(_id_cliente);

                        MySqlParameter _telefono = new MySqlParameter("_telefono", MySqlDbType.VarChar, 10);
                        _telefono.Value = MkdTelefono.Text;
                        cmd.Parameters.Add(_telefono);

                        cmd.ExecuteNonQuery();
                        cargar.DgvTelefono_cliente(Dgv);
                        MessageBox.Show("SE ELIMINO EL NUMERO TELEFONONICO: " + MkdTelefono.Text + " DEL CLIENTE: " + CmbNombreClienteTelefono.Text);
                        Limpiar();
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

        private void TxtID_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void MkdTelefono_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
           
        }

        private void Txtbuscar_KeyUp(object sender, KeyEventArgs e)
        {
            Consultas();
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            
        }

        private void BtnNuevoNumero_Click(object sender, EventArgs e)
        {
            MkdTelefono.Clear();
            MkdTelefono.Focus();
            
        }

        private void CmbNombreClienteTelefono_SelectedIndexChanged(object sender, EventArgs e)
        {
            ConsultaIdCliente();
        }

        private void Txtbuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32) && (e.KeyChar <= 255) && CboBuscarPor.Text == "")
            {
                MessageBox.Show("Eliga por qué tipo de dato quiere consultar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Handled = true;
                return;
            }
            else
            {
                Consultas();
            }
        }

        private void BtnLimpiarTxtBuscar_Click(object sender, EventArgs e)
        {
            Txtbuscar.Clear();
            cargar.DgvTelefono_cliente(Dgv);
        }
    }
}
