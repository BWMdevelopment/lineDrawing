using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestApplication.BL.Model;

namespace TestApplication.BL.Models
{
    public class SegmentModel
    {
        public IEnumerable<Point> CoordinatesList { get; set; }
        public String Color { get; set; }
    }
}