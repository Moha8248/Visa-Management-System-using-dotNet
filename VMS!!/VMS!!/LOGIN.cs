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

namespace VMS__
{
    public partial class LOGIN : Form
    {
      
        public LOGIN()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            SIGNUP registration = new SIGNUP();
            registration.ShowDialog();
        }

        private void LOGIN_Load(object sender, EventArgs e)
        {
            usertype.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            APPLICATION a = new APPLICATION();
            String App=uname.Text;
            a.std = App;

            SqlConnection con = new SqlConnection("Data Source=MOHANRAJ;Initial Catalog=VMS;Integrated Security=True;Pooling=False");
            SqlCommand cmd = new SqlCommand("select * from Login where username='" + uname.Text + "' and password='" + pass.Text + "'", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            String item = usertype.SelectedItem.ToString();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["usertype"].ToString() == item)
                    {
                        MessageBox.Show("You are successfully Login as" + dt.Rows[i][2]);
                        if (item=="User")
                        {
                           USER f = new USER();
                            f.stdName=App;
                            f.Show();
                            this.Hide();
                        }
                        else if (item=="Admin")
                        {
                            Admin k = new Admin();
                            k.Show();
                            this.Hide();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Error");
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked==true)
            {
                pass.UseSystemPasswordChar = false;
            }
            else
            {
                pass.UseSystemPasswordChar = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
