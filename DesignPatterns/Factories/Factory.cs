using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Factory - separate component which knows how to initialize types in a paticular way
namespace DesignPatterns.Factories
{

    public enum CoordinateSystem2
    {
        Cartesian,
        Polar
    }
    public class Point2
    {
        private double x, y;
        public Point2(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public static Point2 NewPolarPoint2(double rho, double theta)
        {
            return new Point2(rho * Math.Cos(theta), (rho * Math.Sin(theta)));
        }
        public static Point2 NewCartesianPoint2(double x, double y)
        {
            return new Point2(x, y);
        }

        public override string ToString()
        {
            return $"{nameof(x)}: {x}, {nameof(y)}: {y}";
        }
    }

    public static class PointFactory
    {
        public static Point2 NewPolarPoint2(double rho, double theta)
        {
            return new Point2(rho * Math.Cos(theta), (rho * Math.Sin(theta)));
        }
        public static Point2 NewCartesianPoint2(double x, double y)
        {
            return new Point2(x, y);
        }
    }
}
