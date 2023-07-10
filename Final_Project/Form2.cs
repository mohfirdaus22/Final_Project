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
    }
}
