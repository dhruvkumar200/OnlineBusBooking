using OBB.Data.Entities;
using OBB.Models;

namespace OBB.Business
{
    public interface IUserBusiness
    {
        bool AddUser(AddUserModel addUser);
        UserTable GetUserDetailbyEmail(string email);
        public bool VerifyEmail(string email);
    }
}