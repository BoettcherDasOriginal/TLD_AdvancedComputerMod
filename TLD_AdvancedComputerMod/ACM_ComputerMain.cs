using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TLD_AdvancedComputerMod
{
    internal class ACM_ComputerMain
    {
        public static List<computerscript> waitForSyntaxError = new List<computerscript>();

        public static void handleComputerInput(computerscript cmp, string computerInput)
        {
            string[] args = computerInput.Split(' ');
            switch (args[0])
            {
                case "helloworld":
                    cmp.WriteLn("Hello World!");
                    waitForSyntaxError.Add(cmp);
                    break;
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

            if (cmp.CursorPos.y > cmp.ySize - 1) --cmp.CursorPos.y;
            else cmp.CursorPos.y -= 2;

            cmp.UpdScreenText();
            waitForSyntaxError.Remove(cmp);
        }
    }
}
