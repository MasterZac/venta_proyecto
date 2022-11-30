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
    public partial class Proveedor : Form
    {
        MySqlConnection cnn = new MySqlConnection();
        MySqlCommand cmd = new MySqlCommand();
        Cargar_Dgv cargar = new Cargar_Dgv();
        MySqlDataReader rd;
        MySqlDataAdapter da;
        DataTable dt;
        public string NombreUsuario { get; set; }

        public Proveedor()
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
                cmd.CommandText = "SELECT * FROM proveedor Where (" + CboBuscarPor.Text + ") Like ('" + Txtbuscar.Text + "%')";
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
            TxtRFC.Clear();
            MkdTelefono.Clear();
            TxtPaginaWeb.Clear();
            TxtID.Focus();
            TxtID.ReadOnly = false;
           
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Menu x = new Menu();
            x.NombreUsuario = lblstatus1.Text;
            this.Hide();
            x.Show();
        }

        private void Proveedor_Load(object sender, EventArgs e)
        {
            lblstatus1.Text = string.Format("{0}", NombreUsuario);
            lblstatus2.Text = DateTime.Now.ToString("f");
            cargar.DgvProveedor(Dgv);
           
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            bool existe = false;

            if (TxtID.Text == "" || TxtNombre.Text == "" || TxtRFC.Text == "" || MkdTelefono.Text == "" || TxtPaginaWeb.Text == "")
            {
                MessageBox.Show("EXISTEN CAMPOS VACIOS, NO SE PUEDE AGREGAR");
            }
            else
            {

                try
                {
                    Conectar();
                    string query = "Select * From proveedor Where ID = ('" + TxtID.Text + "') And Nombre = ('"+ TxtNombre.Text +"') And RFC = ('"+ TxtRFC.Text +"')";
                    cmd = new MySqlCommand(query, cnn);
                    cmd.CommandType = CommandType.Text;
                    rd = cmd.ExecuteReader();
                    if (rd.Read())
                    {
                        existe = true;
                        MessageBox.Show("PROVEEDOR YA EXISTENTE");
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

                bool existe_telefono = false;
                try
                {
                    Conectar();
                    string query = "Select Telefono From proveedor Where Telefono = ('" + MkdTelefono.Text + "'); ";
                    cmd = new MySqlCommand(query, cnn);
                    cmd.CommandType = CommandType.Text;
                    rd = cmd.ExecuteReader();
                    if (rd.Read())
                    {
                        existe_telefono = true;
                        MessageBox.Show("TELEFONO YA EXISTENTE");
                    }
                    else
                    {
                        existe_telefono = false;
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

                bool existe_RFC = false;

                try
                {
                    Conectar();
                    string query = "Select RFC From proveedor Where RFC = ('" + TxtRFC.Text + "'); ";
                    cmd = new MySqlCommand(query, cnn);
                    cmd.CommandType = CommandType.Text;
                    rd = cmd.ExecuteReader();
                    if (rd.Read())
                    {
                        existe_RFC = true;
                        MessageBox.Show("RFC YA EXISTENTE");
                    }
                    else
                    {
                        existe_RFC = false;
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


                if (existe == false && existe_telefono == false && existe_RFC == false)
                {
                    try
                    {
                        Conectar();
                        cmd = new MySqlCommand("AddProveedor", cnn);
                        cmd.CommandType = CommandType.StoredProcedure;

                        MySqlParameter _id = new MySqlParameter("_id", MySqlDbType.VarChar, 5);
                        _id.Value = TxtID.Text.Trim();
                        cmd.Parameters.Add(_id);

                        MySqlParameter _nombre = new MySqlParameter("_nombre", MySqlDbType.VarChar, 100);
                        _nombre.Value = TxtNombre.Text.Trim();
                        cmd.Parameters.Add(_nombre);

                        MySqlParameter _rfc = new MySqlParameter("_rfc", MySqlDbType.VarChar, 10);
                        _rfc.Value = TxtRFC.Text.ToUpper().Trim();
                        cmd.Parameters.Add(_rfc);

                        MySqlParameter _telefono = new MySqlParameter("_telefono", MySqlDbType.VarChar, 10);
                        _telefono.Value = MkdTelefono.Text;
                        cmd.Parameters.Add(_telefono);

                        MySqlParameter _web = new MySqlParameter("_pagina_web", MySqlDbType.Text);
                        _web.Value = TxtPaginaWeb.Text.Trim();
                        cmd.Parameters.Add(_web);

                        cmd.ExecuteNonQuery();
                        cargar.DgvProveedor(Dgv);
                        MessageBox.Show("SE HA AGREGADO EL PROVEEDOR: " + TxtNombre.Text);
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

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            bool existe = false;
             
            if (TxtID.Text == "")
            {
                MessageBox.Show("AGREGUE LA CLAVE DEL PRODUCTO PARA PODER ELIMINAR");
            }
            else
            {
                try
                {
                    Conectar();
                    string query = "Select * From proveedor Where ID = ('" + TxtID.Text + "'); ";
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
                        MessageBox.Show("NO EXISTE ESE PRODUCTO");
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
                        cmd = new MySqlCommand("DeleteProveedor", cnn);
                        cmd.CommandType = CommandType.StoredProcedure;

                        MySqlParameter _id = new MySqlParameter("_id", MySqlDbType.VarChar, 5);
                        _id.Value = TxtID.Text.Trim();
                        cmd.Parameters.Add(_id);

                        cmd.ExecuteNonQuery();
                        cargar.DgvProveedor(Dgv);
                        MessageBox.Show("SE HA ELIMINADO EL PROVEEDOR: " + TxtNombre.Text);
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

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            bool cambios = true;
            bool existe = false;

            if (TxtID.Text == "" || TxtNombre.Text == "" || TxtRFC.Text == "" || MkdTelefono.Text == "" || TxtPaginaWeb.Text == "")
            {
                MessageBox.Show("EXISTEN CAMPOS VACIOS, NO SE PUEDE ACTUALIZAR");
            }
            else
            {
                try
                {
                    Conectar();
                    string query = "Select * From proveedor Where ID = ('" + TxtID.Text + "') " +
                        "And Nombre = ('" + TxtNombre.Text + "') And RFC = ('" + TxtRFC.Text + "') " +
                        "And Telefono = ('" + MkdTelefono.Text+"') And Pagina_web = ('"+TxtPaginaWeb.Text+"'); ";

                    cmd = new MySqlCommand(query, cnn);
                    cmd.CommandType = CommandType.Text;
                    rd = cmd.ExecuteReader();
                    if (rd.Read())
                    {
                        cambios = false;
                        MessageBox.Show("NO SE REALIZO NINGUN CAMBIO");
                        existe = true;
                      
                    }
                    else
                    {
                        cambios = true;
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

                if (cambios == true && existe == true)
                {
                    try
                    {
                        Conectar();
                        cmd = new MySqlCommand("UpdateProveedor", cnn);
                        cmd.CommandType = CommandType.StoredProcedure;

                        MySqlParameter _id = new MySqlParameter("_id", MySqlDbType.VarChar, 5);
                        _id.Value = TxtID.Text.Trim();
                        cmd.Parameters.Add(_id);

                        MySqlParameter _nombre = new MySqlParameter("_nombre", MySqlDbType.VarChar, 50);
                        _nombre.Value = TxtNombre.Text.Trim();
                        cmd.Parameters.Add(_nombre);

                        MySqlParameter _rfc = new MySqlParameter("_rfc", MySqlDbType.VarChar, 10);
                        _rfc.Value = TxtRFC.Text.ToUpper().Trim();
                        cmd.Parameters.Add(_rfc);

                        MySqlParameter _telefono = new MySqlParameter("_telefono", MySqlDbType.VarChar, 10);
                        _telefono.Value = MkdTelefono.Text;
                        cmd.Parameters.Add(_telefono);

                        MySqlParameter _web = new MySqlParameter("_pagina_web", MySqlDbType.Text);
                        _web.Value = TxtPaginaWeb.Text.Trim();
                        cmd.Parameters.Add(_web);

                        cmd.ExecuteNonQuery();
                        cargar.DgvProveedor(Dgv);
                        MessageBox.Show("SE HAN ACTUALIZADO LOS DATOS DEL PROVEEDOR: " + TxtNombre.Text);
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
            TxtID.ReadOnly = false;
        }

        private void Dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (Dgv.SelectedRows.Count > 0)
                {
                    TxtID.Text = Dgv.SelectedCells[0].Value.ToString();
                    TxtNombre.Text = Dgv.SelectedCells[1].Value.ToString();
                    TxtRFC.Text = Dgv.SelectedCells[2].Value.ToString();
                    MkdTelefono.Text = Dgv.SelectedCells[3].Value.ToString();
                    TxtPaginaWeb.Text = Dgv.SelectedCells[4].Value.ToString();
                    TxtID.ReadOnly = true;
                    Dgv.ClearSelection();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void TxtID_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void TxtNombre_TextChanged(object sender, EventArgs e)
        {
        
        }

        private void TxtRFC_TextChanged(object sender, EventArgs e)
        {
        
        }

        private void MkdTelefono_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            
        }

        private void TxtPaginaWeb_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void Txtbuscar_KeyUp(object sender, KeyEventArgs e)
        {
            
        }

        private void BtnNuevoTelefono_Click(object sender, EventArgs e)
        {
            MkdTelefono.Clear();
            MkdTelefono.Focus();
        }

        private void BtnNuevoRFC_Click(object sender, EventArgs e)
        {
            TxtRFC.Clear();
            TxtRFC.Focus();
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
            if ((e.KeyChar >= 32 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo letras ", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Handled = true;
                return;
            }
        }

        private void TxtRFC_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32) && (e.KeyChar <= 47) || (e.KeyChar >= 58) && (e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo numeros y letras", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Handled = true;
                return;
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
    }
}
