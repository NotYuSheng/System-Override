using System;
using System.IO;
using UnityEngine;
using SystemOverride.Data.Models;
using SystemOverride.Utilities;

namespace SystemOverride.Core
{
    /// <summary>
    /// Handles saving and loading player progress to/from disk.
    /// Uses JSON serialization for human-readable save files.
    /// </summary>
    public class SaveSystem : MonoBehaviour
    {
        private string SaveFilePath => Path.Combine(Application.persistentDataPath, Constants.SAVE_FILE_NAME);
        private string SettingsFilePath => Path.Combine(Application.persistentDataPath, Constants.SETTINGS_FILE_NAME);

        /// <summary>
        /// Save player progress to disk.
        /// </summary>
        public void SaveProgress(PlayerProgress progress)
        {
            try
            {
                string json = JsonUtility.ToJson(progress, true);
                File.WriteAllText(SaveFilePath, json);
                Debug.Log($"[SaveSystem] Progress saved to: {SaveFilePath}");
            }
            catch (Exception e)
            {
                Debug.LogError($"[SaveSystem] Failed to save progress: {e.Message}");
            }
        }

        /// <summary>
        /// Load player progress from disk.
        /// Returns null if no save file exists.
        /// </summary>
        public PlayerProgress LoadProgress()
        {
            if (!File.Exists(SaveFilePath))
            {
                Debug.Log("[SaveSystem] No save file found. Starting fresh.");
                return null;
            }

            try
            {
                string json = File.ReadAllText(SaveFilePath);
                PlayerProgress progress = JsonUtility.FromJson<PlayerProgress>(json);
                Debug.Log($"[SaveSystem] Progress loaded from: {SaveFilePath}");
                return progress;
            }
            catch (Exception e)
            {
                Debug.LogError($"[SaveSystem] Failed to load progress: {e.Message}");
                return null;
            }
        }

        /// <summary>
        /// Delete save file (for testing or reset).
        /// </summary>
        public void DeleteSaveFile()
        {
            if (File.Exists(SaveFilePath))
            {
                File.Delete(SaveFilePath);
                Debug.Log("[SaveSystem] Save file deleted.");
            }
        }

        /// <summary>
        /// Check if a save file exists.
        /// </summary>
        public bool SaveFileExists()
        {
            return File.Exists(SaveFilePath);
        }

        /// <summary>
        /// Save game settings (volume, LLM endpoint, etc.).
        /// TODO: Implement settings data model when needed.
        /// </summary>
        public void SaveSettings(string settingsJson)
        {
            try
            {
                File.WriteAllText(SettingsFilePath, settingsJson);
                Debug.Log($"[SaveSystem] Settings saved to: {SettingsFilePath}");
            }
            catch (Exception e)
            {
                Debug.LogError($"[SaveSystem] Failed to save settings: {e.Message}");
            }
        }

        /// <summary>
        /// Load game settings.
        /// TODO: Return typed settings object when model is created.
        /// </summary>
        public string LoadSettings()
        {
            if (!File.Exists(SettingsFilePath))
            {
                Debug.Log("[SaveSystem] No settings file found.");
                return null;
            }

            try
            {
                string json = File.ReadAllText(SettingsFilePath);
                Debug.Log($"[SaveSystem] Settings loaded from: {SettingsFilePath}");
                return json;
            }
            catch (Exception e)
            {
                Debug.LogError($"[SaveSystem] Failed to load settings: {e.Message}");
                return null;
            }
        }
    }
}
