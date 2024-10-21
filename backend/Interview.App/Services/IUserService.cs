using Interview.App.Models;

namespace Interview.App.Services;

public interface IUserService
{
  public Task<UserResponseModel> GetUserByIdAsync(Guid userId);
  
  public void CreateUser(string username, string password, string firstName, string lastName);

}