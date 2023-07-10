using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final_Project
{
    public partial class Form6 : Form
    {
        private string stringConnection = "data source=Jorengezzz\\THEPASHTER;" + "database=Restaurant_K1;User ID=sa;password=Salahtompo22";
        private SqlConnection koneksi;
        public Form6()
        {
            InitializeComponent();
            koneksi = new SqlConnection(stringConnection);
            refreshform();
        }

        private void refreshform()
        {
            txtidsup.Text = "";
            txtnama.Text = "";
            txtnotlp.Text = "";
            txtkotaasal.Text = "";

            btnClear.Enabled = false;
            btnSave.Enabled = false;
            btnOpen.Enabled = false;

        }

        private void dataGridView()
        {
            koneksi.Open();
            string query = "SELECT Id_koki, Nama, Alamat, No_telp FROM dbo.Koki";
            SqlDataAdapter da = new SqlDataAdapter(query, koneksi);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            koneksi.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            txtidsup.Enabled = true;
            txtnama.Enabled = true;
            txtnotlp.Enabled = true;
            txtkotaasal.Enabled = true;
            btnSave.Enabled = true;
            btnOpen.Enabled = true;
            btnClear.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string idkoki = txtidsup.Text;
            string nama = txtnama.Text;
            string alamat = txtkotaasal.Text;
            string notelp = txtnotlp.Text;

            if (idkoki == "")
            {
                MessageBox.Show("Masukkan Id Pembeli", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (nama == "")
            {
                MessageBox.Show("Masukkan Nama", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (notelp == "")
            {
                MessageBox.Show("Masukkan No Telp", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (alamat == "")
            {
                MessageBox.Show("Masukkan Alamat", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                koneksi.Open();
                string str = "INSERT INTO Koki (Id_koki, Nama, Alamat,No_telp) VALUES (@id_koki, @nama, @alamat, @No_telp)";
                SqlCommand cmd = new SqlCommand(str, koneksi);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SqlParameter("@Id_koki", idkoki));
                cmd.Parameters.Add(new SqlParameter("@Alamat", alamat));
                cmd.Parameters.Add(new SqlParameter("@No_telp", notelp));
                cmd.Parameters.Add(new SqlParameter("@Nama", nama));

                cmd.ExecuteNonQuery();

                koneksi.Close();
                MessageBox.Show("Data Berhasil Disimpan", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView();
                refreshform();
            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            dataGridView();
            btnOpen.Enabled = false;
        }
    }
}
