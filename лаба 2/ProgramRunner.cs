using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labrab2
{
    internal class ProgramRunner
    {
        public static void Main()
        {
            IProgram program = new CompositionsProgram();
            program.Run();
        }
    }
}
