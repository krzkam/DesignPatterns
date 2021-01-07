using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPatterns.TheSOLIDDesignPrinciples;
using DesignPatterns.Builder;

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
            ////04 Interface Segregation Principle {
            //}

            ////05 Dependency Inversion Principle p1{
            ////high-level module

            //var parent = new Person { Name = "John" };
            //var child1 = new Person { Name = "Chris" };
            //var child2 = new Person { Name = "Mary" };

            //var relationships = new Relationshps();
            //relationships.AddParentAndChild(parent, child1);
            //relationships.AddParentAndChild(parent, child2);
            ////new Program(relationships);
            //new Program(relationships);
            ////}
            // 06 Life Without Builder {            
            //low-level builder which build the string
            var hello = "hello";
            var sb = new StringBuilder();
            sb.Append("<p>");
            sb.Append(hello);
            sb.Append("</p>");
            Console.WriteLine(sb);

            //more complicated:
            var words = new[] { "hello","world"};
            sb.Clear();
            sb.Append("<ul>");
            foreach (var word in words)
            {
                //sb.AppendFormat("<li>{0}</li>",word);
                sb.Append("<li>"+ word + "</li>");
            }
            sb.Append("</ul>");
            Console.WriteLine(sb);
            //}

            // 07 Builder {
            // we'd rather this whole thing with html was presented in some kind three, structured format. 
            //This is the reason that we'd like to want some kind of HTML BUILDER, so that we can build up different HTML objects with nice API
            var builder = new HtmlBuilder("ul");
            builder.AddChild("li", "hello");
            builder.AddChild("li", "world");
            Console.WriteLine(builder.ToString());
            //}


            Console.ReadKey();
        }

        ////03 Liskov Substitution Principle p2 {
        //static public int Area(Rectangle r) => r.Width * r.Height;
        ////}

        ////05 Dependency Inversion Principle p2{
        //high-level module
        //public Program(Relationshps relationshps)
        //{
        //    var relations = relationshps.relationsPublic;
        //    foreach (var r in relations.Where(
        //        x => x.Item1.Name == "John" &&
        //        x.Item2 == Relationship.Parent
        //        ))
        //    {
        //        Console.WriteLine($"Johnk has a child called {r.Item3.Name}");
        //    }
        //}

        ////better way: we can build another constructor, but this time we don't depend on Relationships instead we depend on interface
        //public Program(IRelationshipBrowser browser)
        //{
        //    foreach (var p in browser.FindAllChildrenOf("John"))
        //    {
        //        Console.WriteLine($"Johnk has a child called {p.Name}");
        //    }
        //}
        ////}

    }
}
