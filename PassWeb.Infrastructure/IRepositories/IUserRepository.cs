using PassWeb.Domain.Models;

namespace PassWeb.Infrastructure.IRepositories
{
    public interface IUserRepository
    {
        void Add(User user);
        User FindByEmail(string email);
        User FindByUserName(string userName);
    }
}
