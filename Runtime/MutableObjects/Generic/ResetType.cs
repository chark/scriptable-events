using UnityEngine;

namespace MutableObjects.Generic
{
    public enum ResetType
    {
        [Tooltip("Do not reset")]
        None,

        [Tooltip("Reset when the active (focused) scene changes")]
        ActiveSceneChange,

        [Tooltip("Reset when the current scene gets unloaded")]
        SceneUnloaded,

        [Tooltip("Reset when the scene is loaded")]
        SceneLoaded
    }
}
