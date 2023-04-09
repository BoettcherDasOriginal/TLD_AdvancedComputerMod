using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace TLD_AdvancedComputerMod.ACM_OS
{
    public class ACMConsole
    {
        /// <summary>
        /// The currently linked computerscript
        /// </summary>
        computerscript cmp;

        public ACMConsole(computerscript cmp) { this.cmp = cmp; }

        /// <summary>
        /// Writes the specified string to the defined computerscript screen.
        /// </summary>
        /// <param name="message"></param>
        public void Write(string message)
        {
            cmp.Write(message);
        }

        /// <summary>
        /// Writes the specified string value, followed by the current line terminator, to the defined computerscript screen.
        /// </summary>
        /// <param name="message"></param>
        public void WriteLine(string message)
        {
            cmp.WriteLn(message);
        }

        /// <summary>
        /// Replaces the shown characters with the new ones or ' '.
        /// </summary>
        /// <param name="replacement"></param>
        public void ReplaceScreen(string replacement)
        {
            cmp.ScreenText.text = "";
            cmp.screenText = new char[cmp.xSize * cmp.ySize];
            for (int index = 0; index < cmp.screenText.Length; ++index)
                cmp.screenText[index] = ' ';

            Vector2 newCursorPos = Vector2.zero;
            for (int y = 0; y < cmp.ySize; ++y)
            {
                for (int x = 0; x < cmp.xSize; ++x)
                {
                    if((x + y * cmp.xSize) < replacement.Length)
                    {
                        cmp.screenText[x + y * cmp.xSize] = replacement.ToCharArray()[x + y * cmp.xSize];
                    }
                    else
                    {
                        if(newCursorPos == Vector2.zero)
                        {
                            newCursorPos = new Vector2((float)x,(float)y);
                        }
                        cmp.screenText[x + y * cmp.xSize] = ' ';
                    }

                    cmp.ScreenText.text += cmp.screenText[x + y * cmp.xSize].ToString();
                }
                cmp.ScreenText.text += "\n";
            }

            if(replacement != " ") { cmp.CursorPos = newCursorPos; }
            else { cmp.CursorPos = new Vector2(0f,-1f); }
        }

        /// <summary>
        /// Clears the screen
        /// </summary>
        public void ClearScreen()
        {
            ReplaceScreen(" ");
        }
    }
}
