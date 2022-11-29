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
    public partial class Categoria : Form
    {
        MySqlConnection cnn = new MySqlConnection();
        MySqlCommand cmd = new MySqlCommand();
        Cargar_Dgv cargar = new Cargar_Dgv();
        MySqlDataReader rd;
        MySqlDataAdapter da;
        DataTable dt;

        public string NombreUsuario { get; set; }
        public string Rol { get; set; }

        public Categoria()
        {
            InitializeComponent();
        }

        private void Categoria_Load(object sender, EventArgs e)
        {
            lblstatus1.Text = string.Format(NombreUsuario);
            lblstatus2.Text = DateTime.Now.ToString("f");
            cargar.DgvCategoria(Dgv);
           
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
            TxtID_categoria.Text = "Automatico";
            TxtNombre.Clear();
            TxtDescripcion.Clear();
            TxtNombre.Focus();
        }

       

        public void Consultas()
        {
            try
            {
                Conectar();

                cmd = cnn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM categoria Where (" + CboBuscar.Text + ") Like ('%" + Txtbuscar.Text + "%')";
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

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            bool existe = false;

            if (TxtID_categoria.Text == "" || TxtNombre.Text == "" || TxtDescripcion.Text == "")
            {
                MessageBox.Show("EXISTEN CAMPOS VACIOS, NO SE PUEDE AGREGAR");
            }
            else
            {

                try
                {
                    Conectar();
                    string query = "Select Nombre From categoria Where Nombre = ('"+ TxtNombre.Text +"');";
                    cmd = new MySqlCommand(query, cnn);
                    cmd.CommandType = CommandType.Text;
                    rd = cmd.ExecuteReader();
                    if (rd.Read())
                    {
                        existe = true;
                        MessageBox.Show("YA EXISTE ESA CATEGORIA");
                        Limpiar();
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
                        cmd = new MySqlCommand("AddCategoria", cnn);
                        cmd.CommandType = CommandType.StoredProcedure;

                        MySqlParameter _nombre = new MySqlParameter("_nombre", MySqlDbType.VarChar, 100);
                        _nombre.Value = TxtNombre.Text.ToUpper().Trim();
                        cmd.Parameters.Add(_nombre);

                        MySqlParameter _Descripcion = new MySqlParameter("_descripcion", MySqlDbType.Text);
                        _Descripcion.Value = TxtDescripcion.Text.Trim();
                        cmd.Parameters.Add(_Descripcion);

                        cmd.ExecuteNonQuery();
                        cargar.DgvCategoria(Dgv);
                        MessageBox.Show("SE HA AGREGADO LA CATEGORIA: " + TxtNombre.Text);
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

            if (TxtID_categoria.Text == "")
            {
                MessageBox.Show("INGRESE LA CLAVE DE LA CATEGORIA PARA PODER ELIMINAR");
            }
            else
            {
                try
                {
                    Conectar();
                    string query = "Select * From categoria Where ID = (" + TxtID_categoria.Text + "); ";
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
                        cmd = new MySqlCommand("DeleteCategoria", cnn);
                        cmd.CommandType = CommandType.StoredProcedure;

                        MySqlParameter _id = new MySqlParameter("_Id", MySqlDbType.Int64);
                        _id.Value = TxtID_categoria.Text;
                        cmd.Parameters.Add(_id);

                        cmd.ExecuteNonQuery();
                        cargar.DgvCategoria(Dgv);
                        MessageBox.Show("SE HA ELIMINADO LA CATEGORIA: " + TxtNombre.Text);
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

            if (TxtID_categoria.Text == "" || TxtNombre.Text == "" || TxtDescripcion.Text == "")
            {
                MessageBox.Show("EXISTEN CAMPOS VACIOS, NO SE PUEDE ACTUALIZAR");
            }
            else
            {
                try
                {
                    Conectar();
                    string query = "Select * From categoria Where Nombre = ('" + TxtNombre.Text + "') " +
                        "And Descripcion = ('"+ TxtDescripcion.Text +"'); ";
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

                if (cambios == true)
                {
                    try
                    {
                        Conectar();
                        cmd = new MySqlCommand("UpdateCategoria", cnn);
                        cmd.CommandType = CommandType.StoredProcedure;

                        MySqlParameter _id = new MySqlParameter("_id", MySqlDbType.Int32);
                        _id.Value = TxtID_categoria.Text;
                        cmd.Parameters.Add(_id);

                        MySqlParameter _nombre = new MySqlParameter("_nombre", MySqlDbType.VarChar, 100);
                        _nombre.Value = TxtNombre.Text;
                        cmd.Parameters.Add(_nombre);

                        MySqlParameter _Descripcion = new MySqlParameter("_descripcion", MySqlDbType.Text);
                        _Descripcion.Value = TxtDescripcion.Text;
                        cmd.Parameters.Add(_Descripcion);

                        cmd.ExecuteNonQuery();
                        cargar.DgvCategoria(Dgv);
                        MessageBox.Show("SE HAN ACTUALIZADO LOS DATOS DE LA CATEGORIA: " + TxtNombre.Text);
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

        private void Dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (Dgv.SelectedRows.Count > 0)
                {
                    
                    TxtID_categoria.Text = Dgv.SelectedCells[0].Value.ToString();
                    TxtNombre.Text = Dgv.SelectedCells[1].Value.ToString();
                    TxtDescripcion.Text = Dgv.SelectedCells[2].Value.ToString();
                    Dgv.ClearSelection();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void Txtbuscar_KeyUp(object sender, KeyEventArgs e)
        {
            Consultas();
        }

        private void TxtID_categoria_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void TxtNombre_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void TxtDescripcion_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Menu x = new Menu();
            x.NombreUsuario = lblstatus1.Text;
            this.Hide();
            x.Show();
        }

        private void BtnLimpiarTxtBuscar_Click(object sender, EventArgs e)
        {
            Txtbuscar.Clear();
            Txtbuscar.Focus();
        }
    }
}
