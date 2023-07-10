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
    public partial class Form5 : Form
    {
        private string stringConnection = "data source=Jorengezzz\\THEPASHTER;" + "database=Restaurant_K1;User ID=sa;password=Salahtompo22";
        private SqlConnection koneksi;
        public Form5()
        {
            InitializeComponent();
            refreshform();
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            koneksi.Open();
            string query = "SELECT Id_koki, Nama, Alamat, No_telp, FROM dbo.Koki";
            SqlDataAdapter da = new SqlDataAdapter(query, koneksi);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            koneksi.Close();
        }

        private void refreshform()
        {
            txtidko.Text = "";
            txtnama.Text = "";
            txtnotelp.Text = "";
            txtalamat.Text = "";
            
            btnClear.Enabled = false;
            btnSave.Enabled = false;
            btnOpen.Enabled = false;
            
        }

        //buat datagrid
        private void dataGridView()
        {
            koneksi.Open();
            string query = "SELECT Id_koki, Nama, Alamat, No_telp, FROM dbo.Koki";
            SqlDataAdapter da = new SqlDataAdapter(query, koneksi);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            koneksi.Close();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            dataGridView();
            btnOpen.Enabled = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            txtidko.Enabled = true;
            txtnama.Enabled = true;
            txtnotelp.Enabled = true;
            txtalamat.Enabled = true;
            btnSave.Enabled = true;
            btnOpen.Enabled = true;
            btnClear.Enabled=true;
           
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string idkoki = txtnama.Text;
            string nama = txtnama.Text;
            string alamat = txtalamat.Text;
            string notelp = txtnotelp.Text;

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
            koneksi.Open();
            string str = "INSERT INTO Koki (Id_koki, Nama, Alamat,No_telp) VALUES (@id_koki, @nama, @alamat, @notelp)";
            SqlCommand cmd = new SqlCommand(str, koneksi);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add(new SqlParameter("@Id_koki", idkoki));
            cmd.Parameters.Add(new SqlParameter("@Alamat",alamat));
            cmd.Parameters.Add(new SqlParameter("@No_telp", notelp));
            cmd.Parameters.Add(new SqlParameter("@Nama", nama));

            cmd.ExecuteNonQuery();

            koneksi.Close();
            MessageBox.Show("Data Berhasil Disimpan", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dataGridView();
            refreshform();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            refreshform();
        }
    }
}
