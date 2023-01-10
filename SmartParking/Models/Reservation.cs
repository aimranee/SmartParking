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
        private string matricule;
        private string ownername;
        private string model;
        private int type;
        private double prix;
        private DateTime dateEnreg;
        private int owenerCin;

        public int Id { get => id; set => id = value; }
        public string Matricule { get => matricule; set => matricule = value; }
        public string Ownername { get => ownername; set => ownername = value; }
        public string Model { get => model; set => model = value; }
        public int Type { get => type; set => type = value; }
        public double Prix { get => prix; set => prix = value; }
        public DateTime DateEnreg { get => dateEnreg; set => dateEnreg = value; }
        public int OwenerCin { get => owenerCin; set => owenerCin = value; }


        public Reservation(string matricule, string ownername, string model, int type, double prix, DateTime dateEnreg, int owenerCin)
        {
            this.matricule = matricule;
            this.ownername = ownername;
            this.model = model;
            this.type = type;
            this.prix = prix;
            this.dateEnreg = dateEnreg;
            this.owenerCin = owenerCin;
        }

        public Reservation(int id, string matricule, string ownername, string model, int type, double prix, DateTime dateEnreg, int owenerCin)
        {
            this.id = id;
            this.matricule = matricule;
            this.ownername = ownername;
            this.model = model;
            this.type = type;
            this.prix = prix;
            this.dateEnreg = dateEnreg;
            this.owenerCin = owenerCin;
        }
    }
}
