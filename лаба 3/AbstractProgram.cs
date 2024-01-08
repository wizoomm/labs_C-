using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labrab3
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
        protected int PromptChoice(string prompt, string[] choices)
        {
            Console.WriteLine(prompt);
            for(int i = 0; i< choices.Length; i++)
            {
                Console.WriteLine(i + 1 + " " + choices[i]);
            }
            return int.Parse(Console.ReadLine());
        }
    }
}
