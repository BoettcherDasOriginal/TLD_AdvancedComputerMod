using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TLD_AdvancedComputerMod.ACM_OS;

namespace ACM_TestPlugin
{
    public class ACM_TestPlugin : ACM_ICommand
    {
        public override string Name { get { return "test"; } }
        public override string Description { get { return "plugin test"; } }
        public override Action CommandFunction { get { return () => Command(); } }
        public override Action HelpFunction { get { return () => Help(); } }
        private string[] _InputProperties;
        public override string[] Arguments { get { return _InputProperties; } set { _InputProperties = value; } }
        private computerscript _cmp;
        public override computerscript cmp { get { return _cmp; } set { _cmp = value; } }
        private ACMConsole _Console;
        public override ACMConsole console { get { return _Console; } set { _Console = value; } }

        public void Command()
        {
            console.WriteLine("Test Test 1,2,3!");
        }
        public void Help()
        {
            
        }
    }
}
