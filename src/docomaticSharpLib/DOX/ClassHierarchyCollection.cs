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

        public Dictionary<int, ClassHierarchy> ClassHierarchies { get; set; }

        public override string ToDoxString()
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine(GetDoxName());
            str.AppendLine(GetData());

            foreach (var item in ClassHierarchies)
            {
                str.AppendLine(item.Value.ToDoxString());
            }

            return str.ToString();
        }
    }
}
