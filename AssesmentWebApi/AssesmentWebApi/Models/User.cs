using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssesmentWebApi.Model
{
    public class User
    {
        public string id { set; get; }
        public string username { set; get; }
        public string password { set; get; }
        public string email { set; get; }
        public string phone { set; get; }
        public string country { set; get; }
        public string city { set; get; }
        public string postcode { set; get; }
        public string name { set; get; }
        public string address { set; get; }
    }
}
