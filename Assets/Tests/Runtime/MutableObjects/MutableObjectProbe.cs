using MutableObjects.Generic;

namespace MutableObjects
{
    public class MutableObjectProbe : IMutableObject
    {
        public bool Persisting { get; set; }

        public int ResetCount { get; private set; }

        public void ResetValues()
        {
            ResetCount++;
        }
    }
}
