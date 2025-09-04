using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace docomaticSharpLib.DOX
{
    public class Configuration : DoxItemBase
    {
        public string Name { get; set; }

        public List<DoxItemBase> Items { get; set; }
    }
}
