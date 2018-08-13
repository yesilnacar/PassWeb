using PassWeb.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PassWeb.Interfaces.IRepositories
{
    public interface IPassResetTokenRepository
    {
        void Add(PassResetToken token);
    }
}
