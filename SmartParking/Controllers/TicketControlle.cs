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



    internal class TicketControlle
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
        public static void AjouterTicket(Ticket reservation)
        {

            string sql = "INSERT INTO ticket VALUES (@id, @idRes,@idUser, @dateEmp, @total)";
            MySqlConnection cnn = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, cnn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@id", MySqlDbType.VarChar).Value = reservation.Id;
            cmd.Parameters.Add("@idOwner", MySqlDbType.VarChar).Value = reservation.IdRes;
            cmd.Parameters.Add("@ownername", MySqlDbType.VarChar).Value = reservation.IdUser;
            cmd.Parameters.Add("@model", MySqlDbType.VarChar).Value = reservation.DateEmp;
            cmd.Parameters.Add("@type", MySqlDbType.VarChar).Value = reservation.Total;

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
        public static void UpdateTicket(Ticket reservation, string id)
        {

            string sql = "UPDATE ticket SET  idRes=@idRes,idUser=@idUser,total= @totalwhere id= @id";
            MySqlConnection cnn = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, cnn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@id", MySqlDbType.VarChar).Value = id;
            cmd.Parameters.Add("@idOwner", MySqlDbType.VarChar).Value = reservation.IdRes;
            cmd.Parameters.Add("@ownername", MySqlDbType.VarChar).Value = reservation.IdUser;
            cmd.Parameters.Add("@model", MySqlDbType.VarChar).Value = reservation.DateEmp;
            cmd.Parameters.Add("@type", MySqlDbType.VarChar).Value = reservation.Total;
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Ticket modifier aves success.", "Inforamtion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ticket n'est pas modifier ! \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            cnn.Close();
        }

        public static void SupprimerTicket(string idC)
        {
            string sql = "DELETE FROM ticket WHERE id = @id ";
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
