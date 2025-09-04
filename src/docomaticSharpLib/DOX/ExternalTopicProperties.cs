using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace docomaticSharpLib.DOX
{
    public class ExternalTopicProperties : DoxItemBase
    {
        public ExternalTopicProperties()
        {
            Items = new List<DoxItemBase>();
        }
        public List<DoxItemBase> Items { get; set; }
    }
}
