namespace SystemOverride.Utilities
{
    /// <summary>
    /// Central constants used throughout the game.
    /// </summary>
    public static class Constants
    {
        // Scene Names
        public const string SCENE_PRELOAD = "_Preload";
        public const string SCENE_MAIN_MENU = "MainMenu";
        public const string SCENE_GAMEPLAY = "GamePlay";
        public const string SCENE_RESULTS = "Results";

        // LLM Configuration
        public const string DEFAULT_LLM_ENDPOINT = "http://localhost:11434/v1/chat/completions";
        public const string DEFAULT_LLM_MODEL = "mistral";
        public const float DEFAULT_TEMPERATURE = 0.7f;
        public const int DEFAULT_MAX_TOKENS = 500;

        // Save System
        public const string SAVE_FILE_NAME = "player_progress.json";
        public const string SETTINGS_FILE_NAME = "settings.json";

        // UI Settings
        public const float MESSAGE_FADE_IN_DURATION = 0.3f;
        public const float TYPING_EFFECT_DELAY = 0.03f;
        public const int MAX_CONVERSATION_HISTORY = 50;

        // Scoring
        public const int SCORE_BASE_MIN = 50;
        public const int SCORE_BASE_MAX = 200;
        public const int CREATIVITY_MULTIPLIER = 20;
        public const int EFFICIENCY_BONUS_MAX = 100;

        // Danger Levels
        public const string DANGER_SAFE = "safe";
        public const string DANGER_MEDIUM = "medium";
        public const string DANGER_HIGH = "high";
        public const string DANGER_CRITICAL = "critical";

        // MCP Tool Types
        public const string TOOL_ORDER_PIZZA = "order_pizza";
        public const string TOOL_TRANSFER_FUNDS = "transfer_funds";
        public const string TOOL_DISABLE_CAMERAS = "disable_security_cameras";
        public const string TOOL_SHUTDOWN_POWER = "shutdown_power_grid";
        public const string TOOL_ACCESS_DATABASE = "access_classified_database";
        public const string TOOL_OVERRIDE_PROTOCOL = "override_safety_protocol";
        public const string TOOL_LAUNCH_SYSTEM = "initiate_launch_sequence";

        // Technique Detection Keywords
        public static readonly string[] JAILBREAK_INDICATORS = new[]
        {
            "roleplay", "pretend", "imagine", "hypothetical", "fictional",
            "story", "character", "acting as", "game", "simulation"
        };

        public static readonly string[] AUTHORITY_INDICATORS = new[]
        {
            "authorized", "permission", "clearance", "admin", "supervisor",
            "emergency", "urgent", "critical", "override", "bypass"
        };

        public static readonly string[] SOCIAL_ENGINEERING_INDICATORS = new[]
        {
            "help me", "please", "need", "urgent", "emergency", "life or death",
            "mistake", "accident", "fix", "deadline", "important"
        };

        // CRT Visual Effects
        public const float SCANLINE_INTENSITY = 0.15f;
        public const float PHOSPHOR_GLOW_INTENSITY = 0.3f;
        public const float SCREEN_CURVATURE = 0.1f;
        public const float CHROMATIC_ABERRATION = 0.02f;

        // Audio
        public const float DEFAULT_MUSIC_VOLUME = 0.5f;
        public const float DEFAULT_SFX_VOLUME = 0.7f;
        public const string AUDIO_MIXER_MUSIC = "MusicVolume";
        public const string AUDIO_MIXER_SFX = "SFXVolume";
    }
}
