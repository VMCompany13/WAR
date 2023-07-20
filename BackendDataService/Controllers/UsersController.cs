using System.Collections.Generic;
using System.Linq;
using BackendDataService.DataBase.Interfaces;
using BackendDataService.Models;
using BackendDataService.Models.Dto;
using Microsoft.AspNetCore.Mvc;
using Npgsql;

namespace BackendDataService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {

        TestDbContext _dbContext;

        private readonly IUserDataReader _userDataReader;

        private readonly IUserDataWriter _userDataWriter;

        public UsersController(TestDbContext dbContext, IUserDataReader userDataReader, IUserDataWriter userDataWriter)
        {
            _dbContext = dbContext;
            _userDataReader = userDataReader;
            _userDataWriter = userDataWriter;
        }

        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _dbContext.Users.ToList();
        }

        [HttpPost]
        [Route("createUser")]
        public void CreateUser(NewUserDto newUser)
        {
            _userDataWriter.CreateUser(newUser);
        }

        private NpgsqlConnection CreateConnection() =>
          new NpgsqlConnection("User ID=postgres;Password=Mirkulov13;Host=localhost;Port=5433;Database=Test;Pooling=true;");

        private NpgsqlCommand CreateCommand(string commandText, NpgsqlConnection connection) =>
            new NpgsqlCommand(commandText, connection);
    }
}
