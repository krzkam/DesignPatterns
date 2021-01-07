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

    //low-level module
    public class Relationshps : IRelationshipBrowser
    {
        private List<(Person, Relationship, Person)> relations = new List<(Person, Relationship, Person)>();

        public void AddParentAndChild(Person parent, Person child)
        {
            relations.Add((parent, Relationship.Parent, child));
            relations.Add((child, Relationship.Parent, parent));
        }

        public IEnumerable<Person> FindAllChildrenOf(string name)
        {
            foreach (var r in relations.Where(
                x => x.Item1.Name == name &&
                x.Item2 == Relationship.Parent
                ))
            {
                yield return r.Item3;
            }
        }

        //one way: expose private field as public property
        //public List<(Person, Relationship, Person)> relationsPublic => relations; 


    }

    //better way: abstraction by defining an interface for how the relationships acctualy allows you to access certain high level data
    //we have low level module but instead of depending on low level module we depend on abstraction which is the IRelationshipBrowser
    public interface IRelationshipBrowser
    {
        IEnumerable<Person> FindAllChildrenOf(string name);
    }

}
