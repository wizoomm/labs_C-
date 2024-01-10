using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labrab5
{
    [PrimaryKey(nameof(Name), nameof(Composer))]
    public class Composition
    {
        public required string Name { get; set; }
        public required string Composer { get; set; }

        public bool SearchMatches(string query)
        {
            return Name == query || Composer == query;
        }

        public new string ToString()
        {
            return Composer + " - " + Name;
        }
    }
}
