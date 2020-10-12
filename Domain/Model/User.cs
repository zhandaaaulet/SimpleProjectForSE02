using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Model
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string PasswordHash { get; set; }
       
        public Role Role { get; set; }
        public DateTime RegistrationDate { get; set; }

    }
}
