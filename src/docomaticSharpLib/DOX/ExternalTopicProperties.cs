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
            Topics = new Dictionary<string, ExternalTopic>();
        }

        public Dictionary<string, ExternalTopic> Topics { get; set; }
    }
}
