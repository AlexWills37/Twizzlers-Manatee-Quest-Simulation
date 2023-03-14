# A list of game obects configured to be tracked by the Telemetry Manager!
This list contains gmae objects that are able to show up in the `lookingAt` data entry. They are organized by scene.

This list will provide the names of the game objects that can be recorded, along with a short description. In order for a game object to be
tracked by the telemetry manager, it must have the `RecordPlayerLookingAt` layer and a collider.

## 0 - Intro on Boat
- Water Surface (Collider)
  - This is the surface of the water, around the boat
- Boat Floor
  - The ground the player stands on
- Information Canvas Background
  - The panel behind the canvas information
  - The player is looking at this if they are facing the canvases, but not looking
  directly at any text/pictures
- Slide Continue Button
  - The button that the player clicks to progress the intro scene

-----
- Welcome Message
  - The title screen of the game
- Trigger Control Diagram
  - Picture of the Quest controller, telling the player where the trigger is
- Controller Instructions
  - Short text telling the player to point and click the continue button

-----
- Manatee Species Info
  - Text describing the 3 species and habitats of manatees
- Manatee Sound Canvas
  - The area with a button to listen to manatee sounds
- Manatee Social Info Text
  - Text describing manatees' social behavior
- Manatee Family Photo
  - A photo of 2 manatees together :)

-----
- Chosen Manatee Names
  - The text containing the names the player has already chosen for their manatee friends
- Twicks Name Button
- Skittlez Name Button
- Oreoo Name Button
  - The buttons to choose the names for the manatees
- Choose Manatee Names Instructions
  - Text instructing the player to choose their manatee friends' names

-----
- Anatomy Info Text
  - Description of manatee anatomy
- Manatee Photo (Anatomy Slide)
  - Picture of a manatee accompanying the anatomy information

-----
- Becoming a manatee story
  - The description of the player about to become a manatee
- Becoming a manatee button
  - The button the player presses to begin the simulation

## 1 - UnderwaterTutorial
- Tutorial Kelp Collider
  - The seagrass the player eats in the tutorial
- Task Panel
  - The small panel instructing the player on what to do next
  - Follows the player's rotation
- Eat Seagrass Info
  - Tutorial information telling the player how to move around and eat seagrass
  - Follows player rotation
- Swim Up Info
- Swim Down Info
  - Tutorial information telling the player how to swim up and down
  - Follows player rotation

## 2 - SocialLife
- Seagrass Collider
  - Seagrass that the player can eat to gain points
- ManateeAI
  - One of the manatees that the player can see swimming and interact with
- Health Bar
- Breath Bar
- Task List
  - Parts of the GUI that the player should see
  - Follows player rotation
- Artificial Reef
  - The spherical artificial reefs in the environment
- Coral Reef
  - The natrual reefs in the environment

## 4 - BoatScene
(there are no tracked objects in Scene 3 - Transition)
- LookUpHint / BoatNoiseInfo
  - GUI Element at start of scene that introduces players to boats and tells the player to look at the manatee in front of them
  - Follows player rotation
- Cutscene Manatee (Boat Hit)
  - The manatee in front of the player that will get hit by a boat :(
- Boat that hits manatee
  - The boat that quickly speeds by and hits the cutscene manatee 
- ManateeAI (doesn't get hit)
  - The manatee friends that are in the distance to the left of the player, that will not get hit by a boat :)
- Water Surface
  - The surface of the water
- BoatStrikeInfo
  - The GUI information telling the player about the frequency of boat strikes
  - Follows player rotation

## 5 - End Scene
- Thank You + Stats
  - The final information canvas!
