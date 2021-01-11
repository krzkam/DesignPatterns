using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//copy constructor - lets specify to copy all the data from object
namespace DesignPatterns.Prototype
{
    public class Person2
    {
        public string[] Names;
        public Address2 Address;

        public Person2(string[] names, Address2 address)
        {
            if (names == null)
            {
                throw new ArgumentNullException(paramName: nameof(names));
            }
            if (address == null)
            {
                throw new ArgumentNullException(paramName: nameof(address));
            }
            Names = names;
            Address = address;
        }

        public Person2(Person2 other)
        {
            Names = other.Names;
            Address = new Address2(other.Address); ;
        }

        public override string ToString()
        {
            return $"{nameof(Names)}: {string.Join(" ", Names)}, {nameof(Address)}: {Address}";
        }
    }

    public class Address2
    {
        public string StreetName;
        public int HouseNumber;
        public Address2(string streetName, int houseNumber)
        {
            if (streetName == null)
            {
                throw new ArgumentNullException(paramName: nameof(streetName));
            }
            if (houseNumber == null)
            {
                throw new ArgumentNullException(paramName: nameof(houseNumber));
            }
            StreetName = streetName;
            HouseNumber = houseNumber;
        }

        public Address2(Address2 other)
        {
            StreetName = other.StreetName;
            HouseNumber = other.HouseNumber;
        } 

        public override string ToString()
        {
            return $"{nameof(StreetName)}: {StreetName}, {nameof(HouseNumber)}: {HouseNumber}";
        }
    }

}
