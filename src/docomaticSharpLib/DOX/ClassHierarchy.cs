using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace docomaticSharpLib.DOX
{
    public class ClassHierarchy : DoxItemBase
    {
        public ClassHierarchy()
        {
            Items = new List<DoxItemBase>();
        }
        public int Index { get; set; } = 0;
        public List<DoxItemBase> Items { get; set; }

        public override string ToDoxString()
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine(this.GetDoxName());
            str.AppendLine(this.GetData());

            foreach (var item in Items)
            {
                str.AppendLine(item.ToDoxString());
            }

            return str.ToString();
        }
    }
}
