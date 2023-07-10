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
    public partial class Form3 : Form
    {

        //connection to database
        private string stringConnection = "data source=Jorengezzz\\THEPASHTER;" + "database=Restaurant_K1;User ID=sa;password=Salahtompo22";
        private SqlConnection koneksi;
        public Form3()
        {
            InitializeComponent();
            koneksi = new SqlConnection(stringConnection);
            refreshform();
        }

        //refreshform
        private void refreshform()
        {
            txtidkas.Text = "";
            txtnama.Text = "";
            txtnotelp.Text = "";
            txtemail.Text = "";

            btnClear.Enabled = false;
            btnSave.Enabled = false;
            btnOpen.Enabled = false;

        }

        //buat datagrid
        private void dataGridView()
        {
            koneksi.Open();
            string query = "SELECT Id_kasir, Nama, Email, No_telp FROM dbo.Kasir";
            SqlDataAdapter da = new SqlDataAdapter(query, koneksi);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            koneksi.Close();
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        //button Add
        private void button1_Click(object sender, EventArgs e)
        {
            txtidkas.Enabled = true;
            txtnama.Enabled = true;
            txtnotelp.Enabled = true;
            txtemail.Enabled = true;
            btnSave.Enabled = true;
            btnOpen.Enabled = true;
            btnClear.Enabled = true;

        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            dataGridView();
            btnOpen.Enabled = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string idkas = txtidkas.Text;
            string nama = txtnama.Text;
            string email = txtemail.Text;
            string notelp = txtnotelp.Text;

            if (idkas == "")
            {
                MessageBox.Show("Masukkan Id Kasir", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (nama == "")
            {
                MessageBox.Show("Masukkan Nama", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (notelp == "")
            {
                MessageBox.Show("Masukkan No Telp", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (email == "")
            {
                MessageBox.Show("Masukkan Email", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                koneksi.Open();
                string str = "INSERT INTO Koki (Id_kasir, Nama, Email ,No_telp) VALUES (@id_kasir, @nama, @email, @No_telp)";
                SqlCommand cmd = new SqlCommand(str, koneksi);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SqlParameter("@Id_kasir", idkas));
                cmd.Parameters.Add(new SqlParameter("@Email", email));
                cmd.Parameters.Add(new SqlParameter("@No_telp", notelp));
                cmd.Parameters.Add(new SqlParameter("@Nama", nama));

                cmd.ExecuteNonQuery();

                koneksi.Close();
                MessageBox.Show("Data Berhasil Disimpan", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView();
                refreshform();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            {
                refreshform();
            }
        }
    }
}
