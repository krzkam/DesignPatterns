using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Autofac.Features.Metadata;
using MoreLinq;
using NUnit.Framework;
using JetBrains.dotMemoryUnit;
using MediatR;
using System.Threading; 
using System.Reactive.Linq;


//using DesignPatterns.Bridge;
//using MoreLinq.Extensions;
//using DesignPatterns.TheSOLIDDesignPrinciples;
//using DesignPatterns.Builder;
//using DesignPatterns.Factories;
//using DesignPatterns.Prototype;
//using DesignPatterns.Singleton;
//using DesignPatterns.Adapter;
//using DesignPatterns.Composite;
//using DesignPatterns.Decorator;
//using DesignPatterns.Flyweight;
//using DesignPatterns.Proxy;
//using DesignPatterns.ChainOfResponsibility;
//using DesignPatterns.Command;
//using DesignPatterns.Interpreter;
//using DesignPatterns.Iterator;
//using DesignPatterns.Mediator;
//using DesignPatterns.Memento;
//using DesignPatterns.NullObject;
using DesignPatterns.Observer;

namespace DesignPatterns
{
    //[TestFixture]
    //
    class Program //Observer via Special Interfaces p2 : IObserver<Event> 
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
            ////24 Monostate {
            //var ceo = new CEO();
            //ceo.Name = "Adam Smith";
            //ceo.Age = 55;

            //var ceo2 = new CEO();
            //Console.WriteLine(ceo2);
            ////}
            ////25 Per-Thread Singleton {
            //var t1 = Task.Factory.StartNew(() =>
            //{
            //    Console.WriteLine("t1: " + PerThreadSingleton.Instance.Id);
            //});
            //var t2 = Task.Factory.StartNew(() =>
            //{
            //    Console.WriteLine("t2: " + PerThreadSingleton.Instance.Id);
            //    Console.WriteLine("t2: " + PerThreadSingleton.Instance.Id);
            //});
            //Task.WaitAll(t1, t2);
            ////}
            ////26 Ambient Context {
            //var house = new Building();
            //using (new BuildingContext(3000))
            //{
            //    //ground 3000
            //    house.Walls.Add(new Wall(new Point(0, 0), new Point(5000, 0)));
            //    house.Walls.Add(new Wall(new Point(0, 0), new Point(0, 4000)));

            //    using (new BuildingContext(3500))
            //    {
            //        //1st 3500
            //        house.Walls.Add(new Wall(new Point(0, 0), new Point(6000, 0)));
            //        house.Walls.Add(new Wall(new Point(0, 0), new Point(0, 4000)));
            //    }
            //    //ground 3000
            //    house.Walls.Add(new Wall(new Point(5000, 0), new Point(5000, 4000)));
            //}
            //Console.WriteLine(house);
            ////}
            //Adapter - construct which adapts an existing interface X to conform to the required interface Y. 
            ////27 Vector/Raster Demo p1 {
            //Draw();
            //Draw();
            ////}
            ////28 Adapter Caching p1{
            //Draw2();
            //Draw2();
            ////}
            ////29 Generic Value Adapter{
            //var v = new Vector2i();
            //v[0] = 0;

            //var vv = new Vector2i(3,2);

            ////var result = v + vv;

            //var u = Vector3f.Create(3.5f, 2.2f, 1);
            ////}
            ////30 Adapter in Dependency Injection {

            //var b = new ContainerBuilder();
            //b.RegisterType<SaveCommand>().As<ICommand>().WithMetadata("Name","Save");
            //b.RegisterType<OpenCommand>().As<ICommand>().WithMetadata("Name", "Open");
            ////b.RegisterType<Button>();
            ////b.RegisterAdapter<ICommand, Button>(cmd=>new Button(cmd));
            //b.RegisterAdapter<Meta<ICommand>, Button>(cmd=>new Button(cmd.Value,(string)cmd.Metadata["Name"]));
            //b.RegisterType<Editor>();

            //using (var c = b.Build())
            //{
            //    var editor = c.Resolve<Editor>();
            //    foreach (var btn in editor.Buttons)
            //    {
            //        btn.PrintMe();
            //    }

            //}
            ////}
            //Exercise
            //var sq = new Square();
            //sq.Side = 10;
            ////Console.WriteLine(sq.Side);
            //var adapter = new SquareToRectangleAdapter(sq);
            //Console.WriteLine(adapter.Area());

