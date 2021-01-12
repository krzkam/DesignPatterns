using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Autofac;
using MoreLinq;
using NUnit.Framework;

namespace DesignPatterns.Singleton
{
    public interface IDatabase3
    {
        int GetPopulation(string name);
    }

    public class SingletonDatabase3 : IDatabase3
    {
        private Dictionary<string, int> capitals;
        private static int instanceCount; //0
        public static int Count => instanceCount;

        private SingletonDatabase3()
        {
            instanceCount++;

            Console.WriteLine("Initializing database");

            capitals = File.ReadAllLines(
                Path.Combine(new FileInfo(typeof(IDatabase3).Assembly.Location).DirectoryName,
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

        private static Lazy<SingletonDatabase3> instance = new Lazy<SingletonDatabase3>(() => new SingletonDatabase3());
        public static SingletonDatabase3 Instance => instance.Value;
    }

    public class OrdinaryDatabase : IDatabase3
    {
        private Dictionary<string, int> capitals;

        public OrdinaryDatabase()
        {
            Console.WriteLine("Initializing database");

            capitals = File.ReadAllLines(
                Path.Combine(new FileInfo(typeof(IDatabase3).Assembly.Location).DirectoryName,
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
    }

    public class SingletonRecordFinder2
    {
        public int GetTotalPopulation(IEnumerable<string> names)
        {
            int result = 0;
            foreach (var name in names)
            {
                result += SingletonDatabase3.Instance.GetPopulation(name);
            }
            return result;
        }
    }

    public class ConfigurableRecordFinder
    {
        IDatabase3 database;
        public ConfigurableRecordFinder(IDatabase3 database)
        {
            this.database = database ?? throw new ArgumentNullException(paramName: nameof(database));
        }

        public int GetTotalPopulation(IEnumerable<string> names)
        {
            int result = 0;
            foreach (var name in names)
            {
                result += database.GetPopulation(name);
            }
            return result;
        }
    }

    public class DummyDatabase : IDatabase3
    {
        public int GetPopulation(string name)
        {
            return new Dictionary<string, int>
            {
                ["alpha"] = 1,
                ["beta"] = 2,
                ["gamma"] = 3
            }[name];
        }
    }

    [TestFixture]
    public class SingletonTest2
    {
        [Test]
        public void IsSingletonTest2()
        {
            var db = SingletonDatabase3.Instance;
            var db2 = SingletonDatabase3.Instance;
            Assert.That(db, Is.SameAs(db2));
            Assert.That(SingletonDatabase3.Count, Is.EqualTo(1));

        }

        [Test]
        public void SingletonTotalPopulationTest()
        {
            var rf = new SingletonRecordFinder2();
            var names = new[] { "Seoul", "Mexico City" };
            int tp = rf.GetTotalPopulation(names);
            Assert.That(tp, Is.EqualTo(17500000 + 174000000));
        }

        [Test]
        public void ConfigurePopulationTest()
        {
            var rf = new ConfigurableRecordFinder(new DummyDatabase());
            var names = new[] {"alpha","gamma" };
            int tp = rf.GetTotalPopulation(names);
            Assert.That(tp, Is.EqualTo(4));
        }

        [Test]
        public void DIPopulationTest()
        {
            var cb = new ContainerBuilder();
            cb.RegisterType<OrdinaryDatabase>().As<IDatabase3>().SingleInstance();
            cb.RegisterType<ConfigurableRecordFinder>();
            using(var c = cb.Build())
            {
                var rf = c.Resolve<ConfigurableRecordFinder>();
            }

        }
    }

}