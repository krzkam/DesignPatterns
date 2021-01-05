using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPatterns.TheSOLIDDesignPrinciples;


namespace DesignPatterns
{
    class Program 
    {
        static void Main(string[] args)
        {
            ////01 Single Responsibility Principle {

            //var j = new Journal();
            //j.AddEntry("Entry 1");
            //j.AddEntry("Entry 2");
            //Console.WriteLine(j);

            //var p = new Persistence();
            //var filename = @"c:\temp\journal.txt";
            //p.SaveToFile(j, filename, true); 
            //Process.Start(filename);
            ////}

            ////02 Open-Closed Principle {
            //var apple = new Product("Apple", Color.Green, Size.Small);
            //var tree = new Product("Tree", Color.Green, Size.Large);
            //var house = new Product("House", Color.Blue, Size.Large);

            //Product[] products = { apple, tree, house };
            //var pf = new ProductFilter();
            //Console.WriteLine("Green products (old): ");
            //foreach (var p in pf.FilterByColor(products, Color.Green))
            //{
            //    Console.WriteLine($" - {p.Name} is Green");
            //}

            //var bf = new BetterFilter();
            //Console.WriteLine("Green products (new):");
            //foreach (var p in bf.Filter(products, new ColorSpecification(Color.Green)))
            //{
            //    Console.WriteLine($" - {p.Name} is Green");
            //}

            //Console.WriteLine("Large blue items:");
            //foreach (var p in bf.Filter(
            //    products,
            //    new AndSpecification<Product>(
            //        new ColorSpecification(Color.Blue), 
            //        new SizeSpecification(Size.Large))))
            //{
            //    Console.WriteLine($" - {p.Name} is Large and Blue");
            //}
            ////}

            ////03 Liskov Substitution Principle p1 {
            //Rectangle rc = new Rectangle(2,3);
            //Console.WriteLine($"{rc} has area {Area(rc)}");

            //Rectangle sq = new Square(); //holding Rectangle reference to a Square
            //sq.Width = 4;
            //Console.WriteLine($"{sq} has area {Area(sq)}");
            ////}

            Console.ReadKey();
        }

        ////03 Liskov Substitution Principle p2 {
        //static public int Area(Rectangle r) => r.Width * r.Height;
        ////}
    }
}
