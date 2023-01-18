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
    public partial class AutoSetting : Form
    {
        private static int nbrPanel = 1;
        Panel myPanel;
        Label myLabel;
        private List<Place> placeList;
        Panel b;
        string n = "";
        int X = 3, Y = 3;
        List<Panel> panels = new List<Panel>();

        public AutoSetting()
        {
            InitializeComponent();
        }

        private void panel1_DragDrop(object sender, DragEventArgs e)
        {
            int code = PlaceControlle.getLastId();
            n = "A-" + (code + 1);
            Image getPic = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            Place p1 = new Place(n, 1, "Auto");
            PlaceControlle.AjouterPlace(p1);
            myPanel = new Panel();
            myPanel.Name = n;
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
            myPanel.BackgroundImage = getPic;

            myLabel = new Label();
            myLabel.AutoSize = true;
            myLabel.BackColor = Color.Transparent;
            myLabel.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            myLabel.ForeColor = Color.White;
            myLabel.Location = new Point(39, 54);
            myLabel.Name = "label1";
            myLabel.Size = new Size(44, 25);
            myLabel.TabIndex = 0;
            myLabel.Text = n;
            myPanel.Controls.Add(myLabel);
            myPanel.Click += b_Click;
            myPanel.Cursor = Cursors.Hand;
            myPanel.BackgroundImageLayout = ImageLayout.Stretch;
            panels.Add(myPanel);
            panel1.Controls.Add(myPanel);
            nbrPanel++;
        }

        private void panel1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        void b_Click(object sender, EventArgs e)
        {
            b = (Panel)sender;
            if (b != null)
            {
                pictureBox2.Visible = true;
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            ((PictureBox)sender).DoDragDrop(((PictureBox)sender).Image, DragDropEffects.Copy);
        }

        private void AutoSetting_Load(object sender, EventArgs e)
        {
            getPlaces();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Panel p = panels.Find(r => r.Name == b.Name);
            Place pl = PlaceControlle.FindByCode(b.Name);
            if (pl.Status == 1)
            {
                panel1.Controls.Remove(b);
                panels.Remove(p);
                pictureBox2.Visible = false;
                panel1.Refresh();
                PlaceControlle.SupprimerPlace(pl.Id.ToString());

            }
            else
            {
                MessageBox.Show("Place deja reserer");
            }
        }

        private void getPlaces()
        {
            placeList = PlaceControlle.afficher("Auto");
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
                    myPanel.BackgroundImage = Properties.Resources.icons8_automobile_96;
                }
                myPanel.BackgroundImageLayout = ImageLayout.Stretch;
                panel1.Controls.Add(myPanel);
                nbrPanel++;
            }
        }


    }
}
