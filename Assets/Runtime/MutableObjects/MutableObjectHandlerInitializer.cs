using System.Collections.Generic;
using MutableObjects.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MutableObjects
{
    public static class MutableObjectHandlerInitializer
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void RuntimeInit()
        {
            var handler = new MutableObjectHandler(FindMutableObjects());
            handler.SetInitialMutableObjectValues();

            SceneManager.activeSceneChanged += (curr, next) => handler.ResetActiveSceneChange();
            SceneManager.sceneUnloaded += scene => handler.ResetSceneUnloaded();
            SceneManager.sceneLoaded += (scene, mode) => handler.ResetSceneLoaded();
        }

        private static List<IMutableObject> FindMutableObjects()
        {
            return new List<IMutableObject>(Resources.FindObjectsOfTypeAll<MutableObject>());
        }
    }
}
