using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TLD_AdvancedComputerMod
{
    public class ACM_ComputerKernal
    {
        public static List<ACM_ComputerKernal> kernals = new List<ACM_ComputerKernal>();

        public static void activateACMOs(computerscript cmp)
        {
            ACM_ComputerKernal newKernal = new ACM_ComputerKernal(cmp);
            kernals.Add(newKernal);
        }

        public static void deactivateACMOs(computerscript cmp)
        {
            ACM_ComputerKernal kernal = getKernalFromCmp(cmp);
            if(kernal != null)
            {
                kernals.Remove(kernal);
            }
        }

        public static ACM_ComputerKernal getKernalFromCmp(computerscript cmp)
        {
            foreach (ACM_ComputerKernal kernal in kernals)
            {
                if (kernal.cmp.Equals(cmp))
                {
                    return kernal;
                }
            }
            return null;
        }


        //ACM Kernal class

        public computerscript cmp;
        public char[] screenText;

        public ACM_ComputerKernal(computerscript cmp) 
        { 
            this.cmp = cmp;
            screenText = new char[cmp.xSize * cmp.ySize];
            for (int index = 0; index < this.screenText.Length; ++index)
                this.screenText[index] = ' ';
            cmp.CursorPos.x = 0;
            cmp.CursorPos.y = 0;
        }

        public void updateScreenText()
        {
            cmp.CursorLimits();
            cmp.ScreenText.text = "";
            cmp.screenText = screenText;
            for(int y = 0; y < cmp.ySize; ++y)
            {
                for(int x = 0; x < cmp.xSize; ++x)
                {
                    cmp.ScreenText.text += this.screenText[x + y * cmp.xSize].ToString();
                    cmp.screenText[x + y * cmp.xSize] = this.screenText[x + y * cmp.xSize];
                }
                cmp.ScreenText.text += "\n";
            }
        }
    }
}
