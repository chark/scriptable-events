using MutableObjects.Extensions;
using UnityEngine;

namespace MutableObjects
{
    public class SceneHandler : MonoBehaviour
    {
        private void Awake()
        {
            MutableObjectExtensions.ResetMutatedObjects();
        }
    }
}
