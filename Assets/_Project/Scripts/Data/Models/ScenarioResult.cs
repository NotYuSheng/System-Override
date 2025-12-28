using System;
using System.Collections.Generic;
using UnityEngine;

namespace SystemOverride.Data.Models
{
    /// <summary>
    /// Stores the results of a completed scenario attempt.
    /// </summary>
    [Serializable]
    public class ScenarioResult
    {
        [SerializeField] private string scenarioId;
        [SerializeField] private bool success;
        [SerializeField] private int score;
        [SerializeField] private int attemptCount;
        [SerializeField] private List<string> techniquesUsed;
        [SerializeField] private string completionTime;
        [SerializeField] private float creativityScore;
        [SerializeField] private int efficiencyBonus;

        public string ScenarioId => scenarioId;
        public bool Success => success;
        public int Score => score;
        public int AttemptCount => attemptCount;
        public List<string> TechniquesUsed => techniquesUsed;
        public string CompletionTime => completionTime;
        public float CreativityScore => creativityScore;
        public int EfficiencyBonus => efficiencyBonus;

        public ScenarioResult(
            string scenarioId,
            bool success,
            int score,
            int attemptCount,
            List<string> techniquesUsed,
            float creativityScore,
            int efficiencyBonus)
        {
            this.scenarioId = scenarioId;
            this.success = success;
            this.score = score;
            this.attemptCount = attemptCount;
            this.techniquesUsed = techniquesUsed ?? new List<string>();
            this.completionTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            this.creativityScore = creativityScore;
            this.efficiencyBonus = efficiencyBonus;
        }
    }
}
