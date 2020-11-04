using AlibiScript.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlibiScript.Interface
{
    public interface IUserService
    {
        public bool UserSignUp(User user);
    }
}
