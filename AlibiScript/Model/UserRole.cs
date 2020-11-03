using System;
using System.Collections.Generic;

namespace AlibiScript.Model
{
    public partial class UserRole
    {
        public Guid UserId { get; set; }
        public string Role { get; set; }
    }
}
