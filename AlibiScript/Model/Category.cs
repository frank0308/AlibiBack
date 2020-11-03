using System;
using System.Collections.Generic;

namespace AlibiScript.Model
{
    public partial class Category
    {
        public Category()
        {
            Script = new HashSet<Script>();
        }

        public Guid ScriptId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Script> Script { get; set; }
    }
}
