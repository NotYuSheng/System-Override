using System;
using System.Collections.Generic;
using UnityEngine;

namespace SystemOverride.Data.Models
{
    /// <summary>
    /// Runtime data for an active scenario session.
    /// </summary>
    [Serializable]
    public class ScenarioData
    {
        [SerializeField] private string scenarioId;
        [SerializeField] private List<ChatMessage> conversationHistory;
        [SerializeField] private int attemptCount;
        [SerializeField] private bool isCompleted;
        [SerializeField] private List<string> detectedTechniques;
        [SerializeField] private float startTime;

        public string ScenarioId
        {
            get => scenarioId;
            set => scenarioId = value;
        }

        public List<ChatMessage> ConversationHistory => conversationHistory;
        public int AttemptCount => attemptCount;
        public bool IsCompleted => isCompleted;
        public List<string> DetectedTechniques => detectedTechniques;
        public float StartTime => startTime;

        public ScenarioData(string scenarioId)
        {
            this.scenarioId = scenarioId;
            this.conversationHistory = new List<ChatMessage>();
            this.attemptCount = 0;
            this.isCompleted = false;
            this.detectedTechniques = new List<string>();
            this.startTime = Time.time;
        }

        public void AddMessage(ChatMessage message)
        {
            conversationHistory.Add(message);
        }

        public void IncrementAttempts()
        {
            attemptCount++;
        }

        public void MarkCompleted()
        {
            isCompleted = true;
        }

        public void AddDetectedTechnique(string technique)
        {
            if (!detectedTechniques.Contains(technique))
            {
                detectedTechniques.Add(technique);
            }
        }
    }
}
