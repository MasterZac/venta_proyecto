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
    public partial class Almacen : Form
    {
        MySqlConnection cnn = new MySqlConnection();
        MySqlCommand cmd = new MySqlCommand();
        Cargar_Dgv cargar = new Cargar_Dgv();
        MySqlDataReader rd;
        MySqlDataAdapter da;
        DataTable dt;
        public string NombreUsuario { get; set; }

        public Almacen()
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

        private void Almacen_Load(object sender, EventArgs e)
        {
            lblstatus1.Text = string.Format("{0}", NombreUsuario);
            cargar.DgvProductos(Dgv);
            ConsultaComboProveedor();
            ConsultaComboCategoria();
        }

        public void ConsultaIdCategoria()
        {
            try
            {
                Conectar();
                string query = "Select ID From categoria Where Nombre Like ('" + CmbCategoria.Text + "%'); ";
                cmd = new MySqlCommand(query, cnn);
                cmd.CommandType = CommandType.Text;
                rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    LabelCategoria.Text = rd[0].ToString();
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

        public void ConsultaIdProveedor()
        {
            try
            {
                Conectar();
                string query = "Select ID from proveedor Where Nombre Like ('" + CmbProveedor.Text + "%'); ";
                cmd = new MySqlCommand(query, cnn);
                cmd.CommandType = CommandType.Text;
                rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    LabelProveedor.Text = rd[0].ToString();
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

        public void Consultas()
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

        public void ConsultaComboCategoria()
        {
            try
            {
                Conectar();
                string query = "Select Nombre From categoria Where Estatus = 'Activo';";
                cmd = new MySqlCommand(query, cnn);
                cmd.CommandType = CommandType.Text;
                rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    CmbCategoria.Items.Add(rd[0].ToString());
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

        public void ConsultaComboProveedor()
        {
            try
            {
                Conectar();
                string query = "Select Nombre From proveedor Where Estatus = 'Activo'; ";
                cmd = new MySqlCommand(query, cnn);
                cmd.CommandType = CommandType.Text;
                rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    CmbProveedor.Items.Add(rd[0].ToString());
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

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Menu x = new Menu();
            x.NombreUsuario = lblstatus1.Text;
            this.Hide();
            x.Show();
        }

        public void Limpiar()
        {
            TxtSku.Clear();
            TxtNombre.Clear();
            TxtStock.Clear();
            TxtPrecio.Clear();
            TxtPrecioVenta.Clear();
            CmbCategoria.Text = " ";
            CmbProveedor.Text = " ";
            LabelCategoria.Text = "ID";
            LabelProveedor.Text = "ID";
            TxtEstatus.Text = " ";
            TxtSku.Focus();
            TxtSku.ReadOnly = false;
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

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            bool existe = false;

            if (TxtSku.Text == "" || TxtNombre.Text == "" || TxtStock.Text == "" || TxtPrecio.Text == "" || CmbCategoria.Text == "" || CmbProveedor.Text == "")
            {
                MessageBox.Show("EXISTEN CAMPOS VACIOS, NO SE PUEDE AGREGAR");
            }
            else
            {
                try
                {
                    Conectar();
                    string query = "Select * From producto Where SKU = ('" + TxtSku.Text + "') And Nombre = ('" + TxtNombre.Text +"')";
                    cmd = new MySqlCommand(query, cnn);
                    cmd.CommandType = CommandType.Text;
                    rd = cmd.ExecuteReader();
                    if (rd.Read())
                    {
                        existe = true;
                        MessageBox.Show("PRODUCTO YA EXISTENTE");
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
                        cmd = new MySqlCommand("AddProducto", cnn);
                        cmd.CommandType = CommandType.StoredProcedure;

                        MySqlParameter _sku = new MySqlParameter("_sku", MySqlDbType.VarChar, 5);
                        _sku.Value = TxtSku.Text;
                        cmd.Parameters.Add(_sku);

                        MySqlParameter _nombre = new MySqlParameter("_nombre", MySqlDbType.VarChar, 100);
                        _nombre.Value = TxtNombre.Text;
                        cmd.Parameters.Add(_nombre);

                        MySqlParameter _stock = new MySqlParameter("_stock", MySqlDbType.Int32);
                        _stock.Value = TxtStock.Text;
                        cmd.Parameters.Add(_stock);

                        MySqlParameter _precio = new MySqlParameter("_precio", MySqlDbType.Double);
                        _precio.Value = TxtPrecio.Text;
                        cmd.Parameters.Add(_precio);

                        MySqlParameter _precio_venta = new MySqlParameter("_precio_venta", MySqlDbType.Double);
                        _precio_venta.Value = TxtPrecioVenta.Text;
                        cmd.Parameters.Add(_precio_venta);

                        MySqlParameter _id_categoria = new MySqlParameter("_id_categoria", MySqlDbType.Int32);
                        _id_categoria.Value = LabelCategoria.Text;
                        cmd.Parameters.Add(_id_categoria);

                        MySqlParameter _id_proveedor = new MySqlParameter("_id_proveedor", MySqlDbType.VarChar, 5);
                        _id_proveedor.Value = LabelProveedor.Text;
                        cmd.Parameters.Add(_id_proveedor);

                        cmd.ExecuteNonQuery();
                        cargar.DgvProductos(Dgv);
                        MessageBox.Show("SE HA AGREGADO EL PRODUCTO: " + TxtNombre.Text);
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

            if (TxtSku.Text == "") // Si la caja de texto de la clave PK esta vacia
            {
                MessageBox.Show("INGRESA LA CLAVE PARA DESHABILITAR EL PRODUCTO"); //imprimo que no se puede eliminar
            }
            else
            {
                try
                {
                    Conectar();
                    
                    string query = "Select * From producto Where SKU = ('" + TxtSku.Text + "'); "; 
                    cmd = new MySqlCommand(query, cnn);
                    cmd.CommandType = CommandType.Text;
                    rd = cmd.ExecuteReader();
                    if (rd.Read()) 
                    {
                        existe = true;//Si me regrese el valor la consuta siginfica que si existe
                    }
                    else
                    {
                        existe = false;
                        MessageBox.Show("NO EXISTE ESE PRODUCTO"); 
                        //Si no Imprimo un mensaje que no existe el producto que quiere eliminar
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

                bool estatus = false;
                if ( existe == true) //Si existe el producto que haga el proceso para eliminar
                {
                    if (TxtEstatus.Text == "Activo")
                    {
                        TxtEstatus.Text = "Inactivo";
                        estatus = true;
                    }
                    else if (TxtEstatus.Text == "Inactivo")
                    {
                        estatus = false;
                        TxtEstatus.Text = "Activo";
                    }

                    try
                    {
                        Conectar();
                        cmd = new MySqlCommand("DeleteProducto", cnn);
                        cmd.CommandType = CommandType.StoredProcedure;

                        MySqlParameter _sku = new MySqlParameter("_sku", MySqlDbType.VarChar, 5);
                        _sku.Value = TxtSku.Text;
                        cmd.Parameters.Add(_sku);

                        MySqlParameter _estatus = new MySqlParameter("_estatus", MySqlDbType.VarChar, 20);
                        _estatus.Value = TxtEstatus.Text;
                        cmd.Parameters.Add(_estatus);

                        cmd.ExecuteNonQuery();
                        cargar.DgvProductos(Dgv);
                        if (estatus == true)
                            MessageBox.Show("Producto deshabilitado");
                        else
                            MessageBox.Show("Producto habilitado");
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

            if (TxtSku.Text == "" || TxtNombre.Text == "" || TxtStock.Text == "" || TxtPrecio.Text == "" || CmbCategoria.Text == "" || CmbProveedor.Text == "")
            {
                MessageBox.Show("EXISTEN CAMPOS VACIOS, NO SE PUEDE ACTUALIZAR");
            }
            else
            {
                try
                {
                    Conectar();
                    string query = "Select * From producto Where SKU = ('" + TxtSku.Text + "') " +
                        "And Nombre = ('" + TxtNombre.Text + "') And Stock = (" + TxtStock.Text + ") " +
                        "And Precio = (" + TxtPrecio.Text + ") And Precio_Venta = ('"+TxtPrecioVenta.Text+"')" +
                        "And ID_categoria = (" + LabelCategoria.Text + ") " +
                        "And ID_proveedor  = ('" + LabelProveedor.Text + "'); ";
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
                        cmd = new MySqlCommand("UpdateProducto", cnn);
                        cmd.CommandType = CommandType.StoredProcedure;

                        MySqlParameter _sku = new MySqlParameter("_sku", MySqlDbType.VarChar, 5);
                        _sku.Value = TxtSku.Text;
                        cmd.Parameters.Add(_sku);

                        MySqlParameter _nombre = new MySqlParameter("_nombre", MySqlDbType.VarChar, 100);
                        _nombre.Value = TxtNombre.Text;
                        cmd.Parameters.Add(_nombre);

                        MySqlParameter _stock = new MySqlParameter("_stock", MySqlDbType.Int32);
                        _stock.Value = TxtStock.Text;
                        cmd.Parameters.Add(_stock);

                        MySqlParameter _precio = new MySqlParameter("_precio", MySqlDbType.Double);
                        _precio.Value = TxtPrecio.Text;
                        cmd.Parameters.Add(_precio);

                        MySqlParameter _precio_venta = new MySqlParameter("_precio_venta", MySqlDbType.Double);
                        _precio_venta.Value = TxtPrecioVenta.Text;
                        cmd.Parameters.Add(_precio_venta);

                        MySqlParameter _id_categoria = new MySqlParameter("_id_categoria", MySqlDbType.Int32);
                        _id_categoria.Value = int.Parse(LabelCategoria.Text);
                        cmd.Parameters.Add(_id_categoria);

                        MySqlParameter _id_proveedor = new MySqlParameter("_id_proveedor", MySqlDbType.VarChar, 5);
                        _id_proveedor.Value = LabelProveedor.Text;
                        cmd.Parameters.Add(_id_proveedor);

                        cmd.ExecuteNonQuery();
                        cargar.DgvProductos(Dgv);
                        MessageBox.Show("SE HAN ACTUALIZADO LOS DATOS DEL PRODUCTO: " + TxtNombre.Text);
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
        
        private void Dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (Dgv.SelectedRows.Count > 0)
                {
                    TxtSku.Text = Dgv.SelectedCells[0].Value.ToString();
                    TxtNombre.Text = Dgv.SelectedCells[1].Value.ToString();
                    TxtStock.Text = Dgv.SelectedCells[2].Value.ToString();
                    TxtPrecio.Text = Dgv.SelectedCells[3].Value.ToString();
                    TxtPrecioVenta.Text = Dgv.SelectedCells[4].Value.ToString();
                    LabelCategoria.Text = Dgv.SelectedCells[5].Value.ToString();
                    LabelProveedor.Text = Dgv.SelectedCells[6].Value.ToString();
                    TxtEstatus.Text = Dgv.SelectedCells[7].Value.ToString();
                    Dgv.ClearSelection();
                    TxtSku.ReadOnly = true;
                    ConsultaNombreProveedor();
                    ConsultaNombreCategoria();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CmbID_categoria_KeyUp(object sender, KeyEventArgs e)
        {
           
        }

        private void CmbID_proveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void CmbID_proveedor_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (CmbProveedor.SelectedIndex >= 0)
                ConsultaIdProveedor();
            CmbCategoria.Focus();
        }

        private void CmbID_categoria_SelectedIndexChanged(object sender, EventArgs e)
        {

            
        }

        public void ConsultaNombreCategoria()
        {
            try
            {
                Conectar();
                string query = "Select Nombre From categoria Where ID = ('" + LabelCategoria.Text + "'); ";
                cmd = new MySqlCommand(query, cnn);
                cmd.CommandType = CommandType.Text;
                rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    CmbCategoria.Text = rd[0].ToString();
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

        public void ConsultaNombreProveedor()
        {
            try
            {
                Conectar();
                string query = "Select Nombre From proveedor Where ID = ('" + LabelProveedor.Text + "'); ";
                cmd = new MySqlCommand(query, cnn);
                cmd.CommandType = CommandType.Text;
                rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    CmbProveedor.Text = rd[0].ToString();
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

        private void LabelCategoria_TabIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void CmbID_categoria_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (CmbCategoria.SelectedIndex >= 0)
                ConsultaIdCategoria();
            TxtSku.Focus();
        }

        private void CmbID_categoria_DropDownClosed(object sender, EventArgs e)
        {
            
        }

        private void CmbID_categoria_VisibleChanged(object sender, EventArgs e)
        {

        }

        private void CmbID_categoria_SelectedValueChanged(object sender, EventArgs e)
        {
           
        }

        private void TxtSku_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void TxtNombre_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void TxtStock_TextChanged(object sender, EventArgs e)
        {
         
        }

        private void TxtPrecio_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void BtnLimpiarTxtBuscar_Click(object sender, EventArgs e)
        {
            Txtbuscar.Clear();
            cargar.DgvProductos(Dgv);
        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter_1(object sender, EventArgs e)
        {

        }

        private void TxtStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32) && (e.KeyChar <= 47) || (e.KeyChar >= 58) && (e.KeyChar <= 255))
            {
                MessageBox.Show("Solo valores numericos!", "aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Handled = true;
                return;
            }
        }

        private void TxtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 33) && (e.KeyChar <= 47) || (e.KeyChar >= 58) && (e.KeyChar <= 64) || (e.KeyChar >= 91) && (e.KeyChar <= 96) || (e.KeyChar >= 123) && (e.KeyChar <= 255))
            {
                MessageBox.Show("Solo letras", "aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Handled = true;
                return;
            }
        }

        private void TxtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32) && (e.KeyChar <= 47) || (e.KeyChar >= 58) && (e.KeyChar <= 255))
            {
                MessageBox.Show("Solo valores numericos!", "aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Handled = true;
                return;
            }
        }

        private void Txtbuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void Txtbuscar_TextChanged(object sender, EventArgs e)
        {
           

        }

        private void timer_Tick(object sender, EventArgs e)
        {
            lblstatus2.Text = DateTime.Now.ToString("F");
        }
    }
}
