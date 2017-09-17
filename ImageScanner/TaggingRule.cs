using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageScanner
{
    public class TaggingRule
    {
        public string Text { get; set; }
        public string Tag { get; set; }

        public override string ToString()
        {
            return $"'{Text}' -> '{Tag}'";
        }

    }
}
