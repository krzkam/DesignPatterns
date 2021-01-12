using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//you allow people to call the constructors, allow people to make as many object as they want but whenever people acctualy use properties of the object they still map to static fields and as the result they all share the same data
namespace DesignPatterns.Singleton
{
    public class CEO
    {
        private static string name;
        private static int age;
 

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(Age)}: {Age}";
        }
    }
}
