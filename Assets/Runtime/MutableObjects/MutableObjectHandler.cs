using System.Collections.Generic;
using System.Linq;
using MutableObjects.Generic;

namespace MutableObjects
{
    public class MutableObjectHandler
    {
        private readonly List<IMutableObject> mutableObjects;

        public MutableObjectHandler(List<IMutableObject> mutableObjects)
        {
            this.mutableObjects = mutableObjects;
        }

        /// <summary>
        ///     Set initial mutable object values (ignoring reset type).
        /// </summary>
        public void SetInitialMutableObjectValues()
        {
            // Initial all mutable objects are reset (set initial values).
            ResetMutableObjects(mutableObjects);
        }

        /// <summary>
        ///     Reset objects with <see cref="ResetType.ActiveSceneChange"/> reset type.
        /// </summary>
        public void ResetActiveSceneChange()
        {
            ResetMutableObjects(ResetType.ActiveSceneChange);
        }

        /// <summary>
        ///     Reset objects with <see cref="ResetType.SceneUnloaded"/> reset type.
        /// </summary>
        public void ResetSceneUnloaded()
        {
            ResetMutableObjects(ResetType.SceneUnloaded);
        }

        /// <summary>
        ///     Reset objects with <see cref="ResetType.SceneLoaded"/> reset type.
        /// </summary>
        public void ResetSceneLoaded()
        {
            ResetMutableObjects(ResetType.SceneLoaded);
        }

        private void ResetMutableObjects(ResetType resetType)
        {
            var filteredByType = mutableObjects.Where(obj => obj.ResetType == resetType);
            ResetMutableObjects(filteredByType);
        }

        private static void ResetMutableObjects(IEnumerable<IMutableObject> objects)
        {
            foreach (var obj in objects)
            {
                obj.ResetValues();
            }
        }
    }
}
