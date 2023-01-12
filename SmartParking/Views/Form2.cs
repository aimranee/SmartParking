using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartParking.Views
{
    public partial class Form2 : Form
    {
        string type;
        public Form2()
        {
            InitializeComponent();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            type = "Moto";
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            type = "Camion";
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            type = "Auto";
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            type = "Velo";
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            type = "Handicap";
        }
    }
}
