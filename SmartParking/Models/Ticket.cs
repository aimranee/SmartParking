using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartParking.Models
{
    class Ticket
    {
        private int id;
        private Reservation idRes;
        private User idUser;
        private DateTime dateEmp;
        private double total;

        public int Id { get => id; set => id = value; }
        public DateTime DateEmp { get => dateEmp; set => dateEmp = value; }
        public double Total { get => total; set => total = value; }
        internal Reservation IdRes { get => idRes; set => idRes = value; }
        internal User IdUser { get => idUser; set => idUser = value; }

        public Ticket(int id, Reservation idRes, User idUser, DateTime dateEmp, double total)
        {
            this.id = id;
            this.idRes = idRes;
            this.idUser = idUser;
            this.dateEmp = dateEmp;
            this.total = total;
        }

        public Ticket(Reservation idRes, User idUser, DateTime dateEmp, double total)
        {
            this.idRes = idRes;
            this.idUser = idUser;
            this.dateEmp = dateEmp;
            this.total = total;
        }
    }
}
