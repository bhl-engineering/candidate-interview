using Interview.App.Models;

namespace Interview.App.Services;

public interface IDataService
{
  public Task<UserModel?> GetUserById(Guid userId);
  
  public Task<IEnumerable<UserModel>> GetAllUsers();
}