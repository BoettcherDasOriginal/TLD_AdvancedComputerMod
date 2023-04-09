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
        public override string Description { get { return "Range: 5km"; } }
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

    public class ACM_Radar_cmd : ACM_ICommand
    {
        public override string Name { get { return "radar"; } }
        public override string Description { get { return "simple radar"; } }
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
            console.ReplaceScreen(Radar());
        }
        public void Help()
        {

        }

        public string Radar()
        {
            float radius = 1600f; //m
            float cellSize = 200f;

            Vector3 radarZero = cmp.transform.position - new Vector3(radius, 0, radius);
            List<GameObject> BuildingObjects = mainscript.M.objCountBuilding.objects;

            string[] radarString = new string[16];
            bool building = false;
            for (int y = 0; y < 16; y++)
            {
                string line = "";
                for (int x = 0; x < 16; x++)
                {
                    building = false;
                    foreach (GameObject obj in BuildingObjects)
                    {
                        if (obj.transform.position.x > radarZero.x + x * cellSize &&
                           obj.transform.position.x < radarZero.x + (x + 1) * cellSize &&
                           obj.transform.position.z > radarZero.z + y * cellSize &&
                           obj.transform.position.z < radarZero.z + (y + 1) * cellSize)
                        {
                            building = true;
                        }
                    }

                    if (y == 7 && x == 7)
                    {
                        line += "P";
                    }
                    else if (building)
                    {
                        line += "B";
                    }
                    else { line += " "; }
                }
                radarString[y] = line;
            }

            string result = " a b c d e f g h |Radar v1.0  " +
                "1" + radarString[0] + "+------------" +
                " " + radarString[1] + "|     N      " +
                "2" + radarString[2] + "|    W O     " +
                " " + radarString[3] + "|     S      " +
                "3" + radarString[4] + "+------------" +
                " " + radarString[5] + "|Radius:1600m" +
                "4" + radarString[6] + "|Cell:   200m" +
                " " + radarString[7] + "+------------" +
                "5" + radarString[8] + "|B = Building" +
                " " + radarString[9] + "|P = Current " +
                "6" + radarString[10] + "|            " +
                " " + radarString[11] + "|            " +
                "7" + radarString[12] + "|            " +
                " " + radarString[13] + "|            " +
                "8" + radarString[14] + "|            " +
                " " + radarString[15] + "|           ";

            return result;
        }
    }
}
