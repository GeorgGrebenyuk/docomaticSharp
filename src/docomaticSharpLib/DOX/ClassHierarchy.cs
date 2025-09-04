using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace docomaticSharpLib.DOX
{
    public class ClassHierarchy : DoxItemBase
    {
        public int Index { get; set; }
        public List<DoxItemBase> Items { get; set; }
    }
}
