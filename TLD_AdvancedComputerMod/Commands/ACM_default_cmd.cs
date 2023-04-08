using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TLD_AdvancedComputerMod.ACM_OS;

namespace TLD_AdvancedComputerMod.Commands
{
    #region SYSTEM_CMDS

    public class ACM_Help_cmd : ACM_ICommand
    {
        public override string Name { get { return "help"; } }
        public override string Description { get { return "shows help"; } }
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
            Help();
        }
        public void Help()
        {
            foreach(ACM_ICommand command in ACM_ComputerMain.ICommands)
            {
                if(command.Name != "") 
                {
                    console.WriteLine(command.Name + " => " + command.Description);
                }
            }
        }
    }

    public class ACM_Reload_cmd : ACM_ICommand
    {
        public override string Name { get { return "reload"; } }
        public override string Description { get { return "reloads commands"; } }
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
            ACM_ComputerMain.acm_init();

            console.WriteLine("All commands reloaded!");
        }
        public void Help()
        {

        }
    }

    public class ACM_Helloworld_cmd : ACM_ICommand
    {
        public override string Name { get { return "helloworld"; } }
        public override string Description { get { return "Test Command"; } }
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
            console.WriteLine("Hello World!");
        }
        public void Help()
        {
            
        }
    }

    #endregion
    #region MATH_CMDS

    public class ACM_Add_cmd : ACM_ICommand
    {
        public override string Name { get { return "add"; } }
        public override string Description { get { return "add <f> <f>"; } }
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
            if(Arguments.Length > 2)
            {
                float result = float.Parse(Arguments[1]) + float.Parse(Arguments[2]);
                console.WriteLine($"{result}");
            }
        }
        public void Help()
        {

        }
    }

    public class ACM_Sub_cmd : ACM_ICommand
    {
        public override string Name { get { return "sub"; } }
        public override string Description { get { return "sub <f> <f>"; } }
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
            if (Arguments.Length > 2)
            {
                float result = float.Parse(Arguments[1]) - float.Parse(Arguments[2]);
                console.WriteLine($"{result}");
            }
        }
        public void Help()
        {

        }
    }

    public class ACM_Mul_cmd : ACM_ICommand
    {
        public override string Name { get { return "mul"; } }
        public override string Description { get { return "mul <f> <f>"; } }
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
            if (Arguments.Length > 2)
            {
                float result = float.Parse(Arguments[1]) * float.Parse(Arguments[2]);
                console.WriteLine($"{result}");
            }
        }
        public void Help()
        {

        }
    }

    public class ACM_Div_cmd : ACM_ICommand
    {
        public override string Name { get { return "div"; } }
        public override string Description { get { return "div <f> <f>"; } }
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
            if (Arguments.Length > 2)
            {
                float result = float.Parse(Arguments[1]) / float.Parse(Arguments[2]);
                console.WriteLine($"{result}");
            }
        }
        public void Help()
        {

        }
    }

    public class ACM_Pow_cmd : ACM_ICommand
    {
        public override string Name { get { return "pow"; } }
        public override string Description { get { return "pow <f> <f>"; } }
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
            if (Arguments.Length > 2)
            {
                double result = Math.Pow(double.Parse(Arguments[1]), double.Parse(Arguments[2]));
                console.WriteLine($"{result}");
            }
        }
        public void Help()
        {

        }
    }

    public class ACM_Sqrt_cmd : ACM_ICommand
    {
        public override string Name { get { return "sqrt"; } }
        public override string Description { get { return "sqrt <f>"; } }
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
            if (Arguments.Length > 1)
            {
                double result = Math.Sqrt(double.Parse(Arguments[1]));
                console.WriteLine($"{result}");
            }
        }
        public void Help()
        {

        }
    }

    #endregion
}
