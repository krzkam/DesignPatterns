using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Decorator
{
    public interface IShape
    {
        string AsString();
    }
    public class Circle : IShape
    {
        private float radius;
        public Circle(float radius)
        {
            this.radius = radius;
        }
        public void Resize(float factor)
        {
            radius *= factor;
        }
        public string AsString()
        {
            return $"A circle with radius {radius}";
        }
    }

    public class Square : IShape
    {
        private float side;
        public Square(float side)
        {
            this.side = side;
        }
        public string AsString()
        {
            return $"A Square with side {side}";
        }
    }

    public class ColoredSquare : IShape
    {
        private IShape shape;
        private string color;

        public ColoredSquare(IShape shape, string color)
        {
            this.shape = shape ?? throw new ArgumentNullException(nameof(shape));
            this.color = color ?? throw new ArgumentNullException(nameof(color));
        }

        public string AsString()
        {
            return $"{shape.AsString()} has the color {color}";
        }
    }

    public class TransparentShape : IShape
    {
        private IShape shape;
        float transparency;

        public TransparentShape(IShape shape, float transparency)
        {
            this.shape = shape ?? throw new ArgumentNullException(nameof(shape));
            this.transparency = transparency;
        }

        public string AsString()
        {
            return $"{shape.AsString()} has the transparency {transparency}";
        }
    }
}
