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
    public partial class Proveedor : Form
    {
        MySqlConnection cnn = new MySqlConnection();
        MySqlCommand cmd = new MySqlCommand();
        Cargar_Dgv cargar = new Cargar_Dgv();
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
            try
            {
                Conectar();
                cmd = new MySqlCommand("AddProveedor", cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                MySqlParameter _id = new MySqlParameter("_id", MySqlDbType.VarChar, 5);
                _id.Value = TxtID.Text;
                cmd.Parameters.Add(_id);

                MySqlParameter _nombre = new MySqlParameter("_nombre", MySqlDbType.VarChar, 100);
                _nombre.Value = TxtNombre.Text;
                cmd.Parameters.Add(_nombre);

                MySqlParameter _rfc = new MySqlParameter("_rfc", MySqlDbType.VarChar, 10);
                _rfc.Value = TxtRFC.Text;
                cmd.Parameters.Add(_rfc);

                MySqlParameter _telefono = new MySqlParameter("_telefono", MySqlDbType.VarChar, 10);
                _telefono.Value = MkdTelefono.Text;
                cmd.Parameters.Add(_telefono);

                MySqlParameter _web = new MySqlParameter("_pagina_web", MySqlDbType.Text);
                _web.Value = TxtPaginaWeb.Text;
                cmd.Parameters.Add(_web);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Producto Agregado");
                cargar.DgvProveedor(Dgv);
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

                cmd = new MySqlCommand("DeleteProveedor", cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                MySqlParameter _id = new MySqlParameter("_id", MySqlDbType.VarChar, 5);
                _id.Value = TxtID.Text;
                cmd.Parameters.Add(_id);

                cmd.ExecuteNonQuery();
                cargar.DgvProveedor(Dgv);
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
                cmd = new MySqlCommand("UpdateProveedor", cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                MySqlParameter _id = new MySqlParameter("_id", MySqlDbType.VarChar, 5);
                _id.Value = TxtID.Text;
                cmd.Parameters.Add(_id);

                MySqlParameter _nombre = new MySqlParameter("_nombre", MySqlDbType.VarChar, 50);
                _nombre.Value = TxtNombre.Text;
                cmd.Parameters.Add(_nombre);

                MySqlParameter _rfc = new MySqlParameter("_rfc", MySqlDbType.VarChar, 10);
                _rfc.Value = TxtRFC.Text;
                cmd.Parameters.Add(_rfc);

                MySqlParameter _telefono = new MySqlParameter("_telefono", MySqlDbType.VarChar, 10);
                _telefono.Value = MkdTelefono.Text;
                cmd.Parameters.Add(_telefono);

                MySqlParameter _web = new MySqlParameter("_pagina_web", MySqlDbType.Text);
                _web.Value = TxtPaginaWeb.Text;
                cmd.Parameters.Add(_web);

                cmd.ExecuteNonQuery();
                cargar.DgvProveedor(Dgv);
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
        }

        public void ValidarCampos()
        {
            var vr = !string.IsNullOrEmpty(TxtID.Text) &&
                !string.IsNullOrEmpty(TxtNombre.Text) &&
                !string.IsNullOrEmpty(TxtRFC.Text) &&
                !string.IsNullOrEmpty(MkdTelefono.Text) &&
                !string.IsNullOrEmpty(TxtPaginaWeb.Text);
            BtnAgregar.Enabled = vr;
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

                    BtnAgregar.Enabled = false;
                    TxtID.ReadOnly = true;

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void TxtID_TextChanged(object sender, EventArgs e)
        {
            ValidarCampos();
        }

        private void TxtNombre_TextChanged(object sender, EventArgs e)
        {
            ValidarCampos();
        }

        private void TxtRFC_TextChanged(object sender, EventArgs e)
        {
            ValidarCampos();
        }

        private void MkdTelefono_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            ValidarCampos();
        }

        private void TxtPaginaWeb_TextChanged(object sender, EventArgs e)
        {
            ValidarCampos();
        }

        private void Txtbuscar_KeyUp(object sender, KeyEventArgs e)
        {
            Consultas();
        }
    }
}
