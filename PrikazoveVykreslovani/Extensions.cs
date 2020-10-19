using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrikazoveVykreslovani
{
    public static class Extensions
    {
        public static double Distance(this Point p, Point p2) {
            int odv1 = p.X - p2.X;
            int odv2 = p.Y - p2.Y;

            return Math.Sqrt(odv1 * odv1 + odv2 * odv2);
        }
    }
}
