# Asg1

## File Structure
This scene and scripts for the assignment are located under:
`Assets/I3E_Asg1/’

Only files in this directory are related to the I3E Asg1 project.

Below is the organization of the project files located in Assets/I3E_Asg1/:

Assets/
Folder for all third-party or imported assets used in the project (e.g., trees, props, environment packs).

Audio/
Contains all sound effects and background music used in the game.

Materials/
Includes all custom materials applied to GameObjects such as lava, poison, and collectible glows.

Prefabs/
Contains reusable prefabs like Lava Spheres, Energy Cubes, and the Laser trap.

Scenes/
Stores the main playable scene for the assignment. This is where the full game world is built and saved.

Scripts/
Contains all gameplay scripts used in the project, including interaction logic, hazard behavior, UI updates, and win conditions.

## 🎮 Game Overview

In game, the player must survive deadly environmental hazards and solve interactive challenges across 4 distinct zones. The goal is to collect key items (Power Cell, Shield, and Key) and escape the facility through the final gate.

---

## 🎮 How to Play

- **Controls:**
  - `WASD`: Move
  - `Mouse`: Look around
  - `Shift`: To run
  - `E`: Interact (collect items, open doors)
 
- **Objective:**
  - Explore all 4 zones
  - Collect a total of **12 items**
  - Use the **Power Cell** and **Key** to unlock access and escape

---

## 🧩 Zone Descriptions & Objectives

### 🟥 Zone A: Lava Challenge
- Terrain filled with lava that deals damage over time
- Collect 5 **Lava Spheres**
- Jump between terrain to avoid damage
- Return later to open a door with the **Power Cell**

### 🟦 Zone B: Cube Chamber
- Collect 4 **Energy Cubes**
- After collecting all, gain access to the **Power Cell**
- Power Cell is needed to unlock the door in Zone A

### 🟩 Zone C: Shield Room
- Contains a poison area that deals damage over time
- Contains a glowing **Shield**
- Required to pass through the **Laser Hazard** in Zone D safely

### ⬛ Zone D: Laser & Key
- Lethal **laser blocks** the path
- Use the **Shield** to survive
- Collect the **Key** needed to open the final Exit Gate 

---

## 🎯 Game Puzzle Answer Key

To complete the game:

1. Collect all **5 Lava Spheres** in Zone A
2. Go to Zone B and collect **4 Energy Cubes**
3. Pick up the **Power Cell**
4. Use the Power Cell to open a door in Zone A
5. Go to Zone C and collect the **Shield**
6. Enter Zone D using the Shield, collect the **Key**
7. Use the Key to unlock the final gate and finish the game

---

## 💻 Platforms / Hardware Requirements

- Built with Unity (tested on Unity 2022.3 LTS)
- Platform: **Windows PC**
- Recommended:
  - 8GB RAM
  - Mid-range GPU
  - 1080p display resolution
  - Mouse + Keyboard

---

## ⚠️ Limitations / Bugs

- Door closes immediately after passing through it
- Sometimes Door may close before passing through it
- You don't take damage until you die (for the DOT hazards) on the hazard. Only the damage that is dealt over time or if you repeatedly fall into the hazard.
- Respawn is immediate with no downtime.
 

## 🎵 Audio & Asset Credits

YouTube Videos:

(IInteractable) How To Interact With ANY Object In Unity [Video]. YouTube. https://youtu.be/xQciOlbRtUQ?si=Q_qJYmmb5wmYrb73

(Coroutine) Unity - Damage Over Time (Hazards Tutorial) [Video]. YouTube. https://youtu.be/DKKZeQtxxig?si=kL76TLEI1jjy9Iz4

Unity Asset Store – 3D Models & Textures:

BOTD. (n.d.). Conifers [BOTD] [3D Trees]. Unity Asset Store. https://assetstore.unity.com/packages/3d/vegetation/trees/conifers-botd-225613

PolySquid. (2020). Stylized Lava Materials [2D textures]. Unity Asset Store. https://assetstore.unity.com/packages/2d/textures-materials/stylized-lava-materials-180943

Game Asset Factory. (2020). Sci-Fi Construction Kit - Modular [3D assets & audio]. Unity Asset Store. https://assetstore.unity.com/packages/3d/environments/sci-fi/sci-fi-construction-kit-modular-159280

Trisgames. (2020). Rust Key [3D prop]. Unity Asset Store. https://assetstore.unity.com/packages/3d/props/rust-key-167590

Dekogon. (2017). Shield [3D prop]. Unity Asset Store. https://assetstore.unity.com/packages/3d/props/weapons/shield-61351

Sound Effects (Freesound.org):

LilMati. (2018). Sci-Fi UI Confirm Sound [Sound effect]. Freesound. https://freesound.org/people/LilMati/sounds/453067/

ejfortin. (2008). Menu Button Confirm Sound [Sound effect]. Freesound. https://freesound.org/people/ejfortin/sounds/49669/

ImATaco. (2023). Shield Pickup Sound [Sound effect]. Freesound. https://freesound.org/people/ImATaco/sounds/781125/

tomf_. (2010). Key Pickup Sound [Sound effect]. Freesound. https://freesound.org/people/tomf_/sounds/121990/