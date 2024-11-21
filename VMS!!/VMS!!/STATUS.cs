using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VMS__
{
    public partial class STATUS : Form
    {
        String l1;
        public String std { get; set; }
        int id;
        SqlCommand cmd;
        SqlConnection cn;
        SqlDataReader dr;
        String status;
        String date;
        String type;
        public STATUS()
        {
            InitializeComponent();
        }

        private void STATUS_Load(object sender, EventArgs e)
        {

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
                type = Convert.ToString(dr.GetValue(11));

            }
            dr.Close();
            cmd = new SqlCommand("select * from status where id='" + id + "'", cn);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                status = Convert.ToString(dr.GetValue(1));

            }
            dr.Close() ;
            cmd = new SqlCommand("select * from date where id='" + id + "'", cn);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                date = Convert.ToString(dr.GetValue(1));

            }
            dr.Close();
            label1.Text = status;
            l1 = status;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            if (l1 == "Upload Documents")
            {
                if (type == "Student")
                {
                    STUDENT s = new STUDENT();
                    s.id = id;
                    s.Show();
                    this.Hide();

                }
                else if (type == "Tourist")
                {
                    TOUR t = new TOUR();t.id = id;
                    t.Show();
                    this.Hide();
                }
                else if (type == "Business")
                {
                    BUSS b = new BUSS();
                    b.id =id;
                    b.Show();
                    this.Hide();
                }
                else if (type == "Employement")
                {
                    EMPLOY em = new EMPLOY();
                    em.id =id;
                    em.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if(l1== "Interview Scheduling")
            {
                MessageBox.Show("Your Interview was scheduled by this date"+date, "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(l1, "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            USER u = new USER();
            u.Show();
            this.Hide();
        }
    }
}
