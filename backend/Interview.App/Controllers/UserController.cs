using Interview.App.Exceptions;
using Interview.App.Models;
using Interview.App.Services;
using Microsoft.AspNetCore.Mvc;

namespace Interview.App.Controllers;

[ApiController]
[Route("api/users")]
public class UserController : ControllerBase
{
  private readonly IUserService _userService;

  public UserController(IUserService userService)
  {
    _userService = userService;
  }

  [HttpGet]
  public ActionResult<UserResponseModel> GetUser([FromQuery] Guid id)
  {
    try
    {
      var user = _userService.GetUserByIdAsync(id);
      return Ok(user);
    }
    catch (UserNotFoundException)
    {
      return NotFound();
    }
  }

  [HttpPost]
  public ActionResult<UserResponseModel> CreateUser([FromBody] UserCreateModel newUser)
  {
    _userService.CreateUser(newUser.Username, newUser.Password, newUser.FirstName, newUser.LastName );
    return Ok();
  }
}