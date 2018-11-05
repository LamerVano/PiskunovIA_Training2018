using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HW_14.Models
{
    public class Function
    {
        public double A { get; set; }
        public double B { get; set; }
        public double C { get; set; }
        public Roots Root { get; set; }

        public void CalcRoots()
        {
            double disc = B * B - 4 * A * C;

            Root = new Roots();

            if (disc >= 0)
            {
                Root.RealRoot1 = (-B + Math.Sqrt(disc)) / 2 / A;
                Root.RealRoot2 = (-B - Math.Sqrt(disc)) / 2 / A;
            }

            else
            {
                Root.RealRoot1 = -B / 2 / A;
                Root.RealRoot2 = -B / 2 / A;

                Root.ImaginaryRoot1 = Math.Sqrt(-disc) / 2 / A;
                Root.ImaginaryRoot2 = -Math.Sqrt(-disc) / 2 / A;
            }
        }
    }
}