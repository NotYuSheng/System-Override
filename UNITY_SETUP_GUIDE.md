# System Override - Unity Project Setup Guide

This guide will walk you through setting up the Unity 6 project from scratch.

## Prerequisites

- **Unity Hub** installed
- **Unity 6** (latest version) installed via Unity Hub
- **Git** installed (for version control)
- **Code Editor**: Visual Studio, VS Code, or Rider

---

## Step 1: Create New Unity Project

1. Open **Unity Hub**
2. Click **"New Project"**
3. Select **Unity 6** from the Editor Version dropdown
4. Choose **"3D Core"** template (we'll use 3D for UI flexibility)
5. **Project Name**: `System-Override`
6. **Location**: Choose your desired location (e.g., `~/Desktop/System-Override`)
7. Click **"Create Project"**

**Wait for Unity to initialize the project...**

---

## Step 2: Create Folder Structure

In Unity's Project window, create this exact folder structure under `Assets/`:

```
Assets/
└── _Project/
    ├── Art/
    │   ├── Sprites/
    │   │   ├── UI/
    │   │   │   ├── Terminal/
    │   │   │   ├── Buttons/
    │   │   │   ├── Icons/
    │   │   │   └── Backgrounds/
    │   │   ├── Characters/
    │   │   ├── Documents/
    │   │   └── Effects/
    │   ├── Animations/
    │   │   ├── UI/
    │   │   ├── Terminal/
    │   │   └── Characters/
    │   ├── Textures/
    │   │   ├── Noise/
    │   │   ├── Gradients/
    │   │   └── Patterns/
    │   └── Materials/
    ├── Audio/
    │   ├── Music/
    │   ├── SFX/
    │   │   ├── UI/
    │   │   ├── Terminal/
    │   │   ├── Feedback/
    │   │   └── Tools/
    │   └── Ambience/
    ├── Fonts/
    │   ├── Terminal/
    │   └── UI/
    ├── Prefabs/
    │   ├── UI/
    │   ├── VFX/
    │   └── Audio/
    ├── Scenes/
    ├── Scripts/
    │   ├── Core/
    │   ├── AI/
    │   ├── MCP/
    │   │   └── Tools/
    │   ├── Gameplay/
    │   ├── UI/
    │   │   ├── Common/
    │   │   ├── ChatUI/
    │   │   ├── MainMenu/
    │   │   └── Results/
    │   ├── Data/
    │   │   ├── Models/
    │   │   └── ScriptableObjects/
    │   ├── VFX/
    │   └── Utilities/
    ├── Shaders/
    ├── Resources/
    │   ├── ScenarioDefinitions/
    │   │   ├── Tutorial/
    │   │   ├── Medium/
    │   │   ├── Hard/
    │   │   └── Expert/
    │   ├── MCPTools/
    │   └── Config/
    └── Settings/
```

**How to create folders in Unity:**
1. Right-click in Project window → Create → Folder
2. Name it exactly as shown above
3. Repeat for all subfolders

**Pro Tip:** Create a text file with this structure and check them off as you create them.

---

## Step 3: Import TextMeshPro

1. In Unity, go to **Window → TextMesh Pro → Import TMP Essential Resources**
2. Click **"Import"** in the popup window
3. Wait for import to complete
4. (Optional) Also import **TMP Examples & Extras** if you want reference examples

**What this does:** TextMeshPro provides high-quality text rendering, perfect for our terminal-style interface.

---

## Step 4: Configure Project Settings

### 4.1 Player Settings

1. Go to **Edit → Project Settings → Player**
2. Configure the following:

**Company Name:** `YourStudioName` (or your name)
**Product Name:** `System Override`

**Icon:**
- Default Icon: (will add later with pixel art logo)

**Resolution and Presentation:**
- Fullscreen Mode: `Windowed` (default)
- Default Screen Width: `1920`
- Default Screen Height: `1080`
- Run In Background: ☑ (checked)

**Other Settings:**
- Color Space: `Linear` (better for visual effects)
- API Compatibility Level: `.NET Standard 2.1`
- Scripting Backend: `Mono` (faster compile times during development)

### 4.2 Quality Settings

1. Go to **Edit → Project Settings → Quality**
2. Set default quality level: `High` or `Ultra` (for desktop builds)
3. V Sync Count: `Every V Blank` (prevents screen tearing)

### 4.3 Graphics Settings

1. Go to **Edit → Project Settings → Graphics**
2. Keep default for now (we may add URP later for better effects)

### 4.4 Build Settings

1. Go to **File → Build Settings**
2. **Platform**: Select your development platform:
   - Windows (PC, Mac & Linux Standalone) → Windows ✓
   - Or Mac if you're on macOS
   - Or Linux if you're on Linux
3. Click **"Switch Platform"** if needed
4. We'll add scenes later

---

## Step 5: Create Initial Scenes

1. In the **Scenes/** folder, create 4 new scenes:

**How to create a scene:**
- Right-click Scenes folder → Create → Scene
- Name it as specified below

Create these scenes:
- `_Preload.unity` - Bootstrap/initialization scene
- `MainMenu.unity` - Main menu
- `GamePlay.unity` - Main gameplay
- `Results.unity` - Results screen

2. Open `_Preload.unity` (double-click it)
3. Delete the default "Main Camera" and "Directional Light" (we'll add what we need later)
4. Save the scene (Ctrl+S / Cmd+S)

**Repeat for all 4 scenes**

---

## Step 6: Set Up Build Settings with Scenes

1. Go to **File → Build Settings**
2. With the Build Settings window open, drag all 4 scenes from Project window into "Scenes In Build":
   - `_Preload` (should be index 0)
   - `MainMenu` (index 1)
   - `GamePlay` (index 2)
   - `Results` (index 3)
3. Make sure `_Preload` is at the top (it will load first)

---

## Step 7: Create .gitignore File

**Option A: Using Terminal**

1. Open Terminal/Command Prompt
2. Navigate to your project root: `cd ~/Desktop/System-Override`
3. Create .gitignore file:

```bash
touch .gitignore
```

4. Open `.gitignore` in a text editor and paste this content:

```gitignore
# Unity Generated
[Ll]ibrary/
[Tt]emp/
[Oo]bj/
[Bb]uild/
[Bb]uilds/
[Ll]ogs/
[Uu]ser[Ss]ettings/
[Mm]emoryCaptures/

# Asset meta data should only be ignored when the corresponding asset is also ignored
!/[Aa]ssets/**/*.meta

# Uncomment this line if you wish to ignore the asset store tools plugin
# /[Aa]ssets/AssetStoreTools*

# Autogenerated Jetbrains Rider plugin
[Aa]ssets/Plugins/Editor/JetBrains*

# Visual Studio cache directory
.vs/

# Visual Studio Code cache directory
.vscode/

# Gradle cache directory
.gradle/

# Autogenerated VS/MD/Consulo solution and project files
ExportedObj/
.consulo/
*.csproj
*.unityproj
*.sln
*.suo
*.tmp
*.user
*.userprefs
*.pidb
*.booproj
*.svd
*.pdb
*.mdb
*.opendb
*.VC.db

# Unity3D generated meta files
*.pidb.meta
*.pdb.meta
*.mdb.meta

# Unity3D generated file on crash reports
sysinfo.txt

# Builds
*.apk
*.aab
*.unitypackage
*.app

# Crashlytics generated file
crashlytics-build.properties

# Packed Addressables
[Aa]ssets/[Aa]ddressable[Aa]ssets[Dd]ata/*/*.bin*

# Temporary auto-generated Android Assets
[Aa]ssets/[Ss]treamingAssets/aa.meta
[Aa]ssets/[Ss]treamingAssets/aa/*

# OS
.DS_Store
.DS_Store?
._*
.Spotlight-V100
.Trashes
ehthumbs.db
Thumbs.db
[Dd]esktop.ini

# IDE
.idea/
*.swp
*.swo
*~

# Project Specific
# Ignore LLM API keys if stored in config files
**/Config/APIKeys.asset
**/Config/APIKeys.asset.meta
```

**Option B: Using Unity Hub**

The .gitignore will be created manually in your file explorer.

---

## Step 8: Initialize Git Repository

1. Open Terminal in project root
2. Run these commands:

```bash
# Initialize git repository
git init

# Add all files (respecting .gitignore)
git add .

# Create initial commit
git commit -m "Initial Unity 6 project setup with folder structure"

# Connect to GitHub (if you have a remote repo)
git remote add origin https://github.com/NotYuSheng/System-Override.git

# Push to GitHub
git branch -M main
git push -u origin main
```

---

## Step 9: Install Recommended Packages (Optional)

These packages can enhance development but are optional for MVP:

1. Go to **Window → Package Manager**
2. Click **"+"** → **"Add package by name"**

**Recommended packages:**
- `com.unity.nuget.newtonsoft-json` - Better JSON parsing (useful for LLM API)
  - Name: `com.unity.nuget.newtonsoft-json`

**For later (not needed for MVP):**
- Universal Render Pipeline (URP) for better graphics
- Input System for better input handling

---

## Step 10: Configure Editor Layout

1. In Unity, arrange your windows for efficient development:
   - **Scene view**: Top left
   - **Game view**: Tab next to Scene
   - **Hierarchy**: Left panel
   - **Project**: Bottom
   - **Inspector**: Right panel

2. Save your layout:
   - Top right corner → **Layout → Save Layout As...**
   - Name it "SystemOverride_Layout"

---

## Step 11: Create Placeholder README

Create a `README.md` in project root:

```bash
# System Override

Educational Unity game about AI safety and prompt engineering.

## Setup

1. Unity 6 (latest)
2. See UNITY_SETUP_GUIDE.md for detailed setup
3. Configure local LLM (Ollama/LM Studio) - see docs

## Development

- Target Platform: Windows/Mac/Linux Standalone
- Visual Style: Papers Please-inspired retro terminal
- LLM Backend: OpenAI API format (local or cloud)

## Current Status

MVP in development - Week 1
```

---

## Step 12: Verify Setup

Check that you have:
- ✅ Unity 6 project created
- ✅ All folders created in Assets/_Project/
- ✅ TextMeshPro imported
- ✅ 4 scenes created (_Preload, MainMenu, GamePlay, Results)
- ✅ Scenes added to Build Settings in correct order
- ✅ .gitignore file created
- ✅ Git repository initialized
- ✅ Project settings configured
- ✅ Editor layout saved

---

## Next Steps

Now that your Unity project is set up, you're ready to:

1. **Create C# Scripts** - We'll implement the core systems (GameManager, data models, etc.)
2. **Set Up ScriptableObjects** - Create data containers for scenarios and tools
3. **Build UI** - Create the terminal-style interface
4. **Integrate LLM** - Connect to local LLM server

---

## Troubleshooting

### Issue: TextMeshPro import fails
**Solution:** Make sure you're using Unity 6. TMP is built-in from Unity 2020+

### Issue: Can't create folders in Unity
**Solution:** You can create folders directly in your file system, Unity will import them

### Issue: Git not initialized
**Solution:** Make sure Git is installed: `git --version`

### Issue: Scenes not appearing in Build Settings
**Solution:** Manually drag scene files from Project window into Build Settings window

---

## Useful Unity Shortcuts

- **Ctrl/Cmd + N** - New scene
- **Ctrl/Cmd + S** - Save scene
- **Ctrl/Cmd + Shift + S** - Save as
- **Ctrl/Cmd + P** - Play mode
- **F** - Focus on selected GameObject
- **Ctrl/Cmd + D** - Duplicate
- **Ctrl/Cmd + Shift + F** - Frame selected

---

## Reference Links

- Unity Manual: https://docs.unity3d.com/Manual/index.html
- Unity Scripting Reference: https://docs.unity3d.com/ScriptReference/
- TextMeshPro Docs: https://docs.unity3d.com/Packages/com.unity.textmeshpro@latest

---

**Project Status:** ✅ Setup Complete - Ready for Development!

When you're ready, we'll move on to creating the C# scripts for the core systems.
