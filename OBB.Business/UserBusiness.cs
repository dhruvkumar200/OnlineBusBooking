using OBB.Data.Entities;
using OBB.Models;
using OBB.Repository;
namespace OBB.Business
{
    public class UserBusiness:IUserBusiness
    {
        public readonly IUserRepository _iUserRepository;

        public UserBusiness(IUserRepository iUserRepository)
        {
            _iUserRepository = iUserRepository;
        }

         public bool AddUser(AddUserModel addUser)
         {
            return _iUserRepository.AddUser(addUser);
         }
         public UserTable GetUserDetailbyEmail(string email)
         {
            return _iUserRepository.GetUserDetailbyEmail(email);
         }
         public bool VerifyEmail(string email)
         {
            return _iUserRepository.VerifyEmail(email);
         }
        
    }
}