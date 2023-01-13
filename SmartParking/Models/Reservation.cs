using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartParking.Models
{
    class Reservation
    {
        private int id;
        private Place placeId;
        private string matricule;
        private string ownername;
        private string model;
        private string type;
        private double prix;
        private DateTime dateEnreg;
        private string owenerCin;

        public int Id { get => id; set => id = value; }
        public string Matricule { get => matricule; set => matricule = value; }
        public string Ownername { get => ownername; set => ownername = value; }
        public string Model { get => model; set => model = value; }
        public string Type { get => type; set => type = value; }
        public double Prix { get => prix; set => prix = value; }
        public DateTime DateEnreg { get => dateEnreg; set => dateEnreg = value; }
        public string OwenerCin { get => owenerCin; set => owenerCin = value; }
        internal Place PlaceId { get => placeId; set => placeId = value; }

        public Reservation(string matricule, string ownername, string model, string type, double prix, DateTime dateEnreg, string owenerCin, Place placeId)
        {
            this.matricule = matricule;
            this.ownername = ownername;
            this.model = model;
            this.type = type;
            this.prix = prix;
            this.dateEnreg = dateEnreg;
            this.owenerCin = owenerCin;
            this.placeId = placeId;
        }

        public Reservation(int id, string matricule, string ownername, string model, string type, double prix, DateTime dateEnreg, string owenerCin, Place placeId)
        {
            this.id = id;
            this.matricule = matricule;
            this.ownername = ownername;
            this.model = model;
            this.type = type;
            this.prix = prix;
            this.dateEnreg = dateEnreg;
            this.owenerCin = owenerCin;
            this.placeId = placeId;
        }
    }
}
