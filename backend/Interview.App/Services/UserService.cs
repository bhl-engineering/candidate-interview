using Interview.App.Exceptions;
using Interview.App.Models;

namespace Interview.App.Services;

public class UserService : IUserService
{
  private IDataService _dataService;

  public UserService(IDataService dataService)
  {
    _dataService = dataService;
  }

  public async Task<UserResponseModel> GetUserById(Guid userId)
  {
    var user = await _dataService.GetUserById(userId);
    if (user == null)
    {
      throw new UserNotFoundException();
    }

    return new UserResponseModel
    {
      Id = user.Id,
      Email = user.Email,
      Username = user.Username,
      FirstName = user.FirstName,
      LastName = user.LastName,
    };
  }
}