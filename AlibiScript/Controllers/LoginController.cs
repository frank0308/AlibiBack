using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlibiScript.Interface;
using AlibiScript.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AlibiScript.Controllers
{   
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IJwtHelper _jwt;

        public LoginController(IUserService userService, IJwtHelper jwtHelper)
        {
            _userService = userService;
            _jwt = jwtHelper;
        }

        [HttpGet]
        public ActionResult<string> Login([FromQuery]LoginViewModel loginVM)
        {
            if (_userService.LoginVerify(loginVM))
            {
                return _jwt.GenerateToken(loginVM.Account);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
