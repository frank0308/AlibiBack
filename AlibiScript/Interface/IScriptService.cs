using AlibiScript.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlibiScript.Interface
{
    public interface IScriptService
    {
        public bool CreateScript(ScriptViewModel scriptVM, string UserId);
        public ScriptViewModel GetScriptDetail(string name);
        public bool DeleteScript(Guid Id);
    }
}
