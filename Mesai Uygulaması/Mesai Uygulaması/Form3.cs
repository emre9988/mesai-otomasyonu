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
    public partial class Form3 : Form
    {

        SqlConnection con = new SqlConnection("server=Emre-HP; Initial Catalog=MesaiData;Integrated Security=True");
      
        public string sorgu;
        public int kontrol = 0;
        

        public string kullaniciadi;
        
        public Form3()
        {
            InitializeComponent();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Form4 forma4 = NewMethod();
            Form3 forma3 = this;
            forma3.Hide();
            forma4.Show();
        }

        private static Form4 NewMethod()
        {
            return new Form4();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            girisfrm forma1 = NewMethod1();
            Form3 forma3 = this;
            forma3.Hide();
            forma1.Show();

        }

        private static girisfrm NewMethod1()
        {
            return new girisfrm();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            kullaniciadi = girisfrm.kullaniciid.ToString();
        
            string ekle;
            ekle = "SELECT* FROM calisantablo where calisanid = '"+ kullaniciadi +"' ";
            con.Open();
            SqlCommand komut = new SqlCommand(ekle, con);
            SqlDataReader oku = komut.ExecuteReader();

            while (oku.Read())
            {
                label9.Text = oku["calisanadisoyadi"].ToString();
                label11.Text = oku["prim"].ToString()+"TL";           
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
                pictureBox1.Image = Image.FromFile(@"..\..\resim\ok.png");
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
               
                kontrol = 1;
                comboBox1.Enabled = true;
            }
            else
            {
                pictureBox1.Image = Image.FromFile(@"..\..\resim\cancel.png");
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                comboBox1.Enabled = false;
                kontrol = 2;
            }
            con.Close();
            string ekle2;
            ekle2 = "SELECT* FROM mesaigunlertablo where calisanid = '" + kullaniciadi + "' ";
            con.Open();
            SqlCommand komut2 = new SqlCommand(ekle2, con);
            SqlDataReader oku2 = komut2.ExecuteReader();

            while (oku2.Read())
            {
                listBox1.Items.Add(oku2["mesaigunsaat"].ToString());
            }
            con.Close();
            string ekle3;
            ekle3 = "SELECT* FROM mesaitablo ";
            con.Open();
            SqlCommand komut3 = new SqlCommand(ekle3, con);
            SqlDataReader oku3 = komut3.ExecuteReader();

            while (oku3.Read())
            {
                label13.Text = oku3["mesaiucret"].ToString() + "TL";
            }
            con.Close();
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label2.Text = DateTime.Now.ToLongDateString();
            label3.Text = DateTime.Now.ToLongTimeString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            girisfrm forma1 = new girisfrm();
            Hide();
            forma1.Show();
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            if (kontrol == 1)
            { 

                if (comboBox1.SelectedItem == null)
                {
                    MessageBox.Show("boş geçilemez");
                }
                 else
                 { 
                    try
                    {
                        string ekle;
                        string a = label2.Text + " " + comboBox1.Text;
                        ekle = "insert into mesaigunlertablo(calisanid,mesaigunsaat) values(@calisanid,@mesaitarih)";
                        con.Open();
                        SqlCommand komut = new SqlCommand(ekle, con);
                        komut.Parameters.AddWithValue("@calisanid", kullaniciadi);
                        komut.Parameters.AddWithValue("@mesaitarih", a);
                        komut.ExecuteNonQuery();
                        con.Close();

                        MessageBox.Show("mesainiz eklendi");
                        comboBox1.SelectedItem = null;
                    }
                    catch
                    {
                        MessageBox.Show("bir hata meydana geldi");

                    }
                }
            }
           else if  (kontrol==2  )
            {
                MessageBox.Show("mesai açık değildir.Mesai ekleyemezsiniz");
            }
        }
    }
}
