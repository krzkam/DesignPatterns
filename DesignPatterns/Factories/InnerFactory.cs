using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Factories
{

    public class Point3
    {
        private double x, y;
        internal Point3(double x, double y) //it allows to use constructor within current assembly but it doesn't allows to use contructor within anybody who's consuming that assembly from the outside
        {
            this.x = x;
            this.y = y;
        }

        public static Point3 NewPolarPoint2(double rho, double theta)
        {
            return new Point3(rho * Math.Cos(theta), (rho * Math.Sin(theta)));
        }
        public static Point3 NewCartesianPoint2(double x, double y)
        {
            return new Point3(x, y);
        }

        public override string ToString()
        {
            return $"{nameof(x)}: {x}, {nameof(y)}: {y}";
        }

        public static class Factory2
        {
            public static Point3 NewPolarPoint2(double rho, double theta)
            {
                return new Point3(rho * Math.Cos(theta), (rho * Math.Sin(theta)));
            }
            public static Point3 NewCartesianPoint2(double x, double y)
            {
                return new Point3(x, y);
            }
        }

        //indicating origin
        public static Point3 Origin => new Point3(0, 0);

        public static Point3 Origin2 = new Point3(0, 0); //better way
    }


}
