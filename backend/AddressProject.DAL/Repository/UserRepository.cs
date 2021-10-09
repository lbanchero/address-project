using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using AddressProject.DAL.Model;
using Microsoft.Extensions.Configuration;

namespace AddressProject.DAL.Repository
{
    public interface IUserRepository
    {
        public Task<List<User>> GetAsync();

        public Task<User> CreateAsync(User user);
    }

    public class UserRepository : IUserRepository
    {
        private readonly IMongoCollection<User> _users;

        public UserRepository(IConfiguration config)
        {
            var connectionString = config.GetConnectionString("mongoDbConnection");
            
            var client = new MongoClient(connectionString);
            
            var database = client.GetDatabase("addressProjectDb");
            
            _users = database.GetCollection<User>("Users");
        }

        public async Task<List<User>> GetAsync()
        {
            return await _users.Find(u => true).ToListAsync();
        }

        public async Task<User> CreateAsync(User user)
        {
            await _users.InsertOneAsync(user);
            return user;
        }
    }
}