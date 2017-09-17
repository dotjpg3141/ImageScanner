using System;

namespace ImageScanner
{
    public abstract class Condition
    {
        public abstract bool Matches(ImageInfo imageInfo);
        public abstract bool IsValid();

        public abstract void ApplyFromString(string value);
        public abstract string GetAsString();

    }
}