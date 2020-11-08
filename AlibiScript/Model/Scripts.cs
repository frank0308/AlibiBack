using System;
using System.Collections.Generic;

namespace AlibiScript.Model
{
    public partial class Scripts
    {
        public Scripts()
        {
            Characters = new HashSet<Characters>();
            ScriptImages = new HashSet<ScriptImages>();
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
        public int CategoryId { get; set; }

        public virtual Categories Category { get; set; }
        public virtual Users User { get; set; }
        public virtual ICollection<Characters> Characters { get; set; }
        public virtual ICollection<ScriptImages> ScriptImages { get; set; }
    }
}
