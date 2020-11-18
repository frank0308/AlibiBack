using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Threading.Tasks;

namespace AlibiScript.ViewModel
{
    public class ScriptViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Intro { get; set; }
        public int Difficulty { get; set; }
        public string PlayerNum { get; set; }
        public string Time { get; set; }
        public string Price { get; set; }
        public bool IsPlace { get; set; }
        public List<string> Tags { get; set; }
        public string GameMaster { get; set; }
        public string Owner { get; set; }
        public int Category { get; set; }
        public List<Character> Characters { get; set; }
        public List<ScriptImage> Images { get; set; }
    }
    public class Character
    {
        public string Name { get; set; }
        public string Intro { get; set; }
        public string Image { get; set; }
    }
    public class ScriptImage
    {
        public string url { get; set; }
        public string orderNum { get; set; }
    }
}
