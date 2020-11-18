using AlibiScript.Interface;
using AlibiScript.Model;
using AlibiScript.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace AlibiScript.Service
{
    public class UserService : IUserService
    {
        private readonly IRepository<Users> _repo;
        private readonly IRepository<UserRole> _repo_Role;
        private readonly IRepository<Scripts> _repo_Script;
        private readonly IRepository<ScriptImages> _repo_ScriptImage;
        private readonly IEncryptionAdapter _encrypt;
        public UserService(IRepository<Users> userRepo, IEncryptionAdapter encryptionAdapter, IRepository<UserRole> userRoleRepo, IRepository<Scripts> scriptRepo, IRepository<ScriptImages> scriptImageRepo)
        {
            _repo = userRepo;
            _encrypt = encryptionAdapter;
            _repo_Role = userRoleRepo;
            _repo_Script = scriptRepo;
            _repo_ScriptImage = scriptImageRepo;
        }

        public bool UserSignUp(SignUpViewModel userVM)
        {
            if (UserExist(userVM.Account))
            {
                return false;
            }

            Users user = new Users
            {
                Account = userVM.Account,
                Password = _encrypt.HashPassword(userVM.Password),
                Id = Guid.NewGuid(),
                Image = userVM.Avatar,
                Name = userVM.Name,
                ApplicatedDate = DateTime.Now
            };

            UserRole role = new UserRole();
            if(userVM.IsScriptOwner == "true")
            {
                role.Role = "Owner";
                role.UserId = user.Id;
            } else
            {
                role.Role = "User";
                role.UserId = user.Id;

            };

            _repo.Create(user);
            _repo_Role.Create(role);
            return true;
        }

        public bool LoginVerify(LoginViewModel loginVM)
        {
            if (UserExist(loginVM.Account))
            {
                Users user = _repo.GetAll().Single(x => x.Account == loginVM.Account);
                if(_encrypt.Verify(user.Password, loginVM.Password))
                {
                    return true;
                }
            }
            return false;
        }

        public bool UserExist(string account)
        {
            return _repo.GetAll().Any(x => x.Account == account);
        }

        public UserInfoViewModel GetUserInfo(string account)
        {
            Users user = _repo.GetAll().FirstOrDefault(x => x.Account == account);
            return new UserInfoViewModel
            {
                Id = user.Id,
                Name = user.Name,
                Image = user.Image
            };
        }

        public IEnumerable<SimpleScriptViewModel> GetMyScript(string account)
        {
            Guid userId = _repo.GetAll().FirstOrDefault(x => x.Account == account).Id;
            return _repo_Script.GetAll().Where(x => x.UserId == userId).Select(x => new SimpleScriptViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Image = _repo_ScriptImage.GetAll().Where(y => y.ScriptId == x.Id).OrderBy(x => x.OrderNumber)
                        .ElementAt(0).Image

            });
        }
    }
}
