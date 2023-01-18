using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLiteNetExtensions.Attributes;

namespace Proiect.Models
{
    public class Insurance
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public string Type { get; set; }

        public DateTime ExpirationDate { get; set; }

        public string InsuranceDetails
        {
            get
            {
                return Type + " " + ExpirationDate.ToLongDateString();} }

        [ForeignKey(typeof(CarDetail))]
        public int CarDetailID { get; set; }
    }
}
