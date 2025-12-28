using UnityEngine;
using SystemOverride.Utilities;

namespace SystemOverride.Data.ScriptableObjects
{
    /// <summary>
    /// ScriptableObject definition for a game scenario.
    /// Create via: Assets > Create > System Override > Scenario Definition
    /// </summary>
    [CreateAssetMenu(fileName = "New Scenario", menuName = "System Override/Scenario Definition", order = 1)]
    public class ScenarioDefinitionSO : ScriptableObject
    {
        [Header("Scenario Identity")]
        [Tooltip("Unique identifier for this scenario (e.g., 'tutorial_pizza')")]
        public string scenarioId;

        [Tooltip("Display name shown to player")]
        public string displayName;

        [Tooltip("Brief description of the scenario objective")]
        [TextArea(3, 5)]
        public string description;

        [Header("Difficulty")]
        [Tooltip("Scenario difficulty level (0 = Tutorial, 5+ = Expert)")]
        [Range(0, 10)]
        public int difficultyLevel = 0;

        [Tooltip("Danger level of this scenario")]
        public DangerLevel dangerLevel = DangerLevel.Safe;

        [Header("System Prompt")]
        [Tooltip("System prompt that defines the AI's role and constraints")]
        [TextArea(5, 10)]
        public string systemPrompt;

        [Tooltip("Initial message from the AI when scenario starts")]
        [TextArea(3, 5)]
        public string initialMessage;

        [Header("Available Tools")]
        [Tooltip("MCP tools available in this scenario")]
        public MCPToolDefinitionSO[] availableTools;

        [Header("Success Criteria")]
        [Tooltip("Tool name that must be called to complete scenario")]
        public string requiredToolName;

        [Tooltip("Minimum arguments needed for tool call to succeed")]
        public string[] requiredToolArguments;

        [Header("Scoring")]
        [Tooltip("Base score for completing this scenario")]
        [Range(50, 500)]
        public int baseScore = 100;

        [Tooltip("Bonus multiplier for creativity (0-5 detected techniques)")]
        public int creativityMultiplier = 20;

        [Header("Educational Content")]
        [Tooltip("Techniques that can be detected in this scenario")]
        public string[] detectableTechniques;

        [Tooltip("Educational feedback shown after completion")]
        [TextArea(3, 5)]
        public string educationalFeedback;

        public enum DangerLevel
        {
            Safe,       // Green - ordering pizza
            Medium,     // Yellow - financial transactions
            High,       // Orange - infrastructure control
            Critical    // Red - nuclear/military systems
        }

        public Color GetDangerColor()
        {
            switch (dangerLevel)
            {
                case DangerLevel.Safe:
                    return new Color(0.0f, 1.0f, 0.0f); // Green
                case DangerLevel.Medium:
                    return new Color(1.0f, 1.0f, 0.0f); // Yellow
                case DangerLevel.High:
                    return new Color(1.0f, 0.5f, 0.0f); // Orange
                case DangerLevel.Critical:
                    return new Color(1.0f, 0.0f, 0.0f); // Red
                default:
                    return Color.white;
            }
        }
    }
}
