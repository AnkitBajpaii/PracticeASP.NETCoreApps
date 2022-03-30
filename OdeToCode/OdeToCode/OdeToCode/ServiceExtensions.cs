using OdeToFood.Data;

namespace OdeToCode
{
    public static class ServiceExtensions
    {
        public static void RegisterRepos(this IServiceCollection collection)
        {
            collection.AddScoped<IRestaurantData, SqlRestaurantData>();
        }
    }
}
