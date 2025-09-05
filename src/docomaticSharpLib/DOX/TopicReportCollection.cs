using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace docomaticSharpLib.DOX
{
    public class TopicReportCollection : DoxItemBase
    {
        public TopicReportCollection()
        {
            TopicReports = new Dictionary<int, TopicReport>();
        }
        public Dictionary<int, TopicReport> TopicReports { get; set; }
    }
}
