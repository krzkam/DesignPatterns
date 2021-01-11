using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace DesignPatterns.Prototype
{
    public static class ExtensionMethods
    {
        public static T DeepCopy<T>(this T self)
        {
            var stream = new MemoryStream();
            var formatter = new BinaryFormatter();
            formatter.Serialize(stream, self);
            stream.Seek(0,SeekOrigin.Begin);
            object copy = formatter.Deserialize(stream);
            stream.Close();
            return (T)copy;
        }

        public static T DeepCopyXml<T>(this T self)
        {
            using(var ms = new MemoryStream())
            {
                var s = new XmlSerializer(typeof(T));
                s.Serialize(ms,self);
                ms.Position = 0;
                return (T)s.Deserialize(ms);
            }

        }
    }

    //[Serializable]
    public class Person4
    {
        public string[] Names;
        public Address4 Address;

        public Person4(string[] names, Address4 address)
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

        public Person4(Person4 other)
        {
            Names = other.Names;
            Address = new Address4(other.Address); ;
        }

        public override string ToString()
        {
            return $"{nameof(Names)}: {string.Join(" ", Names)}, {nameof(Address)}: {Address}";
        }

        public Person4()
        {

        }
    }

    //[Serializable]
    public class Address4
    {
        public string StreetName;
        public int HouseNumber;
        public Address4(string streetName, int houseNumber)
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

        public Address4(Address4 other)
        {
            StreetName = other.StreetName;
            HouseNumber = other.HouseNumber;
        }

        public override string ToString()
        {
            return $"{nameof(StreetName)}: {StreetName}, {nameof(HouseNumber)}: {HouseNumber}";
        }

        public Address4()
        {

        }

    }
}
