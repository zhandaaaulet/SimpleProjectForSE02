using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Security
{
    public interface IPasswordHasher
    {
        string Hash(string password);
        bool Verify(string hash, string password);
    }
}
