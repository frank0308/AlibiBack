using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlibiScript.Interface;
using AlibiScript.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AlibiScript.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScriptController : ControllerBase
    {
        private readonly IScriptService _scriptService;

        public ScriptController(IScriptService scriptService)
        {
            _scriptService = scriptService;
        }

        [HttpPost]
        [Authorize]
        public IActionResult CreateScript(ScriptViewModel scriptVM)
        {
            if (_scriptService.CreateScript(scriptVM, User.Identity.Name))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        [Authorize]
        [Route("{Id}")]
        public IActionResult DeleteScript(Guid Id)
        {
            if (ModelState.IsValid)
            {
                if (_scriptService.DeleteScript(Id))
                {
                    return Ok();
                }
                else
                {
                    return NotFound();
                }
            }else
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("{name}")]
        public ActionResult<ScriptViewModel> GetScriptDetail(string name)
        {
            if(_scriptService.GetScriptDetail(name) != null)
            {
                return _scriptService.GetScriptDetail(name);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
