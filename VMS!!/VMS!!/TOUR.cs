using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VMS__
{
    public partial class TOUR : Form
    {
        public int id { get; set; }
        SqlCommand cmd;
        SqlConnection cn;
        public TOUR()
        {
            InitializeComponent();
        }

        private void TOUR_Load(object sender, EventArgs e)
        {
            cn = new SqlConnection(@"Data Source=MOHANRAJ;Initial Catalog=VMS;Integrated Security=True;Pooling=False");
            cn.Open();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            String imageLocation = null;
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "jpg files(*.jpg)|*.jpg|png files(*.png)|*.png|All files(*.*)|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                imageLocation = dialog.FileName;
                image1.ImageLocation = imageLocation;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            String imageLocation = null;
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "jpg files(*.jpg)|*.jpg|png files(*.png)|*.png|All files(*.*)|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                imageLocation = dialog.FileName;
                image2.ImageLocation = imageLocation;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {

            String imageLocation = null;
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "jpg files(*.jpg)|*.jpg|png files(*.png)|*.png|All files(*.*)|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                imageLocation = dialog.FileName;
                image3.ImageLocation = imageLocation;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            String imageLocation = null;
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "jpg files(*.jpg)|*.jpg|png files(*.png)|*.png|All files(*.*)|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                imageLocation = dialog.FileName;
                image4.ImageLocation = imageLocation;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            String imageLocation = null;
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "jpg files(*.jpg)|*.jpg|png files(*.png)|*.png|All files(*.*)|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                imageLocation = dialog.FileName;
                image5.ImageLocation = imageLocation;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            String imageLocation = null;
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "jpg files(*.jpg)|*.jpg|png files(*.png)|*.png|All files(*.*)|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                imageLocation = dialog.FileName;
                image6.ImageLocation = imageLocation;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            String imageLocation = null;
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "jpg files(*.jpg)|*.jpg|png files(*.png)|*.png|All files(*.*)|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                imageLocation = dialog.FileName;
                image7.ImageLocation = imageLocation;
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            String imageLocation = null;
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "jpg files(*.jpg)|*.jpg|png files(*.png)|*.png|All files(*.*)|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                imageLocation = dialog.FileName;
                image8.ImageLocation = imageLocation;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("insert into document1 values(@id,@pass,@voter,@aadhar,@pan,@licence,@card,@passbook,@medical)", cn);
            cmd.Parameters.AddWithValue("id", id);
            cmd.Parameters.AddWithValue("pass", getPhoto());
            cmd.Parameters.AddWithValue("voter", getPhoto2());
            cmd.Parameters.AddWithValue("aadhar", getPhoto3());
            cmd.Parameters.AddWithValue("pan", getPhoto4());
            cmd.Parameters.AddWithValue("licence", getPhoto5());
            cmd.Parameters.AddWithValue("card", getPhoto6());
            cmd.Parameters.AddWithValue("passbook", getPhoto7());
            cmd.Parameters.AddWithValue("medical", getPhoto8());
            cmd.ExecuteNonQuery();
            MessageBox.Show("Documents Inserted.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            USER u = new USER();
            u.Show();
            this.Close();
        }
        private byte[] getPhoto()
        {
            MemoryStream stream = new MemoryStream();
            image1.Image.Save(stream, image1.Image.RawFormat);
            return stream.GetBuffer();
        }
        private byte[] getPhoto2()
        {
            MemoryStream stream = new MemoryStream();
            image2.Image.Save(stream, image2.Image.RawFormat);
            return stream.GetBuffer();
        }
        private byte[] getPhoto3()
        {
            MemoryStream stream = new MemoryStream();
            image3.Image.Save(stream, image3.Image.RawFormat);
            return stream.GetBuffer();
        }
        private byte[] getPhoto4()
        {
            MemoryStream stream = new MemoryStream();
            image4.Image.Save(stream, image4.Image.RawFormat);
            return stream.GetBuffer();
        }
        private byte[] getPhoto5()
        {
            MemoryStream stream = new MemoryStream();
            image5.Image.Save(stream, image5.Image.RawFormat);
            return stream.GetBuffer();
        }
        private byte[] getPhoto6()
        {
            MemoryStream stream = new MemoryStream();
            image6.Image.Save(stream, image6.Image.RawFormat);
            return stream.GetBuffer();
        }
        private byte[] getPhoto7()
        {
            MemoryStream stream = new MemoryStream();
            image7.Image.Save(stream, image7.Image.RawFormat);
            return stream.GetBuffer();
        }
        private byte[] getPhoto8()
        {
            MemoryStream stream = new MemoryStream();
            image8.Image.Save(stream, image8.Image.RawFormat);
            return stream.GetBuffer();
        }
    }
}
