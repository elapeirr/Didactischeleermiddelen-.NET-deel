using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DidactischeLeermiddelen.Models.domain
{
    public class Blocking : ReservedMaterial
    {
        public List<DateTime> WeekDays
        {
            get; set;
        }


    }
}