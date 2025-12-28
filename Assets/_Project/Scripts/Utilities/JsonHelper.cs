using System;
using System.Collections.Generic;
using UnityEngine;

namespace SystemOverride.Utilities
{
    /// <summary>
    /// Helper methods for JSON serialization/deserialization.
    /// Unity's JsonUtility doesn't support lists directly, so we use wrapper classes.
    /// </summary>
    public static class JsonHelper
    {
        /// <summary>
        /// Convert a list to JSON using a wrapper class.
        /// </summary>
        public static string ToJson<T>(List<T> list, bool prettyPrint = false)
        {
            Wrapper<T> wrapper = new Wrapper<T> { items = list };
            return JsonUtility.ToJson(wrapper, prettyPrint);
        }

        /// <summary>
        /// Convert JSON to a list using a wrapper class.
        /// </summary>
        public static List<T> FromJson<T>(string json)
        {
            Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
            return wrapper.items;
        }

        /// <summary>
        /// Convert an array to JSON using a wrapper class.
        /// </summary>
        public static string ArrayToJson<T>(T[] array, bool prettyPrint = false)
        {
            Wrapper<T> wrapper = new Wrapper<T> { items = new List<T>(array) };
            return JsonUtility.ToJson(wrapper, prettyPrint);
        }

        /// <summary>
        /// Convert JSON to an array using a wrapper class.
        /// </summary>
        public static T[] FromJsonToArray<T>(string json)
        {
            Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
            return wrapper.items.ToArray();
        }

        [Serializable]
        private class Wrapper<T>
        {
            public List<T> items;
        }
    }
}
