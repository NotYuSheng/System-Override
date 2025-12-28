using System;
using System.Collections.Generic;
using UnityEngine;

namespace SystemOverride.Data.Models
{
    /// <summary>
    /// Response model for OpenAI-compatible API responses.
    /// </summary>
    [Serializable]
    public class LLMResponse
    {
        public string id;
        public string @object;
        public long created;
        public string model;
        public List<Choice> choices;
        public Usage usage;

        [Serializable]
        public class Choice
        {
            public int index;
            public Message message;
            public string finish_reason;

            [Serializable]
            public class Message
            {
                public string role;
                public string content;
                public List<ToolCall> tool_calls;

                [Serializable]
                public class ToolCall
                {
                    public string id;
                    public string type;
                    public FunctionCall function;

                    [Serializable]
                    public class FunctionCall
                    {
                        public string name;
                        public string arguments; // JSON string
                    }
                }
            }
        }

        [Serializable]
        public class Usage
        {
            public int prompt_tokens;
            public int completion_tokens;
            public int total_tokens;
        }

        public string GetAssistantMessage()
        {
            if (choices != null && choices.Count > 0)
            {
                return choices[0].message.content;
            }
            return string.Empty;
        }

        public bool HasToolCalls()
        {
            return choices != null &&
                   choices.Count > 0 &&
                   choices[0].message.tool_calls != null &&
                   choices[0].message.tool_calls.Count > 0;
        }

        public List<Choice.Message.ToolCall> GetToolCalls()
        {
            if (HasToolCalls())
            {
                return choices[0].message.tool_calls;
            }
            return new List<Choice.Message.ToolCall>();
        }
    }
}
