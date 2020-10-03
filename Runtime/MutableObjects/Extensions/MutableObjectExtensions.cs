using System.Linq;
using MutableObjects.Generic;
using UnityEngine;

namespace MutableObjects.Extensions
{
    public static class MutableObjectExtensions
    {
        /// <summary>
        ///     Reset all mutable objects to their inspector state.
        /// </summary>
        public static void ResetMutatedObjects()
        {
            var mutableObjects = Resources
                .FindObjectsOfTypeAll<MutableObject>()
                .OfType<IMutableObject>();

            foreach (var mutableObject in mutableObjects)
            {
                mutableObject.ResetValues();
            }
        }
    }
}
