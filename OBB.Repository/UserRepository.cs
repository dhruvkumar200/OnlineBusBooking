using Microsoft.EntityFrameworkCore;
using OBB.Data;
using OBB.Data.Entities;
using OBB.Models;

namespace OBB.Repository
{
    public class UserRepository:IUserRepository
    {
        private readonly BookingDBContext _context;
        public UserRepository(BookingDBContext context)
        {
            _context = context;
        }
        public bool AddUser(AddUserModel addUser)
        {
            UserTable user = new UserTable();
            user.FirstName=addUser.FirstName;
            user.LastName=addUser.LastName;
            user.Address=addUser.Address;
            user.Email=addUser.Email;
            user.Password=addUser.Password;
            user.PhoneNo=addUser.Phone;
            user.RoleId=2; 
            _context.Add(user);
            _context.SaveChanges();
            return true;
        }
        public UserTable GetUserDetailbyEmail(string email)
        {
            return _context.UserTables.FirstOrDefault(x=>x.Email==email);
        }
        
         public bool VerifyEmail(string email)
        {
            return _context.UserTables.Any(x => x.Email == email);
        }

         public List<RolesTable> GetRoles()
        {
            
           return _context.RolesTables.ToList();
            
        }
        
        
      
        
    
       
    }
}