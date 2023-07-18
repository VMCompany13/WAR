using BackendDataService.DataBase.Interfaces;
using BackendDataService.Models.Dto;
using Npgsql;

namespace BackendDataService.DataBase
{
    public class UsersDataWriter : IUserDataWriter
    {
        public void CreateUser(NewUserDto newUser)
        {
            using var connection = CreateConnection();
            connection.Open();
            using var command = CreateCommand(
                @"
                INSERT INTO webapi.user
(name, date_of_birth, is_del, is_blocked)
VALUES(@name, @dateOfBirth, 0::bit, 0::bit);
", connection);

            command.Parameters.AddWithValue("@name", newUser.Name);
            command.Parameters.AddWithValue("@dateOfBirth", newUser.DateOfBirth);

            command.ExecuteNonQuery();
        }

        private NpgsqlConnection CreateConnection() =>
          new NpgsqlConnection("User ID=postgres;Password=Mirkulov13;Host=localhost;Port=5433;Database=Test;Pooling=true;");

        private NpgsqlCommand CreateCommand(string commandText, NpgsqlConnection connection) =>
            new NpgsqlCommand(commandText, connection);
    }
}
