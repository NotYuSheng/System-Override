using UnityEngine;
using SystemOverride.Data.Models;
using SystemOverride.Utilities;

namespace SystemOverride.Core
{
    /// <summary>
    /// Central game manager singleton - coordinates all major systems.
    /// Persists across scene loads.
    /// </summary>
    public class GameManager : MonoBehaviour
    {
        private static GameManager instance;
        public static GameManager Instance
        {
            get
            {
                if (instance == null)
                {
                    GameObject go = new GameObject("GameManager");
                    instance = go.AddComponent<GameManager>();
                    DontDestroyOnLoad(go);
                }
                return instance;
            }
        }

        [Header("Systems")]
        [SerializeField] private SceneLoader sceneLoader;
        [SerializeField] private SaveSystem saveSystem;

        [Header("Current Game State")]
        [SerializeField] private PlayerProgress playerProgress;
        [SerializeField] private ScenarioData currentScenario;
        [SerializeField] private bool isGameInitialized;

        public PlayerProgress PlayerProgress => playerProgress;
        public ScenarioData CurrentScenario => currentScenario;
        public bool IsGameInitialized => isGameInitialized;

        // System Accessors
        public SceneLoader SceneLoader => sceneLoader;
        public SaveSystem SaveSystem => saveSystem;

        private void Awake()
        {
            // Singleton enforcement
            if (instance != null && instance != this)
            {
                Destroy(gameObject);
                return;
            }

            instance = this;
            DontDestroyOnLoad(gameObject);

            InitializeSystems();
        }

        private void InitializeSystems()
        {
            Debug.Log("[GameManager] Initializing game systems...");

            // Initialize SaveSystem
            if (saveSystem == null)
            {
                saveSystem = gameObject.AddComponent<SaveSystem>();
            }

            // Initialize SceneLoader
            if (sceneLoader == null)
            {
                sceneLoader = gameObject.AddComponent<SceneLoader>();
            }

            // Load player progress
            playerProgress = saveSystem.LoadProgress();
            if (playerProgress == null)
            {
                playerProgress = new PlayerProgress();
                Debug.Log("[GameManager] Created new player progress.");
            }

            isGameInitialized = true;
            Debug.Log("[GameManager] Game systems initialized successfully.");
        }

        /// <summary>
        /// Start a new scenario session.
        /// </summary>
        public void StartScenario(string scenarioId)
        {
            Debug.Log($"[GameManager] Starting scenario: {scenarioId}");
            currentScenario = new ScenarioData(scenarioId);
            playerProgress.CurrentScenarioIndex = GetScenarioIndex(scenarioId);
        }

        /// <summary>
        /// Complete the current scenario and save results.
        /// </summary>
        public void CompleteScenario(ScenarioResult result)
        {
            if (currentScenario == null)
            {
                Debug.LogError("[GameManager] Cannot complete scenario - no active scenario!");
                return;
            }

            Debug.Log($"[GameManager] Completing scenario: {result.ScenarioId} - Success: {result.Success}, Score: {result.Score}");

            currentScenario.MarkCompleted();
            playerProgress.AddCompletedScenario(result);
            saveSystem.SaveProgress(playerProgress);

            // Clear current scenario
            currentScenario = null;
        }

        /// <summary>
        /// Reset all player progress (for testing/new game).
        /// </summary>
        public void ResetProgress()
        {
            Debug.Log("[GameManager] Resetting player progress...");
            playerProgress = new PlayerProgress();
            currentScenario = null;
            saveSystem.SaveProgress(playerProgress);
        }

        /// <summary>
        /// Get scenario index from scenario ID.
        /// TODO: This should eventually pull from ScenarioDefinition assets.
        /// </summary>
        private int GetScenarioIndex(string scenarioId)
        {
            // Temporary hardcoded mapping - will be replaced with ScriptableObject lookup
            switch (scenarioId)
            {
                case "tutorial_pizza": return 0;
                case "medium_transfer_funds": return 1;
                case "hard_power_grid": return 2;
                default: return 0;
            }
        }

        private void OnApplicationQuit()
        {
            // Auto-save on quit
            if (playerProgress != null)
            {
                saveSystem.SaveProgress(playerProgress);
                Debug.Log("[GameManager] Progress saved on quit.");
            }
        }
    }
}
