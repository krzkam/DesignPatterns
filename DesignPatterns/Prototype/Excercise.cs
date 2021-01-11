using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Prototype
{
    public class Point
    {
        public int X, Y;

        public override string ToString()
        {
            return $"{nameof(X)}: {X}, {nameof(Y)}: {Y}";
        }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
    }

    public class Line
    {
        public Point Start, End;
        public Line DeepCopy()
        {
            return new Line(Start, End);
        }

        public Line(Point start, Point end)
        {
            Start = start ?? throw new ArgumentNullException(paramName: nameof(start));
            End = end ?? throw new ArgumentNullException(paramName: nameof(end));
        }

        public override string ToString()
        {
            return $"{nameof(Start)}: {Start}, {nameof(End)}: {End}";
        }
    }
}


