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
    public partial class Form6 : Form
    {
        private Ticket ticket;
        private readonly Form3 _prunt;

        public Form6(Form3 prunt)
        {
            InitializeComponent();
            this._prunt = prunt;
        }

        internal Ticket Ticket { get => ticket; set => ticket = value; }

        private void Form6_Load(object sender, EventArgs e)
        {
            /*DateTime dateF = ticket.DateEmp;
            labelDate.Text = dateF.ToString("dddd, dd MMMM yyyy HH:mm:ss");

            labelDateS.Text = dateF.ToString("MM/dd/yyyy HH:mm:ss");

            DateTime finTime = dateF;
            TimeSpan span = finTime.Subtract(dateD);

            nbrHours.Text = span.Days + " Jours, " + span.Hours + " Heurs, " + span.Minutes + " Min, " + span.Seconds + " Sec";
            labelCost.Text = cost.ToString();*/

            richBox.Clear();
            richBox.Text += "        Ticket : "+ticket.Id+"   \n";
            richBox.Text += "*********************************\n";
            richBox.Text += "***         Bienvenue         ***\n";
            richBox.Text += "*********************************\n\n\n";
            richBox.Text += " Responsable : "+ticket.IdUser.Nom+" "+ticket.IdUser.Prenom;
            richBox.Text += " Client : "+ ticket.IdRes.Ownername;
            richBox.Text += " Model : "+ ticket.IdRes.Model;
            richBox.Text += " Matricule : "+ ticket.IdRes.Matricule;
            richBox.Text += " Matricule : " + ticket.IdRes.Matricule;

            richBox.Text += " Total : "+ ticket.Total;
        }
    }
}
