
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Services.Interfaces
{
    public interface IAuthService
    {
        User Register(RegisterUserDTO dto);
    }
}
