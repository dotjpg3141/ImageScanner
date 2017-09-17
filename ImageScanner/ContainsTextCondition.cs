using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageScanner
{
    [RuleCondition("Contains OCR text")]
    public class ContainsTextCondition : Condition
    {
        private string _ContainingText;

        public string ContainingText
        {
            get { return _ContainingText; }
            set { _ContainingText = value?.ToLowerInvariant(); }
        }

        public override void ApplyFromString(string value)
        {
            this.ContainingText = value;
        }

        public override string GetAsString()
        {
            return ContainingText;
        }

        public override bool IsValid()
        {
            return !string.IsNullOrEmpty(_ContainingText);
        }

        public override bool Matches(ImageInfo imageInfo)
        {
            return imageInfo.Text.ToLowerInvariant().Contains(ContainingText);
        }
    }
}
