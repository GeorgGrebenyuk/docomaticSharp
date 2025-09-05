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
            if (base.DataRaw.ContainsKey("Count")) Count = Convert.ToInt32(base.DataRaw["Count"]);
            if (base.DataRaw.ContainsKey("ETPCommand0"))  ETPCommand0 = Convert.ToInt32(base.DataRaw["ETPCommand0"]);
            if (base.DataRaw.ContainsKey("ETPCommand1")) ETPCommand1 = Convert.ToInt32(base.DataRaw["ETPCommand1"]);
            if (base.DataRaw.ContainsKey("ETPCommand2")) ETPCommand2 = Convert.ToInt32(base.DataRaw["ETPCommand2"]);
            if (base.DataRaw.ContainsKey("ETPContentsEntry2")) ETPContentsEntry2 = Convert.ToInt32(base.DataRaw["ETPContentsEntry2"]);
            if (base.DataRaw.ContainsKey("ETPGroup1")) ETPGroup1 = base.DataRaw["ETPGroup1"];
            if (base.DataRaw.ContainsKey("ETPTopicOrder0")) ETPTopicOrder0 = Convert.ToInt32(base.DataRaw["ETPTopicOrder0"]);
        }

        public string TopicId { get; set; }

        public int Count { get; set; }
        public int? ETPCommand0 { get; set; }
        public int? ETPCommand1 { get; set; }
        public int? ETPCommand2 { get; set; }
        public int? ETPContentsEntry2 { get; set; }
        public string? ETPGroup1 { get; set; }
        public int? ETPTopicOrder0 { get; set; }

        public override string ToDoxString()
        {
            this.NameRaw = "External Topic Properties\\" + TopicId;
            string countDataS = this.DataRaw["Count"];
            this.DataRaw = new Dictionary<string, string>();
            this.DataRaw.Add("Count", countDataS);

            int countData = 0;
            if (ETPCommand0 != null)
            {
                countData++;
                this.DataRaw.Add("ETPCommand0", ETPCommand0.Value.ToString());
            }
            if (ETPCommand1 != null)
            {
                countData++;
                this.DataRaw.Add("ETPCommand1", ETPCommand1.Value.ToString());
            }
            if (ETPCommand2 != null)
            {
                countData++;
                this.DataRaw.Add("ETPCommand2", ETPCommand2.Value.ToString());
            }
            if (ETPContentsEntry2 != null)
            {
                countData++;
                this.DataRaw.Add("ETPContentsEntry2", ETPContentsEntry2.Value.ToString());
            }
            if (ETPGroup1 != null)
            {
                countData++;
                this.DataRaw.Add("ETPGroup1", ETPGroup1);
            }
            if (ETPTopicOrder0 != null)
            {
                countData++;
                this.DataRaw.Add("ETPTopicOrder0", ETPTopicOrder0.Value.ToString());
            }

            //this.DataRaw["Count"] = countData.ToString();

            return base.ToDoxString();
        }

    }
}
