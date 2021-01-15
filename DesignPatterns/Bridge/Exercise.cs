using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Bridge
{
    public abstract class Shape2
    {
        public string Name { get; set; }

        protected IRenderer2 renderer;

        protected Shape2(IRenderer2 renderer)
        {
            this.renderer = renderer ?? throw new ArgumentNullException(nameof(renderer));
        }
    }

    public class Triangle : Shape2
    {
        public Triangle(IRenderer2 renderer) : base(renderer)
        {
            Name = "Triangle";
            renderer.WhatToRenderAs = Name;
        }

        public override string ToString()
        {
            return renderer.ToString();
        }
    }

    public class Square : Shape2
    {
        public Square(IRenderer2 renderer) : base(renderer)
        {
            Name = "Square";
            renderer.WhatToRenderAs = Name;
        }
        public override string ToString()
        {
            return renderer.ToString();
        }
    }

    public interface IRenderer2
    {
        string WhatToRenderAs { get; set; }
    }

    public class RasterRenderer2 : IRenderer2
    {
        public string WhatToRenderAs
        {
            get; set;
        }

        public override string ToString() => $"Drawing {WhatToRenderAs} as pixels";
    }

    public class VectorRenderer2 : IRenderer2
    {
        public string WhatToRenderAs
        {
            get; set;
        }

        public override string ToString() => $"Drawing {WhatToRenderAs} as lines";
    }
}
