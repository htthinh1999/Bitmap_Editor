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
        private Bitmap bm = null;
        private int scale = 0;

        private void btnOpen_Click(object sender, EventArgs e)
        {
            scale = 0;
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = @"C:\",
                Title = "Browse Text Files",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = ".jpg",
                Filter = "All files (*.*)|*.*|jpg files (*.jpg)|*.jpg|jpeg files (*.jpeg)|*.jpeg",
                FilterIndex = 1,
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
                scaleImage(scale);
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

                // Duyet anh bitmap
                for (int i = 0; i < bm.Width; i++)
                {
                    for(int j=0; j<bm.Height; j++)
                    {
                        int t = (p[0] + p[1] + p[2]) / 3; //p[0] la xanh bien, p[1] la xanh la, p[2] la do
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

                // Scale Image
                scaleImage(scale);
            }
            else
            {
                MessageBox.Show("You must open an image first!!", "Warning!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private Size newSize;
        private void scaleImage(int scale)
        {
            if (scale > 0)
                newSize = new Size((int)(bm.Width * scale), (int)(bm.Height * scale));
            if (scale < 0)
                newSize = new Size((int)(bm.Width / Math.Abs(scale)), (int)(bm.Height / Math.Abs(scale)));
            if (scale == 0)
                newSize = new Size(bm.Width, bm.Height);
            Bitmap bmp = new Bitmap(bm, newSize);
            pictureBox1.Image = bmp;
        }

        private void btnZoomIn_Click(object sender, EventArgs e)
        {
            if (bm != null)
            {
                scale += 2;
                scaleImage(scale);
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
                scale -= 2;
                scaleImage(scale);
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
                bm.RotateFlip(RotateFlipType.Rotate270FlipNone);
                pictureBox1.Image = bm;
                scaleImage(scale);
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
                bm.RotateFlip(RotateFlipType.Rotate90FlipNone);
                pictureBox1.Image = bm;
                scaleImage(scale);
            }
            else
            {
                MessageBox.Show("You must open an image first!!", "Warning!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

    }
}
