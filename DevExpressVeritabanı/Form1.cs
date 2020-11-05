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

namespace DevExpressVeritabanı
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection baglan = new SqlConnection(@"Data Source=EREN\SQLEXPRESS;Initial Catalog=Kisiler;Integrated Security=True");

        private void VerileriGoster()
        {
            listView1.Items.Clear();
            baglan.Open();
            SqlCommand komut = new SqlCommand("Select *from Rehber", baglan);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["Ad"].ToString();
                ekle.SubItems.Add(oku["Soyad"].ToString());
                ekle.SubItems.Add(oku["Yaş"].ToString());
                ekle.SubItems.Add(oku["Semt"].ToString());
                ekle.SubItems.Add(oku["Meslek"].ToString());

                listView1.Items.Add(ekle);

            }
            baglan.Close();
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            VerileriGoster();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("Insert into Rehber(Ad,Soyad,Yaş,Semt,Meslek) Values('" + textEdit1.Text.ToString() + "','" + textEdit2.Text.ToString() + "','" + textEdit3.Text.ToString() + "','" + textEdit4.Text.ToString() + "','" + textEdit5.Text.ToString() + "')", baglan);
            komut.ExecuteNonQuery();
            baglan.Close();
            VerileriGoster();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            textEdit1.Text = " ";
            textEdit2.Text = " ";
            textEdit3.Text = " ";
            textEdit4.Text = " ";
            textEdit5.Text = " ";
        }

        private void hyperlinkLabelControl1_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            frm.Show();
            this.Hide();
        }
    }
}
