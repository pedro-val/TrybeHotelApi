using TrybeHotel.Models;
using TrybeHotel.Dto;

namespace TrybeHotel.Repository
{
    public class UserRepository : IUserRepository
    {
        protected readonly ITrybeHotelContext _context;
        public UserRepository(ITrybeHotelContext context)
        {
            _context = context;
        }
        public UserDto GetUserById(int userId)
        {
            throw new NotImplementedException();
        }

        public UserDto Login(LoginDto login)
        {
           throw new NotImplementedException();
        }

        public UserDto Add(UserDtoInsert user)
        {
            if (_context.Users.Any(u => u.Email == user.Email))
            {
                throw new ArgumentException("User email already exists");
            }

            var toAddUser = new User
            {
                Name = user.Name,
                Email = user.Email,
                Password = user.Password,
                UserType = "client"
            };

            _context.Users.Add(toAddUser);
            _context.SaveChanges();
            
            var savedUser = _context.Users.FirstOrDefault(u => u.Email == user.Email);
            if (savedUser == null)
            {
                throw new ArgumentException("Error saving user");
            }
            return new UserDto
            {
                UserId = savedUser.UserId,
                Name = savedUser.Name,
                Email = savedUser.Email,
                UserType = savedUser.UserType
            };
        }

        public UserDto GetUserByEmail(string userEmail)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserDto> GetUsers()
        {
           throw new NotImplementedException();
        }

    }
}