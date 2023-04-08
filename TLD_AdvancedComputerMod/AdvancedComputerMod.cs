using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TLDLoader;
using UnityEngine;

namespace TLD_AdvancedComputerMod
{
    public class AdvancedComputerMod : Mod
    {
        public override string ID => nameof(AdvancedComputerMod);

        public override string Version => "0.0.1";

        public override string Author => "leonarudo";

        public override string Name => "Advanced Computer";

        mainscript.ModEvent modEvent = onComputerEvent;

        public override void Update()
        {
            if (ModLoader.GetCurrentScene() == ModLoader.CurrentScene.Game)
            {
                if (!mainscript.ModEvents.Contains(modEvent))
                {
                    mainscript.ModEvents.Add(modEvent);
                }
            }

            foreach(ACM_ComputerKernal kernal in ACM_ComputerKernal.kernals)
            {
                kernal.updateScreenText();
                UnityEngine.Debug.LogError((object)$"update Screen on Cmp Name:{kernal.cmp.name}");
            }
        }

        public static void onComputerEvent(object sender,string eventType)
        {
            if(eventType.Contains(":"))
            {
                string[] eventName = eventType.Split(':');

                if (eventName[0].Equals("ComputerHitEnterWithCommand"))
                {
                    computerscript cmp = (computerscript)sender;
                    if (ACM_ComputerKernal.getKernalFromCmp(cmp) == null && eventName[1].Equals("acm"))
                    {
                        Debug.Log("Starting acm os...");
                        ACM_ComputerKernal.activateACMOs(cmp);
                    }
                }
            }
        }
    }
}
