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
            /*using var connection = CreateConnection();
            connection.Open();
            using var command = CreateCommand("" +
                @"
                INSERT INTO webapi.user
(name, date_of_birth, is_del, is_blocked)
VALUES(@name, @dateOfBirth, 0::bit, 0::bit);
", connection);

            command.Parameters.AddWithValue("@name", newUser.Name);
            command.Parameters.AddWithValue("@dateOfBirth", newUser.DateOfBirth);

            command.ExecuteNonQuery();*/
        }

        private NpgsqlConnection CreateConnection() =>
          new NpgsqlConnection("User ID=postgres;Password=Mirkulov13;Host=localhost;Port=5433;Database=Test;Pooling=true;");

        private NpgsqlCommand CreateCommand(string commandText, NpgsqlConnection connection) =>
            new NpgsqlCommand(commandText, connection);
    }
}
