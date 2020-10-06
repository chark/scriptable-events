using System.Collections.Generic;
using System.Linq;
using MutableObjects.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MutableObjects
{
    public static class MutableObjectHandler
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void RuntimeInit()
        {
            SetInitialMutableObjectValues();
            SceneManager.sceneUnloaded += scene => ResetMutableObjectValues();
        }

        private static void SetInitialMutableObjectValues()
        {
            var mutableObjects = FindMutableObjects();
            foreach (var mutableObject in mutableObjects)
            {
                mutableObject.ResetValues();
            }
        }

        private static void ResetMutableObjectValues()
        {
            var mutableObjects = FindMutableObjects()
                .Where(mutableObject => !mutableObject.Persisting);

            foreach (var mutableObject in mutableObjects)
            {
                mutableObject.ResetValues();
            }
        }

        private static IEnumerable<IMutableObject> FindMutableObjects()
        {
            return Resources.FindObjectsOfTypeAll<MutableObject>();
        }
    }
}
