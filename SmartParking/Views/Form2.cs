using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;

namespace SmartParking.Views
{
    public partial class Form2 : Form
    {
        private string type;
        private readonly Form1 _prunt;

        public string Type { get => type; set => type = value; }

        public Form2(Form1 prunt)
        {
            InitializeComponent();
            _prunt = prunt;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            type = "Moto";
            this.DialogResult = DialogResult.OK;
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            type = "Camion";
            this.DialogResult = DialogResult.OK;
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            type = "Auto";
            this.DialogResult = DialogResult.OK;
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            type = "Velo";
            this.DialogResult = DialogResult.OK;
            this.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            type = "Handicap";
            this.DialogResult = DialogResult.OK;
            this.Hide();
        }
    }
}
