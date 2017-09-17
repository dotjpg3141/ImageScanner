using System;

namespace ImageScanner.TaggingSystem
{

    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public sealed class RuleConditionAttribute : Attribute
    {
        public String Description { get; }

        public RuleConditionAttribute(string description)
        {
            Description = description;
        }
    }
}
