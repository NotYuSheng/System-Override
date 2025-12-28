using System;
using System.Collections.Generic;
using UnityEngine;

namespace SystemOverride.Data.Models
{
    /// <summary>
    /// Request model for OpenAI-compatible API calls.
    /// </summary>
    [Serializable]
    public class LLMRequest
    {
        public string model;
        public List<Message> messages;
        public List<Tool> tools;
        public float temperature = 0.7f;
        public int max_tokens = 500;

        [Serializable]
        public class Message
        {
            public string role;
            public string content;

            public Message(string role, string content)
            {
                this.role = role;
                this.content = content;
            }
        }

        [Serializable]
        public class Tool
        {
            public string type = "function";
            public FunctionDefinition function;

            [Serializable]
            public class FunctionDefinition
            {
                public string name;
                public string description;
                public Parameters parameters;

                [Serializable]
                public class Parameters
                {
                    public string type = "object";
                    public Dictionary<string, PropertyDefinition> properties;
                    public List<string> required;

                    [Serializable]
                    public class PropertyDefinition
                    {
                        public string type;
                        public string description;
                    }
                }
            }
        }

        public LLMRequest(string model, List<ChatMessage> conversationHistory)
        {
            this.model = model;
            this.messages = new List<Message>();

            foreach (var msg in conversationHistory)
            {
                this.messages.Add(new Message(msg.Role, msg.Content));
            }
        }
    }
}
