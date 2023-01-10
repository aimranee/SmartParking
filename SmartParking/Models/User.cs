using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartParking.Models
{
    class User
    {
        private int id;
        private string role;
        private string username;
        private string password;
        private string nom;
        private string prenom;
        private string cin;

        public int Id { get => id; set => id = value; }
        public string Role { get => role; set => role = value; }
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Prenom { get => prenom; set => prenom = value; }
        public string Cin { get => cin; set => cin = value; }

        public User(int id, string role, string username, string password, string nom, string prenom, string cin)
        {
            this.id = id;
            this.role = role;
            this.username = username;
            this.password = password;
            this.nom = nom;
            this.prenom = prenom;
            this.cin = cin;
        }

        public User(string role, string username, string password, string nom, string prenom, string cin)
        {
            this.role = role;
            this.username = username;
            this.password = password;
            this.nom = nom;
            this.prenom = prenom;
            this.cin = cin;
        }
    }
}
