using OdeToFood.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFood.Data
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        readonly List<Restaurant> restaurants;

        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant { Id = 1, Name = "Papa Jones", Location="Redmond", Cuisine=CuisineType.Italian },
                new Restaurant { Id = 2, Name = "Sombrero", Location="Seattle", Cuisine=CuisineType.Mexican },
                new Restaurant { Id = 3, Name = "Spice Bucket", Location="Washington", Cuisine=CuisineType.Indian}
            };
        }

        public Restaurant Add(Restaurant newRestaurant)
        {
            restaurants.Add(newRestaurant);
            newRestaurant.Id = restaurants.Max(r => r.Id) + 1;
            return newRestaurant;
        }

        public int Commit()
        {
            return 0;
        }

        public Restaurant Delete(int id)
        {
            var restaurant = restaurants.FirstOrDefault(r => r.Id == id);
            if (restaurant != null)
            {
                restaurants.Remove(restaurant);
            }
            return restaurant;
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return from a in restaurants
                   orderby a.Name
                   select a;
        }

        public Restaurant GetById(int id)
        {
            return restaurants.SingleOrDefault(r => r.Id == id);
        }

        public int GetCountOfRestaurants()
        {
            return restaurants.Count();
        }

        public IEnumerable<Restaurant> GetRestaurantByNamae(string name = null)
        {
            return from a in restaurants
                   where string.IsNullOrEmpty(name) || a.Name.StartsWith(name, StringComparison.InvariantCultureIgnoreCase)
                   orderby a.Name
                   select a;
        }

        public Restaurant Update(Restaurant updatedRestaurant)
        {
            var restaurant = restaurants.SingleOrDefault(r => r.Id == updatedRestaurant.Id);
            if (restaurant != null)
            {
                restaurant.Name = updatedRestaurant.Name;
                restaurant.Location = updatedRestaurant.Location;
                restaurant.Cuisine = updatedRestaurant.Cuisine;
            }
            return restaurant;
        }
    } 
}
