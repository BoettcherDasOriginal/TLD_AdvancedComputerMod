using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TLD_AdvancedComputerMod.ACM_OS
{
    public abstract class ACM_ICommand
    {
        /// <summary>
        /// The name of your command
        /// </summary>
        public abstract string Name { get; }

        /// <summary>
        /// The description of your command
        /// </summary>
        public abstract string Description { get; }

        /// <summary>
        /// The main function of your command
        /// </summary>
        public abstract Action CommandFunction { get; }

        /// <summary>
        /// The Help Information
        /// </summary>
        public abstract Action HelpFunction { get; }

        /// <summary>
        /// The given parameter from the user
        /// </summary>
        public abstract string[] Arguments { get; set; }

        /// <summary>
        /// Sender
        /// </summary>
        public abstract computerscript cmp { get; set; }

        /// <summary>
        /// ACMConsole Instance (Read to use, linked with the current sender(cmp))
        /// </summary>
        public abstract ACMConsole console { get; set; }

        public void Execute(string[] properties, computerscript computerscript)
        {
            //Start
            Arguments = properties;
            cmp = computerscript;
            console = new ACMConsole(cmp);

            //Run
            CommandFunction();

            //End
            ACM_ComputerMain.waitForSyntaxError.Add(cmp);
        }
    }
}
