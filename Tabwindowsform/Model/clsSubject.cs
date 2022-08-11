using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tabwindowsform.Model
{
    public class clsSubject
    {
        public string sub_code { get; set; }
        public string sub_name { get; set; }
        public bool isElective { get; set; }
        public bool isCommonForAll { get; set; }
        /*public clsDepartment dept_Id { get; set; }
        public clsSemester sem_Id { get; set; }*/
        public string sub_dept_name { get; set; }
        public string sub_sem_name { get; set; }

    }
}
