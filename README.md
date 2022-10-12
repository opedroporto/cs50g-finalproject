# The Pit
#### Video Demo:
<a href="https://youtu.be/sP8kI1ItUSM" target="_blank">
     <img src="https://user-images.githubusercontent.com/77935889/182732125-1457dd64-b815-4524-a2b9-21eaba6b9762.png" alt="Demo Video of The Pit" height="100%" />
</a>

#### Description:
#### The Pit is a single-player first-person fighting game. On each level, you are put into the very bottom floor of a pit, and your goal is to defeat the enemies on that level and stack the bodies of the enemies up to set foot on the next floor until you get out of the pit. As you pass levels, floors are added to the pit and the harder it gets to get out of it.

| |
|:-------------------------:|
**Main Menu Scene**
![Main menu screenshot](https://user-images.githubusercontent.com/77935889/178791495-025ee0ef-b6b0-432b-a397-8a2978822047.png)

| | |
|:-------------------------:|:-------------------------:|
| **Main Menu Scene**: Controls Canvas <img width="1604" alt="Main Menu Scene" src="https://user-images.githubusercontent.com/77935889/178791653-3cd29529-c58e-49d0-8cb0-356e04eff306.png">| **Level Menu Scene**: Level 1 <img width="1604" alt="Level 1" src="https://user-images.githubusercontent.com/77935889/178791661-f439745d-9906-4aec-ad91-11bbe08eebde.png">|
| **Level Scene**: Level 1 - In Play <img width="1604" alt="screen shot 2017-08-07 at 12 18 15 pm" src="https://user-images.githubusercontent.com/77935889/178791665-63999c67-04fc-4289-8638-ac193cb60dfa.png">| **Level Scene**: Level 1 - Pause Canvas <img width="1604" alt="screen shot 2017-08-07 at 12 18 15 pm" src="https://user-images.githubusercontent.com/77935889/178801474-b1e35f62-0b61-4d6c-b945-8ac1320b3980.png">|
| **Main Menu Scene**: Level Unlocked <img width="1604" alt="screen shot 2017-08-07 at 12 18 15 pm" src="https://user-images.githubusercontent.com/77935889/178791674-3e7a8790-5b48-46cb-bb2f-d756505823e8.png">| **Level Scene**: Level 2 (+1 floor auto-generated) <img width="1604" alt="screen shot 2017-08-07 at 12 18 15 pm" src="https://user-images.githubusercontent.com/77935889/178802817-171620ea-6820-41b2-a80a-b328fc358f45.png">|
| **Level Scene**: Level 2 - Stacking pile of bodies up <img width="1604" alt="screen shot 2017-08-07 at 12 18 15 pm" src="https://user-images.githubusercontent.com/77935889/178791688-2034f49d-54e4-4226-baed-ddd456202ec2.png">| **Level Scene**: Level 2 - Stacking pile of bodies up <img width="1604" alt="screen shot 2017-08-07 at 12 18 15 pm" src="https://user-images.githubusercontent.com/77935889/178791694-4163ae3a-c898-4e59-ac81-702ddb12b2a4.png">|
| **Level Scene**: Level 2 - Second floor view <img width="1604" alt="screen shot 2017-08-07 at 12 18 15 pm" src="https://user-images.githubusercontent.com/77935889/178791699-c248aca4-2950-459f-9df0-5e6fa1593780.png">| **Level Scene**: Level 2 - Winning Canvas <img width="1604" alt="screen shot 2017-08-07 at 12 18 15 pm" src="https://user-images.githubusercontent.com/77935889/178791703-76d5206f-1c58-4d6a-8914-61df415a4343.png">|

The Level Scene includes a **Bottom-up Level Generator**, which generates each level based on the level the player currently is at, this includes generating the whole scenario (floors and walls) and enemies. The enemies and the player move around and are oriented through the scenario with  **Navigation meshes** (designated meshes in the scene which specify navigable areas in the environment, including areas where characters can walk, as well as obstacles).



</br></br>
## States

As the other projects of this course, this **Game** contains multiple states such as the:
>**Main Menu State**: It is the initial state, rendered when the player opens the game. It contains the game title ("The Pit"), a button ("Controls") that gives the player access to a description of the game controls, a button ("Exit Game") that quits the application and a whole menu frame with 15 buttons, each representing a level from the game; these level buttons are initially all unlocked, except for the first level (Level 1), and are dynamic unlocked according to a control variable that persists between scenes and records as the player concludes the highest unlocked level.\
**Level Menu State**: It acts as some sort of "pre-game" state and it includes a Level Indicator, which shows the player the current level he is entering, a Go Back Button that allows the user to go back to the Main Menu State and a Play Button that allows the user to enter the game itself, rendering the next State.\
**In Play State**: It is called from the previous state ("Level Menu State") and is rendered according to a control variable that persists between scenes which informs the Level Generator Script ("LevelGenerator.cs") of the current level the player is so it can generate enemies, floors, walls, colliders, etc. accordingly.\
**Pause State**: If the player is on "In Play State", he can pause the game whenever he wants. By pressing "ESC" while on "In Play State", the whole game freezes ("Time.timeScale = 0;"), darkens itself and the Pause Canvas with the "Resume" button that allows the player to return to the "In Play State", a "Return to Menu" button that allows the player to give up the current game and go back to the "Main Menu State" and an "Exit Button" that quits the application.\
**Winning State**: A Collider is put on each level and when the player hits it, similarly to the "Pause State", the game freezes and darkens itself, and a "Level Completed!" congratulations message is centred on the rendered canvas and a button ("Return to Menu") is rendered at the bottom of the screen allowing the player to go back to the "Main Menu State". In addition to its functionalities, when the player concludes the level, it may or may not mean the player has unlocked one more level, and it is in this state that the record is taken.\
**Game Over State**: If the player is on "In Play State" and he gets to "Dead State" (when his life gets to 0), the whole game is frozen and a black canvas is rendered with a game over message and a menu where the player can choose between going back to "Main Menu State" or quit the application.

-----

The **Player** may vary between:
>**Idle State**: It is the initial player state and it is active always the player doesn't move and its coordinates are the same.\
**Walking State**: While one of the Movement Keys ("WASD") is pressed,  the state is active and the player's coordinates change according to the pressed keys, in other words, the player gets to move.\
**Running State: Similarly to the walking state, the player also is able to move around the scene with the Movement Keys, however, the state is active while the "Shift" Key is pressed and the player's speed is increased, in other words, he moves faster.**\
**Dead State**: As the player takes damage from other entities, his life decreases. Once the player's life gets to 0, he is taken as dead independent from his previous current state and the Game Over State is called.\

And he can simultaneously, while idling, walking or running:
>**Attack** entities by swiping his sword: The player has a sword Prefab with a Collider rendered in front of him and whenever the player clicks mouse1 the attack is executed, in other words, both the sword Prefab and the collider rotates in a swipe movement and if the sword Collider collides with some entity during the attack duration, the "TakeDamage()" method of the entity is called, however, if it does not hit anything, nothing happens. While attacking, he can not reinitiate the attack and goes back to the not attacking state.\
**Carry** bodies of dead entities: If he is not already carrying an entity, whenever the player presses the Key "c", a ray is traced forward from the centre of the screen, if the ray hits some Dead Entity within a range of "3f", this entity body Transform Positions becomes relative to the player. If the Key "c" is pressed again, the body position becomes absolute again, in other words, the player drops the dead entity on the floor again.
-----

The **Enemies** are entities that vary their states and animation states between:
>**Idle State**: It is the default state and it is always active when the entity is not moving.\
**Patrolling State**: If the player is out of the enemy sight range, the enemy can not detect him and this state is active. While in this state, the enemy constantly picks random points within a limited range to walk to and the Walking Animation is rendered.\
**Chasing Player State**: As the player and enemies move, the player may get within the enemy sight range; and when it happens, the enemy chases the player, in other words, the enemy Chasing Player Animation is rendered and its transform position changes until it gets close to the player.\
**Attacking Player State**: If the enemy is close enough to the player, he, similarly to the player, has a collider which moves according to the attack movement and if during the attack duration it hits the player, the player "TakeDamage()" method is called. This attack movement and animation are repeated while within the limited range.\
**Dead State**: Once the lifes of the enemies get to 0 and it is taken as dead, its **Radgdoll** Component is instantly activated, which means the enemy instantly becomes a ragdoll and his rigid body physics abruptly changes, which makes the enemies body falls on the floor.



</br></br>
## Scripts

#### Among the multiple scripts created for the various game functionalities, there are:
**ActivateCursor.cs** and **DeactivateCursor.cs**: Respectively activate and deactivate the application cursor on each scene

**AudioManager.cs**: Manages the audio throughout the whole game.

**CanvasController.cs**, **GameOverMenu.cs**, **MainMenu.cs** and  **PauseMenu.cs**: Control the canvas menus functionalities of different menus of the game.

**PikcupEntity.cs**: Implemented on the player to give him the ability to carry dead bodies.

**DontDestroy.cs**: Prevent objects from being destroyed through scenes.

**Enemy.cs**: Manages specifications of the enemies such as their health points and takes care of activating the ragdoll physics on the entities.

**EnemyAI.cs**: Manages enemies AI, taking care of its state and animations associated with each state, in other words, here are the functionalities that make the enemies walk patrolling, look for a player and go after him.

**GameInfo.cs**: Keeps information about the player's current progress throughout scenes.

**GenerateMenuLevels.cs**: Generate the levels button for each level on Main Menu.

**Player.cs**: Manages player's features, such as taking damage (flashing damage canvas when damage is taken), attacking and dying (used for calling game over canvas).

**LevelGenerator.cs**: An object with this script is spawned every time a player enters a level and it is necessary to generate the whole level, floor by floor from the bottom of the pit. Given the current level, the script resizes the base shapes (walls and floors created using ProBuilder API) and spawns them at their respective positions so they institute a pit, enemies are also spawned on randomly picked locations through the floors.

Among other auxiliary scripts...

</br></br>
## Characters and Animations

The characters and animations mentioned above used on this project have been taken from [Mixamo](https://www.mixamo.com).
<img width="401" alt="Main Menu Scene" src="https://user-images.githubusercontent.com/77935889/195225966-7314ca66-d248-4461-a4e5-8559734b3d4f.png">

</br></br>
## Files walkthrough
**Assets/**: Used to store and manage game assets.\
**Packages/**: Unity package management folder.\
**ProjectSettings/**: Contains information about various project settings like type of the project, input, graphics, quality, physics, audio settings etc.\
**.gitattributes**: Contains specifications for files and paths attributes used by Git and Git LFS when performing git actions.\
**.gitignore**: Contains specifications for files and paths that Git should ignore when performing git actions.\
**README.md**: It is this file.



</br></br>
## How to play (Linux only)
#### Download from web:
• Go to [Download Link](https://drive.google.com/drive/folders/1jNkPpK6-_DXVlI24532SCjOfAcSG7pg7). \
• Enjoy it.

Course: [CS50’s Introduction to Game Development: Final Project](https://cs50.harvard.edu/games/2018)
