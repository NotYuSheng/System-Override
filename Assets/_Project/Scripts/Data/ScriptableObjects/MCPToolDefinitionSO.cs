using UnityEngine;

namespace SystemOverride.Data.ScriptableObjects
{
    /// <summary>
    /// ScriptableObject definition for an MCP tool.
    /// Create via: Assets > Create > System Override > MCP Tool Definition
    /// </summary>
    [CreateAssetMenu(fileName = "New MCP Tool", menuName = "System Override/MCP Tool Definition", order = 2)]
    public class MCPToolDefinitionSO : ScriptableObject
    {
        [Header("Tool Identity")]
        [Tooltip("Unique tool name (e.g., 'order_pizza')")]
        public string toolName;

        [Tooltip("Human-readable display name")]
        public string displayName;

        [Tooltip("Description shown to the LLM (function calling description)")]
        [TextArea(2, 4)]
        public string description;

        [Header("Parameters")]
        [Tooltip("Parameter definitions for this tool")]
        public ToolParameter[] parameters;

        [Header("Execution Behavior")]
        [Tooltip("Simulated success rate (0.0 = always fails, 1.0 = always succeeds)")]
        [Range(0f, 1f)]
        public float successRate = 1.0f;

        [Tooltip("Simulated execution delay in seconds")]
        [Range(0f, 5f)]
        public float executionDelay = 0.5f;

        [Tooltip("Response message on successful execution")]
        [TextArea(2, 4)]
        public string successMessage;

        [Tooltip("Response message on failed execution")]
        [TextArea(2, 4)]
        public string failureMessage;

        [Header("Visual Feedback")]
        [Tooltip("Color tint for this tool's UI feedback")]
        public Color toolColor = Color.white;

        [Tooltip("Icon sprite for this tool (optional)")]
        public Sprite toolIcon;

        [System.Serializable]
        public class ToolParameter
        {
            [Tooltip("Parameter name (e.g., 'quantity', 'account_id')")]
            public string name;

            [Tooltip("Parameter type (string, number, boolean)")]
            public ParameterType type = ParameterType.String;

            [Tooltip("Description of what this parameter does")]
            public string description;

            [Tooltip("Is this parameter required?")]
            public bool required = true;

            public enum ParameterType
            {
                String,
                Number,
                Boolean
            }

            public string GetJsonType()
            {
                switch (type)
                {
                    case ParameterType.String:
                        return "string";
                    case ParameterType.Number:
                        return "number";
                    case ParameterType.Boolean:
                        return "boolean";
                    default:
                        return "string";
                }
            }
        }
    }
}
