using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace VMS__
{
    public partial class APPLICATION : Form
    {
        public String std {  get; set; }
        SqlCommand cmd;
        SqlConnection cn;
        SqlDataReader dr;
        String g1;
        String m1;
        int pass2;
        int id;



        public APPLICATION()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            String imageLocation = null;
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "jpg files(*.jpg)|*.jpg|png files(*.png)|*.png|All files(*.*)|*.*";
                if(dialog.ShowDialog()==DialogResult.OK)
                {
                    imageLocation=dialog.FileName;
                    image1.ImageLocation = imageLocation;
                }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            APPLICATION a = new APPLICATION();
            this.Hide();
            a.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pass2 = (int)Convert.ToInt64(textBox2.Text);
            String dob = Convert.ToString(dateTimePicker1.Text);
            String issue=Convert.ToString(dateTimePicker2.Text);
            String expiry=Convert.ToString(dateTimePicker3.Text);

            if(radioButton1.Checked)
            {
                g1 = "Male";
            }
            else if (radioButton2.Checked)
            {
                g1 = "Female";
            }
            else if (radioButton3.Checked)
            {
                g1 = "Others";
            }
            else
            {
                MessageBox.Show("Please Select Gender", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (radioButton4.Checked)
            {
                m1 = "Married";
            }
            else if (radioButton5.Checked)
            {
                m1 = "Unmarried";
            }
            else
            {
                MessageBox.Show("Please Select Marital Status", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
                dr.Close();
                cmd = new SqlCommand("insert into application1 values(@id,@name,@gender,@dob,@nation,@marital,@address,@contact,@passport,@issued,@expiry,@visatype,@visaperiod,@image)", cn);
                cmd.Parameters.AddWithValue("id", id);
                cmd.Parameters.AddWithValue("name", textBox1.Text);
                cmd.Parameters.AddWithValue("gender",g1);
                cmd.Parameters.AddWithValue("dob", dob);
                cmd.Parameters.AddWithValue("nation", textBox3.Text);
                cmd.Parameters.AddWithValue("marital",m1);
                cmd.Parameters.AddWithValue("address",richTextBox1.Text);
                cmd.Parameters.AddWithValue("contact", richTextBox2.Text);
                cmd.Parameters.AddWithValue("passport",pass2);
                cmd.Parameters.AddWithValue("issued",issue);
                cmd.Parameters.AddWithValue("expiry",expiry);
                cmd.Parameters.AddWithValue("visatype", visatype.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("visaperiod",visaperiod.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("image",getPhoto());
                cmd.ExecuteNonQuery();
                MessageBox.Show("Your Application Applied.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);



                cmd = new SqlCommand("insert into status values(@id,@status)", cn);
                String status = "Under Verification";
                cmd.Parameters.AddWithValue("id", id);
                cmd.Parameters.AddWithValue("status",status);
                cmd.ExecuteNonQuery();
                USER a = new USER();
                this.Hide();
                a.Show();
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            USER a = new USER();
            this.Hide();
            a.Show();
        }

        private void APPLICATION_Load(object sender, EventArgs e)
        {
            String username = std;
            cn = new SqlConnection(@"Data Source=MOHANRAJ;Initial Catalog=VMS;Integrated Security=True;Pooling=False");
            cn.Open();
            cmd = new SqlCommand("select * from Login where username='" + username + "'", cn);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                id= Convert.ToInt32(dr.GetValue(0).ToString());
                label14.Text =Convert.ToString( id);
                
            }
            dr.Close();
        }
        private byte[] getPhoto()
        {
            MemoryStream stream= new MemoryStream();
            image1.Image.Save(stream, image1.Image.RawFormat);
            return stream.GetBuffer();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            txtresult.Clear();
            txtresult.Text += "********************************\n";
            txtresult.Text += "******    FEE RECEIPT   ********\n";
            txtresult.Text += "********************************\n";
            txtresult.Text += "Date :"+DateTime.Now+"\n\n";
            txtresult.Text += "ID   :"+label14.Text;
            txtresult.Text += "\n\nNAME :" +textBox1.Text ;
            txtresult.Text += "\n\nPASSPORT NO.:" +textBox2.Text ;
            txtresult.Text += "\n\nVISA TYPE :" + visatype.SelectedItem.ToString();
            txtresult.Text += "\n\nVISA PERIOD :" +visaperiod.SelectedItem.ToString();
            txtresult.Text += "\n\nFEES: \t\t"+"5000\n\n";
            txtresult.Text += "\n                        Signature";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString(txtresult.Text, new Font("Microsoft Sans Serif", 18, FontStyle.Bold), Brushes.Black, new Point(10, 10));

        }
    }
}
