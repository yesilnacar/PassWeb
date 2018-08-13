using PassWeb.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PassWeb.Interfaces.IServices
{
    public interface IPassResetTokenService
    {
        string GenerateToken(User user);
    }
}
