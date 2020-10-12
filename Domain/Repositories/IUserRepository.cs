using Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Repositories
{
    public interface IUserRepository
    {
        User SignIn();
        void CreateUser(User user);
    }
}
