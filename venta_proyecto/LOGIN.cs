﻿using System;
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
            try
            {
                Conectar();
                string query = "Select Usuario, Constraseña From users Where Usuario = ('" + TxtUsuario.Text + "') And Constraseña = ('" + TxtContraseña.Text + "'); ";
                cmd = new MySqlCommand(query, cnn);
                cmd.CommandType = CommandType.Text;
                rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    
                    Menu x = new Menu();
                    x.NombreUsuario = TxtUsuario.Text;
                    this.Hide();
                    x.Show();
                }
                else
                {
                    MessageBox.Show(" ! USUARIO Y/O CONTRASEÑA INCORRECTA");
                    TxtUsuario.Focus();
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

        private void LinkRegistrar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Registro_usuario x = new Registro_usuario();
            this.Hide();
            x.Show();
        }
    }
}