using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace docomaticSharpLib.DOX
{

    public class ClassHierarchyCollection : DoxItemBase
    {
        public ClassHierarchyCollection()
        {
            ClassHierarchies = new Dictionary<int, ClassHierarchy>();
        }

        public int Count { get; set; }
        public int Current { get; set; }

        public Dictionary<int, ClassHierarchy> ClassHierarchies { get; set; }
    }
}
