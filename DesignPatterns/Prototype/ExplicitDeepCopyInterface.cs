using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Prototype
{
    public interface IPrototype<T>
    {
        T DeepCopy();
    }

    public class Person3 : IPrototype<Person3>
    {
        public string[] Names;
        public Address3 Address;

        public Person3(string[] names, Address3 address)
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

        public Person3(Person3 other)
        {
            Names = other.Names;
            Address = new Address3(other.Address); ;
        }

        public override string ToString()
        {
            return $"{nameof(Names)}: {string.Join(" ", Names)}, {nameof(Address)}: {Address}";
        }

        public Person3 DeepCopy()
        {
            return new Person3(Names,Address.DeepCopy());
        }
    }

    public class Address3 : IPrototype<Address3>
    {
        public string StreetName;
        public int HouseNumber;
        public Address3(string streetName, int houseNumber)
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

        public Address3(Address3 other)
        {
            StreetName = other.StreetName;
            HouseNumber = other.HouseNumber;
        }

        public override string ToString()
        {
            return $"{nameof(StreetName)}: {StreetName}, {nameof(HouseNumber)}: {HouseNumber}";
        }

        public Address3 DeepCopy()
        {
            return new Address3(StreetName,HouseNumber);
        }
    }

}
