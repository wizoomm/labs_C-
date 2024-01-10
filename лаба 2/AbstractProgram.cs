using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labrab2
{
    abstract class AbstractProgram: IProgram
    {
        public abstract void Run();

        protected string PromptUser(string prompt)
        {
            Console.WriteLine(prompt);
            Console.Write("> ");
            return Console.ReadLine()!;
        }

    }
}
