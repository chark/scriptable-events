using System;
using System.IO;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

namespace ScriptableEvents.Editor
{
    /// <summary>
    /// Takes screenshots of editor windows.
    /// </summary>
    internal static class Screenshots
    {
        #region Private Menu Item Methods

        [MenuItem("Tools/Set Event Window Size %&F1")]
        private static void SetEventWindowSize()
        {
            SetFocusedWindowSize(360f, 400f);
        }

        [MenuItem("Tools/Set Script Listener Window Size %&F2")]
        private static void SetListenerWindowSize()
        {
            SetFocusedWindowSize(360f, 400f);
        }

        [MenuItem("Tools/Set Script Creator Window Size %&F3")]
        private static void SetScriptCreatorWindowSize()
        {
            SetFocusedWindowSize(360f, 520f);
        }

        [MenuItem("Tools/Screenshot Editor Window %&s")]
        private static void ScreenshotEditorWindow()
        {
            if (!TryGetFocusedEditorWindow(out var window))
            {
                return;
            }

            TakeScreenShot(window);
        }

        #endregion

        #region Private Methods

        private static void SetFocusedWindowSize(float width, float height)
        {
            if (!TryGetFocusedEditorWindow(out var window))
            {
                return;
            }

            var windowPosition = window.position;
            windowPosition.width = width;
            windowPosition.height = height;

            window.position = windowPosition;
            window.Repaint();
        }

        private static bool TryGetFocusedEditorWindow(out EditorWindow window)
        {
            window = EditorWindow.focusedWindow;
            if (window == null)
            {
                Debug.LogError("No focused window!");
                return false;
            }

            return true;
        }

        private static void TakeScreenShot(EditorWindow window)
        {
            var windowPosition = window.position;
            var width = (int) windowPosition.width;
            var height = (int) windowPosition.height;

            var pixels = InternalEditorUtility.ReadScreenPixel(
                window.position.position,
                width,
                height
            );

            var texture = new Texture2D(
                width,
                height,
                TextureFormat.RGB24,
                false
            );

            texture.SetPixels(pixels);

            var bytes = texture.EncodeToPNG();

            var name = window.titleContent.text.Replace(" ", "");
            var time = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
            var path = $"{Application.dataPath}/Screenshot-{name}-{time}.png";

            File.WriteAllBytes(path, bytes);

            Debug.Log($"Saved screenshot: {path}");
        }

        #endregion
    }
}
