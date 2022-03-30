using OdeToFood.Core;

namespace OdeToFood.Data
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        List<Restaurant> restaurants;

        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant> {
                new Restaurant { Id = 1, Name = "Scott's Pizza", Location="Maryland", Cuisine = CuisinType.Italian},
                new Restaurant { Id = 2, Name = "Cinnamon Club", Location="London", Cuisine = CuisinType.Mexican},
                new Restaurant { Id = 3, Name = "La Costa", Location="California", Cuisine = CuisinType.Indian}
            };
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return from r in restaurants
                   orderby r.Name
                   select r;
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string? name)
        {
            return from r in restaurants
            where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
            orderby r.Name
            select r;

        }

        public Restaurant GetById(int id)
        {
            return restaurants.SingleOrDefault(x => x.Id == id);
        }

        public Restaurant Update(Restaurant updatedRestaurant)
        {
            var restaurant = restaurants.SingleOrDefault(r => r.Id == updatedRestaurant.Id);

            if(restaurant != null)
            {
                restaurant.Name = updatedRestaurant.Name;
                restaurant.Location = updatedRestaurant.Location;
                restaurant.Cuisine = updatedRestaurant.Cuisine;

            }

            return restaurant;
        }

        public int Commit()
        {
            return 0;
        }

        public Restaurant Add(Restaurant newRestaurant)
        {
            newRestaurant.Id = restaurants.Max(x => x.Id) + 1;

            restaurants.Add(newRestaurant);

            return newRestaurant;
        }

        public Restaurant Delete(int restaurantId)
        {
            Restaurant restaurant = restaurants.SingleOrDefault(r => r.Id == restaurantId);

            if(restaurant != null)
            {
                restaurants.Remove(restaurant);
            }

            return restaurant;
        }

        public int GetCountOfRestaurants()
        {
            return restaurants.Count;
        }
    }
}