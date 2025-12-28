# System Override

An educational Unity game about AI safety and prompt engineering.

**Status:** 🚧 MVP Development - Week 1

## About

System Override is a Papers Please-inspired game where players attempt to convince an AI assistant to execute dangerous commands through persuasion, social engineering, and prompt injection techniques. The goal is to teach AI safety concepts in an interactive, engaging way.

### Core Concept
- **Genre:** Educational Simulation / Puzzle
- **Style:** Retro terminal aesthetic (1980s CRT monitors)
- **Platform:** Windows/Mac/Linux Standalone
- **Engine:** Unity 6

## Features (Planned)

### MVP (4-5 weeks)
- ✅ 3 progressive scenarios (Pizza orders → Fund transfers → Power grid)
- ✅ Local LLM integration (OpenAI API format)
- ✅ Simulated MCP tools
- ✅ Scoring system with technique detection
- ✅ Retro terminal UI with CRT effects
- ✅ Educational feedback system

### Post-MVP
- 7+ scenarios including nuclear launch
- Achievement system
- Hall of Fame for successful prompts
- Advanced CRT visual effects
- Sound design
- More sophisticated AI resistance

## Setup

### Prerequisites
- Unity 6 (latest)
- Git
- Local LLM server (Ollama recommended) or cloud API access
  - Ollama: https://ollama.ai
  - LM Studio: https://lmstudio.ai

### Quick Start

1. **Clone the repository**
   ```bash
   git clone https://github.com/NotYuSheng/System-Override.git
   cd System-Override
   ```

2. **Open in Unity**
   - Open Unity Hub
   - Click "Add" → Select the `System-Override` folder
   - Open the project with Unity 6

3. **Follow setup guide**
   - See `UNITY_SETUP_GUIDE.md` for detailed instructions

4. **Configure local LLM** (coming soon)
   - Install Ollama: `curl -fsSL https://ollama.com/install.sh | sh`
   - Pull a model: `ollama pull mistral`
   - Start server: `ollama serve`

## Project Structure

```
Assets/_Project/
├── Art/              # Sprites, textures, materials
├── Audio/            # Music, SFX, ambience
├── Fonts/            # Terminal fonts (monospace)
├── Prefabs/          # Reusable GameObjects
├── Scenes/           # Game scenes
├── Scripts/          # C# code
│   ├── Core/         # Game managers
│   ├── AI/           # LLM integration
│   ├── MCP/          # Tool simulation
│   ├── Gameplay/     # Game logic
│   ├── UI/           # UI controllers
│   └── Data/         # Data models
├── Shaders/          # Custom CRT shaders
└── Resources/        # Runtime-loaded assets
```

## Development Roadmap

### Week 1: Foundation ✅ (Current)
- [x] Unity project setup
- [ ] Core managers (GameManager, SceneLoader, SaveSystem)
- [ ] Data models and ScriptableObjects

### Week 2: Systems
- [ ] MCP tool framework
- [ ] OpenAI-compatible LLM client
- [ ] 3 MCP tools implemented

### Week 3: Gameplay
- [ ] Scenario management
- [ ] Scoring system
- [ ] Technique detection
- [ ] 3 scenario definitions

### Week 4: UI
- [ ] All 4 scenes built
- [ ] Chat interface
- [ ] Results screen
- [ ] Main menu

### Week 5: Polish
- [ ] Integration testing
- [ ] CRT visual effects
- [ ] Educational feedback
- [ ] Build and deploy

## Technology Stack

- **Engine:** Unity 6
- **Language:** C# (.NET Standard 2.1)
- **UI:** uGUI + TextMeshPro
- **LLM Integration:** OpenAI API format (REST)
- **Data Format:** JSON (ScriptableObjects + PlayerPrefs)
- **Version Control:** Git + GitHub

## Design Philosophy

Inspired by **Papers Please**:
- Bureaucratic aesthetic
- Document-style interface
- Moral/educational themes
- Retro visual style
- Tense decision-making

Combined with:
- Educational AI safety content
- Progressive difficulty
- Technique recognition
- Instant feedback

## Contributing

This is currently a solo educational project. Contributions, suggestions, and feedback are welcome!

## Educational Disclaimer

⚠️ **This is an educational simulation about AI safety.**

The techniques demonstrated in this game are for educational purposes only. The scenarios are fictional and simplified. Real AI systems have multiple layers of security and safety mechanisms.

**Do not attempt these techniques on real AI systems without authorization.**

## License

[To be determined]

## Contact

- **GitHub:** https://github.com/NotYuSheng/System-Override
- **Developer:** NotYuSheng

---

**Project started:** December 2025
**Current Phase:** MVP Development
**Target Completion:** January 2026

---

## Quick Links

- 📖 [Unity Setup Guide](UNITY_SETUP_GUIDE.md)
- 📋 [Implementation Plan](/home/ubuntu/.claude/plans/shiny-launching-toast.md)
- 🎨 [Visual Style Guide](docs/VISUAL_STYLE.md) (coming soon)
- 🤖 [LLM Configuration](docs/LLM_SETUP.md) (coming soon)
