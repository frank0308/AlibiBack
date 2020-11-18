using AlibiScript.Model;
using AlibiScript.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlibiScript.Interface
{
    public interface IUserService
    {
        public bool UserSignUp(SignUpViewModel user);
        public bool UserExist(string account);
        public bool LoginVerify(LoginViewModel loginVM);
        public UserInfoViewModel GetUserInfo(string account);
        public IEnumerable<SimpleScriptViewModel> GetMyScript(string account);
    }
}
