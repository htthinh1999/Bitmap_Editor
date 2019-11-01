using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        private Bitmap bm;

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

    }
}
