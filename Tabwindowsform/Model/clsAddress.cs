using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tabwindowsform.Model
{
    public class clsAddress
    {
        public int Add_Id { get; set; }
        public string Address { get; set; }
        public clsCity City { get; set; }
    }
}
