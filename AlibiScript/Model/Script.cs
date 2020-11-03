using System;
using System.Collections.Generic;

namespace AlibiScript.Model
{
    public partial class Script
    {
        public Script()
        {
            Character = new HashSet<Character>();
            ScriptImage = new HashSet<ScriptImage>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Intro { get; set; }
        public int PlayerNum { get; set; }
        public int Time { get; set; }
        public int Price { get; set; }
        public int Difficulty { get; set; }
        public bool IsPlace { get; set; }
        public string Tags { get; set; }
        public DateTime CreateTime { get; set; }
        public string GameMaster { get; set; }
        public Guid UserId { get; set; }
        public Guid CategoryId { get; set; }

        public virtual Category Category { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Character> Character { get; set; }
        public virtual ICollection<ScriptImage> ScriptImage { get; set; }
    }
}
