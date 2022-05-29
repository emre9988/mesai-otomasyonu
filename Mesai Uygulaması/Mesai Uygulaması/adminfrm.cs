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
using System.Data.Sql;

namespace Mesai_Uygulaması
{


    public partial class adminfrm : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source=Emre-HP;Initial Catalog=MesaiData;Integrated Security=True");
        int calisanid = 1;
        int isverenid = 1;
        public adminfrm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            girisfrm forma1 = new girisfrm();
            Hide();
            forma1.Show();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void adminfrm_Load(object sender, EventArgs e)
        { 
            label1.Visible = false;
            label6.Visible = false;
            
            label1.Text = Convert.ToString(verisay("1"));
            label6.Text ="isveren id "+Convert.ToString(verisay2("1"));
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void btnGiris_MouseMove(object sender, MouseEventArgs e)
        {

            btnGiris.BackColor = SystemColors.WindowFrame;

        }
        string verisay2(string aranan)
        {

            string ekle;
            ekle = "select * from isverengiris";
            baglanti.Open();
            SqlCommand komut = new SqlCommand(ekle, baglanti);
            SqlDataReader oku = komut.ExecuteReader();

            while (oku.Read())
            {
                isverenid += 1;
            }
            baglanti.Close();
            return isverenid.ToString();

        }
        string verisay(string aranan)
        {

            string ekle;
            ekle = "select * from calisangiris";
            baglanti.Open();
            SqlCommand komut = new SqlCommand(ekle, baglanti);
            SqlDataReader oku = komut.ExecuteReader();

            while (oku.Read())
            {
                calisanid += 1;
            }
            baglanti.Close();
            return calisanid.ToString();

        }
        private void btnGiris_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Lütfen kayıt şeklinizi seçiniz.");


            }
            else
            {
                if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" ) MessageBox.Show("Boş geçilemez");
               
            
            else
            {
                string selectedcmbox = comboBox1.SelectedItem.ToString();


                    if (selectedcmbox.ToString() == "ÇALIŞAN")
                    {



                        try
                        {




                            string ekle;
                            string ekle2;

                            ekle = "insert into calisangiris(calisanid,kullaniciadi,sifre) values(@calisanid,@kullaniciadi,@sifre)";
                            baglanti.Open();
                            SqlCommand komut = new SqlCommand(ekle, baglanti);
                            komut.Parameters.AddWithValue("@calisanid", calisanid);
                            komut.Parameters.AddWithValue("@kullaniciadi", textBox1.Text);
                            komut.Parameters.AddWithValue("@sifre", textBox2.Text);
                            komut.ExecuteNonQuery();
                            baglanti.Close();


                            ekle2 = "insert into calisantablo(calisanid,calisanadisoyadi) values (@calisanid,@adsoyad)";
                            baglanti.Open();
                            SqlCommand komut2 = new SqlCommand(ekle2, baglanti);
                            komut2.Parameters.AddWithValue("@calisanid", calisanid);
                            komut2.Parameters.AddWithValue("@adsoyad", textBox3.Text);
                            komut2.ExecuteNonQuery();
                            baglanti.Close();
                            comboBox1.SelectedItem = null;
                        }
                        catch
                    {
                        MessageBox.Show("Kayıt sırasında bir hata oluştu");
                    }


                    MessageBox.Show("kayıt işleminiz tamamlandı.");
                        foreach (Control item in this.Controls)
                        {
                            if (item is TextBox)
                            {
                                TextBox txt = item as TextBox;
                                txt.Clear();
                            }

                        }
                     }
                        
                       
                    
                    if (selectedcmbox.ToString() == "İŞVEREN")
                    {
                        try
                        {
                            string ekle;
                            string ekle2;
                            ekle = "insert into isverengiris(isverenid,isverenkullanici,sifre) values(@isverenid,@kullaniciadi,@sifre)";

                            baglanti.Open();
                            SqlCommand komut = new SqlCommand(ekle, baglanti);
                            komut.Parameters.AddWithValue("@isverenid", isverenid);
                            komut.Parameters.AddWithValue("@kullaniciadi", textBox1.Text);
                            komut.Parameters.AddWithValue("@sifre", textBox2.Text);
                            komut.ExecuteNonQuery();
                            baglanti.Close();

                            ekle2 = "insert into işverentablo(isverenid,adisoyadi) values(@id,@adisoyadi)";
                            baglanti.Open();
                            SqlCommand komut2 = new SqlCommand(ekle2, baglanti);
                            komut2.Parameters.AddWithValue("@id", isverenid);
                            komut2.Parameters.AddWithValue("@adisoyadi", textBox3.Text);
                            komut2.ExecuteNonQuery();
                            baglanti.Close();

                            MessageBox.Show("kayıt işleminiz tamamlandı.");
                            comboBox1.SelectedItem = null;
                            foreach (Control item in this.Controls)
                            {
                                if (item is TextBox)
                                {
                                    TextBox txt = item as TextBox;
                                    txt.Clear();
                                }

                            }
                        }
                        catch
                        {
                            MessageBox.Show("Bir hata meydana geldi tekrar deneyin yada programı tekrar başlatın.");
                        }
                    }

                }
            }
            
        }

        private void label6_Click(object sender, EventArgs e)
        {
            label6.Visible = !label6.Visible;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            label1.Visible = !label1.Visible;
        }

        private void label4_Click(object sender, EventArgs e)
        {
       
        }
    }
}
