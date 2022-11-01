using NghiaVoBlog.Data;
using NghiaVoBlog.Dto.User;
using NghiaVoBlog.Models;

namespace NghiaVoBlog.Repository
{
    public class UserRepository
    {
        private readonly AppDBContext _context;
        public UserRepository(AppDBContext context)
        {
            _context = context;
        }
        public UserDto InsertUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            var result  = new UserDto()
            {
                DisplayName =user.DisplayName,
                Email =user.Email,
                Phone =user.Phone,
                Address =user.Address,
                DateOfBirth = user.DateOfBirth
            };
            return result;
        }
    }
}