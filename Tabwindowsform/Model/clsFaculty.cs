﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tabwindowsform.Model
{
    public class clsFaculty
    {
        public clsPerson Person_Id { get; set; }
        public string Building_Name { get; set; }
        public int Room_No { get; set; }
        public string Allocated_To { get; set; }
    }
}
