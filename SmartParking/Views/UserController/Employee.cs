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

namespace SmartParking.Views.UserController
{
    public partial class Employee : UserControl
    {
        public Employee()
        {
            InitializeComponent();
        }

        public void Dispaly()
        {
            UserControlle.DisplayAndSearch("SELECT id, role, username, password, nom, prenom, cin FROM user;", dataGridView);
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                /*formOuvrage.Clear();
                formOuvrage.idO = dataGridView.Rows[e.RowIndex].Cells[3].Value.ToString()!;
                formOuvrage.idC = dataGridView.Rows[e.RowIndex].Cells[2].Value.ToString()!;
                formOuvrage.dateD = DateTime.Parse(dataGridView.Rows[e.RowIndex].Cells[4].Value.ToString()!);
                formOuvrage.dateF = DateTime.Parse(dataGridView.Rows[e.RowIndex].Cells[5].Value.ToString()!);
                formOuvrage.UpdateEmprunt();
                formOuvrage.ShowDialog();*/

                return;
            }
            if (e.ColumnIndex == 1)
            {
                if (MessageBox.Show("Souhaitez-vous supprimer l'emprunt ?", "Information", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    //stock = Int16.Parse(dataGridView.Rows[e.RowIndex].Cells[6].Value.ToString()!)+1;
                    //OuvrageController.UpdateStock(stock, dataGridView.Rows[e.RowIndex].Cells[3].Value.ToString()!);
                    UserControlle.SupprimerUser(dataGridView.Rows[e.RowIndex].Cells[0].Value.ToString()!);

                }

                return;
            }
        }
    }
}
