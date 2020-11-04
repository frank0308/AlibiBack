using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlibiScript.Interface;
using AlibiScript.Model;
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
        public IActionResult SignUp(User user)
        {
            if (ModelState.IsValid && _userService.UserSignUp(user))
            {
                return Ok();
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}
