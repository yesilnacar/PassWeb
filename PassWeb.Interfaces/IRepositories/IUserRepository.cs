using PassWeb.Domain.Models;
using System.Collections.Generic;

namespace PassWeb.Interfaces.IRepositories
{
    public interface IUserRepository
    {
        void Add(User user);
        User FindByEmail(string email);
        User FindByUserName(string userName);
        IEnumerable<User> GetUsers();
    }
}
