using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace docomaticSharpLib.DOX
{
    public class ExternalTopic : DoxItemBase
    {
        public ExternalTopic()
        {

        }

        public override void Initialize()
        {
            if (base.DataRaw.ContainsKey("Count"))  Count = Convert.ToInt32(base.DataRaw["Count"]);
            if (base.DataRaw.ContainsKey("ETPCommand0"))  ETPCommand0 = Convert.ToInt32(base.DataRaw["ETPCommand0"]);
            if (base.DataRaw.ContainsKey("ETPCommand1")) ETPCommand1 = Convert.ToInt32(base.DataRaw["ETPCommand1"]);
            if (base.DataRaw.ContainsKey("ETPGroup1")) ETPGroup1 = base.DataRaw["ETPGroup1"];
            if (base.DataRaw.ContainsKey("ETPTopicOrder0")) ETPTopicOrder0 = Convert.ToInt32(base.DataRaw["ETPTopicOrder0"]);
        }

        public string Name { get; set; }

        public int Count { get; set; }
        public int ETPCommand0 { get; set; }
        public int? ETPCommand1 { get; set; }
        public string? ETPGroup1 { get; set; }
        public int? ETPTopicOrder0 { get; set; }

    }
}
