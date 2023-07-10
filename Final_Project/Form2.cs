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

    public partial class Form2 : Form
    {
        private string stringConnection = "data source=Jorengezzz\\THEPASHTER;" + "database=Restaurant_K1 ;User ID=sa;password=Salahtompo22";
        private SqlConnection koneksi;

        private void refreshform()
        {
            txtidp.Text = "";
            txtnama.Text = "";
            txtnotlp.Text = "";
            txtalamat.Text = "";
            txtemail.Text = "";
            txtidk.Text = "";
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button5.Enabled = false;
        }

        public Form2()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtidp.Enabled = true;
            txtnama.Enabled = true;
            txtnotlp.Enabled = true;
            txtalamat.Enabled = true;
            txtemail.Enabled = true;
            txtidk.Enabled = true;
        }

        //Fungtion datagrid
        private void dataGridView()
        {
            koneksi.Open();
            string query = "SELECT Id_pembeli, Nama, Alamat, No_telp, Email FROM dbo.Pembeli";
            SqlDataAdapter da = new SqlDataAdapter(query, koneksi);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            koneksi.Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            string idpembeli = txtidp.Text;
            string nama = txtnama.Text;
            string notlp = txtnotlp.Text;
            string alamat = txtalamat.Text;
            string email = txtemail.Text;
            string idkasir = txtidk.Text;

            if (idpembeli== "")
            {
                MessageBox.Show("Masukkan Id Pembeli", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (nama== "")
            {
                MessageBox.Show("Masukkan Nama", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (notlp == "")
            {
                MessageBox.Show("Masukkan No Telp", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (alamat == "")
            {
                MessageBox.Show("Masukkan Alamat", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (email == "")
            {
                MessageBox.Show("Masukkan Email", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (idkasir == "")
            {
                MessageBox.Show("Masukkan Id Kasir", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                koneksi.Open();
                string str = "INSERT INTO Pembeli (Id_pembeli, Nama, Alamat, No_telp, Email) VALUES (@Id_pembeli, @Nama, @Alamat, @No_telp, @Email)";
                SqlCommand cmd = new SqlCommand(str, koneksi);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SqlParameter("@Id_pembeli", idpembeli));
                cmd.Parameters.Add(new SqlParameter("@Nama", nama));
                cmd.Parameters.Add(new SqlParameter("@Alamat", alamat));
                cmd.Parameters.Add(new SqlParameter("@No_telp", notlp));
                cmd.Parameters.Add(new SqlParameter("@Email", email));
                cmd.ExecuteNonQuery();

                koneksi.Close();
                MessageBox.Show("Data Berhasil Disimpan", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView();
                refreshform();


            }



        }

        private void button5_Click(object sender, EventArgs e)
        {

        }
    }
}
