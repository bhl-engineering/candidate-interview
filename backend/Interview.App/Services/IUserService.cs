using Interview.App.Models;

namespace Interview.App.Services;

public interface IUserService
{
  public Task<UserResponseModel> GetUserById(Guid userId);
}