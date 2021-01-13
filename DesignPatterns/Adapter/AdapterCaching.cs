using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Adapter
{
    public class Point2
    {
        public int X, Y;
        public Point2(int x, int y)
        {
            X = x;
            Y = y;
        }

        protected bool Equals(Point2 other)
        {
            return X == other.X && Y == other.Y;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Point2)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (X * 397) ^ Y;
            }
        }

        public override string ToString()
        {
            return $"({X}, {Y})";
        }
    }

    public class Line2
    {
        public Point2 Start, End;

        public Line2(Point2 start, Point2 end)
        {
            Start = start ?? throw new ArgumentNullException(nameof(start));
            End = end ?? throw new ArgumentNullException(nameof(end));
            Start = start;
            End = end;
        }

        protected bool Equals(Line2 other)
        {
            return Equals(Start, other.Start) && Equals(End, other.End);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Line2)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Start != null ? Start.GetHashCode() : 0) * 397) ^ (End != null ? End.GetHashCode() : 0);
            }
        }
    }

    public class VectorObject2 : Collection<Line2>
    {

    }

    public class VectorRectangle2 : VectorObject2
    {
        public VectorRectangle2(int x, int y, int width, int height)
        {
            Add(new Line2(new Point2(x, y), new Point2(x + width, y)));
            Add(new Line2(new Point2(x + width, y), new Point2(x + width, y + height)));
            Add(new Line2(new Point2(x, y), new Point2(x, y + height)));
            Add(new Line2(new Point2(x, y + height), new Point2(x + width, y + height)));
        }
    }

    public class LineToPointAdapter2 : IEnumerable<Point2>
    {
        private static int count;
        static Dictionary<int, List<Point2>> cache = new Dictionary<int, List<Point2>>();

        public LineToPointAdapter2(Line2 Line2)
        {
            var hash = Line2.GetHashCode();
            if (cache.ContainsKey(hash)) return;

            Console.WriteLine($"{++count}: Generating Point2s for Line2 [{Line2.Start.X},{Line2.Start.Y}]-[{Line2.End.X},{Line2.End.Y}]");

            var points = new List<Point2>(0);

            int left = Math.Min(Line2.Start.X, Line2.End.X);
            int right = Math.Max(Line2.Start.X, Line2.End.X);
            int top = Math.Min(Line2.Start.Y, Line2.End.Y);
            int bottom = Math.Max(Line2.Start.Y, Line2.End.Y);
            int dx = right - left;
            int dy = Line2.End.Y - Line2.Start.Y;

            if (dx == 0)
            {
                for (int y = top; y <= bottom; ++y)
                {
                    points.Add(new Point2(left, y));
                }
            }
            else if (dy == 0)
            {
                for (int x = left; x <= right; ++x)
                {
                    points.Add(new Point2(x, top));
                }
            }

            cache.Add(hash, points);
        }

        public IEnumerator<Point2> GetEnumerator()
        {
            return cache.Values.SelectMany(x => x).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
