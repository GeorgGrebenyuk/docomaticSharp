using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace docomaticSharpLib.DOX
{
    public class WorkflowCollection : DoxItemBase
    {
        public WorkflowCollection()
        {
            Workflows = new List<DoxItemBase>();
        }
        public List<DoxItemBase> Workflows { get; set; }
    }
}
