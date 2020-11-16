using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
namespace Quan_ly_phong_tro.Model
{
    class Customer
    {
        [PrimaryKey, AutoIncrement]
        public string cmnd { get; set; }
        public string name { get; set; }
        public int birthYear { get; set; }
        public string address { get; set; }
        public string room { get; set; }
        public string numberPhone1 { get; set;}
        public string numberPhone2 { get; set; }
        public DateTime dateRent { get; set; }
        public string gender { get; set; }
        public string jobCustomer { get; set; }

    }
}
