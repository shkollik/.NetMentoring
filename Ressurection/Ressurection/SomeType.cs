using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ressurection
{
    class SomeType
    {
        public SomeType()
        {
            Console.WriteLine("object " + this.GetHashCode());
        }
        ~SomeType()
        {
            Console.WriteLine("Finalizer called");

            GC.ReRegisterForFinalize(this);
        }
    }
}
