using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TLD_AdvancedComputerMod.ACM_OS;
using TLD_AdvancedComputerMod.Commands;

namespace TLD_AdvancedComputerMod
{
    internal class ACM_ComputerMain
    {
        public static List<computerscript> waitForSyntaxError = new List<computerscript>();
        public static List<ACM_ICommand> ICommands = new List<ACM_ICommand>();

        public static void acm_init()
        {
            ICommands = new List<ACM_ICommand>
            {
                //System
                new ACM_Help_cmd(),
                new ACM_Reload_cmd(),
                new ACM_Helloworld_cmd(),
                //Math
                new ACM_Add_cmd(),
                new ACM_Sub_cmd(),
                new ACM_Mul_cmd(),
                new ACM_Div_cmd(),
                new ACM_Pow_cmd(),
                new ACM_Sqrt_cmd(),

                //extra
                new ACM_BuildingFinder_cmd(),
                new ACM_Radar_cmd()
            };

            ACM_PluginLoader.loadPlugins();
        }

        public static void handleComputerInput(computerscript cmp, string computerInput)
        {
            string[] args = computerInput.Split(' ');
            
            foreach(ACM_ICommand cmd in ICommands)
            {
                if(cmd.Name == args[0])
                {
                    cmd.Execute(args,cmp);
                }
            }
        }

        public static void removeSyntaxError(computerscript cmp)
        {
            string syntaxE = "?Syntax  Error";

            for(int i = 0; i < syntaxE.Length; i++)
            {
                --cmp.CursorPos.x;
                cmp.CursorLimits();
                cmp.screenText[(int)cmp.CursorPos.x + (int)cmp.CursorPos.y * cmp.xSize] = ' ';
            }

            if (cmp.CursorPos.y > cmp.ySize - 2) --cmp.CursorPos.y;
            else cmp.CursorPos.y -= 2;

            cmp.UpdScreenText();
            waitForSyntaxError.Remove(cmp);
        }
    }
}
