﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Abstract Factory use is to give out abstract objects (abstract classes / interfaces)
namespace DesignPatterns.Factories
{
    public interface IHotDrink
    {
        void Consume();

    }

    internal class Tea : IHotDrink
    {
        public void Consume()
        {
            Console.WriteLine("Hot tea");
        }
    }

    internal class Coffee : IHotDrink
    {
        public void Consume()
        {
            Console.WriteLine("Hot coffee");
        }
    }

    public interface IHotDrinkFactory
    {
        IHotDrink Prepare(int amount);

    }

    internal class TeaFactory : IHotDrinkFactory
    {
        public IHotDrink Prepare(int amount)
        {
            Console.WriteLine("Tea Prepare");
            return new Tea();
        }
    }

    internal class CoffeeFactory : IHotDrinkFactory
    {
        public IHotDrink Prepare(int amount)
        {
            Console.WriteLine("Coffee Prepare");
            return new Coffee();
        }
    }

    //public class HotDrinkMachine
    //{
    //    public enum AvailableDrink
    //    {
    //        Coffee, Tea
    //    }

    //    private Dictionary<AvailableDrink, IHotDrinkFactory> factories = new Dictionary<AvailableDrink, IHotDrinkFactory>();

    //    public HotDrinkMachine()
    //    {
    //        foreach (AvailableDrink drink in Enum.GetValues(typeof(AvailableDrink)))
    //        {
    //            var factory = (IHotDrinkFactory)Activator.CreateInstance(Type.GetType("DesignPatterns.Factories." + Enum.GetName(typeof(AvailableDrink),drink)+"Factory"));
    //            factories.Add(drink, factory);
    //        }
    //    }

    //    public IHotDrink MakeDrink(AvailableDrink drink, int amount)
    //    {
    //        return factories[drink].Prepare(amount);
    //    }
    //}

    public class HotDrinkMachine
    {

        private List<Tuple<string, IHotDrinkFactory>> factories = new List<Tuple<string, IHotDrinkFactory>>();
        public HotDrinkMachine()
        {
            foreach (var t in typeof(HotDrinkMachine).Assembly.GetTypes())
            {
                if (typeof(IHotDrinkFactory).IsAssignableFrom(t) && !t.IsInterface)
                {
                    factories.Add(Tuple.Create(
                        t.Name.Replace("Factory",string.Empty),
                        (IHotDrinkFactory)Activator.CreateInstance(t)
                        ));
                }
            }
        }

        public IHotDrink MakeDrink()
        {
            Console.WriteLine("Available drinks: ");
            for (var index = 0; index < factories.Count; index++)
            {
                var tuple = factories[index];
                Console.WriteLine($"{index}: {tuple.Item1}");
            }
            while (true)
            {
                string s;
                if ((s = Console.ReadLine()) != null 
                    && int.TryParse(s, out int i) 
                    && i >= 0 
                    && i < factories.Count)
                {
                    Console.Write("Specify amount: ");
                    s = Console.ReadLine();
                    if (s!=null
                        && int.TryParse(s,out int amount)
                        && amount > 0)
                    {
                        return factories[i].Item2.Prepare(amount);
                    }
                }
                Console.WriteLine("Incorrect input, try again");
            }
        }
    }


}
