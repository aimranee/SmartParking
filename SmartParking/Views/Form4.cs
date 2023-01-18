using SmartParking.Controllers;
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

namespace SmartParking.Views
{
    public partial class Form4 : Form
    {
        private string labelCode;
        private readonly ParkingVelo _prunt;
        private readonly ParkingAuto _prunt1;
        private readonly ParkingMoto _prunt2;
        private readonly ParkingCamion _prunt3;
        private string matricule;
        private string model;
        private string fullname;
        private string cin;

        public Form4(ParkingVelo prunt)
        {
            InitializeComponent();
            _prunt = prunt;
        }
        public Form4(ParkingAuto prunt)
        {
            InitializeComponent();
            _prunt1 = prunt;
        }
        public Form4(ParkingMoto prunt)
        {
            InitializeComponent();
            _prunt2 = prunt;
        }
        public Form4(ParkingCamion prunt)
        {
            InitializeComponent();
            _prunt3 = prunt;
        }


        public string LabelCode { get => labelCode; set => labelCode = value; }
        public string Matricule { get => matricule; set => matricule = value; }
        public string Model { get => model; set => model = value; }
        public string Fullname { get => fullname; set => fullname = value; }
        public string Cin { get => cin; set => cin = value; }

        private void button1_Click(object sender, EventArgs e)
        {
            matricule = matricBox.Text.Trim();
            model = textBox2.Text.Trim();
            fullname = textBox5.Text.Trim();
            cin = textBox4.Text.Trim();
            DialogResult = DialogResult.OK;
            Hide();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            label1.Text = labelCode;

            labelDate.Text = DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss");
            if (labelCode.Contains("A"))
            {
                labelCost.Text = "2.00";
            }
            if (labelCode.Contains("C"))
            {
                labelCost.Text = "5.00";
            }
            if (labelCode.Contains("V"))
            {
                labelCost.Text = "1.00";
            }
            if (labelCode.Contains("M"))
            {
                labelCost.Text = "3.00";
            }
        }
    }
}
