using MySqlConnector;
using SmartParking.Models;
using System.Data;

namespace SmartParking.Views
{
    public partial class Login : Form
    {
        int i;
        User user;
        public Login()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        public static MySqlConnection GetConnection()
        {
            string sql = @"server=localhost;userid=root;password=;database=gestionbibl";
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
        private void button1_Click(object sender, EventArgs e)
        {
            /*string cs = @"server=localhost;userid=root;password=;database=gestionbibl";
            var con = new MySqlConnection(cs);*/
            if (textUserName.Text != "" && textPassword.Text != "")
            {
                try
                {
                    i = 0;
                    string sql = "select username, password from user WHERE username = @username AND password = @Password";
                    MySqlConnection con = GetConnection();
                    MySqlCommand cmd = new MySqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@username", textUserName.Text.ToUpper());
                    cmd.Parameters.AddWithValue("@password", textPassword.Text);
                    MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                    DataTable tbl = new DataTable();
                    adp.Fill(tbl);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                        user = new User(int.Parse(reader["id"].ToString()));
                    i = Convert.ToInt32(tbl.Rows.Count.ToString());
                    if (i == 0)
                    {
                        MessageBox.Show("Nom d'utilisateur ou mot de passe est incorrect.\n", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textUserName.Clear();
                        textPassword.Clear();
                        textUserName.Focus();
                    }
                    else
                    {
                        con.Close();
                        main_form();
                    }
                    
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Nom d'utilisateur ou mot de passe est incorrect.\n" + ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textUserName.Clear();
                    textPassword.Clear();
                    textUserName.Focus();
                }
            }
            else
            {
                
                MessageBox.Show("Les champs vide!!.\n", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textUserName.Clear();
                textPassword.Clear();
                textUserName.Focus();
                
            }
            
        }

        private void main_form()
        {
            
            Dashboard home = new Dashboard();
            home.User = user;
            home.ShowDialog();
            this.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            textUserName.Clear();
            textPassword.Clear();
            textUserName.Focus();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                textPassword.UseSystemPasswordChar = false;
            }
            else
            {
                textPassword.UseSystemPasswordChar = true;
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}