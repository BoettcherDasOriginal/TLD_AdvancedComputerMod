using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TLDLoader;

namespace TLD_AdvancedComputerMod
{
    public class AdvancedComputerMod : Mod
    {
        public override string ID => nameof(AdvancedComputerMod);

        public override string Version => "0.0.1";

        public override string Author => "leonarudo";

        public override string Name => "Advanced Computer";

        mainscript.ModEvent modEvent = onComputerHitEnterWithCommand;

        public override void Update()
        {
            if (ModLoader.GetCurrentScene() == ModLoader.CurrentScene.Game)
            {
                if (!mainscript.ModEvents.Contains(modEvent))
                {
                    mainscript.ModEvents.Add(modEvent);
                }
            }
        }

        public static void onComputerHitEnterWithCommand(object sender, string eventType)
        {
            if (eventType.Contains(':'))
            {
                string[] eventTypeName = eventType.Split(':');

                if (eventTypeName[0].Equals("ComputerHitEnterWithCommand"))
                {
                    computerscript computerscript = (computerscript)sender;

                    ACM_ComputerMain.handleComputerInput(computerscript,eventTypeName[1]);
                }

                if (eventType.Equals("ComputerPostWrite:?Syntax  Error"))
                {
                    computerscript cmp = (computerscript)sender;

                    if(ACM_ComputerMain.waitForSyntaxError.Contains(cmp)) ACM_ComputerMain.removeSyntaxError(cmp);
                }
            }
        }
    }
}
