using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlibiScript.Interface;
using AlibiScript.Model;
using AlibiScript.ViewModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AlibiScript.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult SignUp(SignUpViewModel user)
        {
            if (ModelState.IsValid && _userService.UserSignUp(user))
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        [Authorize]
        [HttpGet]
        public ActionResult<UserInfoViewModel> GetUserInfo()
        {
            if (_userService.UserExist(User.Identity.Name))
            {
                UserInfoViewModel userInfo = _userService.GetUserInfo(User.Identity.Name);
                return userInfo;
            }
            else
            {
                return NotFound();
            }
        }

        [Authorize]
        [HttpGet]
        [Route("[action]")]
        public ActionResult<List<SimpleScriptViewModel>> GetMyScript()
        {
            string account = User.Identity.Name;
            return _userService.GetMyScript(account).ToList();
        }
    }
}
