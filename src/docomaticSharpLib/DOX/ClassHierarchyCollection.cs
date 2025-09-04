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
            ClassHierarchies = new List<ClassHierarchy>();
        }
        public int Count { get; set; }
        public int Current { get; set; }

        public List<ClassHierarchy> ClassHierarchies { get; set; }
    }
}
