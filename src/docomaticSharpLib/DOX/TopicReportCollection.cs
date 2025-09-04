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
            TopicReports = new List<TopicReport>();
        }
        public List<TopicReport> TopicReports { get; set; }
    }
}
