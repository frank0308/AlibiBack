using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlibiScript.ViewModel
{
    public class SimpleScriptViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public List<string> Tags { get; set; }
        public string Price { get; set; }
        public string Time { get; set; }
        public bool IsPlace { get; set; }
        public string PlayerNum { get; set; }
    }
}