            //Bridge - connecting different components through abstraction - mechanizm that decouples an interface (hierarchy) from an implementation (hierarchy)
            ////31 Bridge {
            ////IRenderer renderer = new RasterRenderer();
            ////var renderer = new VectorRenderer();
            ////var circle = new Circle(renderer, 5);

            ////circle.Draw();
            ////circle.Resize(2);
            ////circle.Draw();

            //var cb = new ContainerBuilder();
            //cb.RegisterType<VectorRenderer>().As<IRenderer>().SingleInstance();

            //cb.Register((c, p) => new Circle(c.Resolve<IRenderer>(), p.Positional<float>(0)));

            //using (var c = cb.Build())
            //{
            //    var circle = c.Resolve<Circle>(
            //        new PositionalParameter(0, 5.0f)
            //        );
            //    circle.Draw();
            //    circle.Resize(2);
            //    circle.Draw();
            //}
            ////}

            //Exercise
            //Console.WriteLine(new Triangle(new RasterRenderer2()).ToString());
            //Console.WriteLine(new Square(new RasterRenderer2()).ToString());

            //Console.WriteLine(new Triangle(new VectorRenderer2()).ToString());
            //Console.WriteLine(new Square(new VectorRenderer2()).ToString());

            //Composite - mechanism for treating individual (scalar) objects and compositions of objects in uniform manner
            //Objects use other objects' fields/properties/members through inheritance and composition
            //Composition lets us make compound objects
            //  - E.g., a mathematical expression composed of simple expressions; 
            //  - A grouping of shapes that consists of several shapes
            //Composite design patter is used to treat both single (scalar) and composite object uniformly
            ////32 Geometric Shapes {
            //var drawing = new GraphicObject { Name = "My Drawing" };
            //drawing.Children.Add(new Square { Color = "Red" });
            //drawing.Children.Add(new Circle { Color = "Yellow" });

            //var group = new GraphicObject();
            //group.Children.Add(new Circle { Color = "Blue" });
            //group.Children.Add(new Square { Color = "Blue" });

            //drawing.Children.Add(group);

            //Console.WriteLine(drawing);
            // }
            ////33 Neural Networks {
            //var neuron1 = new Neuron();
            //var neuron2 = new Neuron();

            //neuron1.ConnectTo(neuron2);

            //var layer1 = new NeuronLayer();
            //var layer2 = new NeuronLayer();

            //neuron1.ConnectTo(layer1);
            //layer1.ConnectTo(layer2);
            //// }
            //34 Composite Specification {

            //}
            ////Exercise
            //SingleValue sing = new SingleValue();
            //sing.Value = 1;

            //SingleValue sing2 = new SingleValue();
            //sing2.Value = 2;

            //SingleValue sing3 = new SingleValue();
            //List<IValueContainer> values = new List<IValueContainer>();
            //values.Add(sing);
            //values.Add(sing2);
            //Console.WriteLine(values.Sum());

            //Decorator - add behavior to the clas without editing the classes itself
            //35 Custom String Builder{

            ////}
            ////36 Adapter-Decorator{
            //MyStringBuilder s = "hello ";
            //s += "world";
            //Console.WriteLine(s);
            ////}
            //// 37 Multiple Inheritance with Interfaces {
            //var d = new Dragon();
            //d.Weight = 100;
            //d.Fly();
            //d.Crawl();
            //// }
            ////38 Multiple Inheritance with Default Interface Members {
            //Dragon2 d = new Dragon2 { Age = 5 };
            ////}
            ////39 Dynamic Decorator Composition{
            //var square = new Square(1.23f);
            //Console.WriteLine(square.AsString());

            //var redSquare = new ColoredSquare(square, "red");
            //Console.WriteLine(redSquare.AsString());

            //var redHalfTransparentSquare = new TransparentShape(redSquare, 0.5f);
            //Console.WriteLine(redHalfTransparentSquare.AsString());
            ////}

            ////40 Static Decorator Composition {
            //var circle = new TransparentShape<ColoredShape<Circle2>>(0.4f);
            //Console.WriteLine(circle.AsString());
            ////}
            ////41 Decorator in Dependency Injection {
            //var b = new ContainerBuilder();
            //b.RegisterType<ReportingService>().Named<IReportService>("reporting");
            //b.RegisterDecorator<IReportService>(                
            //    (context, service) => new ReportingServiceWithLogging(service), "reporting");

