# Homework2

Building features on top of [3D Beginner: Complete Project](https://assetstore.unity.com/packages/essentials/tutorial-projects/unity-learn-3d-beginner-complete-project-urp-143846)

#### Contributors: 
- **Jack Hanni:** Dot Product and Particle Effect
- **Ruimin Zhang:** Linear Interpolation and Sound Effect


### 1. Dot Product
John Lemon fear when he looks at an enemy increases. The more directly he looks at an enemy (ghost or gargoyle), the more he sweats.

#### Implementation Details:
Created an "Enemy" tag and tagged all the enemies accordingly. Made a script based on "Observer.cs" and made it for John called "PlayerView.cs". Made a collider for John's vision and if an enemy enters, the dot product of the displacement vector and John's forward direction determines who much the sweat particle effect produces particles.

### 2. Linear Interpolation
Added smooth rotation and movement.

#### Implementation Details:
In `PlayerMovement` script, for `OnAnimatorMove` method, implemented **Lerp** for movement and **Slerp** for rotation. 


### 3. Particle Effect
The particle effect of the dust trail behind the cat when he moves. Also, sweat particles effect when you look at an enemy a lot.

#### Implementation Details:
Particle effect under character parent. 

### 4. Sound Effect 

Added sound effects for walking on the five carpets in the map. 

#### Implementation Details:
- Download carpet walking sound
- For all five **Rug_Corridor** objects under _Level -> Dressing -> Rugs_, 
  - add `Box Collider` (select `Is Trigger` so that player can freely walk on it), 
  - add `Audio Source` (unselect `Play On Awake`), 
  - and a `Script` to play only when interacting with the **Player**


