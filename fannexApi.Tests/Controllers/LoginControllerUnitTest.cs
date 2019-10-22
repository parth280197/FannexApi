using fannexApi.Controllers;
using fannexApi.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Results;

namespace fannexApi.Tests.Controllers
{
  [TestClass]
  public class LoginControllerUnitTest
  {
    [TestMethod]
    public void HaveRegisteredUsersInMemory()
    {
      var controller = new LoginController();

      //Should have pre-registered users in memory.
      IHttpActionResult actionResult = controller.GetUsers();
      var contentResult = actionResult as OkNegotiatedContentResult<List<User>>;
      var users = contentResult.Content;

      Assert.IsNotNull(users);
      Assert.AreEqual(5, users.Count);
    }
    [TestMethod]
    public void ValidLogIn()
    {
      var controller = new LoginController();

      //CheckLoginCredentials return true if existing user made post request
      IHttpActionResult actionResult = controller.CheckLoginCredentials(new User("username1", "password1"));
      var contentResult = actionResult as OkNegotiatedContentResult<bool>;
      var isExistingUser = contentResult.Content;
      Assert.IsTrue(isExistingUser);

      actionResult = controller.CheckLoginCredentials(new User("username3", "password3"));
      contentResult = actionResult as OkNegotiatedContentResult<bool>;
      isExistingUser = contentResult.Content;

      Assert.IsTrue(isExistingUser);
    }
    [TestMethod]
    public void InvalidLogIn()
    {
      var controller = new LoginController();

      //CheckLoginCredentials return true if existing user made post request
      IHttpActionResult actionResult = controller.CheckLoginCredentials(new User("username", "password"));
      var contentResult = actionResult as OkNegotiatedContentResult<bool>;
      var isExistingUser = contentResult.Content;
      Assert.IsFalse(isExistingUser);

      actionResult = controller.CheckLoginCredentials(new User("Username", "Password"));
      contentResult = actionResult as OkNegotiatedContentResult<bool>;
      isExistingUser = contentResult.Content;

      Assert.IsFalse(isExistingUser);

    }
  }
}
