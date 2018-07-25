using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AfinicAlgoritm
{
    class Data
    {
        public int FirstFactor { get; set; }
        public int SecondFactor { get; set; }
        public string KeyWord { get; set; }
        public int Mod { get; set; }
        public char[] CharTab { get; set; }
        public int[] IntAlphabet { get; set; }
        public int[] TransIntAlphabet { get; set; }
        public char[] TransChar { get; set; }
        public int InvertMod { get; set; }
        public bool IsInvertAble { get; set; }
    }
}
