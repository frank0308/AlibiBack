using System;
using System.Collections.Generic;

namespace AlibiScript.Model
{
    public partial class Characters
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Intro { get; set; }
        public string Image { get; set; }
        public Guid ScriptId { get; set; }

        public virtual Scripts Script { get; set; }
    }
}
