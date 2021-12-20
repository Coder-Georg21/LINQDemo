using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQDemo
{
    class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Population { get; set; }

        public static IList<City> Factory()
        {
            IList<City> cityList = new List<City>();

            cityList.Add(new City { Id =1, Name = "Wien", Population = 1900000 });
            cityList.Add(new City { Id =2, Name = "Paris", Population = 2100000 });
            cityList.Add(new City { Id =3, Name = "NewYork", Population = 8400000 });
            return cityList;
        }
    }
}
