namespace MutableObjects.Generic
{
    public interface IMutableObject
    {
        /// <summary>
        ///     When this mutable object should be reset.
        /// </summary>
        ResetType ResetType { get; }

        /// <summary>
        ///     Reset values on this mutable object to their original ones.
        /// </summary>
        void ResetValues();
    }
}
