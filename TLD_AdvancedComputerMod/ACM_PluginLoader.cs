using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TLD_AdvancedComputerMod.ACM_OS;

namespace TLD_AdvancedComputerMod
{
    public class ACM_PluginLoader
    {
        public static void loadPlugins()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\TheLongDrive\\Mods\\ACM_Data\\plugins";
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            //Load the DLLs from the Plugins directory
            GetDlls(path);

            Type interfaceType = typeof(ACM_ICommand);
            //Fetch all types that implement the interface ACM_ICommand and are a class
            Type[] types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(a => a.GetTypes())
                .Where(p => interfaceType.IsAssignableFrom(p) && p.IsClass)
                .ToArray();
            foreach (Type type in types)
            {
                if(type.Assembly.FullName != Assembly.GetExecutingAssembly().FullName)
                {
                    //Create a new instance of all found types
                    ACM_ICommand cmd = (ACM_ICommand)Activator.CreateInstance(type);

                    if (!ACM_ComputerMain.ICommands.Contains(cmd))
                    {
                        ACM_ComputerMain.ICommands.Add(cmd);
                    }
                }
            }

            GC.Collect(); // collects all unused memory
            GC.WaitForPendingFinalizers(); // wait until GC has finished its work
            GC.Collect();
        }

        static void GetDlls(string path)
        {
            //Get Dll
            if (Directory.Exists(path))
            {
                string[] files = Directory.GetFiles(path);
                foreach (string file in files)
                {
                    if (file.EndsWith(".dll"))
                    {
                        FileInfo fileInfo = new FileInfo(file);
                        if (!IsAssemblyLoaded(fileInfo.Name.Replace(".dll", "")))
                        {
                            Assembly.Load(File.ReadAllBytes(Path.GetFullPath(file)));
                        }
                    }
                }

                string[] dirs = Directory.GetDirectories(path);
                foreach (string dir in dirs)
                {
                    GetDlls(Path.GetFullPath(dir));
                }
            }
        }

        static bool IsAssemblyLoaded(string fullName)
        {
            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
            foreach (Assembly assembly in assemblies)
            {
                if (assembly.FullName.Split(',')[0] == fullName)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
