namespace MutableObjects.Generic
{
    public interface IMutableObject
    {
        /// <summary>
        ///     Is this mutable object persisting throughout the scenes and should not be reset.
        /// </summary>
        bool Persisting { get; }

        /// <summary>
        ///     Reset values on this mutable object to their original ones.
        /// </summary>
        void ResetValues();
    }
}
