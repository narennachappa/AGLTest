using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObjects
{
    public class UserDetails
    {
        public string name { get; set; }
        public string gender { get; set; }
        public string age { get; set; }
        public IList<pets> pets { get; set; }
    }
}
