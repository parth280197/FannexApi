using fannexApi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;


namespace fannexApi.Controllers
{

  public class LoginController : ApiController
  {
    public List<User> RegisteredUsers { get; set; }
    public LoginController()
    {
      this.RegisteredUsers = new List<User>()
      {
        new User("username1","password1"),
        new User("username2","password2"),
        new User("username3","password3"),
        new User("username4","password4"),
        new User("username5","password5")
      };
    }

    public IHttpActionResult GetUsers()
    {
      return Ok(RegisteredUsers);
    }

    [HttpPost]
    public IHttpActionResult CheckLoginCredentials(User user)
    {
      if (ModelState.IsValid)
      {
        bool isUserRegistered = RegisteredUsers
        .Any(registeredUser => registeredUser.UserName == user.UserName && registeredUser.Password == user.Password);
        return Ok(isUserRegistered);
      }
      return BadRequest();
    }
  }
}
