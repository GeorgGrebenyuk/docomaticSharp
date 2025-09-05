using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace docomaticSharpLib.DOX
{
    public class SectionCollection : DoxItemBase
    {
        public SectionCollection()
        {
            Sections = new List<DoxItemBase>();
        }
        public List<DoxItemBase> Sections { get; set; }

        public override string ToDoxString()
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine(this.GetDoxName());
            str.AppendLine(this.GetData());

            foreach (var item in Sections)
            {
                str.AppendLine(item.ToDoxString());
            }

            return str.ToString();
        }
    }
}
