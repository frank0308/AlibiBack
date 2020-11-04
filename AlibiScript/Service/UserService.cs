using AlibiScript.Interface;
using AlibiScript.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace AlibiScript.Service
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _repo;
        private readonly IEncryptionAdapter _encrypt;
        public UserService(IRepository<User> repository, IEncryptionAdapter encryptionAdapter)
        {
            _repo = repository;
            _encrypt = encryptionAdapter;
        }

        public bool UserSignUp(User user)
        {
            if (UserExist(user.Account))
            {
                return false;
            }
            user.Password = _encrypt.HashPassword(user.Password);
            _repo.Create(user);
            return true;
        }

        private bool UserExist(string account)
        {
            return _repo.GetAll().Any(x => x.Account == account);
        }

    }
}
