using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tabwindowsform.Model
{
    public class clsPerson
    {
        public int person_Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string type { get; set; }
        public string mobile { get; set; }
        /*public clsAddress Address { get; set; }
        public clsDepartment department { get; set; }*/
        public string personFullAddress { get; set; }
        public string personDept { get; set; }
    }
}
