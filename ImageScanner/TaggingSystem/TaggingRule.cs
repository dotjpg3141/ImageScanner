using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ImageScanner.TaggingSystem
{
    public class TaggingRule
    {
        public string RuleName { get; set; }
        public string Tag { get; set; }
        public ConditionOperator ConditionOperator { get; set; }
        public List<Condition> Conditions { get; set; } = new List<Condition>();

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

        public override string ToString()
        {
            return $"{RuleName}: {Tag}";
        }

        public static List<Type> AvailableConditions => RuleTypes.List;

        private static class RuleTypes
        {
            public static List<Type> List = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(assembly => assembly.GetTypes())
                .Where(type => type.IsSubclassOf(typeof(Condition)) && type.GetCustomAttribute<RuleConditionAttribute>() != null)
                .ToList();
        }
    }
}
