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
using System.IO;

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

        private Form rbgBar;
        private string imagePath;
        private Bitmap bm = null;
        private BitmapData bmData = null;
        private int scale = 0;
        private int rValue = 0;
        private int gValue = 0;
        private int bValue = 0;

        private void openRBGBar()
        {
            rbgBar = new RGBBar();
            Point position = this.Location;
            position.X = this.Right;
            rbgBar.Location = position;
            rbgBar.Show();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            scale = 0;
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = @"C:\",
                Title = "Browse Image File",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = ".jpg",
                Filter = "Image(*.bmp, *.jpg, *.jpeg) |*.bmp;*.jpg;*.jpeg",
                //FilterIndex = 1,
                RestoreDirectory = true,
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                imagePath = openFileDialog1.FileName;
                bm = new Bitmap(imagePath);
                pictureBox1.Image = bm;

                rValue = 0;
                gValue = 0;
                bValue = 0;
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

        unsafe
        private void setRGB()
        {
            bmData = bm.LockBits(new Rectangle(0, 0, bm.Width, bm.Height), ImageLockMode.ReadWrite, bm.PixelFormat);
            int offset = bmData.Stride - bm.Width * 3;
            byte* p = (byte*)bmData.Scan0;

            // Duyet anh bitmap
            for (int i = 0; i < bm.Width; i++)
            {
                for (int j = 0; j < bm.Height; j++)
                {
                    //p[0] la xanh bien, p[1] la xanh la, p[2] la do
                    p[0] += (byte)((double)p[0] * bValue / 100);
                    p[1] += (byte)((double)p[1] * gValue / 100);
                    p[2] += (byte)((double)p[2] * rValue / 100);

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

        private void btnRGB_Click(object sender, EventArgs e)
        {
            if (bm != null)
            {
                RGBBar rgb = new RGBBar(rValue, gValue, bValue);

                if (rgb.ShowDialog() == DialogResult.OK)
                {
                    bm = new Bitmap(imagePath);
                    pictureBox1.Image = bm;
                    scaleImage(scale);

                    rValue = rgb.getR();
                    gValue = rgb.getG();
                    bValue = rgb.getB();
                    setRGB();
                    //MessageBox.Show("R: " + Convert.ToString(rValue) + ", G: " + Convert.ToString(gValue) + ", B: " + Convert.ToString(bValue));
                }
            }
            else
            {
                MessageBox.Show("You must open an image first!!", "Warning!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDialog = new SaveFileDialog();

            saveDialog.FileName = Path.GetFileNameWithoutExtension(imagePath) + "-1.jpg";
            saveDialog.DefaultExt = "jpg";
            saveDialog.Filter = "JPG images (*.jpg)|*.jpg"; 

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                bm.Save(Path.GetFullPath(saveDialog.FileName), ImageFormat.Jpeg);
                MessageBox.Show("Image has been saved!", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

    }
}
