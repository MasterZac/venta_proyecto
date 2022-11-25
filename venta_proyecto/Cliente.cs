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
    public partial class Cliente : Form
    {
        MySqlConnection cnn = new MySqlConnection();
        MySqlCommand cmd = new MySqlCommand();
        Cargar_Dgv cargar = new Cargar_Dgv();
        MySqlDataAdapter da;
        DataTable dt;
        public string NombreUsuario { get; set; }
        public Cliente()
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
                cmd.CommandText = "SELECT * FROM cliente Where (" + CboBuscarPor.Text + ") Like ('" + Txtbuscar.Text + "%')";
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
            TxtCorreo.Clear();
            MkdCP.Clear();
            TxtCiudad.Clear();
            TxtComuna.Clear();
            TxtCalle.Clear();
            TxtNumero.Clear();
            TxtID.Focus();

        }

        public void ValidarCampos()
        {
            var vr = !string.IsNullOrEmpty(TxtID.Text) &&
                !string.IsNullOrEmpty(TxtNombre.Text) &&
                !string.IsNullOrEmpty(TxtCorreo.Text) &&
                !string.IsNullOrEmpty(MkdCP.Text) &&
                !string.IsNullOrEmpty(TxtCiudad.Text) &&
                !string.IsNullOrEmpty(TxtCalle.Text) &&
                !string.IsNullOrEmpty(TxtNumero.Text);
            BtnAgregar.Enabled = vr;
        }

        private void Cliente_Load(object sender, EventArgs e)
        {
            lblstatus1.Text = String.Format("{0}", NombreUsuario);
            lblstatus2.Text = DateTime.Now.ToString("f");
            cargar.DgvCliente(Dgv);
            BtnAgregar.Enabled = false;
            BtnActualizar.Enabled = false;
            BtnEliminar.Enabled = false;
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Menu x = new Menu();
            x.NombreUsuario = lblstatus1.Text;
            this.Hide();
            x.Show();
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                Conectar();
                cmd = new MySqlCommand("AddCliente", cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                MySqlParameter _id = new MySqlParameter("_id", MySqlDbType.VarChar, 5);
                _id.Value = TxtID.Text;
                cmd.Parameters.Add(_id);

                MySqlParameter _nombre = new MySqlParameter("_nombre", MySqlDbType.VarChar, 80);
                _nombre.Value = TxtNombre.Text;
                cmd.Parameters.Add(_nombre);

                MySqlParameter _correo = new MySqlParameter("_email", MySqlDbType.VarChar, 100);
                _correo.Value = TxtCorreo.Text;
                cmd.Parameters.Add(_correo);

                MySqlParameter _cp = new MySqlParameter("_cp", MySqlDbType.VarChar, 5);
                _cp.Value = MkdCP.Text;
                cmd.Parameters.Add(_cp);

                MySqlParameter _ciudad = new MySqlParameter("_ciudad", MySqlDbType.VarChar, 100);
                _ciudad.Value = TxtCiudad.Text;
                cmd.Parameters.Add(_ciudad);

                MySqlParameter _calle = new MySqlParameter("_calle", MySqlDbType.VarChar, 100);
                _calle.Value = TxtCalle.Text;
                cmd.Parameters.Add(_calle);

                MySqlParameter _numero = new MySqlParameter("_numero", MySqlDbType.Int32);
                _numero.Value = TxtNumero.Text;
                cmd.Parameters.Add(_numero);

                cmd.ExecuteNonQuery();
                cargar.DgvCliente(Dgv);
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
            TxtID.ReadOnly = false;
            BtnEliminar.Enabled = false;
            BtnActualizar.Enabled = false;

        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                Conectar();
                cmd = new MySqlCommand("DeleteCliente", cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                MySqlParameter _id = new MySqlParameter("_id", MySqlDbType.VarChar, 5);
                _id.Value = TxtID.Text;
                cmd.Parameters.Add(_id);

                cmd.ExecuteNonQuery();
                cargar.DgvCliente(Dgv);
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

        private void BtnTelefono_Click(object sender, EventArgs e)
        {
            Telefono_cliente x = new Telefono_cliente();
            x.Show();
        }

        private void TxtID_TextChanged(object sender, EventArgs e)
        {
            ValidarCampos();
        }

        private void TxtNombre_TextChanged(object sender, EventArgs e)
        {
            ValidarCampos();
        }

        private void TxtCorreo_TextChanged(object sender, EventArgs e)
        {
            ValidarCampos();
        }

        private void MkdCP_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            ValidarCampos();
        }

        private void TxtCiudad_TextChanged(object sender, EventArgs e)
        {
            ValidarCampos();
        }

        private void TxtCalle_TextChanged(object sender, EventArgs e)
        {
            ValidarCampos();
        }

        private void TxtNumero_TextChanged(object sender, EventArgs e)
        {
            ValidarCampos();
        }

        private void Dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (Dgv.SelectedRows.Count > 0)
                {
                    TxtID.Text = Dgv.SelectedCells[0].Value.ToString();
                    TxtNombre.Text = Dgv.SelectedCells[1].Value.ToString();
                    TxtCorreo.Text = Dgv.SelectedCells[2].Value.ToString();
                    MkdCP.Text = Dgv.SelectedCells[3].Value.ToString();
                    TxtCiudad.Text = Dgv.SelectedCells[4].Value.ToString();
                    TxtComuna.Text = Dgv.SelectedCells[5].Value.ToString();
                    TxtCalle.Text = Dgv.SelectedCells[6].Value.ToString();
                    TxtNumero.Text = Dgv.SelectedCells[7].Value.ToString();
                    BtnAgregar.Enabled = false;
                    TxtID.ReadOnly = true;
                    BtnActualizar.Enabled = true;
                    BtnEliminar.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Txtbuscar_KeyUp(object sender, KeyEventArgs e)
        {
            Consultas();
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                Conectar();
                cmd = new MySqlCommand("UpdateCliente", cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                MySqlParameter _id = new MySqlParameter("_id", MySqlDbType.VarChar, 5);
                _id.Value = TxtID.Text;
                cmd.Parameters.Add(_id);

                MySqlParameter _nombre = new MySqlParameter("_nombre", MySqlDbType.VarChar, 80);
                _nombre.Value = TxtNombre.Text;
                cmd.Parameters.Add(_nombre);

                MySqlParameter _correo = new MySqlParameter("_email", MySqlDbType.VarChar, 100);
                _correo.Value = TxtCorreo.Text;
                cmd.Parameters.Add(_correo);

                MySqlParameter _cp = new MySqlParameter("_cp", MySqlDbType.VarChar, 5);
                _cp.Value = MkdCP.Text;
                cmd.Parameters.Add(_cp);

                MySqlParameter _ciudad = new MySqlParameter("_ciudad", MySqlDbType.VarChar, 100);
                _ciudad.Value = TxtCiudad.Text;
                cmd.Parameters.Add(_ciudad);

                MySqlParameter _comuna = new MySqlParameter("_comuna", MySqlDbType.VarChar, 100);
                _comuna.Value = TxtComuna.Text;
                cmd.Parameters.Add(_comuna);

                MySqlParameter _calle = new MySqlParameter("_calle", MySqlDbType.VarChar, 100);
                _calle.Value = TxtCalle.Text;
                cmd.Parameters.Add(_calle);

                MySqlParameter _numero = new MySqlParameter("_numero", MySqlDbType.Int32);
                _numero.Value = TxtNumero.Text;
                cmd.Parameters.Add(_numero);

                cmd.ExecuteNonQuery();
                cargar.DgvCliente(Dgv);
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
