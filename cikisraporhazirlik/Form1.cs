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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-4NA6IDA\SQLEXPRESS;Initial Catalog=rapordb;Integrated Security=True");
        SqlCommand komut = new SqlCommand();
        DataSet ds = new DataSet();
        
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && richTextBox1.Text != "")
            {

                komut.Connection = baglanti;
                komut.CommandText = "Insert Into rapdb(ilgili,urunkodu,miktar," +
                    "urkod1,urun1,urmitar1," +
                    "urkod2,urun2,urmiktar2," +
                    "urunkod3,urun3,urmiktar3," +
                    "urkod4,urun4,urmiktar4," +
                    "urkod5,urun5,urmiktar5," +
                    "urkod6,urun6,urmiktar6," +
                    "urkod7,urun7,urmiktar7," +
                    "urkod8,urun8,urmiktar8," +
                    "urkod9,urun9,urmiktar9," +
                    "urkod10,urun10,urmiktar10,aciklama) "
                    + "values('" + textBox1.Text + "','" + textBox2.Text.ToString() + "','" 
                    + textBox3.Text.ToString() + "','" 
                    + textBox33.Text.ToString() + "','"
                    + textBox4.Text.ToString() + "','"
                    +textBox23.Text.ToString()+ "','"
                    +textBox32.Text.ToString()+"','"
                    + textBox5.Text.ToString() + "','"
                    +textBox22.Text.ToString()+"','"
                    +textBox31.Text.ToString()+"','"
                    + textBox6.Text.ToString() + "','"
                    +textBox21.Text.ToString()+"','"
                    +textBox30.Text.ToString()+"','"
                    + textBox7.Text.ToString() + "','"
                    +textBox20.Text.ToString()+"','"
                    + textBox29.Text.ToString() + "','"
                    + textBox8.Text.ToString() + "','"
                    + textBox19.Text.ToString() + "','"
                    + textBox28.Text.ToString() + "','"
                    + textBox9.Text.ToString() + "','" 
                    + textBox18.Text.ToString() + "','"
                    + textBox27.Text.ToString() + "','" 
                    + textBox10.Text.ToString() + "','"
                    + textBox17.Text.ToString() + "','"
                    + textBox26.Text.ToString() + "','"
                    + textBox11.Text.ToString() + "','"
                    + textBox16.Text.ToString() + "','"
                    + textBox25.Text.ToString() + "','"
                    + textBox12.Text.ToString() + "','"
                    + textBox15.Text.ToString() + "','"
                    + textBox24.Text.ToString() + "','"
                    + textBox13.Text.ToString() + "','"
                    + textBox14.Text.ToString() + "','"
                    + richTextBox1.Text.ToString() + "')";
                baglanti.Open();
                komut.ExecuteNonQuery();
                komut.Dispose();
                baglanti.Close();
                MessageBox.Show("Kayıt Tamamlandı");
                ds.Clear();
                listele();

            }
            else
            {
                MessageBox.Show("Lütfen Eksik Alan Bırakmayınız");
            }

            void listele()
            {
                baglanti.Open();
                SqlDataAdapter adtr = new SqlDataAdapter("Select * From rapdb", baglanti);
                adtr.Fill(ds, "rapdb");
                dataGridView1.DataSource = ds.Tables["rapdb"];
                adtr.Dispose();
                baglanti.Close();
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2();
            this.Hide();
            frm2.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            baglanti.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("Select * From rapdb", baglanti);
            adtr.Fill(ds, "rapdb");
            dataGridView1.DataSource = ds.Tables["rapdb"];
            adtr.Dispose();
            baglanti.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'rapordbDataSet.rapdb' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.rapdbTableAdapter.Fill(this.rapordbDataSet.rapdb);

        }
    }
}
