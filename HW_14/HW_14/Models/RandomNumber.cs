using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HW_14.Models
{
    public class Randomizer
    {
        public int MaxNumber { get; set; }

        public int Number { get; set; }
                
        public int GenerateNumber(Random rnd)
        {
            return rnd.Next(MaxNumber);
        }
    }
}