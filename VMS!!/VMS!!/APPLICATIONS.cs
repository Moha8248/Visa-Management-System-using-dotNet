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
    public partial class APPLICATIONS : Form
    {
        SqlCommand cmd; 
        SqlConnection cn;
        

        public APPLICATIONS()
        {
            InitializeComponent();
        }

        private void APPLICATIONS_Load(object sender, EventArgs e)
        {
            cn = new SqlConnection(@"Data Source=MOHANRAJ;Initial Catalog=VMS;Integrated Security=True;Pooling=False");
            cn.Open();
            cmd = new SqlCommand("Select * from application1", cn);
            SqlDataAdapter sd=new SqlDataAdapter(cmd);
            DataTable dt=new DataTable();   
            DataTable dt1=new DataTable();  
            sd.Fill(dt);
            dataGridView1.Rows.Clear();
            dataGridView1.DataSource = dt;
            cn.Close();
            cn.Open();
            cmd = new SqlCommand("Select * from document1", cn);
            SqlDataAdapter sd1 = new SqlDataAdapter(cmd);
            sd1.Fill(dt1);
            dataGridView2.Rows.Clear();
            dataGridView2.DataSource = dt1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String status = comboBox1.SelectedItem.ToString();
            int id = Convert.ToInt32(textBox1.Text);
            if (status == "Interview Scheduling")
            {
                String d = Convert.ToString(dateTimePicker1.Text);
                cmd = new SqlCommand("insert into date values(@id,@date)", cn);
                cmd.Parameters.AddWithValue("id",id);
                cmd.Parameters.AddWithValue("date", d);
                cmd.ExecuteNonQuery();
            }
            cmd = new SqlCommand("update status set status='"+status+"' where id="+id+"", cn);
            cmd.ExecuteNonQuery();
            MessageBox.Show("UPDATED SUCCESSFULLY ", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Admin admin = new Admin();
            admin.Show();
            this.Close();
        }
    }
}
