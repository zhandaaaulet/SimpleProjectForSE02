﻿using SimpleProjectForSE02.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleProjectForSE02.Repositories.Interfaces
{
    public interface IAuthRepository
    {
        Student Register(Student student, string password);
        Student Login(string username, string password);
        bool UserExists(string username);

    }
}
