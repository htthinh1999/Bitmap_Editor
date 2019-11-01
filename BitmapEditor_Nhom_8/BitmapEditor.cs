using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace BitmapEditor_Nhom_8
{
    public partial class BitmapEditor : Form
    {
        public BitmapEditor()
        {
            InitializeComponent();
        }

        private void BitmapEditor_Load(object sender, EventArgs e)
        {

        }

        private String imagePath;
        private Bitmap bm=null;

        private void btnOpen_Click(object sender, EventArgs e)
        {

            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = @"C:\",
                Title = "Browse Text Files",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = ".jpg",
                Filter = "jpg files (*.jpg)|*.jpg",
                FilterIndex = 2,
                RestoreDirectory = true,
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                imagePath = openFileDialog1.FileName;
                bm = new Bitmap(imagePath);
                pictureBox1.Image = bm;
            }
        }

        private void btnOriginal_Click(object sender, EventArgs e)
        {
            if (bm != null)
            {
                bm = new Bitmap(imagePath);
                pictureBox1.Image = bm;
            }
            else
            {
                MessageBox.Show("You must open an image first!!", "Warning!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private BitmapData bmData = null;
        unsafe
        private void btnGray_Click(object sender, EventArgs e)
        {
            if (bm != null)
            {
                bmData = bm.LockBits(new Rectangle(0, 0, bm.Width, bm.Height), ImageLockMode.ReadWrite, bm.PixelFormat);
                int offset = bmData.Stride - bm.Width * 3;
                byte* p = (byte*)bmData.Scan0;

                for (int i = 0; i < bm.Width; i++)
                {
                    for(int j=0; j<bm.Height; j++)
                    {
                        int t = (p[0] + p[1] + p[2]) / 3; //p[0] is blue, p[1] is green, p[2] is red
                        p[0] = (byte)t;
                        p[1] = (byte)t;
                        p[2] = (byte)t;

                        p += 3;
                    }
                    p += offset;
                }

                // Unlock bits
                bm.UnlockBits(bmData);
                pictureBox1.Image = bm;
            }
            else
            {
                MessageBox.Show("You must open an image first!!", "Warning!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnZoomIn_Click(object sender, EventArgs e)
        {
            if (bm != null)
            {

            }
            else
            {
                MessageBox.Show("You must open an image first!!", "Warning!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnZoomOut_Click(object sender, EventArgs e)
        {
            if (bm != null)
            {

            }
            else
            {
                MessageBox.Show("You must open an image first!!", "Warning!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnTurnLeft_Click(object sender, EventArgs e)
        {
            if (bm != null)
            {

            }
            else
            {
                MessageBox.Show("You must open an image first!!", "Warning!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnTurnRight_Click(object sender, EventArgs e)
        {
            if (bm != null)
            {

            }
            else
            {
                MessageBox.Show("You must open an image first!!", "Warning!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

    }
}
