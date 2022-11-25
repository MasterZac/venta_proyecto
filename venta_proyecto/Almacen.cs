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
            lblstatus2.Text = DateTime.Now.ToString("f");
            cargar.DgvProductos(Dgv);
            BtnAgregar.Enabled = false;
            BtnActualizar.Enabled = false;
            BtnEliminar.Enabled = false;
            ConsultaComboProveedor();
            ConsultaComboCategoria();
        }

        public void ConsultaIdCategoria()
        {
            try
            {
                Conectar();
                string query = "Select ID From categoria Where Nombre = ('" + CmbCategoria.Text + "'); ";
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
                string query = "Select ID from proveedor Where Nombre = ('" + CmbProveedor.Text + "'); ";
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
                string query = "Select Nombre From categoria; ";
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
                string query = "Select Nombre From proveedor; ";
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
            CmbCategoria.Text = " ";
            CmbProveedor.Text = " ";
            LabelCategoria.Text = "Categoria";
            LabelProveedor.Text = "Proveedor";
            TxtSku.Focus();
            TxtSku.ReadOnly = false;
            BtnActualizar.Enabled = false;
            BtnEliminar.Enabled = false;
        }

        private void Txtbuscar_KeyUp(object sender, KeyEventArgs e)
        {
            Consultas();
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
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

                MySqlParameter _id_categoria = new MySqlParameter("_id_categoria", MySqlDbType.Int32);
                _id_categoria.Value = int.Parse(LabelCategoria.Text);
                cmd.Parameters.Add(_id_categoria);

                MySqlParameter _id_proveedor = new MySqlParameter("_id_proveedor", MySqlDbType.VarChar);
                _id_proveedor.Value = LabelProveedor.Text;
                cmd.Parameters.Add(_id_proveedor);

                cmd.ExecuteNonQuery();
                cargar.DgvProductos(Dgv);
                MessageBox.Show("Producto Agregado");
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

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                Conectar();
                cmd = new MySqlCommand("DeleteProducto", cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                MySqlParameter _sku = new MySqlParameter("_sku", MySqlDbType.VarChar);
                _sku.Value = TxtSku.Text;
                cmd.Parameters.Add(_sku);

                cmd.ExecuteNonQuery();
                cargar.DgvProductos(Dgv);
                MessageBox.Show("Producto Eliminado");
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

        private void BtnActualizar_Click(object sender, EventArgs e)
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

                MySqlParameter _id_categoria = new MySqlParameter("_id_categoria", MySqlDbType.Int32);
                _id_categoria.Value = int.Parse(LabelCategoria.Text);
                cmd.Parameters.Add(_id_categoria);

                MySqlParameter _id_proveedor = new MySqlParameter("_id_proveedor", MySqlDbType.VarChar, 5);
                _id_proveedor.Value = LabelProveedor.Text;
                cmd.Parameters.Add(_id_proveedor);

                cmd.ExecuteNonQuery();
                cargar.DgvProductos(Dgv);
                MessageBox.Show("Producto Actualizado");
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

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();

            
        }

        bool validar = false;
        
        private void Dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (Dgv.SelectedRows.Count > 0)
                {
                    validar = true;
                    TxtSku.Text = Dgv.SelectedCells[0].Value.ToString();
                    TxtNombre.Text = Dgv.SelectedCells[1].Value.ToString();
                    TxtStock.Text = Dgv.SelectedCells[2].Value.ToString();
                    TxtPrecio.Text = Dgv.SelectedCells[3].Value.ToString();
                    LabelCategoria.Text = Dgv.SelectedCells[4].Value.ToString();
                    LabelProveedor.Text = Dgv.SelectedCells[5].Value.ToString();
                    BtnActualizar.Enabled = true;
                    BtnEliminar.Enabled = true;
                    TxtSku.ReadOnly = true;
                    ConsultaNombreProveedor();
                    ConsultaNombreCategoria();
                    
                    
                    
                }
                else
                {
                    validar = false;
                }
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CmbID_categoria_KeyUp(object sender, KeyEventArgs e)
        {
            
        }

        private void CmbID_proveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (validar == false)
            {
                ValidarCampos();
            }
        }

        private void CmbID_proveedor_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ConsultaIdProveedor();
            BtnActualizar.Focus();
        }

        private void CmbID_categoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (validar == false)
            {
                ValidarCampos();
            }
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

        public void ValidarCampos()
        {
            var vr = !string.IsNullOrEmpty(TxtSku.Text) &&
                !string.IsNullOrEmpty(TxtNombre.Text) &&
                !string.IsNullOrEmpty(TxtStock.Text) &&
                !string.IsNullOrEmpty(TxtPrecio.Text) &&
                !string.IsNullOrEmpty(CmbCategoria.Text) &&
                !string.IsNullOrEmpty(CmbProveedor.Text);
            BtnAgregar.Enabled = vr;
        }

        private void LabelCategoria_TabIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void CmbID_categoria_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ConsultaIdCategoria();
            CmbProveedor.Focus();
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
            if (validar == false)
            {
                ValidarCampos();
            }
        }

        private void TxtNombre_TextChanged(object sender, EventArgs e)
        {
            if (validar == false)
            {
                ValidarCampos();
            }
        }

        private void TxtStock_TextChanged(object sender, EventArgs e)
        {
            if (validar == false)
            {
                ValidarCampos();
            }
        }

        private void TxtPrecio_TextChanged(object sender, EventArgs e)
        {
            if (validar == false)
            {
                ValidarCampos();
            }
        }

        private void BtnLimpiarTxtBuscar_Click(object sender, EventArgs e)
        {
            Txtbuscar.Clear();
            Txtbuscar.Focus();
        }
    }
}
