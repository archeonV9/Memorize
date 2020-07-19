using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memorize
{
    class Nauka
    {
        public string imie { get; set; }
        public int punktacja { get; set; }
        public int punktacjaZle { get; set; }
        public List<string> slowkaZNAM;
        public List<string> slowkaNIEZNAM;

        public Nauka()
        {
            slowkaZNAM = new List<string>();
            slowkaNIEZNAM = new List<string>();
        }
    }
}

