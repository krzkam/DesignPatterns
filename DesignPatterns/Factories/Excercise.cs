using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Factories
{

 
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }

        private static int instances = 0;

        public Person(string name)
        {            
            this.Name = name;
            this.Id = instances;
            instances++;
            
        }
        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(Name)}: {Name}";
        }
    }

    public class PersonFactory
    { 
        public Person NewPerson(string personsName)
        {
            return new Person(personsName);
        } 
    }
}
