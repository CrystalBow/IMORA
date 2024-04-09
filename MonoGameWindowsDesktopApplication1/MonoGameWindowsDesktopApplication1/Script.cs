using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imora
{
    internal class Script : Component
    {
        public Script() 
        {
            ScriptSystem.Register(this);
        }

        ~Script() 
        {
            ScriptSystem.Unregister(this);
        }
    }
}
