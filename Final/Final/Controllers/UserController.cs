using Data;
using Domain.Final;
using Final.Requests;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Final.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserContext _context;


        public UserController(UserContext context)
        {
            _context = context;
        }

        #region PostUser
        [HttpPost("/AddUser")]
        public async Task<IActionResult> AddUser([FromForm]AddUserRequest AddUserRequest)
        {
            var User = new User();
            {
                User.FirstName = AddUserRequest.FirstName;
                User.LastName = AddUserRequest.LastName;
                User.Email = AddUserRequest.Email;
                User.UserName = AddUserRequest.UserName;
                User.Age= AddUserRequest.Age;
                User.Monthlyincome= AddUserRequest.Monthlyincome;


            }

            await _context.Users.AddAsync(User);
            await _context.SaveChangesAsync();

            return Created("/AddUser",User);
        }
        #endregion


        #region GetUserById
        [HttpGet("{UserId}")]
        public async Task<IActionResult> GetUser( int UserId)
        {
            var user = await _context.Users.FindAsync(UserId);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);

        }
        #endregion


    }
}
