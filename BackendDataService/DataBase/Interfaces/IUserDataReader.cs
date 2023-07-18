using System.Collections.Generic;
using BackendDataService.Models;

namespace BackendDataService.DataBase.Interfaces
{
    public interface IUserDataReader
    {
        public List<User> GetAllUsers();
    }
}
