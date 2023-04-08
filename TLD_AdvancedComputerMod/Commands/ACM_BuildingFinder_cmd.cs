using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TLD_AdvancedComputerMod.ACM_OS;
using UnityEngine;

namespace TLD_AdvancedComputerMod.Commands
{
    public class ACM_BuildingFinder_cmd : ACM_ICommand
    {
        public override string Name { get { return "findbuild"; } }
        public override string Description { get { return "5km radar"; } }
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
            Vector3 currentPos = cmp.transform.position;
            List<GameObject> objects = mainscript.M.objCountBuilding.objects;

            float dist = 5000f;
            GameObject nearestObj = null;
            foreach (GameObject obj in objects)
            {
                if(Vector3.Distance(currentPos, obj.transform.position) < dist)
                {
                    dist = Vector3.Distance(currentPos, obj.transform.position);
                    nearestObj = obj;
                }
            }

            if(nearestObj != null)
            {
                string objName = nearestObj.name.ToLower().Replace("(clone)", "");

                Vector3 targetPoint = new Vector3(nearestObj.transform.position.x, currentPos.y, nearestObj.transform.position.z) - currentPos;
                Quaternion targetRot = Quaternion.LookRotation(-targetPoint,Vector3.up);

                console.WriteLine($"{objName}:");
                console.WriteLine($"Dist: {dist}m");
                console.WriteLine($"RotY: {targetRot.y * 360}°");
            }
            else
            {
                console.WriteLine($"No Building in range!");
            }
        }
        public void Help()
        {
            
        }
    }
}
