using Microsoft.AspNetCore.Mvc;
using SONRISA_BACKEND.Entity;
using SONRISA_BACKEND.Models;

namespace SONRISA_BACKEND.Services
{
    public interface IUserServices
    {
        User Authenticate(string username, string password);
        IEnumerable<User> GetAll();
        User GetById(string id);
        User Create(User user, string password);
        void Update(User user, string password = null);
        void Delete(string id);
    }
}
