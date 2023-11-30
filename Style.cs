using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDB2
{
    public class Style
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public Style() { }
        public Style(int id, string name) { Id = id; Name = name; }
    }
}
