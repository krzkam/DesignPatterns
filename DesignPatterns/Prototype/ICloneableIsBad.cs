using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//If you want to do DEEP copy of object then ICloneable is not interface that you should use
namespace DesignPatterns.Prototype
{
    public class Person : ICloneable
    {
        public string[] Names;
        public Address Address;

        public Person(string[] names, Address address)
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

        public object Clone()
        {
            return new Person(Names, (Address)Address.Clone());
        }

        public override string ToString()
        {
            return $"{nameof(Names)}: {string.Join(" ",Names)}, {nameof(Address)}: {Address}";
        }
    }

    public class Address : ICloneable
    {
        public string StreetName;
        public int HouseNumber;
        public Address(string streetName, int houseNumber)
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

        public object Clone()
        {
            return new Address(StreetName, HouseNumber);
        }

        public override string ToString()
        {
            return $"{nameof(StreetName)}: {StreetName}, {nameof(HouseNumber)}: {HouseNumber}";
        }
    }

    class ICloneableIsBad
    {
    }
}
