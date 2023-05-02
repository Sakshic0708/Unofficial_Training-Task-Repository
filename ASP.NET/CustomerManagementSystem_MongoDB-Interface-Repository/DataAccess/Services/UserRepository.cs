using CommonLibrary;
using DataAccess.Model;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Services
{
    public class UserRepository
    {
        private readonly IMongoCollection<User> _users;

        public UserRepository()
        {
            var client = new MongoClient(AppConfiguration.ConnectionString);
            var database = client.GetDatabase(AppConfiguration.DatabaseName);
            _users = database.GetCollection<User>("Users");
        }
        public void Add(User user)
        {
            user.Id = Guid.NewGuid();
            _users.InsertOne(user);
        }
        public List<User> HasEmailRegistered(string email)
        {
            return _users.Find(u => u.Email == email).ToList();
        }
        public User FindByEmailAndPassword(string email, string password)
        {
            return _users.Find(u => u.Email == email && u.Password == password).FirstOrDefault();
        }


    }
}
