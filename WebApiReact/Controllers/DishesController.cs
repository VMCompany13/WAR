using BackendDataService.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApiReact.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DishesController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Dish> Get()
        {
            return new List<Dish>();
            //todo add service to backend http
            //var dishes = _dbContext.Dishes;
            //return dishes;
        }
    }
}
