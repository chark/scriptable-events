namespace ScriptableEvents
{
    /// <summary>
    /// Constants used in the ScriptableEvent package to reduce duplication.
    /// </summary>
    public static class ScriptableEventConstants
    {
        /// <summary>
        /// Prefix of 'Create' event menus.
        /// </summary>
        public const string MenuNameBase = "Scriptable Event";

        /// <summary>
        /// Base menu name of all custom scriptable event sub menus.
        /// </summary>
        public const string MenuNameCustom = MenuNameBase + " (Custom)";

        /// <summary>
        /// Menu order of event assets which use simple arguments.
        /// </summary>
        public const int MenuOrderSimpleEvent = MenuOrderBase - 400;

        /// <summary>
        /// Menu order of event assets which use primitives as arguments.
        /// </summary>
        public const int MenuOrderPrimitiveEvent = MenuOrderBase - 300;

        /// <summary>
        /// Menu order of event assets which use Unity primitives as arguments.
        /// </summary>
        public const int MenuOrderUnityPrimitiveEvent = MenuOrderBase - 200;

        /// <summary>
        /// Menu order of event assets which use Unity objects as arguments.
        /// </summary>
        public const int MenuOrderUnityObjectEvent = MenuOrderBase - 100;

        /// <summary>
        /// Menu order of event tools.
        /// </summary>
        public const int MenuOrderTools = MenuOrderBase;

        /// <summary>
        /// Base menu order of all scriptable event sub menus.
        /// </summary>
        public const int MenuOrderBase = -100;

        /// <summary>
        /// Base menu order of all custom scriptable event sub menus.
        /// </summary>
        public const int MenuOrderCustom = MenuOrderBase;
    }
}
