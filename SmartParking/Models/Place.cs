using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartParking.Models
{
    class Place
    {
        private int id;
        private string code;
        private int status;
        private string type;

        public int Id { get => id; set => id = value; }
        public string Code { get => code; set => code = value; }
        public int Status { get => status; set => status = value; }
        public string Type { get => type; set => type = value; }

        public Place(int id, string code, int status, string type)
        {
            this.id = id;
            this.code = code;
            this.status = status;
            this.type = type;
        }

        public Place(string code, int status, string type)
        {
            this.code = code;
            this.status = status;
            this.type = type;
        }
    }
}
