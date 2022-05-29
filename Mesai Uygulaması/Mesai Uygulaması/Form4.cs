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

namespace Mesai_Uygulaması
{
    public partial class Form4 : Form
    {
        SqlConnection con = new SqlConnection("server=Emre-HP; Initial Catalog=MesaiData;Integrated Security=True");

        public string sorgu;
        public int konrol = 0;
        public string calisanidsi;
        public string calisanidsib;


        public Form4()
        {
            InitializeComponent();
        }
        public static int kullaniciadi ;

        private void label1_Click(object sender, EventArgs e)
        {
            Form3 forma3 = new Form3();
            Form4 forma4 = NewMethod();
            forma4.Hide();
            forma3.Show();
        }

        private Form4 NewMethod()
        {
            return this;
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            timer1.Start();
          
           
            
            string kullaniciadsoyad;
            kullaniciadsoyad = girisfrm.kullaniciid.ToString();
            string ekle;
            ekle = "SELECT* FROM işverentablo where isverenid = '" + kullaniciadsoyad + "' ";
            con.Open();
            
            SqlCommand komut = new SqlCommand(ekle, con);
            string ekle2;
            ekle2 = "SELECT* FROM calisantablo ";
            SqlCommand komut2 = new SqlCommand(ekle2, con);
            SqlDataReader oku = komut.ExecuteReader();

            while (oku.Read())
            {
                label9.Text = oku["adisoyadi"].ToString();
               
                kullaniciadsoyad = label9.Text;

            }
            con.Close();
             con.Open();
           SqlDataReader oku2 = komut2.ExecuteReader();

           while (oku2.Read())
           {
               listBox1.Items.Add(oku2["calisanadisoyadi"].ToString());
                comboBox1.Items.Add(oku2["calisanadisoyadi"].ToString());
                comboBox2.Items.Add(oku2["calisanadisoyadi"].ToString());

                kullaniciadsoyad = label9.Text;

           }
           con.Close();
     

            string sorgu = "SELECT * FROM mesaitablo where mesai=@mes";
            SqlCommand cmd;
            SqlDataReader dr;
            cmd = new SqlCommand(sorgu, con);
            cmd.Parameters.AddWithValue("@mes", "acik");
            
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                radioButton1.Select();
                konrol = 1;

            }
            else
            {
                radioButton2.Select();
                konrol = 2;
            }
            con.Close();


        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (konrol == 2)
            {
                string a = "acik";
                string ekle3;
                ekle3 = "update mesaitablo set mesai='" + a + "'";
                con.Open();
                SqlCommand komut3 = new SqlCommand(ekle3, con);
                komut3.ExecuteNonQuery();
                con.Close();
                konrol = 1;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string ekle;
            ekle = "select * from calisantablo where calisanadisoyadi='" + comboBox1.Text + "'";
            con.Open();
            SqlCommand komut = new SqlCommand(ekle, con);
            SqlDataReader dr = komut.ExecuteReader();

            while (dr.Read())
            {
                calisanidsib = dr["calisanid"].ToString();
                
            }
            con.Close();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label13.Text = DateTime.Now.ToLongDateString();
            label14.Text = DateTime.Now.ToLongTimeString();
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            girisfrm forma1 = new girisfrm();
            Hide();
            forma1.Show();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string ekle;
            ekle = "select * from calisantablo where calisanadisoyadi='" + comboBox2.Text + "'";
            con.Open();
            SqlCommand komut = new SqlCommand(ekle, con);
            SqlDataReader dr = komut.ExecuteReader();

            while (dr.Read())
            {
                calisanidsi=dr["calisanid"].ToString();
              
            }
            con.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {//seçtiğimiz çalışanın isminden id sini alarak iki tablodanda silmek istiyorum.
            if (comboBox2.SelectedItem == null)
            {
                MessageBox.Show("Lütfen bir çalışan seçiniz");


            }
            else
            {
                try
                {
                    string ekle;
                    string ekle2;
                    ekle = "delete from calisantablo where calisanid= '" + calisanidsi + "'";
                    con.Open();
                    SqlCommand komut = new SqlCommand(ekle, con);
                    komut.ExecuteNonQuery();
                    con.Close();
                    ekle2 = "delete from calisangiris where calisanid='" + calisanidsi + "'";
                    con.Open();
                    SqlCommand komut2 = new SqlCommand(ekle2, con);
                    komut2.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("kaydınız silinmiştir,kaydın silindiğini görmek için lütfen formu yeniden başlatın.");
                    comboBox2.SelectedItem = null;
                }


                catch
                {
                    MessageBox.Show("bir hata meydana geldi tekrar kontrol ediniz");
                }
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (konrol==1)
                {
                string b = "kapali";

                string ekle4;
                ekle4 = "update mesaitablo set mesai ='" + b + "'";
                con.Open();
                SqlCommand komut4 = new SqlCommand(ekle4, con);
                komut4.ExecuteNonQuery();
                con.Close();
                konrol = 2;
            }
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            string ekle;
            ekle = "update calisantablo set prim=" +textBox1.Text +"  where calisanid='"+ calisanidsib +"'";
            con.Open();
            SqlCommand komut = new SqlCommand(ekle, con);
            komut.ExecuteNonQuery();
            con.Close();
            comboBox1.SelectedItem = null;
            textBox1.Clear();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string ekle;
                ekle = "update mesaitablo set mesaiucret="+ textBox2.Text +"";
                con.Open();
                SqlCommand komut = new SqlCommand(ekle, con);
                komut.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("mesai ücretiniz "+textBox2.Text +" "+"TL ye ayarlandı");
                textBox2.Clear();
            }
            catch
            {
                MessageBox.Show("bir hata meydana geldi lütfen rakam girdiğinizden emin olun ve tekrar deneyin.");
            }
        }
    }
}
