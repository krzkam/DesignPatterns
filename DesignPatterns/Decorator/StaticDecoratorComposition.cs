using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Decorator
{
    public abstract class Shape2
    {
        public abstract string AsString();
    }
    public class Circle2 : Shape2
    {
        public Circle2() : this(0)
        {

        }
        private float radius;
        public Circle2(float radius)
        {
            this.radius = radius;
        }
        public void Resize(float factor)
        {
            radius *= factor;
        }
        public override string AsString()
        {
            return $"A Circle2 with radius {radius}";
        }
    }

    public class Square2 : Shape2
    {
        public Square2():this(0.0f)
        {

        }
        private float side;
        public Square2(float side)
        {
            this.side = side;
        }
        public override string AsString()
        {
            return $"A Square2 with side {side}";
        }
    }

    public class ColoredSquare2 : Shape2
    {
        private Shape2 shape;
        private string color;

        public ColoredSquare2(Shape2 shape, string color)
        {
            this.shape = shape ?? throw new ArgumentNullException(nameof(shape));
            this.color = color ?? throw new ArgumentNullException(nameof(color));
        }

        public override string AsString()
        {
            return $"{shape.AsString()} has the color {color}";
        }
    }


 
    public class TransparentShape2 : Shape2
    {
        private Shape2 shape;
        float transparency;

        public TransparentShape2(Shape2 shape, float transparency)
        {
            this.shape = shape ?? throw new ArgumentNullException(nameof(shape));
            this.transparency = transparency;
        }

        public override string AsString()
        {
            return $"{shape.AsString()} has the transparency {transparency}";
        }
    }

    public class ColoredShape<T> : Shape2 where T : Shape2, new()
    {
        private string color;
        private T shape = new T();

        public ColoredShape() : this("black")
        {

        }

        public ColoredShape(string color)
        {
            this.color = color ?? throw new ArgumentNullException(nameof(color));
        }

        public override string AsString()
        {
            return $"{shape.AsString()} has the color {color}";
        }
    }

    public class TransparentShape<T> : Shape2 where T : Shape2, new()
    {
        private float transparency;
        private T shape = new T();

        public TransparentShape() : this(0)
        {

        }

        public TransparentShape(float transparency)
        {
            this.transparency = transparency;

        }

        public override string AsString()
        {
            return $"{shape.AsString()} has the transparency {transparency}";
        }
    }
}
