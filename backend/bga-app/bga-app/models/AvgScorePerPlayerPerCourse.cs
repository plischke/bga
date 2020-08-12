using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bga_app.models
{
    public class AvgScorePerPlayerPerCourse
    {
        public string playerId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string average { get; set; }
        public string courseID { get; set; }
        public string courseName { get; set; }
    }
}
