using System;
using System.Collections.Generic;

namespace AlibiScript.Model
{
    public partial class User
    {
        public User()
        {
            Script = new HashSet<Script>();
        }

        public Guid Id { get; set; }
        public string Account { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }

        public virtual ICollection<Script> Script { get; set; }
    }
}
