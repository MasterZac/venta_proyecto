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
    public partial class Corte_de_caja : Form
    {
        MySqlConnection cnn = new MySqlConnection();
        MySqlCommand cmd = new MySqlCommand();
        Cargar_Dgv cargar = new Cargar_Dgv();
        MySqlDataReader rd;

        public string NombreUsuario;
        public string fecha_inicio;
        public string fecha_corte;
        public int ventas_turno = 0;
        public double totalfacturas = 0;


        public Corte_de_caja()
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

        private void Corte_de_caja_Load(object sender, EventArgs e)
        {
            ConsultarNumCorte();
            lblstatus1.Text = NombreUsuario;
            TxtFecha_cierre.Text = DateTime.Now.ToString("G");
            TxtNombreUsuario.Text = lblstatus1.Text;
            TxtTotal_Ventas.Text = ventas_turno.ToString();
            TxtTotalMonto.Text = totalfacturas.ToString();
        }

        public void ConsultarNumCorte()
        {
            int a;
            try
            {
                Conectar();
                string query = "Select MAX(N°_corte) From corte_caja";
                cmd = new MySqlCommand(query, cnn);
                cmd.CommandType = CommandType.Text;
                rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    string valor = rd[0].ToString();
                    if (valor == "")
                    {
                        TxtNum_corte.Text = "1";
                    }
                    else
                    {
                        a = Convert.ToInt32(rd[0].ToString());
                        a = a + 1;
                        TxtNum_corte.Text = a.ToString();
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

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Ventas x = new Ventas();
            x.NombreUsuario = lblstatus1.Text;
            this.Hide();
            x.Show();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            lblstatus2.Text = DateTime.Now.ToString("F");
        }

        private void BtnCerrarTurno_Click(object sender, EventArgs e)
        {
            DialogResult opcion = MessageBox.Show("Desear continuar con el cierre de turno?","Mensaje",MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (opcion == DialogResult.OK)
            {
                try
                {
                    Conectar();
                    cmd = new MySqlCommand("AddCorte", cnn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Clear();

                    MySqlParameter usuario = new MySqlParameter("usuario", MySqlDbType.VarChar, 50);
                    usuario.Value = TxtNombreUsuario.Text;
                    cmd.Parameters.Add(usuario);

                    MySqlParameter fecha_c = new MySqlParameter("fcorte", MySqlDbType.DateTime);
                    fecha_c.Value = Convert.ToDateTime(TxtFecha_cierre.Text);
                    cmd.Parameters.Add(fecha_c);

                    MySqlParameter ventas = new MySqlParameter("ventas", MySqlDbType.Int32);
                    ventas.Value = TxtTotal_Ventas.Text;
                    cmd.Parameters.Add(ventas);

                    MySqlParameter efectivo = new MySqlParameter("efectivo", MySqlDbType.Double);
                    efectivo.Value = TxtTotalMonto.Text;
                    cmd.Parameters.Add(efectivo);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Corte exitoso");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    Desconectar();
                }

                Menu x = new Menu();
                x.NombreUsuario = lblstatus1.Text;
                this.Hide();
                x.Show();
            }
        }
    }
}
