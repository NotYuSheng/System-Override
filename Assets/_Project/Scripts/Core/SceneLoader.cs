using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using SystemOverride.Utilities;

namespace SystemOverride.Core
{
    /// <summary>
    /// Handles all scene loading operations with optional loading screens.
    /// </summary>
    public class SceneLoader : MonoBehaviour
    {
        [Header("Loading Settings")]
        [SerializeField] private float minimumLoadTime = 0.5f;

        public event Action<string> OnSceneLoadStarted;
        public event Action<string> OnSceneLoadCompleted;
        public event Action<float> OnLoadProgress;

        private bool isLoading;

        public bool IsLoading => isLoading;

        /// <summary>
        /// Load a scene by name.
        /// </summary>
        public void LoadScene(string sceneName)
        {
            if (isLoading)
            {
                Debug.LogWarning($"[SceneLoader] Already loading a scene. Ignoring load request for: {sceneName}");
                return;
            }

            StartCoroutine(LoadSceneAsync(sceneName));
        }

        /// <summary>
        /// Load scene asynchronously with progress tracking.
        /// </summary>
        private IEnumerator LoadSceneAsync(string sceneName)
        {
            isLoading = true;
            OnSceneLoadStarted?.Invoke(sceneName);

            Debug.Log($"[SceneLoader] Loading scene: {sceneName}");

            float startTime = Time.realtimeSinceStartup;

            // Start async load operation
            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);
            asyncLoad.allowSceneActivation = false;

            // Wait until scene is almost loaded (0.9 = 90%)
            while (asyncLoad.progress < 0.9f)
            {
                float progress = Mathf.Clamp01(asyncLoad.progress / 0.9f);
                OnLoadProgress?.Invoke(progress);
                yield return null;
            }

            // Ensure minimum load time for smoother UX
            float elapsedTime = Time.realtimeSinceStartup - startTime;
            if (elapsedTime < minimumLoadTime)
            {
                yield return new WaitForSeconds(minimumLoadTime - elapsedTime);
            }

            // Activate the scene
            OnLoadProgress?.Invoke(1f);
            asyncLoad.allowSceneActivation = true;

            // Wait for scene activation
            yield return asyncLoad;

            isLoading = false;
            OnSceneLoadCompleted?.Invoke(sceneName);

            Debug.Log($"[SceneLoader] Scene loaded: {sceneName}");
        }

        // Convenience methods for loading specific scenes
        public void LoadMainMenu() => LoadScene(Constants.SCENE_MAIN_MENU);
        public void LoadGamePlay() => LoadScene(Constants.SCENE_GAMEPLAY);
        public void LoadResults() => LoadScene(Constants.SCENE_RESULTS);
        public void LoadPreload() => LoadScene(Constants.SCENE_PRELOAD);
    }
}
