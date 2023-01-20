using MySqlConnector;
using ScottPlot.Drawing.Colormaps;
using SmartParking.Controllers;
using SmartParking.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace SmartParking.Views.UserController
{
    public partial class Home : UserControl
    {
        public Home()
        {
            InitializeComponent();
            
            
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        public static MySqlConnection GetConnection()
        {
            string sql = "datasource=localhost;port=3306;username=root;password=;database=smartparking";
            MySqlConnection cnn = new MySqlConnection(sql);

            try
            {
                cnn.Open();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Can not open connection ! \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return cnn;
        }
        /*private void formsPlot1_Load()
        {
            formsPlot1.BackColor = Color.DarkGreen;
           
            int a = RendezVousdb.howMany("select * from animal where categorie='chat'");
            int b = RendezVousdb.howMany("select * from animal where categorie='chien'");
            int c = RendezVousdb.howMany("select * from animal where categorie='oiseau'");
            int d = RendezVousdb.howMany("select * from animal where categorie='Hamster'");
            //double[] values = { 789, 143, 283 };
            double[] values = { a, b, c, d };
            string[] labels = { "Chat", "Chien", "Oiseau", "Hamster" };


            formsPlot1.BackColor = Color.DarkGreen;
            Color[] labelcolors = { Color.White, Color.White, Color.White, Color.White };
            Color[] slicecolors = { Color.Green, Color.MintCream, Color.pink, Color.GreenYellow };
            var pie = formsPlot1.Plot.AddPie(values);
            pie.SliceLabels = labels;
            pie.ShowLabels = true;
            pie.SliceFillColors = slicecolors;
            pie.SliceLabelColors = labelcolors;

            formsPlot1.Refresh();



            /*MySqlConnection cnn = GetConnection();
            MySqlCommand req1 = new MySqlCommand("select count(YEAR(`dateEnreg`)) from reservation ;",cnn);

            MySqlCommand req = new MySqlCommand("select count(*) from reservation  GROUP by year(`dateEnreg`);",cnn);
            Int32 count = Convert.ToInt32(req1.ExecuteScalar());
            double[] X = new double[count] ;
            double[] Y = new double[count];

            string[] labels = new string[count];
            string[] ord = new string[count];

          //  var plt = new ScottPlot.Plot(600, 400);
            MySqlDataReader dr = req.ExecuteReader();
            int i=0;
            while (dr.Read())
            {
                ord[i] = dr.GetString(0);
                i++;
             
            }
            dr.Close();


            MySqlCommand req2 = new MySqlCommand("select YEAR(`dateEnreg`) from reservation  GROUP by year(`dateEnreg`);");
            MySqlDataReader dr2 = req2.ExecuteReader();
            int j = 0;
            while (dr2.Read())
            {
                labels[j] = dr2.GetString(0);
                j++;

            }
            dr2.Close();

            for (i = 0; i < count; i++)
            {
                Y[i] = i;
            }
            for (i = 0; i < count; i++)
            {
                X[i] = Convert.ToInt32(ord[i]);
            }
            formsPlot1.Plot.AddBar(X, Y);
            formsPlot2.Plot.XTicks(Y, labels);
            formsPlot2.Plot.SetAxisLimits(yMin:0);
            formsPlot2.Refresh();

        }*/

        public void chart()
        {

                MySqlConnection conn = new MySqlConnection("Datasource=localhost;database=smartparking;port=3306;username=root;password=");
                conn.Open();
                //MySqlCommand comm = new MySqlCommand("SELECT COUNT(*) FROM reservation", conn);
                MySqlCommand comm = new MySqlCommand("SELECT COUNT(*) FROM reservation", conn);
                Int32 count = Convert.ToInt32(comm.ExecuteScalar());
                conn.Close();

                double[] dataX = new double[count];
                double[] dataY = new double[count];
                var plt = new ScottPlot.Plot(610, 404);
                String[] labels = new String[count];
                String[] ord = new String[count];


                MySqlConnection conn2 = new MySqlConnection("Datasource=localhost;database=smartparking;port=3306;username=root;password=");
                conn2.Open();
                MySqlCommand comm2 = new MySqlCommand("SELECT count(*) FROM reservation group by type", conn2);
                MySqlDataReader rdr;

                rdr = comm2.ExecuteReader();
                int i = 0;
                while (rdr.Read())
                {
                    ord[i] = rdr[0].ToString();
                    i++;
                }

                conn2.Close();



                MySqlConnection conn3 = new MySqlConnection("Datasource=localhost;database=smartparking;port=3306;username=root;password=");
                conn3.Open();
                MySqlCommand comm3 = new MySqlCommand("SELECT distinct type FROM reservation group by type", conn3);
                MySqlDataReader rdr3;

                rdr3 = comm3.ExecuteReader();
                int j = 0;
                while (rdr3.Read())
                {
                    labels[j] = rdr3.GetString(0);
                    j++;
                }

                conn3.Close();

                for (i = 0; i < count; i++)
                {
                    dataY[i] = i;
                }

                for (i = 0; i < count; i++)
                {
                    dataX[i] = Convert.ToInt32(ord[i]);
                }

                formsPlot2.Plot.AddBar(dataX, dataY);
                formsPlot2.Plot.XTicks(dataY, labels);
                formsPlot2.Plot.SetAxisLimits(yMin: 0);
                formsPlot2.BackColor = Color.Gray;
                formsPlot2.Refresh();
            

        }
 

        private void formsPlot1_Load(object sender, EventArgs e)
        {
            MySqlConnection cnn = GetConnection();
            MySqlCommand req1 = new MySqlCommand("SELECT count(*) FROM reservation group by type;", cnn);

            MySqlCommand req = new MySqlCommand("SELECT distinct type FROM reservation group by type", cnn);
            Int32 count = Convert.ToInt32(req1.ExecuteScalar());
            double[] X = new double[count];
            double[] Y = new double[count];


            double[] values = { 789, 143, 283, 222 };
            //double[] values = { a, b, c, d };
            string[] labels = { "Velo", "Moto", "Auto", "Camion" };
            Color[] labelcolors = { Color.White, Color.White, Color.White, Color.White };
            Color[] slicecolors = { Color.Aqua, Color.Red, Color.MintCream, Color.GreenYellow };
            var pie = formsPlot1.Plot.AddPie(values);
            pie.SliceLabels = labels;
            pie.ShowLabels = true;
            pie.BackgroundColor = Color.DarkGray;
            pie.SliceFillColors = slicecolors;
            pie.SliceLabelColors = labelcolors;
            formsPlot1.Refresh();
        }

        private void Home_Load(object sender, EventArgs e)
        {

            label1.Text = ReservationControlle.AllCurrentRes("Moto");
            label2.Text = ReservationControlle.AllCurrentRes("Auto");
            label3.Text = ReservationControlle.AllCurrentRes("Velo");
            label4.Text = ReservationControlle.AllCurrentRes("Camion");
            chart();

        }
    }
}
