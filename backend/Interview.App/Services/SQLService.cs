using Interview.App.Models;

namespace Interview.App.Services;

public class SQLService : IDataService
{

  private readonly IEnumerable<UserModel> _users = new List<UserModel>()
  {
    new()
    {
      Id = Guid.Parse("28af44d0-cbfd-49b5-963c-1d3fe88f5d9d"), Email = "jsmith@gmail.com", Password = "aasdjlkfasdfhjn", Username = "jsmith@gmail.com",
      FirstName = "John", LastName = "Smith"
    },
    new()
    {
      Id = Guid.NewGuid(), Email = "foo@bar.com", Password = "gsdf2345sdfg", Username = "foo@bar.com",
      FirstName = "Jane", LastName = "Doe"
    },
  };
    
  public Task<UserModel?> GetUserByIdAsync(Guid userId)
  {
    return Task.FromResult(_users.FirstOrDefault(u => u.Id == userId));
  }

  public Task<IEnumerable<UserModel>> GetAllUsersAsync()
  {
    return Task.FromResult(_users);
  }
}