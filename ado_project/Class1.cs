using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ado_project
{
    internal class Course
    {
        public int crs_Id { get; set; }
        public string crs_Name { get; set; }
        public int crs_Duration { get; set; }
        public int topic_Id { get; set; }
    }
}
