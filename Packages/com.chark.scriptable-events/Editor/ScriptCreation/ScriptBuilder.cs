using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace CHARK.ScriptableEvents.Editor.ScriptCreation
{
    /// <summary>
    /// Creates custom scriptable event scripts from template files.
    /// </summary>
    internal class ScriptBuilder
    {
        #region Private Fields

        private const string TemplatePath =
            ScriptableEventConstants.PackagePath + "/Editor/ScriptCreation/Templates";

        private readonly string templateName;

        private readonly Dictionary<string, string> substitutes = new Dictionary<string, string>();
        private readonly List<string> imports = new List<string>();

        #endregion

        #region Public methods

        /// <summary>
        /// Create a new builder with given script template.
        /// </summary>
        internal ScriptBuilder(string templateName)
        {
            this.templateName = templateName;
        }

        /// <summary>
        /// Add a substitute for the given placeholder string.
        /// </summary>
        internal ScriptBuilder AddSubstitute(string name, string value)
        {
            substitutes.Add(name, value);
            return this;
        }

        /// <summary>
        /// Add a substitute for the given placeholder int.
        /// </summary>
        internal ScriptBuilder AddSubstitute(string name, int value)
        {
            AddSubstitute(name, value.ToString());
            return this;
        }

        /// <summary>
        /// Add an import (using) statement from a given type.
        /// </summary>
        internal ScriptBuilder AddImport(Type import)
        {
            AddImport(import.Namespace);
            return this;
        }

        /// <summary>
        /// Add a raw import (using) statement.
        /// </summary>
        internal ScriptBuilder AddImport(string import)
        {
            imports.Add(import);
            return this;
        }

        /// <returns>
        /// Built script content.
        /// </returns>
        internal string Build()
        {
            var template = LoadTemplate(templateName);
            var script = template.text;

            return SubstituteScript(script);
        }

        #endregion

        #region Private Methods

        private static TextAsset LoadTemplate(string name)
        {
            var templatePath = $"{TemplatePath}/{name}.txt";
            var template = AssetDatabase.LoadAssetAtPath<TextAsset>(templatePath);

            return template;
        }

        private string SubstituteScript(string script)
        {
            var substitutedScript = script;

            foreach (var substitutePair in substitutes)
            {
                var placeholderName = substitutePair.Key;
                var substituteValue = substitutePair.Value;

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
