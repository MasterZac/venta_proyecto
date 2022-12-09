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
    public partial class Ventas : Form
    {
        MySqlConnection cnn = new MySqlConnection();
        MySqlCommand cmd = new MySqlCommand();
        Cargar_Dgv cargar = new Cargar_Dgv();
        MySqlDataReader rd;
        MySqlDataAdapter da;
        DataTable dt;

        public string NombreUsuario { get; set; }

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
            lblstatus1.Text = String.Format("{0}", NombreUsuario);
            ConsultaIDUsuario();
            cargar.DgvProductos(DgvProducto);
            cargar.DgvCliente(DgvClientes);
            ConsultarNumFactura();
        }

        public void Limpiar()
        {
            TxtID_cliente.Clear();
            TxtCliente.Clear();
            TxtSKU.Clear();
            TxtProducto.Clear();
            TxtStock.Clear();
            TxtCantidad.Value = 0;

        }
        public void ConsultaIDUsuario()
        {
            try
            {
                Conectar();
                string query = "Select ID From users Where Usuario = ('" + lblstatus1.Text + "');";
                cmd = new MySqlCommand(query, cnn);
                cmd.CommandType = CommandType.Text;
                rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    ID_usuario.Text = rd[0].ToString();
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
        public void ConsultaProducto()
        {
            try
            {
                Conectar();

                cmd = cnn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM producto Where (" + CboBuscarPorTipoProducto.Text + ") Like ('" + TxtBuscarP.Text + "%')";
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
                cmd.CommandText = "SELECT * FROM cliente Where (" + CmbConsultPorTipoC.Text + ") Like ('%" + TxtBusc.Text + "%')";
                cmd.ExecuteNonQuery();

                dt = new DataTable();
                da = new MySqlDataAdapter(cmd);

                da.Fill(dt);
                DgvClientes.DataSource = dt;

            }
            catch (MySqlException ex)
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
            tabControlProductos.Visible = true;
        }

        private void BtnCerrarPanel2_Click(object sender, EventArgs e)
        {
        }

        private void BtnConsultar_Click(object sender, EventArgs e)
        {
           
        }

        private void BtnCerrarConsultCliente_Click(object sender, EventArgs e)
        {
            tabControlClientes.Visible = false;
        }

        private void BtnConsultar_Click_1(object sender, EventArgs e)
        {
            tabControlClientes.Visible = true;
        }

        private void Txtbuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void TxtBusc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 32 && e.KeyChar <= 255 && CmbConsultPorTipoC.Text == "")
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
                    DgvClientes.ClearSelection();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DgvProducto_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void DgvProducto_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public bool ProductoAgregado()
        {
            
            bool respuesta = false;
            string SKU_p = TxtSKU.Text;
            if (Dgv.Rows.Count > 0)
            {
                foreach (DataGridViewRow fila in Dgv.Rows)
                {
                    if (fila.Cells["SKU_producto"].Value.ToString() == Convert.ToString(SKU_p))
                    {
                        respuesta = true;
                        break;
                    }
                }
            }
            return respuesta;

        }

        private void calcularTotal()
        {
            double total = 0;
            try
            {
                if (Dgv.Rows.Count > 0)
                {
                    foreach (DataGridViewRow row in Dgv.Rows)
                    {
                        total += Convert.ToDouble(row.Cells["Sub_Total"].Value);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            LabelTotal.Text = total.ToString("0.00");
        }

        private void BtnAgregarProducto_Click(object sender, EventArgs e)
        {
          
           if (TxtCantidad.Value > 0)
           {
                if (TxtID_cliente.Text.Trim() == "" && TxtCliente.Text.Trim() == "")
                {
                    MessageBox.Show("Debe escoger el cliente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                if (TxtSKU.Text.Trim() == "")
                {
                    MessageBox.Show("Debe ingresar el codigo de producto", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                if (ProductoAgregado())
                {
                    MessageBox.Show("El producto ya está agregado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                int stock = Convert.ToInt32(TxtStock.Text);

                if (TxtCantidad.Value > stock)
                {
                    MessageBox.Show("Excaso de productos, necesario abastecimiento", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                int cantidad = Convert.ToInt32(TxtCantidad.Value.ToString());
                double precioVenta = Convert.ToDouble(TxtPrecioVenta.Text);
                double SubTotal = cantidad * precioVenta;
                Dgv.Rows.Add(new object[] {TxtNum_factura.Text ,TxtSKU.Text, TxtProducto.Text, TxtCantidad.Value.ToString(), TxtPrecioVenta.Text, SubTotal.ToString() });
                MessageBox.Show("PRODUCTO AGREGADO AL DETALLE_VENTA");
                BtnConsultar.Enabled = false;
                calcularTotal();

                TxtSKU.Clear();
                TxtProducto.Clear();
                TxtStock.Clear();
                TxtPrecioVenta.Clear();
                TxtCantidad.Value = 0;
                BtnConsultaProducto.Focus();
           }
           else
           {
                MessageBox.Show("INGRESE LA CANTIDAD DE QUE LLEVARA DEL PRODUCTO ELEGIDO");
           }

        }

        public void ConsultarStock()
        {
            Conectar();
            string query = "Select Stock From producto Where SKU = ('" + TxtSKU.Text + "');";
            cmd = new MySqlCommand(query, cnn);
            cmd.CommandType = CommandType.Text;
            rd = cmd.ExecuteReader();
            if (rd.Read())
            {
                TxtStock.Text = rd[0].ToString();
            }
            Desconectar();
        }

        private void Editar_Click(object sender, EventArgs e)
        {
            if (Dgv.SelectedRows.Count > 0)
            {
                TxtSKU.Text = Dgv.SelectedCells[1].Value.ToString();
                TxtProducto.Text = Dgv.SelectedCells[2].Value.ToString();
                TxtCantidad.Value = Convert.ToInt64(Dgv.SelectedCells[3].Value.ToString());
                TxtPrecioVenta.Text = Dgv.SelectedCells[4].Value.ToString();

                ConsultarStock();

                foreach (DataGridViewRow rm in Dgv.SelectedRows)
                {
                    Dgv.Rows.Remove(rm);
                }
                TxtCantidad.Focus();
                calcularTotal();
            }
            else
            {
                MessageBox.Show("Eliga un producto de la tabla para poder editar");
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (Dgv.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow rm in Dgv.SelectedRows)
                {
                    Dgv.Rows.Remove(rm);
                }
                calcularTotal();
            }
            else
            {
                MessageBox.Show("Seleccione un producto de la tabla para poder eliminar");
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            if (Dgv.Rows.Count > 0)
            {
                Dgv.Rows.Clear();
                calcularTotal();
                Limpiar();
                BtnConsultar.Enabled = true;
            }
            else
            {
                MessageBox.Show("No hay producto agregados para cancelar las compras");
            }
        }

        private void BtnTerminar_Click(object sender, EventArgs e)
        {
            DialogResult opcion = MessageBox.Show("Desea terminar con la venta", "Mensaje", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (opcion == DialogResult.OK)
            {
                bool venta_exito = false;
                if (Dgv.Rows.Count == 0)
                {
                    MessageBox.Show("Debe ingresar productos", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                //Agregar Venta
                try
                {
                    Conectar();
                    cmd = new MySqlCommand("AddVenta", cnn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    MySqlParameter _fecha = new MySqlParameter("_fecha", MySqlDbType.DateTime);
                    _fecha.Value = Convert.ToDateTime(DateTime.Now.ToString("s"));
                    cmd.Parameters.Add(_fecha);

                    MySqlParameter _id_cliente = new MySqlParameter("_id_cliente", MySqlDbType.VarChar, 5);
                    _id_cliente.Value = TxtID_cliente.Text;
                    cmd.Parameters.Add(_id_cliente);

                    MySqlParameter _id_usuario = new MySqlParameter("_id_usuario", MySqlDbType.VarChar, 5);
                    _id_usuario.Value = ID_usuario.Text;
                    cmd.Parameters.Add(_id_usuario);

                    MySqlParameter _monto_final = new MySqlParameter("_monto_final", MySqlDbType.Double);
                    _monto_final.Value = Convert.ToDouble(LabelTotal.Text);
                    cmd.Parameters.Add(_monto_final);
                    cmd.ExecuteNonQuery();
                    venta_exito = true;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    Desconectar();
                }

                //Agregar Detalle_venta
                if (venta_exito == true)
                {
                    try
                    {
                        Conectar();
                        cmd = new MySqlCommand("AddDetalle_venta", cnn);
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Con el foreach recorro todos los datos de las columnas del datagridview y mando a mi base de datos
                        foreach (DataGridViewRow row in Dgv.Rows)
                        {
                            cmd.Parameters.Clear();
                            cmd.Parameters.Add("_numero_factura", MySqlDbType.Int32).Value = Convert.ToString(row.Cells["Num_factura"].Value);
                            cmd.Parameters.Add("_sku_producto", MySqlDbType.VarChar, 5).Value = Convert.ToString(row.Cells["SKU_producto"].Value);
                            cmd.Parameters.Add("_nombre_producto", MySqlDbType.VarChar, 100).Value = Convert.ToString(row.Cells["Nombre_producto"].Value);
                            cmd.Parameters.Add("_cantidad", MySqlDbType.Int32).Value = Convert.ToString(row.Cells["Cantidad_venta"].Value);
                            cmd.Parameters.Add("_precio", MySqlDbType.Double).Value = Convert.ToString(row.Cells["Precio_venta"].Value);
                            cmd.ExecuteNonQuery();
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

                    Dgv.Rows.Clear();
                    Limpiar();
                    MessageBox.Show("VENTA EXITOSA");
                    BtnConsultar.Enabled = true;
                    ConsultarNumFactura();
                    calcularTotal();

                }
            }
        }

        public void ConsultarNumFactura()
        {
            int a;
            try
            {
                Conectar();
                string query = "Select MAX(Numero_factura) From venta";
                cmd = new MySqlCommand(query, cnn);
                cmd.CommandType = CommandType.Text;
                rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    string valor = rd[0].ToString();
                    if (valor == "")
                    {
                        TxtNum_factura.Text = "1";
                    }
                    else
                    {
                        a = Convert.ToInt32(rd[0].ToString());
                        a = a + 1;
                        TxtNum_factura.Text = a.ToString();
                    }
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

        private void timer_Tick(object sender, EventArgs e)
        {
            lblstatus2.Text = DateTime.Now.ToString("F");
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            DialogResult boton = MessageBox.Show("Realmente desea salir?", "Mensaje", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (boton == DialogResult.OK)
            {
                Menu x = new Menu();
                x.NombreUsuario = lblstatus1.Text;
                this.Hide();
                x.Show();
            }
        }

        private void TxtBuscarP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 32 && e.KeyChar <= 255 && CboBuscarPorTipoProducto.Text == "")
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

        private void BtnLimpiarBuscP_Click(object sender, EventArgs e)
        {
            TxtBuscarP.Clear();
            cargar.DgvProductos(DgvProducto);
        }

        private void BtnCerrartapControlP_Click(object sender, EventArgs e)
        {
            tabControlProductos.Visible = false;
        }

        private void DgvProducto_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (DgvProducto.SelectedRows.Count > 0)
            {
                TxtSKU.Text = DgvProducto.SelectedCells[0].Value.ToString();
                TxtProducto.Text = DgvProducto.SelectedCells[1].Value.ToString();
                TxtStock.Text = DgvProducto.SelectedCells[2].Value.ToString();
                TxtPrecioVenta.Text = DgvProducto.SelectedCells[3].Value.ToString();
                DgvProducto.ClearSelection();
            }
        }
    }
}
