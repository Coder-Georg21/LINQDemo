using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQDemo
{
    class Person
    {
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public int Age { get; set; }
        public int City { get; set; }

        public static IList<Person> Factory() //Factory Methoden sollen Daten vorbereiten; erzeugen
        {
            IList<Person> personList = new List<Person>();

            personList.Add(new Person
            {
                FirstName = "Sue",
                LastName = "Permarkt",
                Age = 20
            });

            personList.Add(new Person
            {
                FirstName = "Luci",
                LastName = "Fer",
                Age = 666
            });

            personList.Add(new Person
            {
                FirstName = "Harri",
                LastName = "Gersak",
                Age = 69
            });

            personList.Add(new Person
            {
                FirstName = "Andi",
                LastName = "Arbeit",
                Age = 69
            });

            return personList;
        }
    }
}