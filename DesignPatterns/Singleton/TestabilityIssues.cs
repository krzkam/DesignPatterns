using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
//using Autofac;
using MoreLinq;
using NUnit.Framework;
using static System.Console;

namespace DesignPatterns.Singleton
{
    public interface IDatabase2
    {
        int GetPopulation(string name);
    }

    public class SingletonDatabase2 : IDatabase2
    {
        private Dictionary<string, int> capitals;
        private static int instanceCount; //0
        public static int Count => instanceCount;

        private SingletonDatabase2()
        {
            instanceCount++;

            Console.WriteLine("Initializing database");

            //capitals = File.ReadAllLines("capitals.txt")
            //    .Batch(2)
            //    .ToDictionary(
            //        list => list.ElementAt(0).Trim(),
            //        list => int.Parse(list.ElementAt(1))
            //    );

            capitals = File.ReadAllLines(
                Path.Combine(new FileInfo(typeof(IDatabase2).Assembly.Location).DirectoryName,
                "capitals.txt")
                )
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

    public class SingletonRecordFinder
    {
        public int GetTotalPopulation(IEnumerable<string> names)
        {
            int result = 0;
            foreach (var name in names)
            {
                result += SingletonDatabase2.Instance.GetPopulation(name);
            }
            return result;
        }
    }

    [TestFixture]
    public class SingletonTest
    {
        [Test]
        public void IsSingletonTest()
        {
            var db = SingletonDatabase2.Instance;
            var db2 = SingletonDatabase2.Instance;
            Assert.That(db, Is.SameAs(db2));
            Assert.That(SingletonDatabase2.Count, Is.EqualTo(1));

        }

        [Test]
        public void SingletonTotalPopulationTest()
        {
            var rf = new SingletonRecordFinder();
            var names = new[] {"Seoul","Mexico City"};
            int tp = rf.GetTotalPopulation(names);
            Assert.That(tp, Is.EqualTo(17500000+174000000));
        }
    }

}