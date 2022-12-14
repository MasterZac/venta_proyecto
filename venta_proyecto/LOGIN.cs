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
    public partial class LOGIN : Form
    {
        MySqlConnection cnn = new MySqlConnection();
        MySqlCommand cmd = new MySqlCommand();
        MySqlDataReader rd;
        public LOGIN()
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

        private void BtnAcceder_Click(object sender, EventArgs e)
        {
            bool existe = false;
            bool estatus = false;
            try
            {
                Conectar();
                //Creo una consulta para saber si existe
                string query = "Select Usuario, Contraseña From users Where Usuario = ('" + TxtUsuario.Text + "') And Contraseña = ('" + TxtContraseña.Text + "'); ";
                cmd = new MySqlCommand(query, cnn);
                cmd.CommandType = CommandType.Text;
                rd = cmd.ExecuteReader();
                if (rd.Read())// Si existe el usuario
                {
                    existe = true;
                }
                else // si no existe que me mande un mensaje que esta incorrecto
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

            try
            {
                Conectar();
                //Creo una consulta para saber si existe
                string query = "Select Estatus From users Where Usuario = ('" + TxtUsuario.Text + "') And Contraseña = ('" + TxtContraseña.Text + "') And Estatus = 'Activo'; ";
                cmd = new MySqlCommand(query, cnn);
                cmd.CommandType = CommandType.Text;
                rd = cmd.ExecuteReader();
                if (rd.Read())// Si existe el usuario
                {
                    estatus = true;
                }
                else // si no existe que me mande un mensaje que esta incorrecto
                {
                    estatus = false;
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
                if (estatus == true)
                {
                    Menu x = new Menu();
                    x.NombreUsuario = TxtUsuario.Text;
                    this.Hide();
                    x.Show();
                }
                else
                {
                    MessageBox.Show("Usuario deshabilitado del sistema");
                }

            }
            else
            {
                MessageBox.Show("Usuario y/o contraseña incorrecta");
            }
            // que mande al menu
        }

        private void LinkRegistrar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
        }

        private void ChekBoxVer_CheckedChanged(object sender, EventArgs e)
        {
            if (ChekBoxVer.Checked == false)
            {
                TxtContraseña.PasswordChar = '*';
            }
            else
            {
               if (TxtContraseña.Text != "")
               {
                    TxtContraseña.PasswordChar = '\0';
               }

            }
            
        }

        private void LOGIN_Load(object sender, EventArgs e)
        {

        }

        private void linkExit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Application.Exit();
        }
    }
}
