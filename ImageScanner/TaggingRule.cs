using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageScanner
{
    public class TaggingRule
    {
        public string RuleName { get; set; }
        public string Tag { get; set; }
        public ConditionOperator ConditionOperator { get; set; }
        public List<Condition> Conditions { get; set; }

        public bool Matches(ImageInfo imageInfo)
        {
            switch (ConditionOperator)
            {
                case ConditionOperator.All:
                    return Conditions.All(c => c.Matches(imageInfo));

                case ConditionOperator.Any:
                    return Conditions.Any(c => c.Matches(imageInfo));

                case ConditionOperator.None:
                    return !Conditions.Any(c => c.Matches(imageInfo));

                default:
                    throw new InvalidOperationException("unexpected enum value " + ConditionOperator);
            }
        }
    }
}
