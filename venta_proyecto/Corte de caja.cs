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

        public string NombreUsuario { get; set; }
        public string fecha_inicio;
        public string fecha_corte;
        public int ventas_turno = 0;
        public double totalfacturas = 0;

        public Corte_de_caja()
        {
            InitializeComponent();
        }

        private void Corte_de_caja_Load(object sender, EventArgs e)
        {
            lblstatus1.Text = NombreUsuario.ToString();
            TxtFecha_inicio.Text = fecha_inicio.ToString();
            TxtFecha_cierre.Text = fecha_corte.ToString();
            TxtNombreUsuario.Text = lblstatus1.Text;
            TxtTotal_Ventas.Text = ventas_turno.ToString();
            TxtTotalMonto.Text = totalfacturas.ToString();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Ventas x = new Ventas();
            x.NombreUsuario = lblstatus1.Text;
            x.totalfacturas = Convert.ToDouble(TxtTotalMonto.Text);
            this.Hide();
            x.Show();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            lblstatus2.Text = DateTime.Now.ToString("F");
        }

        private void BtnCerrarTurno_Click(object sender, EventArgs e)
        {
            Menu x = new Menu();
            x.NombreUsuario = lblstatus1.Text;
            this.Hide();
            x.Show();
        }
    }
}
