using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ado_2_instructor_crud
{
    internal class instructor
    {
        public int ins_id { get; set; }
        public string ins_name { get; set; }
        public string ins_degree { get; set; }

        public decimal ins_salary { get; set; }
        public int dept_id { get; set; }

    }
}
