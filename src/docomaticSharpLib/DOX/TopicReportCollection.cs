using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace docomaticSharpLib.DOX
{
    public class TopicReportCollection : DoxItemBase
    {
        public TopicReportCollection()
        {
            TopicReports = new Dictionary<int, TopicReport>();
        }
        public Dictionary<int, TopicReport> TopicReports { get; set; }

        public override string ToDoxString()
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine(this.GetDoxName());
            str.AppendLine(this.GetData());

            foreach (var item in TopicReports)
            {
                str.AppendLine(item.Value.ToDoxString());
            }

            return str.ToString();
        }
    }
}
