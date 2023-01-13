using SmartParking.Controllers;
using SmartParking.Models;
using SmartParking.Views;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace SmartParking
{
    public partial class Form1 : Form
    {
        Form2 form2;
        private static int nbrPanel = 1;
        Panel myPanel;
        Label myLabel;
        private List<Place> placeList;
        Panel b;
        int X = 3, Y = 3;
        List<Panel> panels = new List<Panel>();

        public Form1()
        {
            InitializeComponent();
            form2 = new Form2(this);
        }

        private void initCapt()
        {
            placeList = PlaceControlle.afficher();
            foreach (Place item in placeList)
            {
                myPanel = new Panel();
                myPanel.Name = "" + nbrPanel;
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (form2.ShowDialog() == DialogResult.OK)
            {
                Place p1 = new Place(nbrPanel.ToString(), 1, form2.Type);
                //PlaceControlle.AjouterPlace(p1);
                myPanel = new Panel();
                myPanel.Name = ""+ nbrPanel;
                myPanel.Location = new Point(X, Y);
                if (X < 819)
                {
                    X = X + 102;
                }else{
                    X = 3;
                    Y = Y + 102;
                }
            
                myPanel.Size = new Size(96, 96);
                myPanel.BackColor = Color.Transparent;
                myPanel.BorderStyle = BorderStyle.Fixed3D;
                myPanel.BackgroundImage = Properties.Resources.icons8_parking_96;

                myLabel = new Label();
                myLabel.AutoSize = true;
                myLabel.BackColor = Color.Transparent;
                myLabel.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
                myLabel.ForeColor = Color.White;
                myLabel.Location = new Point(39, 54);
                myLabel.Name = "label1";
                myLabel.Size = new Size(44, 25);
                myLabel.TabIndex = 0;
                myLabel.Text = ""+(nbrPanel);
                myPanel.Controls.Add(myLabel);
                myPanel.Click += b_Click;
                myPanel.BackgroundImageLayout = ImageLayout.Stretch;
                panels.Add(myPanel);
                panel1.Controls.Add(myPanel);
                nbrPanel++;


            }
            else
            {
                MessageBox.Show("test test" + form2.Type);
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Panel p = panels.Find(r => r.Name == b.Name);
            panel1.Controls.Remove(b);
            panels.Remove(p);
            button2.Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            initCapt();
        }

        void b_Click(object sender, EventArgs e)
        {
            b = (Panel)sender;
            if (b != null)
            {
                button2.Visible = true;
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