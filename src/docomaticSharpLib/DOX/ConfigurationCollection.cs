using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace docomaticSharpLib.DOX
{
    public class ConfigurationCollection : DoxItemBase
    {
        public ConfigurationCollection()
        {
            Configurations = new List<Configuration>();
        }

        public List<Configuration> Configurations { get; set; }
    }
}
