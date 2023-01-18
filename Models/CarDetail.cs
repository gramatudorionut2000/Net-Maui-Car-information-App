using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect.Models
{
   public class CarDetail
    {
        [PrimaryKey,AutoIncrement]
        public int ID { get; set; }
        public string License_Plate { get; set; }

        public string VIN { get; set; }

        public int Year { get; set; }

        [SQLite.MaxLength(250)]
        public string Description { get; set; }

        public string CarModel { get; set; }

        [ForeignKey(typeof(Service))]
        public int ServiceID { get; set; }

    }
}
