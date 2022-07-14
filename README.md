# The Pit
#### Video Demo: https://youtu.be/sP8kI1ItUSM
#### Description: The Pit is a single-player first-person fighting game. In each level, you are put into the very bottom floor of a pit, and your goal is to defeat the enemies on that level and stack the enemies body up in order to set foot on the next floor until you get out of the pit. As you pass levels, floors are added to the pit and the harder it gets to get out of it.

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

The Level Scene includes a **Bottom-up Level Generator**, in which generates each level based on the level the player currently is, this includes generating the whole scenario (floors and walls) and enemies. The enemies and the player move around and are oriented through the scenario with  **Navigation meshes** (designated meshes in the scene which specifies navigable areas in the environment, including areas where characters can walk, as well as obstacles).

## Files walkthrough
**Assets/**: Used to store and manage game assets.\
**Packages/**: Unity package management folder.\
**ProjectSettings/**: Contains information about various project settings like type of the project, input, graphics, quality, physics, audio settings etc.\
**.gitattributes**: Contains specifications for files and paths attributes used by Git and Git LFS when performing git actions.\
**.gitignore**: Contains specifications for files and paths that Git should ignore when performing git actions.\
**README.md**: It is this file

## How to access it (Linux only)
#### Download from web 
• go to Download [Download Link](https://drive.google.com/drive/folders/1jNkPpK6-_DXVlI24532SCjOfAcSG7pg7) \
• enjoy it.


Course: [CS50’s Introduction to Game Development: Final Project](https://cs50.harvard.edu/games/2018)
