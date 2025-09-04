using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace docomaticSharpLib.DOX
{
    public class Parsing : DoxItemBase
    {
        public Parsing()
        {
            ConditionalDefines = new DoxItemBase();
            ExcludedSourceFiles = new DoxItemBase();
        }
        public DoxItemBase ConditionalDefines { get; set; }
        public DoxItemBase ExcludedSourceFiles { get; set; }
    }
}
