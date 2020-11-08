using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlibiScript.Interface
{
    public interface IJwtHelper
    {
        public string GenerateToken(string account, int expireMinutes = 360);
    }
}
