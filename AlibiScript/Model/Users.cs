using System;
using System.Collections.Generic;

namespace AlibiScript.Model
{
    public partial class Users
    {
        public Users()
        {
            Scripts = new HashSet<Scripts>();
        }

        public Guid Id { get; set; }
        public string Account { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public DateTime ApplicatedDate { get; set; }

        public virtual UserRole UserRole { get; set; }
        public virtual ICollection<Scripts> Scripts { get; set; }
    }
}
