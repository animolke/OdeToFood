using OdeToFood.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace OdeToFood.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAll();

    }

    public class InMemoryRestaurantData : IRestaurantData
    {
        readonly List<Restaurant> restaurants;

        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()  
            {
                new Restaurant { Id = 1, Name = "Papa Jones", Location = "Redmond" , Cuisine = CuisineType.Italian },
                new Restaurant { Id = 2, Name = "Sombrero", Location = "Seattle" , Cuisine = CuisineType.Mexican },
                new Restaurant { Id = 3, Name = "Spice Bucket", Location = "Redmond" , Cuisine = CuisineType.Indian }
            };
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return from r in restaurants
                   orderby r.Name
                   select r;
        }
    }
}
