using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDB2
{
    public class Creator
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public Creator() { }   
        public Creator(int id, string name) {  Id = id; Name = name; }
    }
}
