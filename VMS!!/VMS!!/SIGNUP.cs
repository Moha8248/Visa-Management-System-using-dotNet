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
    public partial class SIGNUP : Form
    {
        SqlCommand cmd;
        SqlConnection cn;
        SqlDataReader dr;
        public SIGNUP()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            LOGIN login = new LOGIN();
            login.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int id=Convert.ToInt32(label6.Text);
            if (txtconfirmpassword.Text != string.Empty || txtpassword.Text != string.Empty || txtusername.Text != string.Empty)
            {
                if (txtpassword.Text == txtconfirmpassword.Text)
                {
                    cmd = new SqlCommand("select * from Login where username='" + txtusername.Text + "'", cn);
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        dr.Close();
                        MessageBox.Show("Username Already exist please try another ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        dr.Close();
                        cmd = new SqlCommand("insert into Login values(@id,@username,@password,@usertype)", cn);
                        cmd.Parameters.AddWithValue("id",id);
                        cmd.Parameters.AddWithValue("username", txtusername.Text);
                        cmd.Parameters.AddWithValue("password", txtpassword.Text);
                        cmd.Parameters.AddWithValue("usertype", usertype.SelectedItem.ToString());
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Your Account is created . Please login now.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Please enter both password same ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please enter value in all field.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SIGNUP_Load(object sender, EventArgs e)
        {
            usertype.SelectedIndex= 0;
            cn = new SqlConnection(@"Data Source=MOHANRAJ;Initial Catalog=VMS;Integrated Security=True;Pooling=False");
            cn.Open();
            GenerateAutoId();
        }
        private void GenerateAutoId()
        {
            
            cmd = new SqlCommand("Select Count(id)from Login", cn);
            int i = Convert.ToInt32(cmd.ExecuteScalar());
           
            i++;
            label6.Text = i.ToString();

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                txtconfirmpassword.UseSystemPasswordChar = false;
            }
            else
            {
                txtconfirmpassword.UseSystemPasswordChar = true;
            }
        }
    }
}
