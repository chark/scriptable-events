using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace ScriptableEvents.Editor
{
    /// <summary>
    /// Extensions to create custom C# scripts.
    /// </summary>
    internal static class TemplateExtensions
    {
        #region Internal Methods

        /// <summary>
        /// Save script to file.
        /// </summary>
        internal static void SaveScript(
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
        }

        /// <summary>
        /// Create script from a template.
        /// </summary>
        internal static string CreateScript(
            this string templateName,
            IDictionary<string, object> substitutes,
            IEnumerable<string> imports
        )
        {
            var template = LoadTemplate(templateName);
            var templateText = template.text;

            return SubstituteScript(templateText, substitutes, imports);
        }

        #endregion

        #region Private Methods

        private static TextAsset LoadTemplate(string name)
        {
            var templatePath = $"Packages/com.chark.scriptable-events/Editor/Templates/{name}.txt";
            var template = AssetDatabase.LoadAssetAtPath<TextAsset>(templatePath);

            return template;
        }

        private static string SubstituteScript(
            string script,
            IDictionary<string, object> substitutes,
            IEnumerable<string> imports
        )
        {
            var substitutedScript = script;

            foreach (var substitutePair in substitutes)
            {
                var placeholderName = substitutePair.Key;
                var substituteValue = substitutePair.Value.ToString();

                var placeholder = $"${{{placeholderName}}}";
                substitutedScript = substitutedScript.Replace(placeholder, substituteValue);
            }

            foreach (var import in imports)
            {
                if (IsContainsImport(substitutedScript, import))
                {
                    continue;
                }

                substitutedScript = $"using {import};\n{substitutedScript}";
            }

            return substitutedScript;
        }

        private static bool IsContainsImport(string script, string import)
        {
            return script.Contains($"using {import};") || script.Contains($"namespace {import}");
        }

        #endregion
    }
}
