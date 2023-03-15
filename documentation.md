# Project Documentation
> *Links to other documents*
>
> [Resources](/resources.md) - *List of resources used to learn and assist development*
> 
> [README](/README.md)

If you want to understand everything about how this project works and how it's organized, this document is for you!

This file contains thorough documentation of all scenes in the game, how they work, and what the different scripts are used for. This documentation is not exhaustive, so there may be some things I missed. I hope that this documentation answers all questions about the project, but if not, you can email me at alexanderwills37@gmail.com. 

## Credits
Before getting into the documentation, I would like to give credits to everyone involved in this project.

Summer 2022 Team:
- Dr. Tania Roy - Project Supervisor
- Devin Gregg - Created 3D models, textures, and animations
- Ender Fluegge - Created the backend for telemetry
- Riley Wood - made a similar simulation for Google Cardboard and helped with Unity development
- Professor Athena Rycyk - Marine Biology and manatee expert
- Alex Wills - wrote scripts and developed this simulation for Quest 2, and wrote this documentation
- Everyone above helped design the game and iterate through feedback collectively during development.

Previous version of this simulation:
- Dr. Roy and Sami Cemek made the first iteration of this project.



## Scripting documentation note
- All of the dates found in file headers (typically to show when the file was updated) are in Month/Day/Year format
- Quest-specific code
  - `NewPlayerController.cs` and `NewVerticalMovement.cs`
    > both files use raw input mapping from the Quest (https://developer.oculus.com/documentation/unity/unity-ovrinput/)

## Versions
 - **Unity Editor** - 2019.4.34f1
 - **Oculus Integration Asset** - Version 40.0.0
   > Unless you reimport this asset, the project will have this version.

## Important things to know
Some scripts and scenes have parts that are not friendly to people unfamiliar with Unity. Many scripts make use of [**coroutines**](/resources.md#coroutines-and-other-ways-to-delayprolong-methods), which are special methods that can be delayed/extended to occur over multiple frames. For resources used during development that might help, [see the resources document](/resources.md). This project uses:
- Coroutines
- Animation clips
- Animation controllers
- Rigidbody physics
- Colliders and trigger colliders
- Oculus Integration package for developing with Quest 2
- Prefabs
- Scene management
- Audio sources
- Particle systems
- Unity Terrain editor
- Canvases, UI Elements, and Text Mesh Pro

## Scene Documentation
This section outlines all of the scenes in the Unity project, the interactions within, and the relevant assets/files. For each scene, this document goes over what happens in the scene, the intended gameplay, important mechanics and systems, and the scripts used in the scene.

Since all of the scripts are documented here, if you don't know what a certain script is used for, try ctrl+f to search for it by name here!
<!-- - [Project Documentation](#project-documentation)
  - [Credits](#credits)
  - [Scripting documentation note](#scripting-documentation-note)
  - [Versions](#versions)
  - [Important things to know](#important-things-to-know)
  - [Scene Documentation](#scene-documentation) -->
  - [Scene 0 - Introduction on Boat](#scene-0---introduction-on-boat)
      - [***Why are there so many canvases?***](#why-are-there-so-many-canvases)
  - [Scene 1 - Tutorial](#scene-1---tutorial)
      - [**Underwater Movement**](#underwater-movement)
      - [**HUD**](#hud)
  - [Scene 2 - Social Life](#scene-2---social-life)
      - [**Manatee Prefab**](#manatee-prefab)
      - [**Water effects**](#water-effects)
  - [Scene 3 - Transition](#scene-3---transition)
  - [Scene 4 - Boat Hit](#scene-4---boat-hit)
  - [Scene 5 - Ending](#scene-5---ending)

## Scene 0 - Introduction on Boat
> [Return to scene list](#scene-documentation)

Filename: `0 - Intro on Boat`

![Title screen of the game](/Documentation%20Resources/Title%20Page.png) ![Sign that lets you choose the names of the manatees in the game](/Documentation%20Resources/Choose%20Name.png)

**Overview**:
This is the first scene of the game. On this boat, the player will learn about manatees, get adjusted in VR, name their manatee friends, and start the game.

**Intended gameplay**:
- Read the title
- Learn how to control the game in VR
- Listen to manatee stress vocalization by clicking the button
- Read and learn some facts about manatees
- Click on names to name the two adult manatees in the game
- Start the game

**Environment**

The environment is made out of a 3D Boat asset and water. The water comes from Standard Assets.

**Canvases**

There are several canvases with text and images explaining controls and manatee facts. All of the canvases can be seen in the hierarchy under `InformationCanvases`.

These canvases are then divided into 2 subcanvases.

`Static Canvas`: for most static signs.
- `Title` - contains the game's title and an image of a manatee.
- `Controls` - shows a diagram and instructions on how to click using the Quest2 controllers.
- `Manatee Info Canvas` - has 2 textboxes and the manatee picture giving manatee facts.
- `Arrows` - holds all of the arrow images that point from one canvas area to another. Used to guide the player to read the canvases from left to right, starting with the title sign.

`Interaction Canvas`: for interactable signs.
- `Story` - holds the text explaining the game.
- `Become a Manatee Button` - the button that will start the game. Located underneath the story text.
- `Move on after some time seconds anyway` - text element next to the manatee button that will automatically change the scene after time has passed. In the inspector, under the `Timer Behavior` component of this object, you can adjust the `Timer Start` value to change how many seconds this object counts down to.
- `ManateeSoundCanvas` - a separate canvas, located near the manatee information, where the user can press a button to listen to manatee stress vocalizations.
- `NameYourManateeCanvas` - another canvas that allows the user to choose the names of the manatees in the later scene.

#### ***Why are there so many canvases?***

[More information can be found here](https://unity.com/how-to/unity-ui-optimization-tips), but in a nutshell any changes to a UI element (timer change, button press, etc.), cause the parent canvas to refresh every object in the canvas, so canvases should be separated for optimization. The current canvas organization in the project could be improved for better performance.

**Player**

The player in this scene uses the `OVR Player Controller` and `UIHelpers` from the Oculus Integration Package. The `OVR Player Controller` allows the user to move around with the joystick, and the `UIHelpers` (found in the hierarchy) creates the red pointer coming out of the user's hand, and allows the user to interact with the canvas buttons. In the `OVR Input Module` component (part of the EventSystems, which is a child of the UIHelpers), you can adjust which buttons count as a click with the Joy Pad Click Button. Currently it is set to either of the triggers.

**AudioManager**

This object contains all of the sound effects in the scene. Currently the ocean sound effect is constant, and the manatee stress vocalization is activated with the button on the canvas.

**Scripts**

Besides scripts that come with certain assets (the scripts in the water surface, the scripts in the OVR Player Controller), a few custom scripts add functionality.

- `TimerBehavior.cs` - attached to a few Text Mesh Pro components, this script counts down from a number set in the inspector. When it hits 0, it invokes a UnityEvent that behavior can be added to. In most cases, the timer counts down to a scene change.
- `ChangeScene.cs` - this script has 2 public methods:
  - `LoadScene(int sceneIndex)` - loads a scene based on the index.
  - `LoadNextScene()` - loads the next scene based on index. This method is preferred because if you add scenes, the index of the later scenes will all change.
- `AudioTrigger.cs` - attached to the EventSystem and referenced by the manatee sound canvas play button, this script plays the manatee sound and switches one button for another while the audio is playing so that there is visual feedback, and so that you cannot press the button again while the audio is playing.
- `ManateeNameChooser.cs` - this script has a static list of the chosen manatee names, as well as a public method `ChooseName(string name)` to select a name. In the inspector, you set the TMPro text components to display the chosen names. These objects must also have a child that indicates which name is currently selected. Calling `ChooseName` multiple times will edit different names in the list, wrapping around back to the first name once all names have been chosen.
- `ManateeNameButton.cs` - this script connects a button, the text in the button, and `ManateeNameChooser.cs` so that when you click the button, it calls `ChooseName` with the text the button shows.


## Scene 1 - Tutorial
> [Return to scene list](#scene-documentation)

Filename: `1 - Underwater Tutorial`

![Tutorial scene where the player is taught how to surface to breathe air](/Documentation%20Resources/Tutorial.png)

**Overview**: This scene introduces the player to the gameplay mechanics and prepares them for the rest of the game, playing underwater as a manatee.

**Intended Gameplay**
- Follow the tutorial
  - Learn to move with the joystick
  - Learn to eat seagrass by touching it
  - Learn to surface for air with Y
  - Learn to go back down with X
- Move on automatically to the next scene

#### **Underwater Movement**

The OVR Player Controller does not allow for gravity to be disabled, so this scene (and all underwater scenes) use a custom player controller. This controller has a rigidbody with frozen rotation, no gravity, and no drag. Velocity is set based entirely on the player's input with the attached scripts.

**Player+HUD**

The underwater scenes all have a Heads Up Display (HUD) to show the player information as they move around (health, breath, text/images), so the Player and HUD are grouped together in this object.

#### **HUD**

Having the HUD at a fixed rotation and distance from the player can be uncomfortable in VR and make information difficult to read. You might want to look up to better see the health bar, so the health bar should not move up with your gaze.

In this game, the HUD uses a custom script `HUDBehavior.cs` to do the following:
- Follow the player's position when they swim around the environment
- Stay at a constant X/Z rotation so that the player can look up or down without the HUD moving away
- Not immediately move Y rotation so that the player can look left/right without the HUD instantly moving away
- When the player looks far enough left/right, the HUD will rotate about the Y axis to catch up with the player

In the inspector, you can adjust how far the player can look before the HUD moves and how quickly it moves.

The HUD has the breath bar, the health bar, and the tutorial canvas. The tutorial canvas has several text/image objects to show during differrent parts of the tutorial.

**Player**

NewPlayerController contains the colliders, rigidbody, and scripts to control the movement of the OVRCameraRig. They are separated like this in case you want to have separate rigidbody colliders on the OVR hand anchors.

Vibration Manager just has the `HapticFeedback.cs` script to rumble the controllers.

**Tutorial Elements**

Tutorial Canvas has the `TutorialBehavior.cs` script to manage all of the tutorial elements. This includes the Tutorial Canvas children.
Tutorial Triggers has objects to load/unload during different parts of the tutorial to check for different conditions to be met.

**Scripts**
- `TutorialBehavior.cs` - attached to the Tutorial Canvas, this script manages the entire scene. The 'tutorial' has multiple steps. In each step, we teach the player how to do a new thing, display a different set of HUD elements (text+image), and update the Task Panel (the bar at the bottom of the HUD with a task and a checkbox). When the player completes the task, the game calls this script's `CompleteTaskAndProgress(int nextTaskNumber)` to move to a different task. This will unload the current HUD display, fill in the checkmark, rumble the controllers, flash the Task Panel's text green, and load the next task. If the `int nextTaskNumber` is equal to the number of tasks (when all tasks are completed), the tutorial will end and begin the transition to the next scene. Otherwise, it will load in the HUD display for the next task, and activate the object in Tutorial Triggers that is set for the task.
This script entirely depends on the objects set in the inspector, and the `CompleteTaskAndProgress` method called in UnityEvents of other objects set in the inspector.
- `NewPlayerController.cs` - moves the player on the x-z plane when they move the thumbstick.
- `NewVerticalMovement.cs` - moves the player up and down on the y axis when the player presses Y and X
- `PlayerScript.cs` - contains static and public variables for the breath and health, and slowly decreases the breath meter over time.
- `MaintainHeight.cs` - keeps an object at a constant Y position. Used on the Sun Rays particle system so that the sun rays will follow the player's location, but not change their height.
- `HapticFeedback.cs` - allows for haptic feedback with the static instance `HapticFeedback.singleton` and its public methods for triggering vibrations.
- `HUDBehavior.cs` - manages the HUD's rotation and location to smoothly follow the player's horizontal gaze. You can customize the angle in degress that the HUD will move at, the time it takes to move to the player, and the curve it will follow to smoothly move.
- `HealthBar.cs` - provides access to modifying the values of the slider gradients used in the health and breath bars.
- `InverseLoadingZone.cs` - used to progress the tutorial when the player leaves the starting collider.
- `TutorialFoodBehavior.cs` - used to progress the tutorial when the player eats the tutorial seagrass.
- `TutorialSurfaceZone.cs` - used to progress the tutorial when the player reaches the surface to breathe.
- `LoadingZone.cs` - used to progress the tutorial when the player goes back underwater after swimming to the surface.
- This scene also uses the Timer and Scene Changer scripts found in [Scene 0](#scene-0---introduction-on-boat)
- Some of these scripts that are only used in this scene are in Scripts > Tutorial Scripts


## Scene 2 - Social Life
> [Return to scene list](#scene-documentation)

Filename: `2 - SocialLife`

![The underwater environment, with a manatee and fish in the distance](/Documentation%20Resources/Underwater.png)

**Overview**: This is the main game. In this scene, the user will swim around as a manatee and complete their two tasks: eat 10 seagrass, and pet a manatee friend. They must also make sure they do not run out of breath, and surface to breathe when it gets low.

**Intended Gameplay**
- Explore the environment by swimming around
- Surface to breathe when the breath meter gets low
- Find all three manatees
- Pet at least one of the manatees
- Eat 10 seagrass while you explore

**Eating Seagrass**

To eat seagrass, you just have to collide with it. In the hierarchy, the seagrass is under Kelps, which is under Environment.

#### **Manatee Prefab**
![The user petting a manatee, who is giving off smiley face emojis](/Documentation%20Resources/Pet%20a%20manatee.png)
The manatee prefab has several components to enable its behavior.
- **ManateeAI** - this is the parent object, which has the main `ManateeBehavior2.cs` script, the rigidbody, and the audio source.
  - **FieldOfViewTrigger** - this object has a trigger collider and the `ManateeVisionTrigger.cs` script to update the `ManateeBehavior2.cs` script when the player enter/exits this collider
  - **Manatee Model** - this object, which may be named differently, contains the 3D model of the manatee along with an Animator for the manatee.
    - **Nametag** - this object is a child of the 'Neck' bone in the armature that displays the manatee's name with the `ManateeNameLabel.cs` script attached to the TMPro object that is a child of the nametag. This is a child of the armature so that the nametag follows the manatee's head, even during animations.
    - **PhysicalManatee** - this object is both a physical and trigger collider with the `ManateePhysicalCollider.cs` script. The physical collider allows for the manatee to have physics, and the trigger collider detects the air trigger and the player's personal space trigger to let the `ManateeBehavior2.cs` script know if the manatee is at the surface, if they are in the player's personal space, or if the player is colliding (such as when they pet the manatee). It is attached to the armature so that the collider's position is accurate, even when the manatee is animated.
  - **HappyParticles** - this particle system can be used to release smiley face emojis from the manatee. To do this, set the emission rate to something higher than 0 for a little bit, then set it back to 0. [For more information on scripting with particles, click here](https://docs.unity3d.com/ScriptReference/ParticleSystem.html).

  With the player's collider having the 'Player' tag, the surface having the 'Air' tag, and the player's personal space collider set in the inspector for the **PhysicalManatee** object (this should be changed, since setting it manually is time consuming), the manatee knows 3 things:
  - If it is at the surface
  - If the player is nearby (is the player in the manatee's sphere)
  - If the manatee is in the player's personal space (is the manatee in the player's sphere)

  If the manatee collides with the player (intended when the player pets the manatee), it will release happy particles. Otherwise, the manatee will move with coroutines.

  
  The manatee will swim forward for 1-5 seconds and rest for 1-5 seconds continually. If the manatee is low on breath, which is a timer set in the inspector, it will surface instead of swimming forward. If the manatee has breath but is in the player's space, it will not swim forward.

  At the same time, the manatee will slowly rotate up to 70 degrees in either direction, wait 1-5 seconds, then rotate again.

  There is commented out code in `ManateeBehavior2.cs` for the manatee to follow the player instead of swimming forward if the player is nearby and the manatee is not in the player's personal space.

  The baby manatee will always follow its parent instead of swimming forward, rotating, or breathing. It will still release happy particles when pet.

**Breath Alarm**
  
  The player has a Heartbeat Effect object attached and the NewPlayerController has the `BreathAlarm.cs` script to alert the player when their breath is low to create a sense of urgency and guide them to breathe.
  ![The breathe alarm pulses a blue vignette over the camera and flashes text that says "Breathe now!"](/Documentation%20Resources/Surfacing.png)

  The Heartbeat Effect, which creates a blue vignette around the camera, uses Post Processing. [Scripting with Post Processing can be read about here](https://docs.unity3d.com/Packages/com.unity.postprocessing@3.0/manual/Manipulating-the-Stack.html).

**Animations**
- **Manatee Animation** - the manatee model has an animation controller that can be found in Assets > Models > EDAP Assets > Manatee. It uses the animations in the manatee FBX and some boolean parameters to determine what animation for the manatee model to play.
- **Spotted Sea Trout** - the sea trout's animation controller is in Assets > Animation. It plays its swimming animation continously.

**Fish swimming around**

These fish are controlled entirely with an asset found [here](https://assetstore.unity.com/packages/3d/characters/animals/simple-boids-flocks-of-birds-fish-and-insects-164188).

#### **Water effects**
- **Sun rays** - a particle system that follows the player's location
- **Blue fog** - a setting at the bottom of the Lighting tab, under "Other Settings"
- **Water surface** - from Standard Assets
- **Caustics** - currently this simulation does not have caustics (you can find them disabled under the water game object). This is because the Projector component does not show up with the seagrass terrain textures, and the Light component with Lighting Cookies does not seem to work on Quest.


**Scripts**
- `TaskList.cs` - used to display and update the HUD that tells the player what to do (eat seagrass, pet a manatee). Invokes a UnityEvent when all tasks are completed.
- `BreathAlarm.cs` - used with `HeartbeatEffect.cs` to alert the player when their breath is low.
- `HeartbeatEffect.cs` - uses the post processing vignette effect to pulse a vignette at a regular interval when active.
- `TeachSocialManatee.cs` - used to display a HUD message telling the player to a pet a manatee when they get close to a manatee for the first time.
- `GrassTrigger.cs` - attached to seagrass. This script hides the model, activates bubble particles, and increases the player's health when colliding.
- `ManateeBehavior2.cs` - the main controller for manatee behavior.
- `ManateeVisionTrigger.cs` - tells `ManateeBehavior2` when the manatee is near the player. Attached to FieldOfViewTrigger under the manatee prefab.
- `ManateePhysicalCollider.cs` - tells `ManateeBehavior2` when the user collides with the manatee, when the manatee is at the surface, and when the manatee is in the player's physical space. Attached to PhysicalManatee under one of the Spine bones in the manatee armature.
- `ManateeNameLabel.cs` - reads the static list in `ManateeNameChooser.cs` to set the manatee's nametag. Attached to the Text (TMPro) object under the Nametag under the Neck bone in the manatee armature. In the inspector, select which index of the list to choose the name from, and whether to add "Jr." to the name. In the future, this script should not be so hard to access (see the issues in this repository).
- `BabyManateeBehavior.cs` - overrides the update method in `ManateeBehaivor2` so that a baby manatee with this script will follow its parent instead of swimming around on its own.
- The other Player+HUD scripts are the same as the ones in [Scene 1 - Tutorial](#scene-1---tutorial)
- This scene also uses the TimerBehavior and ChangeScene scripts found in [Scene 0 - Introduction](#scene-0---introduction-on-boat)
- `ManateeRollBehavior.cs` - an animation StateMachineBehavior that ensures the manatee will only do the roll animation once by setting the isRolling parameter to false.
- `StopBreathingAnimation.cs` - like the previous script, this StateMachineBehavior ensures that the breathing animation only occurs once by setting the isBreathing parameter to false.

## Scene 3 - Transition
> [Return to scene list](#scene-documentation)

Filename: `3 - Transition`

![The transition scene, which says "Later on that day..." with a timer that is at 3 seconds](/Documentation%20Resources/Transition.png)

**Overview**: This scene is purely a transition from gameplay, where the user can swim around, to the boat scene, where the user will not be able to move.

This scene has the Camera Rig, a HUD with the `HUDBehavior.cs` script, and a timer. 

**Scripts**
- HUDBehavior found in [Scene 1 - Tutorial](#scene-1---tutorial)
- TimerBehavior and ChangeScene found in [Scene 0 - Introduction](#scene-0---introduction-on-boat)

## Scene 4 - Boat Hit
> [Return to scene list](#scene-documentation)

Filename: `4 - BoatScene`

![Manatee swimming towards the surface as boats speed by.](/Documentation%20Resources/Boats.png)


**Overview**: In this scene, the player experiences the loud and annoying sound of boats speeding on the surface, and they witness a boat hitting one of their manatee friends. The goal of this scene is to demonstrate the issue that we are trying to address.

Most of this scene is controlled with Animation Clips made in Unity.

**Intended Gameplay**

- Watch the manatee in front of you go to the surface and get hit by a boat.
- Console the manatee with some pats.
- Read the information about boat strikes.
- Move on to the final scene automatically.

**Boats**

The boats have a particle system releasing bubbles as they move. They also have an Audio Source with 3D audio to make the loud sound of boat propellors as they get close to the player. The main boat (under the Cutscene object) has an additional audio source for the collision sound that plays when the boat hits the manatee.

**Manatee**

There are 2 manatees in the background, and 1 manatee that is closer to the player. This manatee goes up for a breath of air, and is hit on the tail by a boat. To make this happen, the Manatee prefab from [Scene 2](#scene-2---social-life) is modified to be the child of another object "CutsceneManatee" that temporarily disables the `ManateeBehavior2.cs` script. The happy particles are replaced with "SadParticles" that slowly float down instead of up, showing that the manatee is injured from the boat but comforted by social interaction. There is also an "InjuryBubbles" particle system to make the impact more noticeable with red bubbles.

The animation of the manatee getting hit by the boat is a mixture of physics and animation. the **CutsceneManatee** parent object does not have a rigidbody, and is moved with its animation controller. Because the **ActualManatee** (with the rigidbody) is a child of this object, the actual manatee correctly moves along with the animation and moves to a place where it is at risk of a boat hit. 

The boat and the manatee have rigidbody colliders, so when the boat hits the manatee, the **ActualManatee** object registers a collision, moves according to the collision physics, creating a realistic effect (the **CutsceneManatee** object does not move, but the **ActualManatee** does). It also calls `OnCollisionEnter` for the **AcutalManatee**, allowing for the sounds and particles to be activated at the right time.

**Animations**
- **Other Boats** - the boats that are not going to hit the manatee speed by in different directions on a loop, controlled by the OtherBoats animation controller.
- **CutsceneManatee** - controlled by the V2ManateeBoatScene animation controller, this animator moves the CutsceneManatee object towards the surface, calls the `Breathe()` method, then the `RunBoatOverManatee()` method, then the `EnablePlayerMovement()` method to synchronize the other animations and functions.
- **Manatee model** - the manatee model has the same animation controller as the manatees in [Scene 2 - Social Life](#scene-2---social-life).
- **Boat (the one under Cutscene)** - controlled by the CutsceneBoat animation controller, this animation just moves the boat quickly from one side of the scene, over the point of impact where the manatee is, to the other side of the scene. This animation is activated by the CutsceneManatee animation when the manatee finishes breathing.

**Scene flow**
1. **CutsceneManatee** begins its animation, moving the manatee to the surface to breathe.
2. HUD text telling the player to look up at the manatee stays on screen for a while.
2. When the manatee reaches the surface, `Breathe` is called from `ManateeBoatSceneBehavior.cs`, which makes the **ActualManatee**'s manatee model do its breathing animation.
3. After the manatee has finished breathing, `RunBoatOverManatee` is called from `ManateeBoatSceneBehavior.cs`, which starts **Boat**'s animation to speed towards the manatee's location.
4. The manatee turns to start swimming down.
5. The boat hits the manatee, calling `OnCollisionEnter`, changing the manatee texture to its wounded texture, playing the collision sound, and releasing the **InjuryBubbles** particles.
6. **CutsceneManatee** moves a bit farther down, and `EnablePlayerMovement` is called form `ManateeBoatSceneBehavior.cs`, which enables player movement, enables the manatee's behavior script, and activates the **BoatStrikeInfo** HUD element.
7. **BoatStrikeInfo** begins counting down
8. **BoatStrikeInfo** finishes counting, and the game moves on to the last scene.


**Scripts**
- `ChangeCameraRotation.cs` - attached to the Player Controller, this script rotates the player so that they are facing a particular direction at the start of the scene. Without this script, the camera's rotation is preserved between scenes. Since the player could be looking in any direction after [Scene 2 - Social Life](#scene-2---social-life), and we want the player to look at the manatee in the cutscene, this script is used to reorient the player.
- `PlayerCutsceneMovement.cs` - attached to **NewPlayerController**, this script starts the scene by disabling the scripts that allow player movement, and this script has public methods to re-enable player movement from `ManateeBoatSceneBehavior.cs`.
- `PlayAnimation.cs` - attached to the cutscene **Boat**, this script allows for the **CutsceneManatee**'s animation to trigger an event that starts the boat's animation.
- `ManateeBoatSceneBehavior.cs` - attached to the **CutsceneManatee**, this script controls most of this scene. It has public methods for the manatee's animation to start the boat animation, start the manatee breathing animation, and enable player movement. It also has public methods to play the right sound effects and particle systems when the manatee collides with the boat.

  *Some of these methods are only called by the animation clip "V2ManateeCutscene". To look at them, open the inspector tab alongside the animation tab. When you click on the __CutsceneManatee__, along the top of the animation tab, you should see Animation Events. Click on them to see the method they call in the inspector.*
  ![An image of the Unity Editor's Animation and Inspector windows side by side](/Documentation%20Resources/Animation%20Event.png)

- `ManateeCollisionBehavior.cs` - attached to the **ActualManatee**, this script detects the collision with the boat with `OnCollisionEnter`, plays the **InjuryBubble** particles, and calls the `ManateeBoatSceneBehavior`'s `BoatCollision` method.
- Manatee AI from [Scene 2 - Social Life](#scene-2---social-life)
- Player+HUD scripts from [Scene 1 - Tutorial](#scene-1---tutorial)
- Timer and Change Scene scripts from [Scene 0 - Introduction](#scene-0---introduction-on-boat)

## Scene 5 - Ending
> [Return to scene list](#scene-documentation)

Filename: `5 - End Scene`

!["Thank you for playing." screen back on the original boat](/Documentation%20Resources/Ending.png)

**Overview**: This scene has some final remarks about boat hit statistics, a farewell, and the option to either quit or replay the game.

**Intended Gameplay**
- Read the farewell messgae, boat strike statistic, and actionable message.
- Quit or restart the game.

In this scene, there is a canvas, and two buttons. One to Quit, and one to Restart. Because the entire middle of the simulation did not use the trigger to click on buttons, this scene also includes the controller diagram to remind the user how to click if they forgot.

**Scripts**
- `RestartSimulationButton.cs` - attached to a button. When the button is clicked, this script will reload [Scene 0 - Introduction](#scene-0---introduction-on-boat).
- `QuitGameButton.cs` - attached to a button. When the butotn is clicked, this script will close the application.

  Both of these scripts require a button component, and automatically connect the button to the script in the Start method, so you do not have to worry about setting the UnityEvent in the inspector.

- `ChangeCameraRotation.cs` from [Scene 4 - Boat Hit](#scene-4---boat-hit) to ensure the player is looking at the ending screen.


This is the end of the Scene Documentation. Currently the telemetry scripts are not included in this documentation.

[Return to scene list](#scene-documentation)

# Telemetry
For research purposes, this simulation tracks data about the user's behavior and stores it in a backend server. This section will overview the data that is being collected and where in the scripts this is happening, so that any modifications may be made.
## TelemetryManager.cs
This is where the bulk of telemetry occurs. 

A static TelemetryManager is created and set to persist between scenes.
**NOTE: Because the TelemetryManager persists between scenes, but the Player is reset in each scene, 
you must attach the PlayerTelemetryLinker.cs script to the player object in each scene.**

Upon creation, the Telemetry Manager attempts to open a connection with the backend server, specified in the `url` field.

Every frame, the Telemetry Manager uses the player's location and rotation to determine what the player is looking at. [More detail on the `lookingAt` entry is given below.](#lookingat-object-name-time-looked-at-seconds)


Every 60 frames, the Telemetry Manager will poll the player's location and rotation and add it as a data entry.

Every 600 frames, the Telemetry Manager will send the information it has collected so far to the database.

To add your own data entry to the backend, call the function
```
TelemetryManager.entries.Add(
  new TelemetryEntry( <string entryName> <other parameters>)
 );
 ```
For the kinds of other parameters you can send to the database, look at `TelemetryEntry.cs` in `Assets > Scripts > Telemetry > api`.
The timestamp of the event will be sent to the database by default.

### PlayerTelemetryLinker.cs
A helper script that finds the game object called "TelemetryManager" in the scene and sets the player transform within the TelemetryManager to the transform of this object. To record the player's rotation and position in VR, this is attached to the LeftEyeAnchor object in the OVR rig.

---

## Recorded Information
### breathAlarmStart, breathAlarmEnd
- BreathAlarm.cs, Scene 2


Two events to mark the start and end of the feedback that activates when the player's breath gets too low.

### sceneChange \[name of scene] \[time spent in scene (seconds)]
- ChangeScene.cs, Scene 0-4

Stores whenever a scene changes, the name of the scene that the player is going into, and the amount of time (in seconds) that the player spent in the scene before the scene change occured.

### grassEaten \[location]
- GrassTrigger.cs, Scene 2

Records when the player eats seagrass, along with a Vector3 containing the position of the seagrass that was eaten.

### manateeInteraction
- ManateeBehavior2.cs, Scene 2, 4

Activates whenever the player pets a manatee, therefore interacting with them.

### nameSelected \[name]
- ManateeNameChooser.cs, Scene 0

In the first scene, when the player chooses the names for their manatee friends, this event records a selection.
NOTE: The player may choose more than 2 names (the name selector cycles between naming the 2 manatees), so you may receive more than 2 instances of this entry. The latest 2 names selected will be the manatee names in the simlulation.

### playerHealth \[health]
- PlayerScript.cs, Scene 1, 2, (3) (health is not relevant in scene 3)

At 10 second intervals, this script will log an entry with the player's health (as an integer).

### playerBreath \[breath]
- PlayerScript.cs, Scene 1, 2, (3) (health is not relevant in scene 3)

At 10 second intervals, this script will log an entry with the player's breath (as an integer).

### restart
- RestartSimulationButton.cs, Scene 5

At the end of the simulation, there is the option to restart. Restarting is recorded to separate multiple playthroughs of the simulation.

### playerHeadRotation \[Vector3 angles]
- TelemetryManager.cs, All Scenes

Every 60 frames, the player's current rotation (x, y, z) is logged in the Poll() method.

### playerPosition \[Vector3 position]
- TelemetryManager.cs, All Scenes

Every 60 frames, the plaeyr's ccurrent position is logged in the Poll() method.

### lookingAt \[object name] \[time looked at (milliseconds)]
- TelemetryManager.cs, All Scenes

Every frame, TelemetryManager performs a physics raycast from the player's position and rotation to determine what the player is looking at. The data entry will include the name of the game object the player is looking at, along with the amount of time they spent looking at the object (null = 0 milliseconds). Time is recorded in milliseconds, rounded down. The entry will not be sent until the player looks at a new game object.

**This script uses layers to filter out the game objects it will record! In order for the TelemetryManager to log the player as looking at a game object, the following conditions must be met**
- The game object has the layer `RecordPlayerLookingAt` applied
- The game object has a collider (physical or trigger; both work)
- The player is looking at the game object
- The game object is within 100 units of the player

> For a full list of game objects set up for tracking, see
> [Observable Objects](/observable_objects.md)
