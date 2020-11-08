using System;
using System.Collections.Generic;

namespace AlibiScript.Model
{
    public partial class Categories
    {
        public Categories()
        {
            Scripts = new HashSet<Scripts>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Scripts> Scripts { get; set; }
    }
}
