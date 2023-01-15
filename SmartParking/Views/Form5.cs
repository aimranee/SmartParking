using SmartParking.Controllers;
using SmartParking.Models;
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
    public partial class Form5 : Form
    {
        private string labelCode;
        private DateTime dateD;
        private int cost;
        private readonly Form3 _prunt;
        Reservation r;

        public Form5(Form3 prunt)
        {
            InitializeComponent();
            this._prunt = prunt;
        }

        public string LabelCode { get => labelCode; set => labelCode = value; }
        public int Cost { get => cost; set => cost = value; }
        public DateTime DateD { get => dateD; set => dateD = value; }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Hide();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            
            label1.Text = labelCode;
            labelDate.Location = new Point(169, 38); 
            labelDate.Text = DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss");

            labelDateS.Text = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");

            DateTime finTime = DateTime.Now;
            TimeSpan span = dateD.Subtract(finTime);
            
            //nbrHours.Text = span.Days + " Jours, " + span.Hours + " Heurs, " + span.Minutes + " Min, " + span.Seconds + " Sec";
            //labelCost.Text = cost.ToString();
            
            //double dif = (DateTime.Now - dateD).TotalHours;
            //labelTotal.Text = (dif * cost).ToString();

        }
    }
}