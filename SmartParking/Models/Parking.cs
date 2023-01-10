using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartParking.Models
{
    class Parking
    {
        private int id;
        private string name;
        private string adresse;
        private string contact;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Adresse { get => adresse; set => adresse = value; }
        public string Contact { get => contact; set => contact = value; }

        public Parking(int id, string name, string adresse, string contact)
        {
            this.id = id;
            this.name = name;
            this.adresse = adresse;
            this.contact = contact;
        }

        public Parking(string name, string adresse, string contact)
        {
            this.name = name;
            this.adresse = adresse;
            this.contact = contact;
        }
    }
}
