namespace ScriptableEvents
{
    public static class ScriptableEventConstants
    {
        /// <summary>
        /// Menu order of event assets which use simple arguments.
        /// </summary>
        public const int SimpleScriptableEventOrder = -100;

        /// <summary>
        /// Menu order of event assets which use primitives as arguments.
        /// </summary>
        public const int PrimitiveScriptableEventOrder = 0;

        /// <summary>
        /// Menu order of event assets which use Unity primitives as arguments.
        /// </summary>
        public const int UnityPrimitiveScriptableEventOrder = 100;

        /// <summary>
        /// Menu order of event assets which use Unity objects as arguments.
        /// </summary>
        public const int UnityObjectScriptableEventOrder = 200;

        /// <summary>
        /// Menu order of custom event assets.
        /// </summary>
        public const int CustomScriptableEventOrder = 300;
    }
}
