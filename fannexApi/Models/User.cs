using System.ComponentModel.DataAnnotations;

namespace fannexApi.Models
{
  public class User
  {
    [Required]
    public string UserName { get; set; }
    [Required]
    public string Password { get; set; }
    public User(string userName, string password)
    {
      this.UserName = userName;
      this.Password = password;
    }
  }
}