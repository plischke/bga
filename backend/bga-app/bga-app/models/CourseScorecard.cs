using Org.BouncyCastle.Bcpg.OpenPgp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bga_app.models
{
    public class CourseScorecard
    {
        public string courseID { get; set; }
        public string courseName { get; set; }
        public string coursePar { get; set; }
        public string holeID { get; set; }
        public string par { get; set; }
        public string yardage { get; set; }
        public string description { get; set; }
    }
}
