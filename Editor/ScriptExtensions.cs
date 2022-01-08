using System.IO;

namespace ScriptableEvents.Editor
{
    /// <summary>
    /// Extensions to persist custom C# scripts.
    /// </summary>
    internal static class ScriptExtensions
    {
        #region Internal Methods

        /// <summary>
        /// Save script to a file.
        /// </summary>
        internal static string SaveScript(
            this string scriptContent,
            string scriptDirectory,
            string scriptName,
            string scriptNamespace
        )
        {
            var scriptPath = Path.Combine(
                scriptDirectory,
                scriptNamespace.Replace(".", "/"),
                $"{scriptName}.cs"
            );

            var scriptDir = Path.GetDirectoryName(scriptPath);
            if (scriptDir != null && !Directory.Exists(scriptDir))
            {
                Directory.CreateDirectory(scriptDir);
            }

            File.WriteAllText(scriptPath, scriptContent);

            return scriptPath;
        }

        #endregion
    }
}
