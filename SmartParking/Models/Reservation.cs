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
        private string prix;
        private string dateEnreg;
        private string owenerCin;
        private string status;

        public int Id { get => id; set => id = value; }
        public string Matricule { get => matricule; set => matricule = value; }
        public string Ownername { get => ownername; set => ownername = value; }
        public string Model { get => model; set => model = value; }
        public string Type { get => type; set => type = value; }
        public string Prix { get => prix; set => prix = value; }
        public string DateEnreg { get => dateEnreg; set => dateEnreg = value; }
        public string OwenerCin { get => owenerCin; set => owenerCin = value; }
        internal Place PlaceId { get => placeId; set => placeId = value; }
        public string Status { get => status; set => status = value; }

        public Reservation(string matricule, string ownername, string model, string type, string prix, string dateEnreg, string owenerCin, Place placeId, string status)
        {
            this.matricule = matricule;
            this.ownername = ownername;
            this.model = model;
            this.type = type;
            this.prix = prix;
            this.dateEnreg = dateEnreg;
            this.owenerCin = owenerCin;
            this.placeId = placeId;
            this.status = status;
        }


        public Reservation(int id, Place placeId, string matricule, string ownername, string model, string type, string prix, string dateEnreg, string owenerCin, string status)
        {
            this.id = id;
            this.placeId = placeId;
            this.matricule = matricule;
            this.ownername = ownername;
            this.model = model;
            this.type = type;
            this.prix = prix;
            this.dateEnreg = dateEnreg;
            this.owenerCin = owenerCin;
            this.status = status;
        }
    }
}
