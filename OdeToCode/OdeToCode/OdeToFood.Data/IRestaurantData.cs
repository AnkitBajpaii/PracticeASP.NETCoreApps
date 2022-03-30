using OdeToFood.Core;

namespace OdeToFood.Data
{
    public interface IRestaurantData
    {
        Restaurant GetById(int id);
        IEnumerable<Restaurant> GetAll();
        IEnumerable<Restaurant> GetRestaurantsByName(string? name);
        Restaurant Update(Restaurant updatedRestaurant);
        Restaurant Add(Restaurant newRestaurant);
        Restaurant Delete(int restaurantId);
        int Commit();
        int GetCountOfRestaurants();
    }
}