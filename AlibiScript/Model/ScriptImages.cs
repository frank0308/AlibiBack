using System;
using System.Collections.Generic;

namespace AlibiScript.Model
{
    public partial class ScriptImages
    {
        public Guid Id { get; set; }
        public string Image { get; set; }
        public Guid ScriptId { get; set; }
        public int? OrderNumber { get; set; }

        public virtual Scripts Script { get; set; }
    }
}
