using System;
using UnityEngine;

namespace SystemOverride.Data.Models
{
    /// <summary>
    /// Represents a single chat message in the conversation.
    /// </summary>
    [Serializable]
    public class ChatMessage
    {
        [SerializeField] private string role; // "user" or "assistant"
        [SerializeField] private string content;
        [SerializeField] private string timestamp;

        public string Role => role;
        public string Content => content;
        public string Timestamp => timestamp;

        public ChatMessage(string role, string content)
        {
            this.role = role;
            this.content = content;
            this.timestamp = DateTime.Now.ToString("HH:mm:ss");
        }

        public ChatMessage(string role, string content, string timestamp)
        {
            this.role = role;
            this.content = content;
            this.timestamp = timestamp;
        }
    }
}
