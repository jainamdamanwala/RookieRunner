# 🏃‍♂️ **Rookie Runner** 🚀  
**The Ultimate 3D Endless Runner Adventure!**

Welcome to **Rookie Runner**, where speed, agility, and quick reflexes are your keys to survival! Immerse yourself in a stunning 3D world as you dodge obstacles, collect coins, and power up to become the ultimate runner. But beware—each step forward brings new challenges and faster-paced action. Are you ready to test your skills and race your way to glory? 🌟  

---

## **🌟 Features**
- **Dynamic Tile Generation**: An infinite, ever-changing world that keeps the excitement alive.  
- **Intuitive Swipe Controls**: Effortlessly jump, slide, and dodge obstacles with simple gestures.  
- **Power-Ups Galore**: Activate magnets, high jumps, and more to give you the edge.  
- **Challenging Gameplay**: Increasing difficulty ensures that no two runs are ever the same.  
- **Real-Time Leaderboard**: Compete with friends and set unbeatable high scores.  
- **Immersive Audio**: Experience the thrill with impactful sound effects and a dynamic soundtrack.  

---

## **🎮 How to Play**
1. **Swipe** to change lanes, jump over obstacles, or slide under them.  
2. **Collect Coins & Gears** to upgrade your abilities.  
3. **Power Up** with magnets to collect coins or high jumps to reach new heights.  
4. Avoid obstacles and aim for the highest score possible!  

---

## **🔧 Code Overview**

### **Key Scripts**

#### **TileManager**
- Dynamically spawns and deletes tiles as the player progresses, ensuring an infinite runner experience.

#### **SwipeManager**
- Detects swipe gestures for controlling player actions like jumping, sliding, and lane switching.

#### **Sound**
- Manages the properties of game sounds, such as volume and looping.

#### **SimpleCameraController**
- Provides customizable camera controls for smooth gameplay and debugging.

#### **PlayerController**
- Handles player movement, power-ups, and interactions with obstacles and collectibles.

#### **PlayerManager**
- Manages game states such as game-over, UI updates, and player stats.

#### **Power-Ups (Magnet, High Jump)**
- Enhance gameplay by introducing temporary abilities to collect coins or perform enhanced jumps.

---

## **📸 Screenshots & Gameplay Videos**
_Showcasing the breathtaking visuals and thrilling action of Rookie Runner._

### **Screenshots**
<div>
    <img src="https://github.com/jainamdamanwala/RookieRunner/blob/main/RookieRunner_ScreenShots/Screenshot%202025-01-27%20234329.png" width = 33%/>
    <img src="https://github.com/jainamdamanwala/RookieRunner/blob/main/RookieRunner_ScreenShots/Screenshot%202025-01-27%20234339.png" width =33%/>
    <img src="https://github.com/jainamdamanwala/RookieRunner/blob/main/RookieRunner_ScreenShots/Screenshot%202025-01-27%20234354.png" width = 33%/>
    <img src="https://github.com/jainamdamanwala/RookieRunner/blob/main/RookieRunner_ScreenShots/Screenshot%202025-01-27%20234401.png" width =33%/>
    <img src="https://github.com/jainamdamanwala/RookieRunner/blob/main/RookieRunner_ScreenShots/Screenshot%202025-01-27%20234443.png" width = 33%/>
    <img src="https://github.com/jainamdamanwala/RookieRunner/blob/main/RookieRunner_ScreenShots/Screenshot%202025-01-27%20234503.png" width =33%/>
    <img src="https://github.com/jainamdamanwala/RookieRunner/blob/main/RookieRunner_ScreenShots/Screenshot%202025-01-27%20234514.png" width = 33%/>
    <img src="https://github.com/jainamdamanwala/RookieRunner/blob/main/RookieRunner_ScreenShots/Screenshot%202025-01-27%20234545.png" width =33%/>
</div>

### **Gameplay Video**
## Watch the Gameplay video on Youtube  
<br align = center>
<a href = "https://youtube.com/shorts/pv6ovPlGaC0?feature=share"><img src="https://img.shields.io/static/v1?message=Youtube&logo=youtube&label=&color=FF0000&logoColor=white&labelColor=&style=for-the-badge" height="35" alt="youtube logo"  /></a> 
</br>

