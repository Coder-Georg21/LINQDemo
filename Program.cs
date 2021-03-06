using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace LINQDemo
{
    class Program
    {
        public static object Age { get; private set; }

        static void Main(string[] args)
        {
            int x = 1; //explizit typisiert
            var z = 22; //implizit typisiert -> Wertzuweisung benötigt

            //geht nicht - c# ist typsicher
            // x = "xx";
            //z = "xx";
            //nicht typsierte Sprachen: JS, PHP -> kann zu laufzeit fehlern führen

            IList<string> names = new List<string>();
            names.Add("Mike Rhosoft");
            names.Add("Sergey Fährlich");
            names.Add("Axel Schweiss");

            //LINQ statememt
            //liste wird nicht umsortiert, ist nur ein View
            var sortedNames = from name in names
                              where name.Length > 5
                              orderby name descending
                              select name;
            foreach (var name in sortedNames)
            {
                Console.WriteLine(name);
            }

            //Lambda Expression
            var sortedNames2 = names.Where(n => n.Length > 5).OrderByDescending(n => n);
            foreach (var name in sortedNames2)
            {
                Console.WriteLine(name);
            }

            var groupedPersonsLambda = Person.Factory().GroupBy(p => p.Age).OrderBy(g => g.Key);


            //Eigene Klasse
            Console.WriteLine("\n----Eigene Klasse-----");
            var sortedPerson = from p in Person.Factory()
                               where p.FirstName.StartsWith('A')
                               orderby p.FirstName descending
                               orderby p.LastName ascending
                               select p;

            var sortedPerson2 = Person.Factory()
                .Where(p => p.FirstName.StartsWith("A"))
                .OrderByDescending(p => p.FirstName)
                .ThenBy(p => p.LastName); //bei mehreren OrderBy nacheinander muss ThenBy verwendet werden

            //Gruppierung
            var groupedPersons = from p in Person.Factory()
                                 group p by p.Age;

            //Gruppierung LINQ
            var groupedPersons2 = from p in Person.Factory()
                                 group p by Age
                                 into personGroup
                                 orderby personGroup.Key
                                 select personGroup;

            //JOINS
            var joinedQuery = from p in Person.Factory()
                join c in City.Factory() on p.City equals c.Id
                where c.Population > 100000
                select p;

            var joinedQuery2 = Person.Factory()
                .Join(City.Factory().Where(c => c.Population > 100000),
                p=>p.City,c=>c.Id,(p,c)=>(p,c));



            //OUTPUT
            joinedQuery2.ToList().ForEach(x => Console.WriteLine($"City: {x.c.Id}; Person: {x.p.FirstName}"));


            //DATA TRANSOFRMATION

            var personStatistics = from p in Person.Factory()
                                  group p by p.Age
                     into personGroup
                                  orderby personGroup.Key
                                  select new PersonStatistics //Data Transformation
                                  {
                                      Age = personGroup.Key,
                                      Number = personGroup.Count(),
                                  };


            //NO RESULTS

            var noResult1 = Person.Factory().Where(p => p.FirstName == "Bill" && p.LastName == "Yard")
                .First();

            if (noResult1 == default(Person)) // NOT == NULL
            {
                Console.WriteLine("No Data Found!");
            }


        }
        
        private void printGroupedPersons(IEnumerable<IGrouping<int, Person>> groupedPersons)
        {
            foreach (var personGroup in groupedPersons)
            {
                Console.WriteLine($"Alter: {personGroup.Key}; Anzahl: {personGroup.Count()}");

                foreach (var person in personGroup)
                {
                    Console.WriteLine($"{person.FirstName} {person.LastName}");
                }
            }
        }
    }
}