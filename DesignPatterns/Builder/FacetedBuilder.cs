using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//somethimes one builder is not enough and we need several builders which are responisble for several aspects of building objects
//
namespace DesignPatterns.Builder
{
    public class Person3
    {
        // address
        public string StreetAddress, PostCode, City;

        // employment
        public string CompanyName, Position;
        public int AnnualIncome;

        public override string ToString()
        {
            return $"{nameof(StreetAddress)}: {StreetAddress},{nameof(PostCode)}: {PostCode},{nameof(City)}: {City},{nameof(CompanyName)}: {CompanyName}, {nameof(Position)}: {Position}, {nameof(AnnualIncome)}: {AnnualIncome}";
        }
    }
    // facade for other builders, id doesn't acctualy build up person but it keeps reference do the person that's being build up
    // it allows you access to those sub-builders
    public class PersonBuilder3 
    {
        //reference to the object
        protected Person3 person = new Person3();

        public PersonJobBuilder Works => new PersonJobBuilder(person);
        public PersonAddressBuilder Lives => new PersonAddressBuilder(person);

        public static implicit operator Person3(PersonBuilder3 pb)
        {
            return pb.person;
        }
    }

    public class PersonJobBuilder : PersonBuilder3
    {
        public PersonJobBuilder(Person3 person)
        {
            this.person = person;
        }

        public PersonJobBuilder At(string companyName)
        {
            person.CompanyName = companyName;
            return this;
        }

        public PersonJobBuilder AsA(string position)
        {
            person.Position = position;
            return this;
        }

        public PersonJobBuilder Earning(int amount)
        {
            person.AnnualIncome = amount;
            return this;
        }
    }


    public class PersonAddressBuilder : PersonBuilder3
    {
        public PersonAddressBuilder(Person3 person)
        {
            this.person = person;
        }

        public PersonAddressBuilder At(string streetAddress)
        {
            person.StreetAddress = streetAddress;
            return this;
        }

        public PersonAddressBuilder WithPostCode(string postCode)
        {
            person.PostCode = postCode;
            return this;
        }

        public PersonAddressBuilder In(string city)
        {
            person.City = city;
            return this;
        }


    }
}
