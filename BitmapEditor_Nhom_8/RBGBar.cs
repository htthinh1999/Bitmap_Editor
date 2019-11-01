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
    public partial class RBGBar : Form
    {
        public RBGBar()
        {
            InitializeComponent();
        }

        private int getR()
        {
            return (int)((double)(trkBarR.Value - 10) / 10 * 100);
        }

        private int getG()
        {
            return (int)((double)(trkBarG.Value - 10) / 10 * 100);
        }

        private int getB()
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
