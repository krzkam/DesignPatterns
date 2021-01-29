using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Proxy
{
    public class Person3
    {
        public int Age { get; set; }

        public string Drink()
        {
            return "drinking";
        }

        public string Drive()
        {
            return "driving";
        }

        public string DrinkAndDrive()
        {
            return "driving while drunk";
        }
    }

    public class ResponsiblePerson
    {
        private Person3 person;

        public ResponsiblePerson(Person3 person)
        {
            this.person = person;
        }

        public int Age
        {
            get { return person.Age; }
            set { person.Age = value; }
        }

        public string Drink()
        {
            if (person.Age < 18)
                return "too young";
            return "drinking";
        }

        public string Drive()
        {
            if (person.Age < 16)
                return "too young";
            return "driving";
        }

        public string DrinkAndDrive()
        {
            return "dead";
        }
    }
}
