using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VMS__
{
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            APPLICATIONS a=new APPLICATIONS();
            a.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LOGIN n =new LOGIN();
            n.Show();
            this.Close();    
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
