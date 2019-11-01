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
    public partial class RGBBar : Form
    {
        public RGBBar()
        {
            InitializeComponent();
        }

        public RGBBar(int rValue, int gValue, int bValue)
        {
            InitializeComponent();
            trkBarR.Value = (int)((double)rValue / 100 * 10 + 10);
            lblR.Text = "R: " + Convert.ToString(rValue) + "%";
            trkBarG.Value = (int)((double)gValue / 100 * 10 + 10);
            lblG.Text = "G: " + Convert.ToString(gValue) + "%";
            trkBarB.Value = (int)((double)bValue / 100 * 10 + 10);
            lblB.Text = "B: " + Convert.ToString(bValue) + "%";
        }

        public void setR(int rValue)
        {
            trkBarR.Value = rValue;
        }

        public void setG(int gValue)
        {
            trkBarG.Value = gValue;
        }

        public void setB(int bValue)
        {
            trkBarB.Value = bValue;
        }

        public int getR()
        {
            return (int)((double)(trkBarR.Value - 10) / 10 * 100);
        }

        public int getG()
        {
            return (int)((double)(trkBarG.Value - 10) / 10 * 100);
        }

        public int getB()
        {
            return (int)((double)(trkBarB.Value - 10) / 10 * 100);
        }

        private void trkBarR_Scroll(object sender, EventArgs e)
        {
            lblR.Text = "R: " + Convert.ToString((double)(trkBarR.Value - 10) / 10 * 100) + "%";
        }

        private void trkBarG_Scroll(object sender, EventArgs e)
        {
            lblG.Text = "G: " + Convert.ToString((double)(trkBarG.Value - 10) / 10 * 100) + "%";
        }

        private void trkBarB_Scroll(object sender, EventArgs e)
        {
            lblB.Text = "B: " + Convert.ToString((double)(trkBarB.Value - 10) / 10 * 100) + "%";
        }

    }
}
