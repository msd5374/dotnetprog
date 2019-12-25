using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace accessspec
{
    public class Class1
    {
        public int PUBLIC; //same + outside
        private int PRIVATE; //same class
        protected int PROTECTED; //same class + derived
        internal int INTERNAL;  //same class + same assembly 
        protected internal int PROTECTED_INTERNAL; //same + derievd + same assembly
    }
}
