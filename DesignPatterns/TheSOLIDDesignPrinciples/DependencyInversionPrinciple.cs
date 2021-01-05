using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//high level parts of the system should not depend on low level parts of the system directly
//that insead it should depend on some kind of abstraction
namespace DesignPatterns.TheSOLIDDesignPrinciples
{
    public enum Relationship
    {
        Parent,
        Child,
        Sibling
    }

    public class Person
    {
        public string Name;
        //
    }

    //low-level
    public class Relationshps
    {
        private List<(Person, Relationship, Person)> relations = new List<(Person, Relationship, Person)>();

    }

    class DependencyInversionPrinciple
    {
        
    }
}
