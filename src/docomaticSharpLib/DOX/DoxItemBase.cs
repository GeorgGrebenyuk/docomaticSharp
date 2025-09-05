using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace docomaticSharpLib.DOX
{
    /// <summary>
    /// The wrapper around each of DOX's file block
    /// </summary>
    public class DoxItemBase
    {
        public DoxItemBase()
        {
            DataRaw = new Dictionary<string, string>();
        }

        /// <summary>
        /// The name of block without bracets []
        /// </summary>
        public string NameRaw { get; internal set; } = "";

        public string GetDoxName()
        {
            return "[" + NameRaw + "]";
        }

        /// <summary>
        /// Any data in block (key=value)
        /// </summary>
        public Dictionary<string, string> DataRaw { get; internal set; }

        public string GetData()
        {
            StringBuilder str = new StringBuilder();
            foreach (var item in DataRaw)
            {
                str.AppendLine($"{item.Key}={item.Value}");
            }
            return str.ToString();
        }

        public void SetRawFrom(DoxItemBase other)
        {
            NameRaw = other.NameRaw;
            DataRaw = other.DataRaw;
        }

        public virtual void Initialize() { }

        public virtual string ToDoxString()
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine(GetDoxName());
            str.AppendLine(GetData());

            return str.ToString();
        }
    }
}
