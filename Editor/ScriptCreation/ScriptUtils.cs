using System.IO;

namespace CHARK.ScriptableEvents.Editor.ScriptCreation
{
    /// <summary>
    /// Utilities to persist custom C# scripts.
    /// </summary>
    internal static class ScriptUtils
    {
        #region Internal Methods

        /// <summary>
        /// Save script to a file.
        /// </summary>
        internal static void SaveScript(
            string scriptContent,
            string scriptDirectory,
            string scriptName
        )
        {
            var scriptPath = Path.Combine(scriptDirectory, $"{scriptName}.cs");
            SaveScript(scriptContent, scriptPath);
        }

        /// <summary>
        /// Save script to a file and create directories for its namespace.
        /// </summary>
        internal static void SaveScript(
            string scriptContent,
            string scriptDirectory,
            string scriptName,
            string scriptNamespace
        )
        {
            var namespacePath = scriptNamespace.Replace(".", "/");
            var scriptPath = Path.Combine(scriptDirectory, namespacePath, $"{scriptName}.cs");

            SaveScript(scriptContent, scriptPath);
        }

        #endregion

        #region Private Methods

        private static void SaveScript(string content, string path)
        {
            var scriptDir = Path.GetDirectoryName(path);
            if (scriptDir != null && !Directory.Exists(scriptDir))
            {
                Directory.CreateDirectory(scriptDir);
            }

            File.WriteAllText(path, content);
        }

        #endregion
    }
}
