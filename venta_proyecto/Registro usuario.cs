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
        MySqlDataReader rd;
        
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
            TxtNombreUsuario.Clear();
            TxtContraseña.Clear();
            CmbTipoUsuario.Text = " ";
            TxtNombreUsuario.Focus();
        }

        public void ValidarCampos()
        {
            var vr = !string.IsNullOrEmpty(TxtNombreUsuario.Text) &&
                !string.IsNullOrEmpty(TxtContraseña.Text) &&
                !string.IsNullOrEmpty(CmbTipoUsuario.Text);
            BtnRegistrar.Enabled = vr;
        }

        private void BtnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                Conectar();
                cmd = new MySqlCommand("AddUser", cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                MySqlParameter _usuario = new MySqlParameter("_usuario", MySqlDbType.VarChar, 50);
                _usuario.Value = TxtNombreUsuario.Text;
                cmd.Parameters.Add(_usuario);

                MySqlParameter _tipo = new MySqlParameter("_tipo", MySqlDbType.VarChar, 15);
                _tipo.Value = CmbTipoUsuario.Text;
                cmd.Parameters.Add(_tipo);

                MySqlParameter _contraseña = new MySqlParameter("_contraseña", MySqlDbType.VarChar, 20);
                _contraseña.Value = TxtContraseña.Text;
                cmd.Parameters.Add(_contraseña);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Usuario registrado");

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

        private void LinkTerminar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LOGIN z = new LOGIN();
            this.Hide();
            z.Show();
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            CmbTipoUsuario.Text = "";
            TxtNombreUsuario.Clear();
            TxtContraseña.Clear();
            CmbTipoUsuario.Focus();
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                Conectar();
                cmd = new MySqlCommand("DeleteUser", cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                MySqlParameter _usuario = new MySqlParameter("_usuario", MySqlDbType.VarChar, 50);
                _usuario.Value = TxtNombreUsuario.Text;
                cmd.Parameters.Add(_usuario);
                rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    TxtContraseña.Text = rd[3].ToString();
                    CmbTipoUsuario.Text = rd[2].ToString();
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

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                Conectar();
                cmd = new MySqlCommand("SelectUser", cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                MySqlParameter _usuario = new MySqlParameter("_usuario", MySqlDbType.VarChar, 50);
                _usuario.Value = TxtNombreUsuario.Text;
                cmd.Parameters.Add(_usuario);
                rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    TxtContraseña.Text = rd[3].ToString();
                    CmbTipoUsuario.Text = rd[2].ToString();
                }
                else
                {
                    MessageBox.Show("!No se ha encontrado el usuario!");
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

        private void Registro_usuario_Load(object sender, EventArgs e)
        {

        }

        private void CmbTipoUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            ValidarCampos();
        }

        private void TxtNombreUsuario_TextChanged(object sender, EventArgs e)
        {
            ValidarCampos();
        }

        private void TxtContraseña_TextChanged(object sender, EventArgs e)
        {
            ValidarCampos();
        }
    }
}
