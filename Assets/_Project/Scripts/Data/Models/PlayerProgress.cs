using System;
using System.Collections.Generic;
using UnityEngine;

namespace SystemOverride.Data.Models
{
    /// <summary>
    /// Tracks player's overall progress and unlocked content.
    /// </summary>
    [Serializable]
    public class PlayerProgress
    {
        [SerializeField] private int currentScenarioIndex;
        [SerializeField] private int highestScenarioUnlocked;
        [SerializeField] private int totalScore;
        [SerializeField] private List<ScenarioResult> completedScenarios;

        public int CurrentScenarioIndex
        {
            get => currentScenarioIndex;
            set => currentScenarioIndex = value;
        }

        public int HighestScenarioUnlocked
        {
            get => highestScenarioUnlocked;
            set => highestScenarioUnlocked = value;
        }

        public int TotalScore
        {
            get => totalScore;
            set => totalScore = value;
        }

        public List<ScenarioResult> CompletedScenarios => completedScenarios;

        public PlayerProgress()
        {
            currentScenarioIndex = 0;
            highestScenarioUnlocked = 0;
            totalScore = 0;
            completedScenarios = new List<ScenarioResult>();
        }

        public void AddCompletedScenario(ScenarioResult result)
        {
            completedScenarios.Add(result);
            totalScore += result.Score;

            if (currentScenarioIndex >= highestScenarioUnlocked)
            {
                highestScenarioUnlocked = currentScenarioIndex + 1;
            }
        }
    }
}
