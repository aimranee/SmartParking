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
using static System.Windows.Forms.DataFormats;

namespace SmartParking.Views.UserController
{
    public partial class ParkingMoto : UserControl
    {
        Form4 form4;
        Form5 form5;
        Form6 form6;
        AutoSetting form1;
        private static int nbrPanel = 1;
        Panel myPanel;
        Label myLabel;
        Reservation res;
        Ticket ticket;
        private List<Place> placeList;
        Panel b;
        int X = 3, Y = 3;
        List<Panel> panels = new List<Panel>();

        public ParkingMoto()
        {
            InitializeComponent();
            form4 = new Form4(this);
            form5 = new Form5(this);
            form6 = new Form6(this);
        }

        private void getPlaces()
        {
            placeList = PlaceControlle.afficher("Moto");
            foreach (Place item in placeList)
            {
                myPanel = new Panel();
                myPanel.Name = item.Code;
                myPanel.Location = new Point(X, Y);
                if (X < 819)
                {
                    X = X + 102;
                }
                else
                {
                    X = 3;
                    Y = Y + 102;
                }
                myPanel.Size = new Size(96, 96);
                myPanel.BackColor = Color.Transparent;
                myPanel.BorderStyle = BorderStyle.Fixed3D;

                myLabel = new Label();
                myLabel.AutoSize = true;
                myLabel.BackColor = Color.Transparent;
                myLabel.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
                myLabel.ForeColor = Color.White;
                myLabel.Location = new Point(39, 54);
                myLabel.Name = "label1";
                myLabel.Size = new Size(44, 25);
                myLabel.TabIndex = 0;
                myLabel.Text = item.Code;
                myPanel.Controls.Add(myLabel);
                myPanel.Click += b_Click;
                myPanel.Cursor = Cursors.Hand;
                myPanel.BackgroundImageLayout = ImageLayout.Stretch;
                panels.Add(myPanel);
                panel1.Controls.Add(myPanel);

                if (item.Status == 0)
                {

                    myPanel.BackgroundImage = Properties.Resources.icons8_parking_close;
                }
                else
                {
                    myPanel.BackgroundImage = Properties.Resources.icons8_motorcycle_96;
                }
                myPanel.BackgroundImageLayout = ImageLayout.Stretch;
                panel1.Controls.Add(myPanel);
                nbrPanel++;
            }
        }

        private void ParkingMoto_Load(object sender, EventArgs e)
        {
            getPlaces();

                pictureBox1.Visible = true;
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //form1.Type = "Moto";
            form1.BringToFront();
            form1.ShowDialog();
        }

        void b_Click(object sender, EventArgs e)
        {
            b = (Panel)sender;
            if (b != null)
            {
                Place pl = placeList.Find(x => x.Code == b.Name);

                if (pl.Status == 1)
                {
                    form4.LabelCode = b.Name;
                    if (form4.ShowDialog() == DialogResult.OK)
                    {

                        if (pl != null)
                        {
                            res = new Reservation(form4.Matricule, form4.Fullname, form4.Model, "Velo", "2.00", DateTime.Now, form4.Cin, pl, "en coure");
                            ReservationControlle.AjouterReservation(res);

                            pl.Status = 0;
                            PlaceControlle.UpdatePlace(pl, pl.Id.ToString());

                            b.BackgroundImage = Properties.Resources.icons8_parking_close;
                        }
                        else
                        {
                            MessageBox.Show("introuvable");
                        }

                    }
                }
                else
                {
                    //Place p = PlaceControlle.FindByCode(b.Name);
                    res = ReservationControlle.CurrentRes(pl);

                    form5.LabelCode = b.Name;
                    form5.Matricule = res.Matricule;
                    form5.Model = res.Model;
                    form5.Cin = res.OwenerCin;
                    form5.Fillname = res.Ownername;

                    form5.DateD = res.DateEnreg;
                    if (pl.Type == "Auto")
                        form5.Cost = 3;
                    if (pl.Type == "Velo")
                        form5.Cost = 1;
                    if (pl.Type == "Moto")
                        form5.Cost = 2;
                    if (pl.Type == "Camion")
                        form5.Cost = 5;

                    DialogResult dd = form5.ShowDialog();
                    if (dd == DialogResult.OK)
                    {

                        if (pl != null)
                        {
                            User u = new User(1, "tyui", "rtyu", "ertyuio", "tyui", "rtyu", "ertyuio");
                            ticket = new Ticket(res, u, form5.DateF, form5.Total);

                            pl.Status = 1;
                            PlaceControlle.UpdatePlace(pl, pl.Id.ToString());

                            b.BackgroundImage = Properties.Resources.icons8_parking_96;
                            form6.Ticket = ticket;
                            form6.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("introuvable");
                        }

                    }
                    else if (dd == DialogResult.No)
                    {
                        if (pl != null)
                        {
                            MessageBox.Show(res.Id.ToString());
                            ReservationControlle.SupprimerReservation(res.Id.ToString());

                            pl.Status = 1;
                            PlaceControlle.UpdatePlace(pl, pl.Id.ToString());

                            b.BackgroundImage = Properties.Resources.icons8_parking_96;
                        }
                        else
                        {
                            MessageBox.Show("introuvable");
                        }
                    }
                }

            }
        }

    }
}
