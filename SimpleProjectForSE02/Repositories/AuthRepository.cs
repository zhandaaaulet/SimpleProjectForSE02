using SimpleProjectForSE02.Data;
using SimpleProjectForSE02.Models;
using SimpleProjectForSE02.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleProjectForSE02.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext _context;

        public AuthRepository(DataContext context)
        {
            _context = context;
        }

        public Student Login(string username, string password)
        {
            var student = _context.Students.FirstOrDefault(x => x.Username == username);
            if (student == null || VerifyPasswordHash(password, student.PasswordHash, student.PasswordSalt))
            {
                return null;
            }
            return student;
        }

        public Student Register(Student student, string password)
        {
            CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);
            student.PasswordHash = passwordHash;
            student.PasswordSalt = passwordSalt;

            _context.Students.Add(student);

            _context.SaveChanges();

            return student;

        }

        public bool UserExists(string username)
        {
            return _context.Students.Any(x => x.Username == username);
        }

        public void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using var hmac = new System.Security.Cryptography.HMACSHA512();
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt);
            var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            return computedHash.SequenceEqual(passwordHash);
        }
    }
}
