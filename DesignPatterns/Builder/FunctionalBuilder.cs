using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//we made Functional Builder into useable component which we can call wherever 
namespace DesignPatterns.Builder
{
    public class Person2
    {
        public string Name, Position;
    }
    //public sealed class PersonBuilder2 //sealed - you can not inherit from it
    //{
    //    private readonly List<Func<Person2, Person2>> actions = new List<Func<Person2, Person2>>();

    //    public PersonBuilder2 Called(string name)=>Do(p=>p.Name = name);

    //    public PersonBuilder2 Do(Action<Person2> action) => AddAction(action);

    //    public Person2 Build() => actions.Aggregate(new Person2(), (p, f) => f(p));

    //    private PersonBuilder2 AddAction(Action<Person2> action)
    //    {
    //        actions.Add(p => { action(p);
    //            return p; });
    //        return this;

    //    }
    //}

    //Generic way:
    public abstract class FunctionalBuilder<TSubject, TSelf> where TSelf : FunctionalBuilder<TSubject, TSelf> where TSubject : new()
    {
        private readonly List<Func<Person2, Person2>> actions = new List<Func<Person2, Person2>>();

        //public TSelf Called(string name) => Do(p => p.Name = name);

        public TSelf Do(Action<Person2> action) => AddAction(action);

        public Person2 Build() => actions.Aggregate(new Person2(), (p, f) => f(p));

        private TSelf AddAction(Action<Person2> action)
        {
            actions.Add(p =>
            {
                action(p);
                return p;
            });
            return (TSelf) this;
        }
    }

    public sealed class PersonBuilder2 : FunctionalBuilder<Person2, PersonBuilder2>
    {
        public PersonBuilder2 Called(string name) => Do(p => p.Name = name);
    }

    public static class PersonBuilderExtensions
    {
        public static PersonBuilder2 WorksAs(this PersonBuilder2 builder, string position) => builder.Do(p => p.Position = position);
    }

    class FunctionalBuilder
    {
    }
}

 
