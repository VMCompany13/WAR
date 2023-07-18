using Microsoft.AspNetCore.Mvc;
using BackendDataService.Models;
using BackendDataService.Models.Dto;
using Npgsql;
using WebApService.Services;

namespace WebApiReact.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;

        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpGet]
        public async Task<IEnumerable<User>> GetAsync()
        {
            return await _usersService.GetAllUsersAsync();
        }

        [HttpPost]
        public IEnumerable<Dish> Post([FromQuery] string name)
        {

            var userName = name;

            User currentUs = GetCeurrentUserFromDb(userName);

            //todo add service to backend http
            //перенести в dishcontroller
            /*var currentUser = _dbContext.Users.FirstOrDefault(x => x.Name == userName) ?? throw new Exception("Undefined user");
            var currentDishesDateId = _dbContext.UserToLink.Where(x => x.UserId == currentUser.UserId).Select(x => x.LinkId).ToList();

            var links = _dbContext.DishToDates.Where(x => currentDishesDateId.Contains(x.Id)).ToList();

            var dishesById = _dbContext.Dishes.Where(x => links.Select(l => l.DishId).Contains(x.DishId)).ToList();*/
            return new List<Dish>();
            //return dishesById;
        }

        [HttpPost]
        [Route("createUser")]
        public async Task<IActionResult> CreateUserAsync([FromBody] NewUserDto newUser)
        {
            await _usersService.CreateUserAsync(newUser);
          
            return Ok("Пользователь создан!");
            
        }

        private User GetCeurrentUserFromDb(string username)
        {
            User result;
            using (var conn = CreateConnection())
            {
                conn.Open();
                using (var command =  CreateCommand("select * from webapi.user u where u.name = @name ", conn))
                {
                    command.Parameters.AddWithValue("@name", username);
                    using (var reader = command.ExecuteReader())
                    {
                        var userIdIndex = reader.GetOrdinal("user_id");
                        if (reader.HasRows && reader.Read())
                        {
                            result = new User { UserId = reader.GetInt32(userIdIndex) };
                            return result;
                        }
                    }
                }
            }

            throw new Exception($"По заданому имени - {username} не найдено пользователя!");
        }

        private NpgsqlConnection CreateConnection() => 
            new NpgsqlConnection("User ID=postgres;Password=Mirkulov13;Host=localhost;Port=5433;Database=Test;Pooling=true;");

        private NpgsqlCommand CreateCommand(string commandText, NpgsqlConnection connection) => 
            new NpgsqlCommand(commandText, connection);
    }
}
