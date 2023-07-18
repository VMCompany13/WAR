using BackendDataService.Models.Dto;

namespace BackendDataService.DataBase.Interfaces
{
    public interface IUserDataWriter
    {
        void CreateUser(NewUserDto newUser);
    }
}
