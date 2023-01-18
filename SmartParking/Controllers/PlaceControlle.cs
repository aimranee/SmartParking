using MySqlConnector;
using SmartParking.Models;
using System.Data;

namespace SmartParking.Controllers
{
    internal class PlaceControlle
    {
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
        //id	code	status	type	
        public static void AjouterPlace(Place user)
        {
            MySqlConnection cnn = GetConnection();
            string sql = "INSERT INTO place VALUES (null, @code, @status, @type)";

            MySqlCommand cmd = new MySqlCommand(sql, cnn);
            cmd.CommandType = CommandType.Text;
      
            cmd.Parameters.Add("@code", MySqlDbType.VarChar).Value = user.Code;
            cmd.Parameters.Add("@status", MySqlDbType.VarChar).Value = user.Status;
            cmd.Parameters.Add("@type", MySqlDbType.VarChar).Value = user.Type;
            try
            {
                cmd.ExecuteNonQuery();

                MessageBox.Show(" ajouter aves success.", "Inforamtion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(" n'est pas ajouter ! \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            cnn.Close();
        }
        public static void UpdatePlace(Place user, string id)
        {
            MySqlConnection cnn = GetConnection();
            string sql = "UPDATE place SET code=@code, status=@status, type=@type WHERE id = @id ";

            MySqlCommand cmd = new MySqlCommand(sql, cnn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@id", MySqlDbType.VarChar).Value = id;

            cmd.Parameters.Add("@code", MySqlDbType.VarChar).Value = user.Code;
            cmd.Parameters.Add("@status", MySqlDbType.VarChar).Value = user.Status;

            cmd.Parameters.Add("@type", MySqlDbType.VarChar).Value = user.Type;

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Place modifier aves success.", "Inforamtion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Place n'est pas modifier ! \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            cnn.Close();
        }

        public static void SupprimerPlace(string idC)
        {
            MySqlConnection cnn = GetConnection();
            string sql = "DELETE FROM place WHERE id = @id ";

            MySqlCommand cmd = new MySqlCommand(sql, cnn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@id", MySqlDbType.VarChar).Value = idC; ;


            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show(" supprimer aves success.", "Inforamtion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(" n'est pas supprimer ! \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            cnn.Close();
        }

        public static List<Place> afficher(string type)
        {
            MySqlConnection cnn = GetConnection();
            List<Place> placeList = new List<Place>();
            string sql = "SELECT * from place where type = '"+type+"'";
            MySqlCommand cmd = new MySqlCommand(sql, cnn);
            cmd.CommandType = CommandType.Text;
            try
            {
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                    placeList.Add(new Place(int.Parse(reader["id"].ToString()), reader["code"].ToString(), int.Parse(reader["status"].ToString()), reader["type"].ToString()));
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            cnn.Close();
            return placeList;
        }

        public static Place FindByCode (string id)
        {
            MySqlConnection cnn = GetConnection();
            Place p = null;
            string sql = "SELECT * from place where code = '"+id+"'";
            MySqlCommand cmd = new MySqlCommand(sql, cnn);
            cmd.CommandType = CommandType.Text;
            try
            {
                MySqlDataReader reader = cmd.ExecuteReader();
                while(reader.Read())
                     p = new Place(int.Parse(reader["id"].ToString()), reader["code"].ToString(), int.Parse(reader["status"].ToString()), reader["type"].ToString());
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            cnn.Close();
            return p;
        }

        public static int getLastId()
        {
            MySqlConnection cnn = GetConnection();
            int id = 0;
            string sql = "SELECT Max(id) as max from place group by id";
            MySqlCommand cmd = new MySqlCommand(sql, cnn);
            cmd.CommandType = CommandType.Text;
            try
            {
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                    id = int.Parse(reader["max"].ToString());
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            cnn.Close();
            return id;
        }
    }
}
