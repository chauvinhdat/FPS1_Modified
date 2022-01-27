# FPS1 MODIFIED
### This project is a modification of Unity tutorial project

## Summary
### 1. Added lives feature to the game, allowing 3 additional lives to the player. 
    Modified Health class to check for lives counter on top of the health bar feature implemented
    Decrease the lives counter whenever the health bar reaches 0, then reset to full with -1 lives
    Modified the UI gameHUD prefab to add 3 lives icon to signifiies the lives counter
    Modified PlayerHealthBar class to update the UI for lives counter whenever it increases/decreases,
    similar to health bar implemented

### 2. Added new enemy class based on the existing "Enemy_HoverBot" class.
    Made a slight adjustment to the object appearance
    Created a RandomSpawner script to spawn N numbers of enemy/object randomly in M radius from the script holder position
    Increased more health to the object for tougher enemy
    The damage are based on the projectile class, hence added new projectile prefab to allow for double the damage of the
    original HoverBot projectile
    
### 3. Added portal feature to teleport player upon collision to the portal
     Created a Teleporter script with player and destination parameters to teleport players back and forth
     Implemented a locking feature and timer in case player accidentally step back to the portal (5 seconds cooldown/lock)

### Files Modified/Added
     Health.cs
     PlayerHealthBar.cs
     Enemy_HoverBot_v2 prefab
     Projectile_v2 prefab
     GameHUD prefab
     Teleporter.cs
     RandomSpawner.cs
     

## Build Instructions
1. Access Builds -> Windows folder
2. open up FPS1.exe to run the game

### OR

1. Own UNITY 2019.4.17 LTS
2. Open the FPS1_Modifed in Unity Hub
3. Test play / Build & Test
