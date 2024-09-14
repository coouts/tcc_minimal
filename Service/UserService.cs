using MongoDB.Driver;

public interface IUserService
{
    public Task<List<User>>  GetUsers();
    public Task CreateUser(CreateUserInput user);

}

public class UserService : IUserService
{
    private readonly IMongoCollection<User> _users;

    public UserService(MongoDbConfig db) {
        _users = db.GetUsersCollection();
    }



    public async Task<List<User>> GetUsers()
    {
        return await this._users.Find(_ => true).ToListAsync();

    }

       public async Task CreateUser(CreateUserInput input)
    {
        var user = new User(input.FirstName, input.LastName, input.Email, input.Password);

        await this._users.InsertOneAsync(user);

    }
}
