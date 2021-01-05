using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//you should be able to substitute a base type for a subtype
//you should be able to upcast to your base type and the operation should be generally ok
namespace DesignPatterns.TheSOLIDDesignPrinciples
{
    public class Rectangle
    {
        public virtual int Width { get; set; } //set properties virutal
        public virtual int Height { get; set; }

        public Rectangle()
        {

        }

        public Rectangle(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public override string ToString()
        {
            return $"{nameof(Width)}: {Width}, {nameof(Height)}: {Height}";
        }
    }

    public class Square : Rectangle
    {
        public override int Width //instead of new you'd put override
        {
            set
            {
                base.Width = base.Height = value;
            }
        }

        public override int Height
        {
            set
            {
                base.Width = base.Height = value;
            }
        }
    }

    class LiskovSubstitutionPrinciple
    {
    }
}
