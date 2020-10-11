using MutableObjects.Generic;

namespace MutableObjects
{
    public class MutableObjectProbe : IMutableObject
    {
        public ResetType ResetType { get; set; } = ResetType.None;

        public int ResetCount { get; private set; }

        public void ResetValues()
        {
            ResetCount++;
        }
    }
}
