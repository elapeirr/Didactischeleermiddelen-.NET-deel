using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DidactischeLeermiddelen.Models.domain
{
   

public class ReservationException : Exception
    {
        public ReservationException()
        {
        }

        public ReservationException(string message)
            : base(message)
        {
        }

        public ReservationException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}