using PassWeb.Domain.Models;

namespace PassWeb.Interfaces.IServices
{
    public interface IUserService
    {
        void Add(RegisterViewModel registerVM);
        User Find(string email);
    }
}
