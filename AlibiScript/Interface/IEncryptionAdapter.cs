using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlibiScript.Interface
{
    public interface IEncryptionAdapter
    {
        string HashPassword(string password);
        bool Verify(string encoded, string password);
    }
}
