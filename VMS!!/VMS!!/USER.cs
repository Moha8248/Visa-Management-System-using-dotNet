using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VMS__
{
    public partial class USER : Form
    {
        public String stdName { get; set; }
        String std;
        int id;
        SqlCommand cmd;
        SqlConnection cn;
        SqlDataReader dr;
 
        int id1;

        String type;
        public USER()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            std = stdName;
            String username = std;
            cn = new SqlConnection(@"Data Source=MOHANRAJ;Initial Catalog=VMS;Integrated Security=True;Pooling=False");
            cn.Open();
            cmd = new SqlCommand("select * from Login where username='" + username + "'", cn);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                id = Convert.ToInt32(dr.GetValue(0).ToString());

            }
            dr.Close();
            cmd = new SqlCommand("select * from application1 where id='" + id + "'", cn);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                id1 = Convert.ToInt32(dr.GetValue(0));
                type = Convert.ToString(dr.GetValue(11));

            }

            if (id == id1)
            {
                dr.Close();
                MessageBox.Show("Application Already Applied ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                STATUS s=new STATUS();
                s.std = std;
                this.Close();
                s.Show();
            }
            else
            {
                this.Hide();
                APPLICATION a = new APPLICATION();
                a.std = std;
                a.ShowDialog();
            }

           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            LOGIN l=new LOGIN();
            l.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            STATUS s=new STATUS();
            s.std = std;
            s.Show();
            this.Hide();
        }

        private void USER_Load(object sender, EventArgs e)
        {

        }
    }
}
