using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework1
{
    class Users
    {
        public Users()
        {

        }
        public Users(string name, string surname, string fatherName, string country, string city, string phoneNumber, DateTime birthDate, Gender gender)
        {
            Name = name;
            Surname = surname;
            FatherName = fatherName;
            Country = country;
            City = city;
            PhoneNumber = phoneNumber;
            BirthDate = birthDate;
            Gender = gender;
        }

        public string Name { get; set; }
        public string Surname { get; set; }
        public string FatherName { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public Gender Gender { get; set; }
    }
    enum Gender { Male, Female};
}