using MySqlConnector;
using SmartParking.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartParking.Controllers
{
    internal class ParkingControlle
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
        public static void AjouterParking(Parking reservation)
        {

            string sql = "INSERT INTO parking VALUES (@id, @name,@adresse, @contact)";
            MySqlConnection cnn = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, cnn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@id", MySqlDbType.VarChar).Value = reservation.Id;
            cmd.Parameters.Add("@name", MySqlDbType.VarChar).Value = reservation.Name;
            cmd.Parameters.Add("@adresse", MySqlDbType.VarChar).Value = reservation.Adresse;
            cmd.Parameters.Add("@contact", MySqlDbType.VarChar).Value = reservation.Contact;
            
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
        public static void UpdateParking(Parking reservation, string id)
        {

            string sql = "UPDATE parking SET  name=@name,adresse=@adresse ,contact= @contact whre id= @id";
            MySqlConnection cnn = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, cnn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@id", MySqlDbType.VarChar).Value = id;
            cmd.Parameters.Add("@name", MySqlDbType.VarChar).Value = reservation.Name;
            cmd.Parameters.Add("@adresse", MySqlDbType.VarChar).Value = reservation.Adresse;
            cmd.Parameters.Add("@contact", MySqlDbType.VarChar).Value = reservation.Contact;
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Parking modifier aves success.", "Inforamtion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Parking n'est pas modifier ! \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            cnn.Close();
        }

        public static void SupprimerParking(string idC)
        {
            string sql = "DELETE FROM parking WHERE id = @id ";
            MySqlConnection cnn = GetConnection();
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
