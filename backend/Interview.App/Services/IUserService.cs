using Interview.App.Models;

namespace Interview.App.Services;

public interface IUserService
{
  public Task<UserResponseModel> GetUserByIdAsync(Guid userId);
}