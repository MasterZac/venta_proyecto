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
    public partial class Seccion_de_Consultas : Form
    {
        MySqlConnection cnn = new MySqlConnection();
        MySqlCommand cmd = new MySqlCommand();
        Cargar_Dgv cargar = new Cargar_Dgv();
        MySqlDataAdapter da;
        DataTable dt;

        public string nombreUsuario { get; set; }

        public Seccion_de_Consultas()
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

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            Menu x = new Menu();
            x.NombreUsuario = lblstatus1.Text;
            this.Hide();
            x.Show();
        }

        private void BtnEjecutar_Click(object sender, EventArgs e)
        {
            if (Cbo.SelectedIndex < 0)
            {
                MessageBox.Show("Escoge que consulta quieres ejecutar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                try
                {
                    Conectar();
                    string query = "";
                    switch(Cbo.SelectedIndex)
                    {
                        case 0: query = "SELECT Nombre, Telefono FROM proveedor WHERE Pagina_web = 'www.TecnoEUDIO.web'";
                            break;
                        case 1: query = "SELECT Nombre FROM categoria WHERE Descripcion LIKE '%unidades de estado solido%';";
                            break;
                        case 2: query = "SELECT nombre FROM cliente WHERE Email LIKE '%hotmail%';";
                            break;
                        case 3: query = "SELECT * FROM producto WHERE precio > 5000;";
                            break;
                        case 4: query = "SELECT * FROM producto WHERE Id_categoria IN ('3', '1');";
                            break;
                        case 5: query = "SELECT * FROM producto WHERE Stock < 30;";
                            break;
                        case 6: query = "SELECT Nombre, Precio FROM producto WHERE Id_categoria NOT IN ('1', '2');";
                            break;
                        case 7: query = "SELECT COUNT(ID) AS Total FROM categoria;";
                            break;
                        case 8: query = "SELECT Id_categoria, COUNT(SKU) AS Total FROM producto GROUP BY Id_categoria;";
                            break;
                        case 9: query = "SELECT ID_categoria, MAX(Precio) AS Precio_Maximo, MIN(Precio) AS Precio_Minimo FROM producto GROUP BY ID_categoria; ";
                            break;
                        case 10: query = "SELECT ID_categoria, AVG(precio) AS Promedio_precios FROM producto GROUP BY ID_categoria;";
                            break;
                        case 11: query = "SELECT ID_proveedor, COUNT(SKU) AS Total FROM producto GROUP BY ID_proveedor;";
                            break;
                        case 12: query = "SELECT SUM(Precio) AS Suma_total FROM producto WHERE ID_categoria = '3';";
                            break;
                        case 13: query = "SELECT Ciudad, COUNT(ID) AS Total  FROM cliente GROUP BY Ciudad HAVING Ciudad <> 'Queretaro';";
                            break;
                        case 14: query = "SELECT Comuna, COUNT(ID) AS Total FROM cliente GROUP BY Comuna HAVING Comuna <> 'Fuentes villanueva';";
                            break;
                        case 15: query = "SELECT cliente.Nombre, count(telefono_cliente.telefono) AS Total_Telefonos FROM cliente, telefono_cliente WHERE cliente.ID = telefono_cliente.ID_cliente GROUP BY cliente.Nombre HAVING cliente.Nombre <> 'grupoVentura'; ";
                            break;
                        case 16: query = "SELECT COUNT(producto.ID_categoria) AS Total_productos FROM producto, categoria WHERE producto.ID_categoria = categoria.ID AND categoria.nombre = 'Audio'; ";
                            break;
                        case 17: query = "SELECT producto.Nombre, producto.Precio, proveedor.Telefono, proveedor.Pagina_web FROM producto, proveedor WHERE producto.ID_proveedor = proveedor.ID AND proveedor.Nombre = 'TecnoAUDIO'; ";
                            break;
                        case 18: query = "SELECT producto.Nombre, detalle_venta.Cantidad FROM producto, cliente, venta, detalle_venta WHERE detalle_venta.SKU = producto.SKU AND detalle_venta.Num_factura = venta.Numero_factura AND venta.ID_cliente = cliente.ID AND cliente.Nombre = 'Siemens'; ";
                            break;
                        case 19: query = "SELECT cliente.Nombre, venta.Monto_final FROM cliente, venta WHERE venta.ID_cliente = cliente.ID AND venta.Monto_final < 10000; ";
                            break;
                        case 20: query = "SELECT telefono_cliente.Telefono FROM venta, cliente, telefono_cliente WHERE cliente.ID = telefono_cliente.ID_cliente  AND venta.ID_cliente = cliente.ID AND venta.Monto_final BETWEEN 10000 AND 100000 GROUP BY telefono_cliente.Telefono; ";
                            break;
                        case 21: query = "SELECT producto.nombre, detalle_venta.Precio FROM detalle_venta, producto WHERE detalle_venta.SKU = producto.SKU AND detalle_venta.Num_factura = 5; ";
                            break;
                        case 22: query = "SELECT SUM(detalle_venta.Importe) As Monto_total FROM detalle_venta, producto WHERE detalle_venta.SKU = producto.SKU AND detalle_venta.Num_factura = 5; ";
                            break;
                        case 23: query = "SELECT producto.nombre FROM producto WHERE producto.ID_categoria NOT IN(SELECT ID FROM categoria WHERE Nombre = 'AUDIO'); ";
                            break;
                        case 24: query = "SELECT * FROM producto WHERE producto.ID_categoria IN(SELECT ID FROM categoria WHERE Nombre = 'ALMACENAMIENTO'); ";
                            break;
                        case 25: query = "SELECT SKU, Nombre FROM producto WHERE producto.SKU IN(SELECT detalle_venta.SKU FROM detalle_venta); ";
                            break;
                        case 26: query = "SELECT * FROM producto WHERE producto.SKU NOT IN(SELECT detalle_venta.SKU FROM detalle_venta); ";
                            break;
                        case 27: query = "SELECT producto.Nombre, COUNT(detalle_venta.Cantidad) As Total FROM producto, detalle_venta WHERE producto.SKU = detalle_venta.SKU AND producto.SKU IN(SELECT detalle_venta.SKU FROM detalle_venta WHERE detalle_venta.Num_factura = 5) GROUP BY producto.Nombre;";
                            break;
                        case 28: query = "SELECT producto.Nombre, detalle_venta.Precio, detalle_venta.Cantidad AS Total_vendidos FROM producto, detalle_venta WHERE producto.SKU = detalle_venta.SKU AND detalle_venta.Num_factura IN(SELECT venta.Numero_factura FROM venta WHERE venta.ID_cliente = '43579');";
                            break;
                        case 29: query = "SELECT producto.Nombre, producto.Precio, categoria.ID,categoria.Nombre FROM producto INNER JOIN categoria WHERE producto.ID_categoria = categoria.ID; ";
                            break;
                        case 30: query = "SELECT cliente.Nombre, telefono_cliente.Telefono FROM cliente INNER JOIN telefono_cliente WHERE telefono_cliente.ID_cliente = cliente.ID; ";
                            break;
                    } 
                    cmd = new MySqlCommand(query, cnn);
                    cmd.CommandType = CommandType.Text;
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
        }

        private void Seccion_de_Consultas_Load(object sender, EventArgs e)
        {
            lblstatus1.Text = string.Format("{0}", nombreUsuario);
        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void timer_Tick(object sender, EventArgs e)
        {
            lblstatus2.Text = DateTime.Now.ToString("F");
        }
    }
}
