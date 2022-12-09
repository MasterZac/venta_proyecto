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
    public partial class Registro_usuario : Form
    {
        MySqlConnection cnn = new MySqlConnection();
        MySqlCommand cmd = new MySqlCommand();
        Cargar_Dgv cargar = new Cargar_Dgv();
        MySqlDataAdapter da;
        DataTable dt;
        MySqlDataReader rd;
        
        public string NombreUsuario { get; set; }

        public Registro_usuario()
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

        public void Limpiar()
        {
            TxtID.Clear();
            TxtNombreUsuario.Clear();
            TxtContraseña.Clear();
            CmbTipoUsuario.Text = " ";
            TxtNombreUsuario.Focus();
            TxtID.ReadOnly = false;
        }

        public void Consultas()
        {
            try
            {
                Conectar();

                cmd = cnn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM users Where (" + CboBuscarPor.Text + ") Like ('%" + Txtbuscar.Text + "%')";
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

        

        private void BtnRegistrar_Click(object sender, EventArgs e)
        {
            bool existe = false;

            if ( TxtID.Text == "" || CmbTipoUsuario.Text == "" || TxtNombreUsuario.Text == "" || TxtContraseña.Text == "")
            {
                MessageBox.Show("EXISTEN CAMPOS VACIOS, NO SE PUEDE REGISTRAR");
            }
            else
            {
                try
                {
                    Conectar();
                    string query = "Select * From users Where ID = ('" + TxtID.Text + "'); ";
                    cmd = new MySqlCommand(query, cnn);
                    cmd.CommandType = CommandType.Text;
                    rd = cmd.ExecuteReader();
                    if (rd.Read())
                    {
                        existe = true;
                        MessageBox.Show("USUARIO YA EXISTENTE");
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
                        cmd = new MySqlCommand("AddUser", cnn);
                        cmd.CommandType = CommandType.StoredProcedure;

                        MySqlParameter _id = new MySqlParameter("_id", MySqlDbType.VarChar, 5);
                        _id.Value = TxtID.Text;
                        cmd.Parameters.Add(_id);
                        
                        MySqlParameter _usuario = new MySqlParameter("_usuario", MySqlDbType.VarChar, 80);
                        _usuario.Value = TxtNombreUsuario.Text;
                        cmd.Parameters.Add(_usuario);

                        MySqlParameter _rol = new MySqlParameter("_rol", MySqlDbType.VarChar, 15);
                        _rol.Value = CmbTipoUsuario.Text;
                        cmd.Parameters.Add(_rol);

                        MySqlParameter _contraseña = new MySqlParameter("_contraseña", MySqlDbType.VarChar, 20);
                        _contraseña.Value = TxtContraseña.Text;
                        cmd.Parameters.Add(_contraseña);

                        cmd.ExecuteNonQuery();
                        cargar.DgvUsuarios(Dgv);
                        MessageBox.Show("Usuario registrado");
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

        private void LinkTerminar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            bool existe = true;

            if ( TxtID.Text == "" || CmbTipoUsuario.Text == "" || TxtNombreUsuario.Text == "" || TxtContraseña.Text == "")
            {
                MessageBox.Show("EXISTEN CAMPOS VACIOS, NO SE PUEDE REGISTRAR");
            }
            else
            {

                try
                {
                    Conectar();
                    string query = "Select * From users Where ID = ('" + TxtID.Text + "'); ";
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
                        MessageBox.Show("USUARIO NO EXISTENTE");
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
                        cmd = new MySqlCommand("DeleteUser", cnn);
                        cmd.CommandType = CommandType.StoredProcedure;

                        MySqlParameter _id = new MySqlParameter("_id", MySqlDbType.VarChar, 50);
                        _id.Value = TxtID.Text;
                        cmd.Parameters.Add(_id);

                        cmd.ExecuteNonQuery();
                        cargar.DgvUsuarios(Dgv);
                        MessageBox.Show("SE ELIMINO EL USUARIO: " + TxtNombreUsuario.Text);
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

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            
        }

        private void Registro_usuario_Load(object sender, EventArgs e)
        {
            lblstatus1.Text = string.Format("{0}", NombreUsuario);
            cargar.DgvUsuarios(Dgv);
        }

        private void CmbTipoUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void TxtNombreUsuario_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void TxtContraseña_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void Dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (Dgv.SelectedRows.Count > 0)
                {
                    TxtID.Text = Dgv.SelectedCells[0].Value.ToString();
                    CmbTipoUsuario.Text = Dgv.SelectedCells[2].Value.ToString();
                    TxtNombreUsuario.Text = Dgv.SelectedCells[1].Value.ToString();
                    TxtContraseña.Text = Dgv.SelectedCells[3].Value.ToString();
                    TxtID.ReadOnly = true;
                    Dgv.ClearSelection();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Txtbuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 32 && e.KeyChar <= 255 && CboBuscarPor.Text == "")
            {
                MessageBox.Show("Elige por que tipo de dato quieres realzar la consulta", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            cargar.DgvUsuarios(Dgv);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool existe = true;
            bool cambios = true;

            if (TxtID.Text == "" || CmbTipoUsuario.Text == "" || TxtNombreUsuario.Text == "" || TxtContraseña.Text == "")
            {
                MessageBox.Show("EXISTEN CAMPOS VACIOS, NO SE PUEDE ACTUALIZAR");
            }
            else
            {
                try
                {
                    Conectar();
                    string query = "Select * From users Where ID = ('" + TxtID.Text + "') And Usuario = ('"+TxtNombreUsuario.Text+"') And Rol_usuario = ('"+CmbTipoUsuario.Text+"') And Contraseña = ('"+TxtContraseña.Text+"'); ";
                    cmd = new MySqlCommand(query, cnn);
                    cmd.CommandType = CommandType.Text;
                    rd = cmd.ExecuteReader();
                    if (rd.Read())
                    {
                        cambios = false;
                        MessageBox.Show("NO REALIZO NINGUN CAMBIO");
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

                try
                {
                    Conectar();
                    string query = "Select * From users Where ID = ('" + TxtID.Text + "');";
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
                        MessageBox.Show("USUARIO NO EXISTENTE");
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
                        cmd = new MySqlCommand("UpdateUser", cnn);
                        cmd.CommandType = CommandType.StoredProcedure;

                        MySqlParameter _id = new MySqlParameter("_id", MySqlDbType.VarChar, 5);
                        _id.Value = TxtID.Text;
                        cmd.Parameters.Add(_id);

                        MySqlParameter _usuario = new MySqlParameter("_usuario", MySqlDbType.VarChar, 80);
                        _usuario.Value = TxtNombreUsuario.Text;
                        cmd.Parameters.Add(_usuario);

                        MySqlParameter _rol = new MySqlParameter("_rol", MySqlDbType.VarChar, 15);
                        _rol.Value = CmbTipoUsuario.Text;
                        cmd.Parameters.Add(_rol);

                        MySqlParameter _contraseña = new MySqlParameter("_contraseña", MySqlDbType.VarChar, 20);
                        _contraseña.Value = TxtContraseña.Text;
                        cmd.Parameters.Add(_contraseña);

                        cmd.ExecuteNonQuery();
                        cargar.DgvUsuarios(Dgv);
                        MessageBox.Show("SE ACTUALIZARON LOS DATOS DEL USUARIO: " + TxtNombreUsuario.Text);
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

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Menu x = new Menu();
            x.NombreUsuario = lblstatus1.Text;
            this.Hide();
            x.Show();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            lblstatus2.Text = DateTime.Now.ToString("F");
        }
    }
}
