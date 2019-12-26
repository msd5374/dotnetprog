using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAttributes
{
    [System.AttributeUsage(System.AttributeTargets.Class |
                       System.AttributeTargets.Struct, AllowMultiple = true)]
    public class Attribute1 : System.Attribute
    {
        public string Name { get; set; }
        public Attribute1(string Name)
        {
            this.Name = Name;
        }
    }
}
