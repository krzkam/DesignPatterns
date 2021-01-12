using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using DesignPatterns.TheSOLIDDesignPrinciples;
//using DesignPatterns.Builder;
//using DesignPatterns.Factories;
//using DesignPatterns.Prototype;
using DesignPatterns.Singleton;
namespace DesignPatterns
{
    class Program 
    {
        static void Main(string[] args)
        ////12 Asynchronous Factory Method p2 {
        //public static async Task Main(string[] args)
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
            ////06 Life Without Builder {            
            ////low-level builder which build the string
            //var hello = "hello";
            //var sb = new StringBuilder();
            //sb.Append("<p>");
            //sb.Append(hello);
            //sb.Append("</p>");
            //Console.WriteLine(sb);

            ////more complicated:
            //var words = new[] { "hello","world"};
            //sb.Clear();
            //sb.Append("<ul>");
            //foreach (var word in words)
            //{
            //    //sb.AppendFormat("<li>{0}</li>",word);
            //    sb.Append("<li>"+ word + "</li>");
            //}
            //sb.Append("</ul>");
            //Console.WriteLine(sb);
            ////}
            ////07 Builder {
            //// we'd rather this whole thing with html was presented in some kind three, structured format. 
            ////This is the reason that we'd like to want some kind of HTML BUILDER, so that we can build up different HTML objects with nice API
            //// 08 Fluent builder (interface): interface which allows you to chain several calls by returning a reference to the object you're working with
            //var builder = new HtmlBuilder("ul");
            //builder.AddChild("li", "hello").AddChild("li", "world");
            //Console.WriteLine(builder.ToString());
            ////}
            ////09 Fluent Builder Inheritance with Recursive Generics {
            //var me = Person.New.Called("John").WorksAsA("Programmer").Build();
            //Console.WriteLine(me);
            ////}
            ////10 Functional Builder {
            //var person = new PersonBuilder2().Called("Sarah").WorksAs("Developer").Build();
            ////}
            ////11 Faceted Builder{
            //var pb = new PersonBuilder3();
            //Person3 person3 = pb.
            //    Works.At("Fabrica").AsA("Engineer").Earning(123000).
            //    Lives.At("Grudziadzka").In("Torun").WithPostCode("87-100");
            //Console.WriteLine(person3);
            ////}
            //Builder Excercise
            //var cb = new CodeBuilder("Person").AddField("Name","string").AddField("Age","int");
            //Console.WriteLine(cb);
            //Factories
            //Factory - component resposible solely for the wholesale (not piecewise) creation of objects)
            //Motivation:
            //Object creation logic becomes too convoluted
            //Constrictor is not descriptive
            //  - Name mandated by name of containing type
            //  - Cannot overload with same set of arguments with different names
            //  - Can turn into 'optional parameter hell'
            //Object creation can be outsourced to:
            //  - A separate function (Factory Method)
            //  - That may exist in a separate class (Factory)
            //  - Can create hierarchy of factories with Abstract Factory
            ////11 Factory Method {
            //var point = Point.NewPolarPoint(1.0, Math.PI / 2);
            //Console.WriteLine(point);
            //// }
            ////12 Asynchronous Factory Method p1 {
            ////var foo = new Foo();
            ////await foo.InitAsync();
            //Foo x = await Foo.CreateAsync();            
            //// }
            ////13 Factory {
            //var point = PointFactory.NewPolarPoint2(1.0, Math.PI / 2);
            //Console.WriteLine(point);
            //// }
            ////14 Inner Factory
            //var point = Point3.Factory2.NewPolarPoint2(1.0, Math.PI / 2);
            //Console.WriteLine(point);
            //var origin = Point3.Origin;
            //var origin2 = Point3.Origin2;
            //// }
            //15 & 16 AbstractFactory And Open-Close Principle {
            //var machine = new HotDrinkMachine();
            ////var drink = machine.MakeDrink(HotDrinkMachine.AvailableDrink.Tea, 100);
            ////drink.Consume();
            //var drink = machine.MakeDrink();
            //drink.Consume();
            // }
            ////Factories Excercise 
            //var p = new PersonFactory().NewPerson("John");
            //var p2 = new PersonFactory().NewPerson("Andrew");
            //Console.WriteLine(p.ToString());
            //Console.WriteLine(p2.ToString());
            //Prototype
            //A partially or fully initialized object that you copy (clone) and make use of
            ////17 ICloneable is Bad {
            //var john = new Person(new[] { "John","Smith"}, new Address("London Road",123));
            //Console.WriteLine(john);

            //var jane = (Person)john.Clone();
            //jane.Address.HouseNumber = 321;

            //Console.WriteLine(jane);
            ////}
            ////18 Copy Constructor {
            //var john = new Person2(new[] { "John", "Smith" }, new Address2("London Road", 123));
            //Console.WriteLine(john);

            //var jane = new Person2(john);
            //jane.Address.HouseNumber = 321;

            //Console.WriteLine(jane);
            ////}
            ////19 Explicit Deep Copy Interface {
            //var john = new Person3(new[] { "John", "Smith" }, new Address3("London Road", 123));
            //Console.WriteLine(john);

            //var jane = john.DeepCopy();
            //jane.Address.HouseNumber = 321;

            //Console.WriteLine(jane);
            ////}
            ////20 Copy Through Serialization {
            //var john = new Person4(new[] { "John", "Smith" }, new Address4("London Road", 123));
            //Console.WriteLine(john);

            ////var jane = john.DeepCopy();
            //var jane = john.DeepCopyXml();
            //jane.Names[0] = "Jane";
            //jane.Address.HouseNumber = 321;

            //Console.WriteLine(jane);
            ////}
            //Excercise
            //var line1 = new Line(new Point(1, 2), new Point(3, 5));
            //var line2 = line1.DeepCopy();
            ////line2.Start = new Point(10, 10);
            //line2.End = new Point(50, line1.End.Y);

            //Console.WriteLine(line1);
            //Console.WriteLine(line2);
            //Singleton - component which is instantiated only once and which tries to resist the idea of beeing instantiated more than once
            ////21 Singleton Implementation {
            //var db = SingletonDatabase.Instance;
            //var city = "Tokyo";
            //Console.WriteLine($"{city} has population {db.GetPopulation(city)}");
            ////}
            //22 Testability Issues {

            //}
            //23 Singleton in Dependency Injection{

            //}
            //24 Monostate {

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
