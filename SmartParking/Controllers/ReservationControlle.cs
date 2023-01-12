using MySqlConnector;
using SmartParking.Models;
using System.Data;

namespace SmartParking.Controllers
{
    internal class ReservationControlle
    {
        public static MySqlConnection cnn = Program.GetConnection();
        public static void AjouterReservation(Reservation reservation)
        {
            
            string sql = "INSERT INTO reservation VALUES (@id, @matricule,@ownername, @model, @type, @prix, @dateEnreg, @ownerCin)";

            MySqlCommand cmd = new MySqlCommand(sql, cnn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@id", MySqlDbType.VarChar).Value = reservation.Id;
            cmd.Parameters.Add("@matricule", MySqlDbType.VarChar).Value = reservation.Matricule;
            cmd.Parameters.Add("@ownername", MySqlDbType.VarChar).Value = reservation.Ownername;
            cmd.Parameters.Add("@model", MySqlDbType.VarChar).Value = reservation.Model;
            cmd.Parameters.Add("@type", MySqlDbType.VarChar).Value = reservation.Type;
            cmd.Parameters.Add("@prix", MySqlDbType.VarChar).Value = reservation.Prix;
            cmd.Parameters.Add("@dateEnreg", MySqlDbType.VarChar).Value = reservation.DateEnreg;
            cmd.Parameters.Add("@ownerCin", MySqlDbType.VarChar).Value = reservation.OwenerCin;
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
            string sql = "UPDATE reservation SET  matricule= @matricule,ownername=@ownername,model= @model,type= @type,prix= @prix, dateEnreg=@dateEnreg,ownerCin= @ownerCin where id= @id";

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

    }
}
