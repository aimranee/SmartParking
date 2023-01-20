using SmartParking.Models;
using SmartParking.Views.UserController;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace SmartParking
{
    public partial class Dashboard : Form
    {
        private User user;

        internal User User { get => user; set => user = value; }

        public Dashboard()          
        {
            InitializeComponent();
        }

        private void addUserControl( UserControl userControl)
        {
            userControl.Dock= DockStyle.Fill;
            panelContainer.Controls.Clear();
            panelContainer.Controls.Add(userControl);
            userControl.BringToFront();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Home h = new Home();
            addUserControl(h);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //UC_Home uc = new UC_Home();
            //addUserControl(uc);
            //label2.Text = button6.Text;
        }

        private void Dashboard_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Dashboard_Load(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            ParkingVelo vp = new ParkingVelo();
            addUserControl(vp);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            ParkingMoto pm = new ParkingMoto();
            addUserControl(pm);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            ParkingAuto pa = new ParkingAuto();
            addUserControl(pa);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            ParkingCamion pc = new ParkingCamion();
            addUserControl(pc);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelContainer_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
