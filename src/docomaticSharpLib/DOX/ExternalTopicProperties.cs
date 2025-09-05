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
            TopicIds = new Dictionary<int, string>();
        }

        public override void Initialize()
        {
            foreach (var prop in base.DataRaw)
            {
                if (prop.Key.Contains("ID"))
                {
                    int topicId = Convert.ToInt32(prop.Key.Replace("ID", ""));
                    this.TopicIds.Add(topicId, prop.Value);
                }
            }
        }

        public void AddTopic(ExternalTopic topicDef)
        {
            TopicIds.Add(TopicIds.Count(), topicDef.TopicId);
            Topics.Add(topicDef.TopicId, topicDef);
        }

        public Dictionary<int, string> TopicIds { get; set; }
        public Dictionary<string, ExternalTopic> Topics { get; set; }

        public override string ToDoxString() 
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine(this.GetDoxName());
            this.DataRaw = new Dictionary<string, string>();
            this.DataRaw.Add("Count", TopicIds.Count().ToString());
            foreach (var topicInfo in TopicIds)
            {
                this.DataRaw.Add("ID" + topicInfo.Key.ToString(), topicInfo.Value);
            }

            str.AppendLine(this.GetData());

            //topics
            foreach (var topic in Topics)
            {
                str.AppendLine(topic.Value.ToDoxString());
            }

            return str.ToString();
        }

    }
}
