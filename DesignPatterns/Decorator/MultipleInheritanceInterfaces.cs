using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Decorator
{
    public interface IBird
    {
        void Fly();
        int Weight { get; set; }
    }

    public interface ILizard
    {
        void Crawl();
        int Weight { get; set; }
    }

    public class Bird: IBird
    {
        public int Weight { get; set; }
        public void Fly()
        {
            Console.WriteLine($"Flying with weight {Weight}");
        }
    }

    public class Lizard: ILizard
    {
        public int Weight { get; set; }
        public void Crawl()
        {
            Console.WriteLine($"Crawl with weight {Weight}");
        }
    }

    public class Dragon : IBird, ILizard
    {
        private Bird bird = new Bird();
        private Lizard lizard = new Lizard();
        private int weight;

        public int Weight {
            get
            {
                return weight;
            }
            set
            {
                this.weight = value;
                bird.Weight = value;
                lizard.Weight = value;
            }

        }

        public void Crawl()
        {
            lizard.Crawl();
        }

        public void Fly()
        {
            bird.Fly();
        }
    }

}
