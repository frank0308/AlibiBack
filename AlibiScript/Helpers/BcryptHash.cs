using AlibiScript.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlibiScript.Helpers
{
    public class BcryptHash : IEncryptionAdapter
    {
        public string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public bool Verify(string encoded, string password)
        {
            return BCrypt.Net.BCrypt.Verify(password, encoded);
        }
    }
}
