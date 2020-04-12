using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace cikisraporhazirlik
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-4NA6IDA\SQLEXPRESS;Initial Catalog=rapordb;Integrated Security=True");
        SqlCommand komut = new SqlCommand();
        DataSet ds = new DataSet();
        DataTable tablo = new DataTable();
        private void Form2_Load(object sender, EventArgs e)
        {
            tablo.Clear();
            SqlDataAdapter adtr = new SqlDataAdapter("Select * From rapdb", baglanti);
            adtr.Fill(tablo);
            CrystalReport1 rapor = new CrystalReport1();
            crystalReportViewer1.ReportSource = rapor;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            tablo.Clear();
            SqlDataAdapter adtr = new SqlDataAdapter("Select * From rapdb Where tesserino='"+ textBox1.Text +"'", baglanti);
            adtr.Fill(tablo);
            CrystalReport1 rapor = new CrystalReport1();
            rapor.SetDataSource(tablo);
            crystalReportViewer1.ReportSource = rapor;
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 frm1 = new Form1();
            this.Hide();
            frm1.Show();
        }
    }
}
