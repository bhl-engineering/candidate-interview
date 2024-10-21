using Interview.App.Models;

namespace Interview.App.Services;

public interface IDataService
{
  public Task<UserModel?> GetUserByIdAsync(Guid userId);
  
  public Task<IEnumerable<UserModel>> GetAllUsersAsync();
  
  public void CreateUser(UserModel user);
}