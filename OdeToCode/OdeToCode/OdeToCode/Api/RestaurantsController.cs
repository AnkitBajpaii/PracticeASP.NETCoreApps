using Microsoft.AspNetCore.Mvc;
using OdeToFood.Core;
using OdeToFood.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OdeToCode.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantsController : ControllerBase
    {
        private readonly OdeToFoodDbContext odeToFoodDbContext;

        public RestaurantsController(OdeToFoodDbContext odeToFoodDbContext)
        {
            this.odeToFoodDbContext = odeToFoodDbContext;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<Restaurant> GetRestaurants()
        {
            return this.odeToFoodDbContext.Restaurants;
        }
    }
}
