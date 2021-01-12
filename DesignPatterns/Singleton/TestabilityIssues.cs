using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Singleton
{
    public interface IDatabase2
    {
        int GetPopulation(string name);
    }



    public class SingletonDatabase2 : IDatabase2
    {
        private Dictionary<string, int> capitals;

        private SingletonDatabase2()
        {
            Console.WriteLine("Initializing database");

            capitals = File.ReadAllLines("capitals.txt")
                .Batch(2)
                .ToDictionary(
                    list => list.ElementAt(0).Trim(),
                    list => int.Parse(list.ElementAt(1))
                );
        }
        public int GetPopulation(string name)
        {
            return capitals[name];
        }

        private static Lazy<SingletonDatabase2> instance = new Lazy<SingletonDatabase2>(() => new SingletonDatabase2());
        public static SingletonDatabase2 Instance => instance.Value;
    }

}