            //using (var c = b.Build())
            //{
            //    var r = c.Resolve<IReportService>();
            //    r.Report();
            //}
            ////}
            ////Exercise {
            //    var d = new Dragon2();
            //    d.Age = 100;
            //    d.Fly();
            //    d.Crawl();
            ////}
            //Flyweight - space optimization that lets us use less memory by storing externally the data associated with similar objects
            // - avoid redundancy when storing data
            //      *Plenty of users with identical first/last names
            //      *No sens in storing same first/last name over and over again
            //      *Store a list of names and pointer to them
            // - .NET performs string intering, so an identical string is stored only once

            ////42 Repeating User Names p1{

            ////}
            ////43 Text Formatting{
            //var ft = new FormattedText("This is a brave new world");
            //ft.Capitalize(10, 15);
            //Console.WriteLine(ft);
            //var bft = new BetterFormatterText("This is a brave new world");
            //bft.GetRange(10, 15).Capitalize = true; ;
            //Console.WriteLine(bft);
            ////}
            //Exercise
            //var sentence = new Sentence("hello world");
            //sentence[1].Capitalize = true;
            //Console.WriteLine(sentence);

            //Proxy - interface for accessing particular resource by replicating this interface. That resource may be remote, expensive to construct, or may require logging or some other added functionality.
            ////44 Protection Proxy {
            //ICar car = new CarProxy(new Driver(12));
            //car.Drive();
            //////}
            ////45 Property Proxy {
            //var c = new Creature();
            //c.Agility = 10;
            ////}
            //// 46 Value Proxy p1{
            //Console.WriteLine(10f*5.Percent());
            //Console.WriteLine(2.Percent()+3.Percent());
            ////
            //// 47 Composite Proxy: SoA/AoS {
            ////AoS
            //var creatures = new Creature2[100];

            //foreach (var c in creatures)
            //{
            //    c.X++;
            //}

            ////AoS/SoA duality
            //var creatures2 = new Creatures(100); //SoA
            //foreach (Creatures.CreatureProxy c in creatures2)
            //{
            //    c.X++;
            //}
            ////
            //48 Composite Proxy with Array - Backed Properties {

            //}
            ////49 Dynamic Proxy for Logging {
            ////var ba = new BankAccount();
            //var ba = Log<BankAccount>.As<IBankAccount>();

            //ba.Deposit(100);
            //ba.Withdraw(50);
            //Console.WriteLine(ba); 
            ////}
            //50 ViewModel {

            //}

            //Chain of Responsibility - chain of components who all get a change to processs a command or a query, 
            //optionally having default processing implementation and an ability to terminate the processing chain
            //51 Command Query Separation - having separate measn of sending commands and queries to e.g., direct fields access
            ////52 Method Chain {
            //var goblin = new Creature("Goblin",2,2);
            //Console.WriteLine(goblin);

            //var root = new CreatureModifier(goblin);

            //root.Add(new NoBonusesModifier(goblin));

            //Console.WriteLine("Let's double the goblin's attack");
            //root.Add(new DoubleAttackModifier(goblin));


            //Console.WriteLine("Let's increase the goblin's defense");
            //root.Add(new IncreasedDefenseModifier(goblin));


            //root.Handle();
            //Console.WriteLine(goblin);

            ////}

            ////53 Broker Chain {
            //var game = new Game();
            //var goblin = new Creature2(game, "Strong Goblin",3,3);
            //Console.WriteLine(goblin);

            //using(new DoubleAttackModifier2(game, goblin))
            //{
            //    Console.WriteLine(goblin);
            //    using (new IncreaseDefenseModifier(game, goblin))
            //    {
            //        Console.WriteLine(goblin);
            //    }
            //}
            //Console.WriteLine(goblin);
            //}

            //Command - An object which represents an instruction to perform a particular action. Contains all the information necessary for the action to be taken.
            ////54 Command {
            //var ba = new BankAccount();
            //var commands = new List<BankAccountCommand>
            //{
            //    new BankAccountCommand(ba,BankAccountCommand.Action.Deposit,100),
            //    new BankAccountCommand(ba,BankAccountCommand.Action.Withdraw,50)
            //};
            //Console.WriteLine(ba);

            //foreach (var c in commands)
            //{
            //    c.Call();
            //}
            //Console.WriteLine(ba);

            ////}

