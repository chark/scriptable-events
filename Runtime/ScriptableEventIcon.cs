using System;

namespace ScriptableEvents
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public class ScriptableEventIcon : Attribute
    {
        #region Public Properties

        public string IconName { get; set; }

        #endregion
    }
}
