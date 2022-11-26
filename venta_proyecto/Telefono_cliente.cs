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
                string query = "Select cliente.Nombre From telefono_cliente, cliente Where telefono_cliente.ID_cliente = Cliente.ID Group by cliente.Nombre; ";
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
                string query = "Select telefono_cliente.ID_cliente From telefono_cliente, cliente Where telefono_cliente.ID_cliente = cliente.ID And Nombre  = ('"+ CmbNombreClienteTelefono.Text+"'); ";
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
                cmd.CommandText = "SELECT telefono_cliente.ID_cliente, cliente.Nombre, telefono_cliente.Telefono FROM telefono_cliente, cliente Where telefono_cliente.ID_cliente = cliente.ID AND (" + CboBuscarPor.Text + ") Like ('" + Txtbuscar.Text + "%')";
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

        public void ValidarCampos()
        {
            var vr = !string.IsNullOrEmpty(CmbNombreClienteTelefono.Text) && 
                !string.IsNullOrEmpty(MkdTelefono.Text);
            BtnAgregar.Enabled = vr;
        }

        private void Telefono_cliente_Load(object sender, EventArgs e)
        {
            ConsultaComboNombreCliente();
            cargar.DgvTelefono_cliente(Dgv);
            BtnAgregar.Enabled = false;
            BtnActualizar.Enabled = false;
            BtnEliminar.Enabled = false;
        }

        public void Limpiar()
        {
            TxtID_cliente.Clear();
            CmbNombreClienteTelefono.Text = "";
            MkdTelefono.Clear();
            CmbNombreClienteTelefono.Focus();
        }
        bool validar = false;
        private void Dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (Dgv.SelectedRows.Count > 0)
                {
                    validar = true;
                    TxtID_cliente.Text = Dgv.SelectedCells[0].Value.ToString();
                    CmbNombreClienteTelefono.Text = Dgv.SelectedCells[1].Value.ToString();
                    MkdTelefono.Text = Dgv.SelectedCells[2].Value.ToString();
                    BtnAgregar.Enabled = false;
                    BtnActualizar.Enabled = true;
                    BtnEliminar.Enabled = true;
                }
                else
                {
                    validar = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                Conectar();
                string query = "Select Telefono From telefono_cliente Where ID_cliente = ('"+ TxtID_cliente.Text +"') And Telefono = ('"+ MkdTelefono.Text +"'); ";
                cmd = new MySqlCommand(query, cnn);
                cmd.CommandType = CommandType.Text;
                rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    MessageBox.Show("Ya existe ese numero de telefono");
                    MkdTelefono.Clear();
                    MkdTelefono.Focus();
                }
                else
                {
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
                    MessageBox.Show("Numero de telefono Agregado");
                    Limpiar();
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

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
            BtnEliminar.Enabled = false;
            BtnActualizar.Enabled = false;
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                Conectar();
                cmd = new MySqlCommand("DeleteTelefono_cliente", cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                MySqlParameter _telefono = new MySqlParameter("_telefono", MySqlDbType.VarChar, 10);
                _telefono.Value = MkdTelefono.Text;
                cmd.Parameters.Add(_telefono);

                cmd.ExecuteNonQuery();
                cargar.DgvTelefono_cliente(Dgv);
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

        private void TxtID_TextChanged(object sender, EventArgs e)
        {
            if(validar == false)
                ValidarCampos();
        }

        private void MkdTelefono_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            if (validar == false)
                ValidarCampos();
        }

        private void Txtbuscar_KeyUp(object sender, KeyEventArgs e)
        {
            Consultas();
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                Conectar();
                cmd = new MySqlCommand("UpdateTelefono_cliente", cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                MySqlParameter _id_cliente = new MySqlParameter("_id_cliente", MySqlDbType.VarChar, 5);
                _id_cliente.Value = TxtID_cliente.Text;
                cmd.Parameters.Add(_id_cliente);

                MySqlParameter _telefono = new MySqlParameter("_telefono", MySqlDbType.VarChar, 10);
                _telefono.Value = MkdTelefono.Text;
                cmd.Parameters.Add(_telefono);

                cmd.ExecuteNonQuery();
                cargar.DgvTelefono_cliente(Dgv);
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

        private void BtnNuevoNumero_Click(object sender, EventArgs e)
        {
            MkdTelefono.Clear();
            MkdTelefono.Focus();
            BtnEliminar.Enabled = false;
            BtnActualizar.Enabled = false;
        }

        private void CmbNombreClienteTelefono_SelectedIndexChanged(object sender, EventArgs e)
        {
            ConsultaIdCliente();
        }
    }
}
