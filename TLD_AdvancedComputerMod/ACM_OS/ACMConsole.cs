using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TLD_AdvancedComputerMod.ACM_OS
{
    public class ACMConsole
    {
        computerscript cmp;

        public ACMConsole(computerscript cmp) { this.cmp = cmp; }

        public void Write(string message)
        {
            cmp.Write(message);
        }

        public void WriteLine(string message)
        {
            cmp.WriteLn(message);
        }
    }
}