            ////55 Undo Operations {
            //var ba = new BankAccount2();
            //var commands = new List<BankAccountCommand2>
            //{
            //    new BankAccountCommand2(ba,BankAccountCommand2.Action.Deposit,100),
            //    new BankAccountCommand2(ba,BankAccountCommand2.Action.Withdraw,50)
            //};
            //Console.WriteLine(ba);

            //foreach (var c in commands)
            //{
            //    c.Call();
            //}
            //Console.WriteLine(ba);

            //foreach (var c in Enumerable.Reverse(commands))
            //{
            //    c.Undo();
            //}
            //Console.WriteLine(ba);
            ////}
            ///
            //    //Interpreter - A component that processes structured text data. 
            //    //Does so by turning it into separate lexical tokens (lexing) and then interpreting sequences of said tokens (parsing)
            //    //56, 57 Handmade Interpreter: Lexing - Parsing p1 {
            //    //

            //    var input = "(13+4)-(12+1)";
            //    var tokens = Lex(input);
            //    Console.WriteLine(string.Join("\t", tokens));

            //    var parsed = Parse(tokens);
            //    Console.WriteLine($"{input} = {parsed.Value}");
            //    //}
            // Iterator = an object (or, in .NET, a method) that facilitates the passing of a data structure
            //58 Iterator Object
            //59 Iterator Method
            //   1
            //  / \
            // 2   3
            //in-order 213

            //var root = new Node<int>(1,
            //    new Node<int>(2), new Node<int>(3));

            //var it = new InOrderIterator<int>(root);
            //while (it.MoveNext())
            //{
            //    Console.Write(it.Current.Value);
            //    Console.Write(',');
            //}
            //Console.WriteLine();

            //var tree = new BinaryTree<int>(root);
            //Console.WriteLine(string.Join(",",
            //    tree.InOrder.Select(x=>x.Value)));

            //60 Interators and Duck Typing
            //var root = new Node<int>(1,
            //    new Node<int>(2), new Node<int>(3));

            //var tree = new BinaryTree<int>(root);
            //foreach (var node in tree)
            //    Console.WriteLine(node.Value);

            //61 Array-Backed Properties

            //Mediator - a component that facilitates communication between other componens without them necessarily being aware of each other or having direct (reference) access to each other
            //62 Chat Room {
            //var room = new ChatRoom();

            //var john = new Person("John");
            //var jane = new Person("Jane");

            //room.Join(john);
            //room.Join(jane);


            //john.Say("hi");
            //john.Say("oh, hey john");

            //var simon = new Person("Simon");
            //room.Join(simon);
            //simon.Say("hi everyone!");

            //jane.PrivateMessage("Simon", "glad you could join us");

            //}

            //63 Event Broker {
            //var cb = new ContainerBuilder();
            //cb.RegisterType<EventBroker>().SingleInstance();
            //cb.RegisterType<FootbalCoach>();
            //cb.Register((c,p)=>
            //    new FootbalPlayer(
            //        c.Resolve<EventBroker>(),
            //        p.Named<string>("name")
            //        ));

            //using (var c = cb.Build())
            //{
            //    var coach = c.Resolve<FootbalCoach>();
            //    var player1 = c.Resolve<FootbalPlayer>(new NamedParameter("name","John"));
            //    var player2 = c.Resolve<FootbalPlayer>(new NamedParameter("name", "Chris"));

            //    player1.Score();
            //    player1.Score();
            //    player1.Score();
            //    player1.AssautlReferee();
            //    player2.Score();
            //}
            //}

            //64 Introduction to MediatR  

            //Memento - A token/handle representing the system state. Lets us roll back to the state when the token was generated. May or may not directly expose state information.
            ////65 Memento {

            //var ba = new BankAccount(100);
            //var m1 = ba.Deposit(50); //150
            //var m2 = ba.Deposit(25); //175
            //Console.WriteLine(ba);

            //ba.Restore(m1);
            //Console.WriteLine(ba);

            //ba.Restore(m2);
            //Console.WriteLine(ba);
            ////}
            //66 Undo and Redo {
            //var ba = new BankAccount(100);
            //ba.Deposit(50);
            //ba.Deposit(25);
            //Console.WriteLine(ba);

            //ba.Undo();
            //Console.WriteLine($"undo 1: {ba}");
            //ba.Undo();
            //Console.WriteLine($"undo 2: {ba}");
            //ba.Redo();
            //Console.WriteLine($"Redo 1: {ba}");

            //}

