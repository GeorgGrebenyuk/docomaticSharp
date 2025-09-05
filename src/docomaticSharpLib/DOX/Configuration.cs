using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace docomaticSharpLib.DOX
{
    public class Configuration : DoxItemBase
    {
        public Configuration()
        {
            Items = new List<DoxItemBase>();
        }
        public string Name { get; set; } = "";

        public List<DoxItemBase> Items { get; set; }

        public override string ToDoxString()
        {
            StringBuilder str = new StringBuilder();

            foreach (DoxItemBase item in Items)
            {
                str.AppendLine(item.ToDoxString());
            }

            return str.ToString();
        }
    }
}
