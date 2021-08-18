using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishStoreLib
{
    public class customer
    {
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public customer(int _id, string _title, string _mail, string _pass)
        {
            id = _id;
            name = _title;
            email = _mail;
            password = _pass;
        }
    }
}