            //Null Object - building an object that conforms to the requeired interface, satisfying a dependency requirement of some other object but does nothing at all
            ////67 Null Object {
            ////var log = new ConsoleLog();
            ////var ba = new BankAccount(null);
            ////ba.Deposit(100);
            //var cb = new ContainerBuilder();

            //cb.RegisterType<BankAccount>();
            //cb.RegisterType<NullLog>().As<ILog>();
            //using (var c = cb.Build())
            //{
            //    var ba = c.Resolve<BankAccount>();
            //    ba.Deposit(100);
            //}
            ////}
            //// 68 Dynamic Null Object {
            //var log = Null<ILog>.Instance;
            //log.Info("dasda");
            //var ba = new BankAccount(log);
            //ba.Deposit(100);

            ////}

            //Observer - an observer is an object that wishes to be informed about events happening in the system. The entity generating the events is an observable.
            ////69 Observer via the 'event' Keyword p1 {
            //var person = new Person();

            //person.FallsIll += CallDoctor;

            //person.CatchACold();

            //person.FallsIll -= CallDoctor;
            ////}
            //70 Weak Event Pattern p1 {
            //var btn = new Button();
            //var window = new Window(btn);
            //var windowRef = new WeakReference(window);

            //btn.Fire();

            //Console.WriteLine("Setting window to null");
            //window = null;

