using Proiect.Data;
using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect.Models
{
   public class Service
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string ServiceDetails
        {
            get
            {
                return Name + " " +Address;} }
        [OneToMany]
 public List<CarDetail> CarDetails { get; set; }
    }
}
