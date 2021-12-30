namespace ScriptableEvents
{
    /// <summary>
    /// Constants used in the ScriptableEvent package to reduce duplication.
    /// </summary>
    public static class ScriptableEventConstants
    {
        #region Public Constants

        /// <summary>
        /// Base menu name of all custom scriptable event sub menus.
        /// </summary>
        public const string MenuNameCustom = MenuNameBase + " (Custom)";

        /// <summary>
        /// Base menu order of all custom scriptable event sub menus.
        /// </summary>
        public const int MenuOrderCustom = MenuOrderBase;

        #endregion

        #region Internal Constants

        /// <summary>
        /// Prefix of 'Create' event menus.
        /// </summary>
        internal const string MenuNameBase = "Scriptable Event";

        /// <summary>
        /// Menu order of event assets which use simple arguments.
        /// </summary>
        internal const int MenuOrderSimpleEvent = MenuOrderBase - 400;

        /// <summary>
        /// Menu order of event assets which use primitives as arguments.
        /// </summary>
        internal const int MenuOrderPrimitiveEvent = MenuOrderBase - 300;

        /// <summary>
        /// Menu order of event assets which use Unity primitives as arguments.
        /// </summary>
        internal const int MenuOrderUnityPrimitiveEvent = MenuOrderBase - 200;

        /// <summary>
        /// Menu order of event assets which use Unity objects as arguments.
        /// </summary>
        internal const int MenuOrderUnityObjectEvent = MenuOrderBase - 100;

        /// <summary>
        /// Menu order of event tools.
        /// </summary>
        internal const int MenuOrderTools = MenuOrderBase;

        /// <summary>
        /// Path of the package.
        /// </summary>
        internal const string PackagePath = "Packages/com.chark.scriptable-events";

        #endregion

        #region Private Constants

        /// <summary>
        /// Base menu order of all scriptable event sub menus.
        /// </summary>
        private const int MenuOrderBase = -100;

        #endregion
    }
}
