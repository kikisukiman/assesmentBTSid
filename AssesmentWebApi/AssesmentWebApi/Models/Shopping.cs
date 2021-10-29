using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssesmentWebApi.Model
{
    public class Shopping : User
    {
        public string Name { set; get; }
        public DateTime CreateDate {set;get;}
    }
}
