using OBB.Data.Entities;
using OBB.Models;

namespace OBB.Repository
{
    public interface IUserRepository
    {
        public bool AddUser(AddUserModel addUser);
        public UserTable GetUserDetailbyEmail(string email);
        public bool VerifyEmail(string email);
        public List<RolesTable> GetRoles();
    }
}