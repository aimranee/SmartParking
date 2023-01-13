using SmartParking.Controllers;
using SmartParking.Models;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using static System.Windows.Forms.DataFormats;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SmartParking.Views
{
    public partial class Form3 : Form
    {
        Form4 form4;
        private static int nbrPanel = 1;
        Panel myPanel;
        Label myLabel;
        Reservation res;
        private List<Place> placeList;
        Panel b;
        int X = 3, Y = 3;
        List<Panel> panels = new List<Panel>();
        public Form3()
        {
            InitializeComponent();
            form4 = new Form4(this);
        }

        private void initCapt()
        {
            placeList = PlaceControlle.afficher();
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
                myLabel.Text = "" + (nbrPanel);
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
                    myPanel.BackgroundImage = Properties.Resources.icons8_parking_96;
                }
                myPanel.BackgroundImageLayout = ImageLayout.Stretch;
                panel1.Controls.Add(myPanel);
                nbrPanel++;
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            initCapt();
        }

        void b_Click(object sender, EventArgs e)
        {
            b = (Panel)sender;
            if (b != null)
            {
                form4.LabelCode = b.Name;
                if (form4.ShowDialog() == DialogResult.OK)
                {
                    Place pl = placeList.Find(x => x.Code == b.Name);
                    if (pl != null)
                    {
                        res = new Reservation(form4.Matricule, form4.Fullname, form4.Model, "Auto", 2.00, DateTime.Now, form4.Cin, pl);
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


                //button2.Visible = true;
                /*button4.Visible = true;
                pictureBox1.Visible = true;
                nameDevice = b.Name;

                Panel p = panels.Find(r => r.Name == nameDevice);*/

                /*if (p != null)
                    MessageBox.Show(p.Name);
                else
                    MessageBox.Show("null");*/

                /*dev = DeviceController.getStatus(nameDevice);

                if (dev == 0)
                {
                    pictureBox1.Image = Properties.Resources.icons8_off_94;
                    pictureBox1.Name = "off";
                }
                else if (dev == 1)
                {
                    pictureBox1.Image = Properties.Resources.icons8_on_94;
                    pictureBox1.Name = "on";

                }
                else
                {
                    MessageBox.Show("erreur ! \n", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }*/
            }
        }
    }
}