[![Gameplay Video](https://github.com/jainamdamanwala/RookieRunner/blob/main/RookieRunner_ScreenShots/Screenshot%202025-01-27%20234329.png)](https://youtube.com/shorts/pv6ovPlGaC0?feature=share)

---

## **🌌 Join the Race!**
Whether you're a casual gamer or a speed-running pro, **Rookie Runner** promises endless excitement. Download the game now and begin your journey to become the ultimate runner!  

---

### **💻 Tech Stack**
- **Engine**: Unity 3D  
- **Programming Language**: C#  
- **Platform**: Cross-platform (PC, Android, iOS)

---

### **📂 Repository Structure**
```
RookieRunner/
├── Assets/
│   ├── Scripts/
│   │   ├── TileManager.cs
│   │   ├── SwipeManager.cs
│   │   ├── PlayerController.cs
│   │   ├── PlayerManager.cs
│   │   ├── PowerUps/
│   │   │   ├── Magnet.cs
│   │   │   ├── HighJump.cs
│   ├── Audio/
│   ├── Prefabs/
│   ├── Sprites/
├── ProjectSettings/
├── README.md
```

---

### **📜 License**
This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

---

Let me know if you'd like to tweak anything further! 🚀

## Coin
- Rotates the coin object continuously.
- Detects collisions with the player to increment the player's coin count and plays a sound effect.

## coin_Move
- Moves coins towards the player when triggered by a coin detector.
- Destroys the coin upon collision with the player.

## coin_new
- Controls the activation of the `coin_Move` script when the coin detector is triggered.
- Tracks the player's position to facilitate the coin movement.

## CoinRotate
- Rotates the coin object with a customizable rotation speed.
- Destroys the coin and plays a sound effect when collected by the player.

## Magnet
- Rotates the magnet power-up object.
- Triggers collection behavior when the player collides with the magnet.

## CameraController
- Smoothly follows the player's movement using a configurable offset.
- Updates the camera position dynamically for a seamless gameplay experience.

## PlayerController
- Handles all player movement, including lane switching, jumping, and sliding.
- Manages interactions with power-ups like magnets and high jumps.
- Tracks player stats such as coins, gears, and scores.
- Includes collision detection with obstacles and end-of-game mechanics.

## PlayerManager
- Oversees the game's state, including game-over and game-start scenarios.
- Updates UI elements such as coins, gears, and scores in real time.
- Handles events like resuming the game after buying lives and starting the game.

## LevelComplete
- Displays the "Level Complete" UI when the player reaches the end of a level.

## LevelComplete2
- Saves player progress and triggers level completion actions via the game menu.

## Lift
- Implements a moving platform that oscillates between two predefined points at a configurable speed.

## AmmoCrate
- Provides an ammo pickup item for the player.
- Plays a sound effect and destroys the crate upon collection.

## CheckPoint
- Records the player's position when they interact with a checkpoint.
- Saves progress for respawning after a death.

## coin
- Plays a sound effect and destroys the coin when collected by the player.

## GameManager
- Manages game states such as checkpoints, player lives, level counters, and resource counts (coins and diamonds).
- Uses a singleton pattern to persist data across levels.

## GameMenu
- Provides functionalities for pausing and resuming the game, accessing the main menu, and exiting the game.
- Tracks and updates the player's level progress.
- Displays game-over and level-complete menus.

## HealthKit
- Represents a health pickup that restores the player's health.
- Destroys itself upon collection by the player.

## IAPManager
- Handles in-app purchases, such as buying diamonds and removing ads.
- Includes functions for initializing purchases, buying items, and restoring previous purchases.
- Ensures compatibility with Unity's purchasing system.

Here are the descriptions for the provided scripts for your game **"Rookie Runner"**:

---

## TileManager
- **Purpose**: Dynamically manages the tiles in the endless runner game.
- Spawns a sequence of tiles from predefined tile prefabs as the player progresses.
- Deletes tiles behind the player to optimize performance.
- Keeps the tile placement consistent using a `zSpawn` position and tile length.

---

## SwipeManager
- **Purpose**: Detects swipe and tap gestures for player controls.
- Supports inputs for mobile (touch) and standalone platforms (mouse).
- Determines the swipe direction (`left`, `right`, `up`, `down`) and triggers appropriate actions based on the swipe magnitude.

---

## Sound
- **Purpose**: Represents individual sound properties for the game's audio system.
- Includes attributes like `volume`, `loop`, and `clip`.
- Contains a `source` field to manage the playback of sounds.

---

## SimpleCameraController
- **Purpose**: Provides a basic, customizable camera control system for debugging or testing.
- Supports movement (WASD keys) and rotation (mouse input) of the camera.
- Allows camera boost using the scroll wheel and offers options for inverting the Y-axis.
- Includes smooth interpolation for camera position and rotation for fluid movement.

---
