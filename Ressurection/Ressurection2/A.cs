using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ressurection2
{
    public class A
    {
        public static A intA;

        ~A()
        {
            intA = this;
        }
    }
}
