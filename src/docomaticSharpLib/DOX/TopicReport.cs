using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace docomaticSharpLib.DOX
{
    public class TopicReport : DoxItemBase
    {
        public TopicReport()
        {
            Items = new List<DoxItemBase>();
        }
        public int Index { get; set; } = 0;
        public List<DoxItemBase> Items { get; set; }
    }
}
