namespace ScriptableEvents
{
    /// <summary>
    /// Constants used in the ScriptableEvent package to reduce duplication.
    /// </summary>
    public static class ScriptableEventConstants
    {
        /// <summary>
        /// Menu order of event tools.
        /// </summary>
        public const int MenuOrderTools = -200;

        /// <summary>
        /// Menu order of event assets which use simple arguments.
        /// </summary>
        public const int MenuOrderSimpleEvent = -100;

        /// <summary>
        /// Menu order of event assets which use primitives as arguments.
        /// </summary>
        public const int MenuOrderPrimitiveEvent = 0;

        /// <summary>
        /// Menu order of event assets which use Unity primitives as arguments.
        /// </summary>
        public const int MenuOrderUnityPrimitiveEvent = 100;

        /// <summary>
        /// Menu order of event assets which use Unity objects as arguments.
        /// </summary>
        public const int MenuOrderUnityObjectEvent = 200;

        /// <summary>
        /// Menu order of custom event assets.
        /// </summary>
        public const int MenuOrderCustomEvent = 300;

        /// <summary>
        /// Prefix of 'Create' event menus.
        /// </summary>
        public const string MenuNamePrefix = "Scriptable Event";
    }
}
