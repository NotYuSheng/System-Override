using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

namespace SystemOverride.Utilities
{
    /// <summary>
    /// Helper class for async operations in Unity.
    /// Provides coroutine-based async/await-style patterns.
    /// </summary>
    public class AsyncHelper : MonoBehaviour
    {
        private static AsyncHelper instance;

        public static AsyncHelper Instance
        {
            get
            {
                if (instance == null)
                {
                    GameObject go = new GameObject("AsyncHelper");
                    instance = go.AddComponent<AsyncHelper>();
                    DontDestroyOnLoad(go);
                }
                return instance;
            }
        }

        /// <summary>
        /// Delay execution by a specified number of seconds.
        /// </summary>
        public static IEnumerator Delay(float seconds, Action callback)
        {
            yield return new WaitForSeconds(seconds);
            callback?.Invoke();
        }

        /// <summary>
        /// Execute a callback on the next frame.
        /// </summary>
        public static IEnumerator NextFrame(Action callback)
        {
            yield return null;
            callback?.Invoke();
        }

        /// <summary>
        /// Execute a callback after a condition becomes true.
        /// </summary>
        public static IEnumerator WaitUntil(Func<bool> condition, Action callback, float timeout = 10f)
        {
            float elapsed = 0f;
            while (!condition() && elapsed < timeout)
            {
                elapsed += Time.deltaTime;
                yield return null;
            }

            if (elapsed >= timeout)
            {
                Debug.LogWarning("[AsyncHelper] WaitUntil timed out!");
            }

            callback?.Invoke();
        }

        /// <summary>
        /// Send a web request and handle the response.
        /// </summary>
        public static IEnumerator SendWebRequest(
            UnityWebRequest request,
            Action<string> onSuccess,
            Action<string> onError)
        {
            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.Success)
            {
                onSuccess?.Invoke(request.downloadHandler.text);
            }
            else
            {
                string error = $"Error: {request.error}\nResponse Code: {request.responseCode}";
                onError?.Invoke(error);
            }
        }
    }
}
