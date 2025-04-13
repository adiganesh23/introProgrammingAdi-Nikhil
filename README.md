# Ball To Fame: Introduction to Programming 2025
Welcome to the **Ball to Fame** project! This Unity-based game is designed to provide an engaging and interactive experience, featuring player customization, decision-making mechanics, and dynamic gameplay elements.

---

## Table of Contents
- [Overview](#overview)
- [Features](#features)
- [Project Structure](#project-structure)
- [Setup and Installation](#setup-and-installation)
- [How to Play](#how-to-play)
- [Scripts Overview](#scripts-overview)
- [Contributing](#contributing)
- [License](#license)

---

## Overview
The **FBLA Game** is a basketball-themed game where players can:
- Customize their player.
- Make decisions that impact gameplay.
- Track stats like wins, losses, and player performance.
- Progress through seasons with dynamic updates to stats and visuals.

This project was created for the FBLA competition and showcases Unity development skills, including UI design, player preferences, and game logic.

---

## Features
- **Player Customization**: Choose jerseys, player stats, and more.
- **Dynamic Stats Tracking**: Track player stats like morale, money, and team record.
- **Decision-Based Gameplay**: Make choices that affect the outcome of the game.
- **Audio Feedback**: Button clicks and other interactions are accompanied by sound effects.
- **Persistent Data**: Player progress is saved using Unity's `PlayerPrefs`.

---

## Project Structure
The project is organized as follows:
Assets/ ├── Scripts/ │ ├── MainMenuScript.cs # Handles main menu interactions │ ├── GameLogic.cs # Core game logic and stat tracking │ ├── SettingsScript.cs # Handles audio and video settings │ ├── NextJersey.cs # Manages jersey selection │ ├── CreatePlayerHandler.cs # Handles player creation │ ├── InstructionScript.cs # Displays game instructions │ └── DecisionManager.cs # Manages decision-based gameplay ├── Scenes/ │ ├── MainMenu.unity # Main menu scene │ ├── GameScreen.unity # Core gameplay scene │ ├── SettingsA.unity # Audio settings scene │ ├── SettingsV.unity # Video settings scene │ ├── PlayerSelection.unity # Player creation scene │ └── Instructions.unity # Instructions scene ├── Images/ # Contains UI and game images ├── Audio/ # Contains sound effects and music └── README.md # Project documentation

---

## Setup and Installation
1. **Clone the Repository**:
   ```bash
   git clone https://github.com/your-repo/fbla-game.git

2. **Open in Unity**:
    Open Unity Hub.
    Add the project folder to your Unity projects.
    Open the project in Unity Editor.

3. **Install Dependencies**:
    Ensure you have the required Unity version (e.g., 2021.3 or later).
    Import any missing packages via the Unity Package Manager.

4. **Run the Game**:
    Open the MainMenu scene.
    Press the Play button in the Unity Editor.

---

# How to Play

## Start the Game:
- Click the "Start" button on the main menu.
- If no player data exists, you'll be redirected to the player creation screen.

## Customize Your Player:
- Choose a jersey using the left and right buttons.
- Set your player stats and confirm your selection.

## Make Decisions:
- Progress through the game by making decisions that impact your team's performance.

## Track Your Progress:
- View stats like morale, money, week, year, and team record on the game screen.

## Adjust Settings:
- Use the settings menu to adjust audio, video, and gameplay preferences.

---

# Scripts Overview

### 1. `MainMenuScript.cs`
- Handles button interactions on the main menu.
- Plays button click sounds using an `AudioSource`.

### 2. `GameLogic.cs`
- Tracks player stats like morale, money, week, year, and team record.
- Saves and loads data using `PlayerPrefs`.
- Updates UI elements dynamically.

### 3. `SettingsScript.cs`
- Manages audio and video settings.
- Saves slider values (e.g., volume) to `PlayerPrefs`.

### 4. `NextJersey.cs`
- Allows players to cycle through available jerseys.
- Updates the displayed jersey image dynamically.

### 5. `CreatePlayerHandler.cs`
- Handles player creation and customization.
- Saves player data to `PlayerPrefs`.

### 6. `InstructionScript.cs`
- Displays instructions and game rules.

### 7. `DecisionManager.cs`
- Manages decision-based gameplay.
- Loads different scenes based on player choices.

---

# Contributing

We welcome contributions to improve the game! To contribute:

1. Fork the repository.
2. Create a new branch for your feature or bug fix.
3. Submit a pull request with a detailed description of your changes.

---

# License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.

---

# Acknowledgments

- **Unity**: For providing the game engine.
- **FBLA**: For inspiring this project.
- **Open Source Assets**: For audio, images, and other resources used in the game.
- **Adithya Ganesh and Nikhil Sharma**: For developing this project

---

Enjoy the game and feel free to contribute or provide feedback!

### Steps:
1. Save this content in the [README.md](http://_vscodecontentref_/2) file located at `/Users/nikhils/Desktop/Unity/FBLA Game/Assets/README.md`.
2. Customize any sections (e.g., repository URL, acknowledgments) as needed.
3. Share the [README.md](http://_vscodecontentref_/3) file with your project to provide clear documentation for collaborators and users.
