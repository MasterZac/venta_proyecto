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
    public partial class Ventas : Form
    {
        MySqlConnection cnn = new MySqlConnection();
        MySqlCommand cmd = new MySqlCommand();
        Cargar_Dgv cargar = new Cargar_Dgv();
        MySqlDataReader rd;
        MySqlDataAdapter da;
        DataTable dt;

        public Ventas()
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

        private void Ventas_Load(object sender, EventArgs e)
        {
            cargar.DgvProductos(DgvProducto);
            cargar.DgvCliente(DgvClientes);
        }

        public void ConsultaProducto()
        {
            try
            {
                Conectar();

                cmd = cnn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM producto Where (" + CboBuscarPor.Text + ") Like ('" + Txtbuscar.Text + "%')";
                cmd.ExecuteNonQuery();

                dt = new DataTable();
                da = new MySqlDataAdapter(cmd);

                da.Fill(dt);
                DgvProducto.DataSource = dt;

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

        public void ConsultaCliente()
        {
            try
            {
                Conectar();

                cmd = cnn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM cliente Where (" + CmbConsultPor.Text + ") Like ('%" + TxtBusc.Text + "%')";
                cmd.ExecuteNonQuery();

                dt = new DataTable();
                da = new MySqlDataAdapter(cmd);

                da.Fill(dt);
                DgvClientes.DataSource = dt;

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

        private void PanelConsultaProducto_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BtnConsultaProducto_Click(object sender, EventArgs e)
        {
            PanelConsultaProducto.Visible = true;
        }

        private void BtnCerrarPanel2_Click(object sender, EventArgs e)
        {
            PanelConsultaProducto.Visible = false;
        }

        private void BtnConsultar_Click(object sender, EventArgs e)
        {
           
        }

        private void BtnCerrarConsultCliente_Click(object sender, EventArgs e)
        {
            PanelConsultaCliente.Visible = false;
        }

        private void BtnConsultar_Click_1(object sender, EventArgs e)
        {
            PanelConsultaCliente.Visible = true;
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
                ConsultaProducto();
            }
        }

        private void TxtBusc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 32 && e.KeyChar <= 255 && CboBuscarPor.Text == "")
            {
                MessageBox.Show("Elige por que tipo de dato quieres realzar la consulta", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Handled = true;
                return;
            }
            else
            {
                ConsultaCliente();
            }
        }

        private void DgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (DgvClientes.SelectedRows.Count > 0)
                {

                    TxtID_cliente.Text = DgvClientes.SelectedCells[0].Value.ToString();
                    TxtCliente.Text = DgvClientes.SelectedCells[1].Value.ToString();
                  
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DgvProducto_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (DgvProducto.SelectedRows.Count > 0)
                {
                    TxtSKU.Text = DgvProducto.SelectedCells[1].Value.ToString();
                    TxtProducto.Text = DgvProducto.SelectedCells[2].Value.ToString();
                    TxtStock.Text = DgvProducto.SelectedCells[3].Value.ToString();
                    Txt
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DgvProducto_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}