            //FireGC();
            //Console.WriteLine($"Is the window alive after GC? {windowRef.IsAlive}");
            //}
            //71 Observer via Special Interfaces p1 {
            // Rx
            // IObserver IObservable
            //}
            Console.ReadKey();


        }

        //////03 Liskov Substitution Principle p2 {
        ////static public int Area(Rectangle r) => r.Width * r.Height;
        //////}

        //////05 Dependency Inversion Principle p2{
        ////high-level module
        ////public Program(Relationshps relationshps)
        ////{
        ////    var relations = relationshps.relationsPublic;
        ////    foreach (var r in relations.Where(
        ////        x => x.Item1.Name == "John" &&
        ////        x.Item2 == Relationship.Parent
        ////        ))
        ////    {
        ////        Console.WriteLine($"Johnk has a child called {r.Item3.Name}");
        ////    }
        ////}

        //////better way: we can build another constructor, but this time we don't depend on Relationships instead we depend on interface
        ////public Program(IRelationshipBrowser browser)
        ////{
        ////    foreach (var p in browser.FindAllChildrenOf("John"))
        ////    {
        ////        Console.WriteLine($"Johnk has a child called {p.Name}");
        ////    }
        ////}
        //////}

        //////27 Vector/Raster Demo p2 {
        ////public static void DrawPoint(Point p)
        ////{
        ////    Console.Write(".");
        ////}
        ////private static readonly List<VectorObject> vectorObjects
        ////    = new List<VectorObject>
        ////    {
        ////        new VectorRectangle(1,1,10,10),
        ////        new VectorRectangle(3,3,6,6)
        ////    };
        ////private static void Draw()
        ////{
        ////    foreach (var vo in vectorObjects)
        ////    {
        ////        foreach (var line in vo)
        ////        {
        ////            var adapter = new LineToPointAdapter(line);
        ////            adapter.ForEach(DrawPoint);
        ////        }
        ////    }
        ////}
        //////28 Adapter Caching p2{
        ////public static void DrawPoint2(Point2 p)
        ////{
        ////    Console.Write(".");
        ////}
        ////private static readonly List<VectorObject2> vectorObjects2
        ////    = new List<VectorObject2>
        ////    {
        ////        new VectorRectangle2(1,1,10,10),
        ////        new VectorRectangle2(3,3,6,6)
        ////    };
        ////private static void Draw2()
        ////{
        ////    foreach (var vo in vectorObjects2)
        ////    {
        ////        foreach (var line in vo)
        ////        {
        ////            var adapter = new LineToPointAdapter2(line);
        ////            adapter.ForEach(DrawPoint2);
        ////        }
        ////    }
        ////}
        //////}
        //////42 Repeating User Names p2{
        ////[Test]
        ////public void TestUser()
        ////{
        ////    var firstNames = Enumerable.Range(0, 100).Select(_ => RandomString());
        ////    var lastNames = Enumerable.Range(0, 100).Select(_ => RandomString());

        ////    var users = new List<User>();

        ////    foreach (var firstName in firstNames)
        ////    {
        ////        foreach (var lastName in lastNames)
        ////        {
        ////            users.Add(new User($"{firstName} {lastName}"));
        ////        }
        ////    }
        ////    ForceGC();

        ////    dotMemory.Check(memory =>
        ////    {
        ////        Console.WriteLine(memory.SizeInBytes);
        ////    });
        ////}

        ////private void ForceGC()
        ////{
        ////    GC.Collect();
        ////    GC.WaitForPendingFinalizers();
        ////    GC.Collect();
        ////}
        ////private string RandomString()
        ////{
        ////    Random rand = new Random();
        ////    return new string(Enumerable.Range(0, 10).Select(i => (char)('a' + rand.Next(26))).ToArray());
        ////}
        ////// }
        ////56, 57 Handmade Interpreter: Lexing - Parsing p2 {
        //static List<Token> Lex(string input)
        //{
        //    var result = new List<Token>();
        //    for (int i = 0; i < input.Length; i++)
        //    {
        //        switch (input[i])
        //        {
        //            case '+':
        //                result.Add(new Token(Token.Type.Plus, "+"));
        //                break;
        //            case '-':
        //                result.Add(new Token(Token.Type.Plus, "-"));
        //                break;
        //            case '(':
        //                result.Add(new Token(Token.Type.Plus, "("));
        //                break;
        //            case ')':
        //                result.Add(new Token(Token.Type.Plus, ")"));
        //                break;
        //            default:
        //                var sb = new StringBuilder(input[i].ToString());
        //                for (int j = i + 1; j < input.Length; ++j)
        //                {
        //                    if (char.IsDigit(input[j]))
        //                    {
        //                        sb.Append(input[j]);
        //                        ++i;
        //                    }
        //                    else
        //                    {
        //                        result.Add(new Token(Token.Type.Integer, sb.ToString()));
        //                    }
        //                }
        //                break;
        //        }
        //    }
        //    return result;
        //}

        //static IElement Parse(IReadOnlyList<Token> tokens)
        //{
        //    var result = new BinaryOperation();
        //    bool haveLHS = false;
        //    for (int i = 0; i < tokens.Count; i++)
        //    {
        //        var token = tokens[i];
        //        switch (token.MyType)
        //        {
        //            case Token.Type.Integer:
        //                var integer = new Integer(int.Parse(token.Text));
        //                if (!haveLHS)
        //                {
        //                    result.Left = integer;
        //                    haveLHS = true; 
        //                }
        //                else
        //                {
        //                    result.Right = integer;
        //                }
        //                break;
        //            case Token.Type.Plus:
        //                result.MyType = BinaryOperation.Type.Addition;
        //                break;
        //            case Token.Type.Minus:
        //                result.MyType = BinaryOperation.Type.Subtraction;
        //                break;
        //            case Token.Type.Lparen:
        //                int j = i;
        //                for (; j < tokens.Count; ++i)
        //                    if (tokens[j].MyType == Token.Type.Rparen)
        //                        break;
        //                var subexpression = tokens.Skip(i + 1).Take(j - i - 1).ToList();
        //                var element = Parse(subexpression);
        //                if (!haveLHS)
        //                {
        //                    result.Left = element;
        //                    haveLHS = true;
        //                }
        //                else
        //                {
        //                    result.Right = element;
        //                }
        //                break;             
        //            default:
        //                throw new ArgumentOutOfRangeException();

        //        }
        //    }
        //    return result;
        //}
        ////}
        ////69 Observer via the 'event' Keyword p2 {
        //private static void CallDoctor(object sender, FallsIllEventArgs eventArgs)
        //{
        //    Console.WriteLine($"A doctor has been called to {eventArgs.Address}");
        //}
        ////}
        //70 Weak Event Pattern p2 {
        //private static void FireGC()
        //{
        //    Console.WriteLine("Starting GC");
        //    GC.Collect();
        //    GC.WaitForPendingFinalizers();
        //    GC.Collect();
        //    Console.WriteLine("GC is done");
        //}
        //}
        ////71 Observer via Special Interfaces p3 {
        //public Program()
        //{
        //    var person = new Person2();
        //    var sub = person.Subscribe(this);

        //    person.OfType<FallsIllEvent>()
        //      .Subscribe(args => Console.WriteLine($"A doctor has been called to {args.Address}"));
        //}

        //public void OnNext(Event value)
        //{
        //    if (value is FallsIllEvent args)
        //        Console.WriteLine($"A doctor has been called to {args.Address}");
        //}

        //public void OnError(Exception error) { }
        //public void OnCompleted() { }
        ////}


    }


}
