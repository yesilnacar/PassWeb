using PassWeb.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PassWeb.Interfaces.IServices
{
    public interface ILoginService
    {
        bool AreValidUserCredentials(string userName, string password);
    }
}
