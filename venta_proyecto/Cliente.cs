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
    public partial class Cliente : Form
    {
        MySqlConnection cnn = new MySqlConnection();
        MySqlCommand cmd = new MySqlCommand();
        Cargar_Dgv cargar = new Cargar_Dgv();
        MySqlDataReader rd;
        MySqlDataAdapter da;
        DataTable dt;
        public string NombreUsuario { get; set; }
        public Cliente()
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

        public void Consultas()
        {
            try
            {
                Conectar();

                cmd = cnn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM cliente Where (" + CboBuscarPor.Text + ") Like ('%" + Txtbuscar.Text + "%')";
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

        public void Limpiar()
        {
            TxtID.Clear();
            TxtNombre.Clear();
            TxtCorreo.Clear();
            MkdCP.Clear();
            TxtCiudad.Clear();
            TxtComuna.Clear();
            TxtCalle.Clear();
            TxtNumero.Clear();
            TxtID.Focus();
            TxtEstatus.Clear();
            TxtID.ReadOnly = false;

        }

        private void Cliente_Load(object sender, EventArgs e)
        {
            lblstatus1.Text = String.Format("{0}", NombreUsuario);
            cargar.DgvCliente(Dgv);
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Menu x = new Menu();
            x.NombreUsuario = lblstatus1.Text;
            this.Hide();
            x.Show();
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            bool existe = false;

            if (TxtID.Text == "" || TxtNombre.Text == "" || TxtCorreo.Text == "" || MkdCP.Text == "" || TxtCiudad.Text == "" || TxtComuna.Text == "" || TxtCalle.Text == "" || TxtNumero.Text == "")
            {
                MessageBox.Show("EXISTEN CAMPOS VACIOS, NO SE PUEDE AGREGAR");
            }
            else
            {
                try
                {
                    Conectar();
                    string query = "Select * From cliente Where ID = ('" + TxtID.Text + "'); ";
                    
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
                        cmd = new MySqlCommand("AddCliente", cnn);
                        cmd.CommandType = CommandType.StoredProcedure;

                        MySqlParameter _id = new MySqlParameter("_id", MySqlDbType.VarChar, 5);
                        _id.Value = TxtID.Text;
                        cmd.Parameters.Add(_id);

                        MySqlParameter _nombre = new MySqlParameter("_nombre", MySqlDbType.VarChar, 80);
                        _nombre.Value = TxtNombre.Text;
                        cmd.Parameters.Add(_nombre);

                        MySqlParameter _correo = new MySqlParameter("_email", MySqlDbType.VarChar, 100);
                        _correo.Value = TxtCorreo.Text;
                        cmd.Parameters.Add(_correo);

                        MySqlParameter _cp = new MySqlParameter("_cp", MySqlDbType.VarChar, 5);
                        _cp.Value = MkdCP.Text;
                        cmd.Parameters.Add(_cp);

                        MySqlParameter _ciudad = new MySqlParameter("_ciudad", MySqlDbType.VarChar, 100);
                        _ciudad.Value = TxtCiudad.Text;
                        cmd.Parameters.Add(_ciudad);

                        MySqlParameter _comuna = new MySqlParameter("_comuna", MySqlDbType.VarChar, 100);
                        _comuna.Value = TxtComuna.Text;
                        cmd.Parameters.Add(_comuna);

                        MySqlParameter _calle = new MySqlParameter("_calle", MySqlDbType.VarChar, 100);
                        _calle.Value = TxtCalle.Text;
                        cmd.Parameters.Add(_calle);

                        MySqlParameter _numero = new MySqlParameter("_numero", MySqlDbType.Int32);
                        _numero.Value = TxtNumero.Text;
                        cmd.Parameters.Add(_numero);

                        cmd.ExecuteNonQuery();
                        cargar.DgvCliente(Dgv);
                        MessageBox.Show("SE HA AGREGADO EL CLIENTE: " + TxtNombre.Text);
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
                else
                {
                    MessageBox.Show("CLIENTE YA EXISTENTE");
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

            if (TxtID.Text == "")
            {
                MessageBox.Show("El campo id esta vacio");
            }
            else
            {
                try
                {
                    Conectar();
                    string query = "Select * From cliente Where ID = ('" + TxtID.Text + "'); ";
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
                        MessageBox.Show("NO EXISTE ESE CLIENTE");
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
                    if (TxtEstatus.Text == "Activo")
                    {
                        TxtEstatus.Text = "Inactivo";
                    }
                    else if (TxtEstatus.Text == "Inactivo")
                    {
                        TxtEstatus.Text = "Activo";
                    }
                    try
                    {
                        Conectar();
                        cmd = new MySqlCommand("DeleteCliente", cnn);
                        cmd.CommandType = CommandType.StoredProcedure;

                        MySqlParameter _id = new MySqlParameter("_id", MySqlDbType.VarChar, 5);
                        _id.Value = TxtID.Text;
                        cmd.Parameters.Add(_id);

                        MySqlParameter _estatus = new MySqlParameter("_estatus", MySqlDbType.VarChar, 20);
                        _estatus.Value = TxtEstatus.Text;
                        cmd.Parameters.Add(_estatus);

                        cmd.ExecuteNonQuery();
                        cargar.DgvCliente(Dgv);
                        MessageBox.Show("SE HA ELIMINADO EL CLIENTE: " + TxtNombre.Text);
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

        private void BtnTelefono_Click(object sender, EventArgs e)
        {
            Telefono_cliente x = new Telefono_cliente();
            x.Show();
        }

        private void TxtID_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void TxtNombre_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void TxtCorreo_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void MkdCP_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            
        }

        private void TxtCiudad_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void TxtCalle_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void TxtNumero_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void Dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (Dgv.SelectedRows.Count > 0)
                {

                    TxtID.Text = Dgv.SelectedCells[0].Value.ToString();
                    TxtNombre.Text = Dgv.SelectedCells[1].Value.ToString();
                    TxtCorreo.Text = Dgv.SelectedCells[2].Value.ToString();
                    MkdCP.Text = Dgv.SelectedCells[3].Value.ToString();
                    TxtCiudad.Text = Dgv.SelectedCells[4].Value.ToString();
                    TxtComuna.Text = Dgv.SelectedCells[5].Value.ToString();
                    TxtCalle.Text = Dgv.SelectedCells[6].Value.ToString();
                    TxtNumero.Text = Dgv.SelectedCells[7].Value.ToString();
                    TxtEstatus.Text = Dgv.SelectedCells[8].Value.ToString();
                    Dgv.ClearSelection();
                    TxtID.ReadOnly = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Txtbuscar_KeyUp(object sender, KeyEventArgs e)
        {
            if (CboBuscarPor.Text == "")
            {
                MessageBox.Show("Elige por que tipo de dato quieres realzar la consulta", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                Consultas();
            }
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            bool cambios = true;
            bool existe = false;

            if (TxtID.Text == "" || TxtNombre.Text == "" || TxtCorreo.Text == "" || MkdCP.Text == "" || TxtCiudad.Text == "" || TxtComuna.Text == "" || TxtCalle.Text == "" || TxtNumero.Text == "")
            {
                MessageBox.Show("EXISTEN CAMPOS VACIOS, NO SE PUEDE ACTUALIZAR");
            }
            else
            {
                try
                {
                    Conectar();
                    string query = "Select * From cliente Where ID = ('" + TxtID.Text + "'); ";
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
                        MessageBox.Show("CLIENTE NO EXISTENTE");
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

                try
                {
                    Conectar();
                    string query = "Select * From cliente Where ID = ('" + TxtID.Text + "') " +
                        "And Nombre = ('" + TxtNombre.Text + "') And Email = ('" + TxtCorreo.Text + "') " +
                        "And CP = ('" + MkdCP.Text + "') And Ciudad = ('" + TxtCiudad.Text + "') " +
                        "And Calle = ('" + TxtCalle.Text + "') And Numero = (" + TxtNumero.Text + "); ";

                    cmd = new MySqlCommand(query, cnn);
                    cmd.CommandType = CommandType.Text;
                    rd = cmd.ExecuteReader();
                    if (rd.Read())
                    {
                        cambios = false;
                        MessageBox.Show("NO SE REALIZO NINGUN CAMBIO");
                    }
                    else
                    {
                        cambios = true;
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

                if (cambios == true && existe == true)
                {
                    try
                    {
                        Conectar();
                        cmd = new MySqlCommand("UpdateCliente", cnn);
                        cmd.CommandType = CommandType.StoredProcedure;

                        MySqlParameter _id = new MySqlParameter("_id", MySqlDbType.VarChar, 5);
                        _id.Value = TxtID.Text;
                        cmd.Parameters.Add(_id);

                        MySqlParameter _nombre = new MySqlParameter("_nombre", MySqlDbType.VarChar, 80);
                        _nombre.Value = TxtNombre.Text;
                        cmd.Parameters.Add(_nombre);

                        MySqlParameter _correo = new MySqlParameter("_email", MySqlDbType.VarChar, 100);
                        _correo.Value = TxtCorreo.Text;
                        cmd.Parameters.Add(_correo);

                        MySqlParameter _cp = new MySqlParameter("_cp", MySqlDbType.VarChar, 5);
                        _cp.Value = MkdCP.Text;
                        cmd.Parameters.Add(_cp);

                        MySqlParameter _ciudad = new MySqlParameter("_ciudad", MySqlDbType.VarChar, 100);
                        _ciudad.Value = TxtCiudad.Text;
                        cmd.Parameters.Add(_ciudad);

                        MySqlParameter _comuna = new MySqlParameter("_comuna", MySqlDbType.VarChar, 100);
                        _comuna.Value = TxtComuna.Text;
                        cmd.Parameters.Add(_comuna);

                        MySqlParameter _calle = new MySqlParameter("_calle", MySqlDbType.VarChar, 100);
                        _calle.Value = TxtCalle.Text;
                        cmd.Parameters.Add(_calle);

                        MySqlParameter _numero = new MySqlParameter("_numero", MySqlDbType.Int32);
                        _numero.Value = TxtNumero.Text;
                        cmd.Parameters.Add(_numero);

                        cmd.ExecuteNonQuery();
                        cargar.DgvCliente(Dgv);
                        MessageBox.Show("SE HAN ACTUALIZADO LOS DATOS DEL CLIENTE " + TxtNombre.Text);
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

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void Txtbuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void TxtID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo numeros, sin espacio", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Handled = true;
                return;
            }
        }

        private void TxtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 33 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo letras ", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Handled = true;
                return;
            }
        }

        private void TxtCorreo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ( (e.KeyChar >= 32) && (e.KeyChar <= 45) || (e.KeyChar == 47) || (e.KeyChar >= 58) && (e.KeyChar <= 63) || (e.KeyChar >= 91) && (e.KeyChar <= 96) || (e.KeyChar > 123) && (e.KeyChar <= 255))
            {
                MessageBox.Show("Caracter no permitido", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Handled = true;
                return;
            }
        }

        private void BtnLimpiarTxtBuscar_Click(object sender, EventArgs e)
        {
            Txtbuscar.Clear();
            cargar.DgvCliente(Dgv);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            lblstatus2.Text = DateTime.Now.ToString("F");
        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
