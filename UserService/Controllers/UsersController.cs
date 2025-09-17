using Microsoft.AspNetCore.Mvc;
using UserService.Data;
using UserService.Models;

namespace UserService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;
        private readonly UserServiceContext _context;

        public UsersController(UserServiceContext context)
        {
            _context = context;
        }

        [HttpGet("getList")]
        public List<User> Index()
        {
            var getlist = _context.Users.ToList();  
            return getlist ;
        }
        [HttpPost("addUser")]
        public IActionResult AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return Ok(user);

     
        }
        [HttpPut("updateUser/{id}")]
        public IActionResult EditUser(User user)
        { 
            var finduser = _context.Users.Find(user.Id);
            if (finduser == null)
            {
                return NotFound();
            }
            else
            {
                User updatedUser = new User()
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    UpdatedAt = user.UpdatedAt,
                    UserName = user.UserName,
                    Password = user.Password

                };
                _context.Entry(finduser).CurrentValues.SetValues(updatedUser);
                _context.SaveChanges();

            }
            
            return Ok(user);
        }
        [HttpDelete("deleteUser/{id}")]
        public IActionResult DeleteUser(int id)
        {
            var finduser = _context.Users.Find(id);
            if (finduser == null)
            {
                return NotFound();
            }
            else
            {
                _context.Users.Remove(finduser);
                _context.SaveChanges();
            }
            return Ok(finduser);
        }

    }
}
