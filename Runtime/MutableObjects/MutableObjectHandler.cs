using System;
using System.Collections.Generic;
using System.Linq;
using MutableObjects.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MutableObjects
{
    public static class MutableObjectHandler
    {
        /// <summary>
        ///     Default mutable object reset action.
        /// </summary>
        public static readonly Action<IEnumerable<IMutableObject>> DefaultOnReset =
            mutableObjects =>
            {
                foreach (var mutableObject in mutableObjects)
                {
                    mutableObject.ResetValues();
                }
            };

        /// <summary>
        ///     Currently used mutable object reset action.
        /// </summary>
        public static Action<IEnumerable<IMutableObject>> OnReset { get; set; } = DefaultOnReset;

        /// <summary>
        ///     Reset mutable object asset values.
        /// </summary>
        public static void ResetMutableObjectValues(
            IEnumerable<IMutableObject> mutableObjects,
            bool excludePersisting = false
        )
        {
            if (excludePersisting)
            {
                mutableObjects = mutableObjects.Where(mutableObject => !mutableObject.Persisting);
            }

            OnReset(mutableObjects);
        }

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void RuntimeInit()
        {
            SetInitialMutableObjectValues();
            SceneManager.activeSceneChanged += ResetMutableObjectValues;
        }

        private static void SetInitialMutableObjectValues()
        {
            ResetMutableObjectValues(FindMutableObjects());
        }

        private static void ResetMutableObjectValues(Scene curr, Scene next)
        {
            ResetMutableObjectValues(FindMutableObjects(), true);
        }

        private static IEnumerable<IMutableObject> FindMutableObjects()
        {
            return Resources.FindObjectsOfTypeAll<MutableObject>();
        }
    }
}
