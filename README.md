# Homework2

Building features on top of [3D Beginner: Complete Project](https://assetstore.unity.com/packages/essentials/tutorial-projects/unity-learn-3d-beginner-complete-project-urp-143846)

#### Contributors: 
- **Jack Hanni:** Dot Product and Particle Effect
- **Ruimin Zhang:** Linear Interpolation and Sound Effect


### 1. Dot Product
cone of vision for the ghosts
if the ghost sees the player better when it's looking directly at the player and not at all when it's 90 degrees or more away from the ghost's forward direction.

#### Implementation Details:

### 2. Linear Interpolation
Added smooth rotation and movement.

#### Implementation Details:
In `PlayerMovement` script, for `OnAnimatorMove` method, implemented **Lerp** foor movement and **Slerp** for rotation. 


### 3. Particle Effect
The particle effect of the dust trail behind the cat when he moves.

#### Implementation Details:


### 4. Sound Effect 

Added sound effects for walking on the five carpets in the map. 

#### Implementation Details:
- Download carpet walking sound
- For all five **Rug_Corridor** objects under _Level -> Dressing -> Rugs_, 
  - add `Box Collider` (select `Is Trigger` so that player can freely walk on it), 
  - add `Audio Source` (unselect `Play On Awake`), 
  - and a `Script` to play only when interacting with the **Player**


