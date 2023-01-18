using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect.Models
{
    public class Car
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        [Unique, MaxLength(20)]
        public string Brand { get; set; }

        [Unique, MaxLength(20)]
        public string Model { get; set; }

    }
}