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
        public List<string> slowka;
        public List<string> slowkaTlumaczenie;

        public Nauka()
        {
            slowkaZNAM = new List<string>();
            slowkaNIEZNAM = new List<string>();
            slowka = new List<string>();
            slowkaTlumaczenie = new List<string>();
        }
    }
}

