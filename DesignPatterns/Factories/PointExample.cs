using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Advatage of factory method: 
//you get to have an overload with the same sets of arguments but they have different descriptive names
//names of factory methods are uniqe 
namespace DesignPatterns.Factories
{

    public enum CoordinateSystem
    {
        Cartesian,
        Polar
    }
    public class Point
    {
        private double x, y;
        //    /// <summary>
        //    /// Initializes a point from EITHER cartesian or polar
        //    /// </summary>
        //    /// <param name="a">x if cartesian, rho if polar</param>
        //    /// <param name="b"></param>
        //    /// <param name="system"></param>
        //    public Point(double a, double b, CoordinateSystem system=CoordinateSystem.Cartesian)
        //    {
        //        switch (system)
        //        {
        //            case CoordinateSystem.Cartesian:
        //                x = a;
        //                y = b;
        //                break;
        //            case CoordinateSystem.Polar:
        //                x = a * Math.Cos(b);
        //                y = a * Math.Sin(b);
        //                break;
        //            default:
        //                throw new ArgumentOutOfRangeException(nameof(system), system, null);
        //        }
        //    }
        private Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public static Point NewPolarPoint(double rho, double theta)
        {
            return new Point(rho * Math.Cos(theta), (rho * Math.Sin(theta)));
        }
        public static Point NewCartesianPoint(double x, double y)
        {
            return new Point(x, y);
        }

        public override string ToString()
        {
            return $"{nameof(x)}: {x}, {nameof(y)}: {y}"; 
        }
    }
}
