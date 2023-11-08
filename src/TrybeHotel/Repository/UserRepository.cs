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
            var user = _context.Users.FirstOrDefault(u => u.Email == login.Email && u.Password == login.Password);

            if (user == null)
            {
                throw new ArgumentNullException(nameof(user), "User cannot be null");
            }

            return new UserDto
            {
                UserId = user.UserId,
                Name = user.Name,
                Email = user.Email,
                UserType = user.UserType
            };
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
            var user = _context.Users.FirstOrDefault(u => u.Email == userEmail);

            if (user == null)
            {
                throw new ArgumentNullException(nameof(user), "User cannot be null");
            }

            return new UserDto
            {
                UserId = user.UserId,
                Name = user.Name,
                Email = user.Email,
                UserType = user.UserType
            };
        }

        public IEnumerable<UserDto> GetUsers()
        {
           var users = _context.Users.ToList();
              return users.Select(u => new UserDto
              {
                UserId = u.UserId,
                Name = u.Name,
                Email = u.Email,
                UserType = u.UserType
              });
        }

    }
}