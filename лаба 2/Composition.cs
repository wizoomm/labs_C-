using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labrab2
{
    internal class Composition
    {
        private readonly string name;
        private readonly string composer;

        public Composition(string name, string composer)
        {
            this.name = name;
            this.composer = composer;
        }

        public bool SearchMatches(string query)
        {
            return name == query || composer == query;
        }

        public new string ToString()
        {
            return composer + " - " + name;
        }
    }
}
