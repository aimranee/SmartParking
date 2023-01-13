using MySqlConnector;
using SmartParking.Models;
using System.Data;

namespace SmartParking.Controllers
{
    internal class PlaceControlle
    {
        public static MySqlConnection cnn = Program.GetConnection();
        //id	code	status	type	
        public static void AjouterPlace(Place user)
        {
            cnn.Open();
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
            cnn.Open(); 
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
            cnn.Open();
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

        public static List<Place> afficher()
        {
            List<Place> placeList = new List<Place>();
            string sql = "SELECT * from place";
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
                MessageBox.Show("Device not deleted. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            cnn.Close();
            return placeList;
        }
    }
}
