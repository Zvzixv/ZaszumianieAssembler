using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Threading;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;
using System.Numerics;

namespace JaProjekt
{



    public partial class Form1 : Form
    {
        Bitmap image;
       
        public Form1()
        {
            InitializeComponent();
        }
        //przycisk zaszum
        private void button1_Click(object sender, EventArgs e)
        {
            if (image == null)
            {
                string message = "Not set image!";
                MessageBox.Show(this, message, "No data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            if (radioButtonIsCS.Checked == false && radioButtonIsAsm.Checked == false)
            {
                string message = "Choose your library!";
                MessageBox.Show(this, message, "No data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ImageRustling.ImageRustl(image, trackBar1.Value, radioButtonIsCS.Checked, radioButtonIsAsm.Checked);
            
        }

        //przycisk załaduj
        private void button2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //Get the path of specified file
                string filePath = openFileDialog1.FileName;
                image = (Bitmap)Image.FromFile(filePath);
                pictureBox1.Image = image;
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            this.labelNumberOfThreads.Text = "Ilość wątków: "+ trackBar1.Value;
        }
    }


   
}


