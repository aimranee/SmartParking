using MySqlConnector;
using SmartParking.Models;
using System.Data;
using System.Security.Policy;

namespace SmartParking.Controllers
{
    internal class ReservationControlle
    {
        public static MySqlConnection cnn = Program.GetConnection();
        public static void AjouterReservation(Reservation reservation)
        {
            string sql = "INSERT INTO reservation VALUES (null, @placeId, @matricule,@ownername, @model, @type, @prix, @dateEnreg, @ownerCin, @status)";

            MySqlCommand cmd = new MySqlCommand(sql, cnn);
            cmd.CommandType = CommandType.Text;
            //cmd.Parameters.Add("@id", MySqlDbType.VarChar).Value = reservation.Id;
            cmd.Parameters.Add("@matricule", MySqlDbType.VarChar).Value = reservation.Matricule;
            cmd.Parameters.Add("@placeId", MySqlDbType.VarChar).Value = reservation.PlaceId.Id;
            cmd.Parameters.Add("@ownername", MySqlDbType.VarChar).Value = reservation.Ownername;
            cmd.Parameters.Add("@model", MySqlDbType.VarChar).Value = reservation.Model;
            cmd.Parameters.Add("@type", MySqlDbType.VarChar).Value = reservation.Type;
            cmd.Parameters.Add("@prix", MySqlDbType.VarChar).Value = reservation.Prix;
            cmd.Parameters.Add("@dateEnreg", MySqlDbType.VarChar).Value = reservation.DateEnreg;
            cmd.Parameters.Add("@ownerCin", MySqlDbType.VarChar).Value = reservation.OwenerCin;
            cmd.Parameters.Add("@status", MySqlDbType.VarChar).Value = reservation.Status;
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
        public static void UpdateReservation(Reservation reservation , string id)
        {
            string sql = "UPDATE reservation SET  matricule= @matricule,ownername=@ownername,model= @model,type= @type,prix= @prix, dateEnreg=@dateEnreg, ownerCin = @ownerCin, status = @status where id= @id";

            MySqlCommand cmd = new MySqlCommand(sql, cnn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@id", MySqlDbType.VarChar).Value = id;
            cmd.Parameters.Add("@matricule", MySqlDbType.VarChar).Value = reservation.Matricule;
            cmd.Parameters.Add("@ownername", MySqlDbType.VarChar).Value = reservation.Ownername;
            cmd.Parameters.Add("@model", MySqlDbType.VarChar).Value = reservation.Model;
            cmd.Parameters.Add("@type", MySqlDbType.VarChar).Value = reservation.Type;
            cmd.Parameters.Add("@prix", MySqlDbType.VarChar).Value = reservation.Prix;
            cmd.Parameters.Add("@dateEnreg", MySqlDbType.VarChar).Value = reservation.DateEnreg;
            cmd.Parameters.Add("@ownerCin", MySqlDbType.VarChar).Value = reservation.OwenerCin;
            cmd.Parameters.Add("@status", MySqlDbType.VarChar).Value = reservation.Status;

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("L'utilisatauer modifier aves success.", "Inforamtion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show("La reservation n'est pas modifier ! \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            cnn.Close();
        }

        public static void SupprimerReservation(string idC)
        {
            string sql = "DELETE FROM reservation WHERE id = @id ";

            MySqlCommand cmd = new MySqlCommand(sql, cnn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@id", MySqlDbType.VarChar).Value = idC;

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

        public static Reservation CurrentRes(Place p)
        {
            //cnn.Open();
            Reservation rs = new Reservation();
            string sql = "SELECT * FROM reservation WHERE placeId = "+p.Id+" and status = 'en coure'";
            MySqlCommand cmd = new MySqlCommand(sql, Program.GetConnection());
            
            cmd.CommandType = CommandType.Text;
            try
            {
                
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                    rs = new Reservation(Int32.Parse(reader["id"].ToString()), p, reader["matricule"].ToString(), reader["ownername"].ToString(), reader["model"].ToString(), reader["type"].ToString(), reader["prix"].ToString(), Convert.ToDateTime(reader["dateEnreg"].ToString()), reader["owenerCin"].ToString(), reader["status"].ToString());

                //rs = new Reservation(Int32.Parse(reader.GetString("id")), p, reader.GetString("matricule"), reader.GetString("ownername"), reader.GetString("model"), reader.GetString("type"), reader.GetString("prix"), reader.GetDateTime("dateEnreg"), reader.GetString("owenerCin"), reader.GetString("status"));

            }
            catch
            {
                MessageBox.Show("Error.\n", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            cnn.Close();
            return rs;
        }

    }
}
