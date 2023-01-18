using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLiteNetExtensions.Attributes;
namespace Proiect.Models
{
    public class Driver
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        [ForeignKey(typeof(CarDetail))]
        public int CarDetailID { get; set; }
        public int PersonID { get; set; }
    }
}
