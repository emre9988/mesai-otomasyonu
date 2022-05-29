using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Mesai_Uygulaması
{
    
    public partial class girisfrm : Form

    {
        public static int kullaniciid;
        public string isverenid;
        public string calisanid;
        Form4 frm4 = new Form4();
        Form3 forma3 = new Form3();


        SqlConnection con = new SqlConnection("server=Emre-HP; Initial Catalog=MesaiData;Integrated Security=True");

        public girisfrm()
        {
            InitializeComponent();
        }
       

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {
            adminfrm forma2 = new adminfrm();
            girisfrm girisfrm = this;
            girisfrm.Hide();
            forma2.ShowDialog();
            
        }
        private void btnGiris_MouseMove(object sender, MouseEventArgs e)
        {
            btnGiris.BackColor = SystemColors.WindowFrame;
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Lütfen giriş şeklinizi seçiniz.");


            }
            else
            {
                string selectedcmbox = comboBox1.SelectedItem.ToString();


                if (selectedcmbox.ToString() == "ÇALIŞAN")
                {

                    string sorgu = "SELECT * FROM calisangiris where kullaniciadi=@user AND sifre=@pass";
                    SqlCommand cmd;
                    SqlDataReader dr;
                    cmd = new SqlCommand(sorgu, con);
                    cmd.Parameters.AddWithValue("@user", textBox1.Text);
                    cmd.Parameters.AddWithValue("@pass", txtsifre.Text);
                    con.Open();
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {

                        kullaniciid = Convert.ToInt32(dr["calisanid"].ToString());
                       
                        this.Hide();
                        forma3.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Kullanıcı adını ve şifrenizi kontrol ediniz.");
                    }
                    con.Close();
                }
                if (selectedcmbox.ToString() == "İŞVEREN")
                {
                    string sorgu = "SELECT * FROM isverengiris where isverenkullanici=@user AND sifre=@pass";
                    SqlCommand cmd;
                    SqlDataReader dr;
                    cmd = new SqlCommand(sorgu, con);
                    cmd.Parameters.AddWithValue("@user", textBox1.Text);
                    cmd.Parameters.AddWithValue("@pass", txtsifre.Text);
                    con.Open();
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    //diger forma bilgi aktarmaya çalışıyorum
                    {
                        kullaniciid = Convert.ToInt32(dr["isverenid"].ToString());
                      
                        this.Hide();
                        frm4.ShowDialog();
                        
                    }
                    else
                    {
                        MessageBox.Show("Kullanıcı adını ve şifrenizi kontrol ediniz.");
                    }

                    con.Close();
                }
                if (selectedcmbox.ToString() == "ADMIN")
                {

                    string sorgu = "SELECT * FROM admingiris where kullaniciadi=@user AND sifre=@pass";
                    SqlCommand cmd;
                    SqlDataReader dr;
                    cmd = new SqlCommand(sorgu, con);
                    cmd.Parameters.AddWithValue("@user", textBox1.Text);
                    cmd.Parameters.AddWithValue("@pass", txtsifre.Text);
                    con.Open();
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {

                        adminfrm adminform = new adminfrm();
                        adminform.ShowDialog();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Kullanıcı adını ve şifrenizi kontrol ediniz.");
                    }
                    con.Close();
          
        
         
           



                }
            }
            

        }

        private void label7_Click(object sender, EventArgs e)
        {
            Form3 forma3 = new Form3();
            girisfrm girisfrm = this;
            girisfrm.Hide();
            forma3.Show();
        }

        private void girisfrm_Load(object sender, EventArgs e)
        {
            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (txtsifre.PasswordChar.ToString() == "*")
            {
                txtsifre.PasswordChar = char.Parse("\0");
               linkLabel1.Text = "Şifreyi Gizle";
                pictureBox2.Image = Image.FromFile(@"..\..\resim\1.png");
                pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;

            }
            else
            {
                txtsifre.PasswordChar = char.Parse("*");
                linkLabel1.Text = "Şifreyi Göster";
                pictureBox2.Image = Image.FromFile(@"..\..\resim\2.png");
                pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
           
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.instagram.com/emregrlnky/");
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
    
}
