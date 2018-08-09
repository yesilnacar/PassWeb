using PassWeb.Domain.Models;

namespace PassWeb.Interfaces
{
    public interface IUserService
    {
        void Add(RegisterViewModel registerVM);
        User Find(string email);
    }
}
