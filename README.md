> This readme is currently under construction! More information and pictures coming soon!
# EDAP Internship
 
From https://github.com/ascemek/Twizzlers


## Scripting documentation note
- All of the dates found in file headers (typically to show when the file was updated) are in Month/Day/Year format
- Quest-specific code
  - `NewPlayerController.cs` and `NewVerticalMovement.cs`
    > both files use raw input mapping from the Quest (https://developer.oculus.com/documentation/unity/unity-ovrinput/)

## Versions
 - **Unity Editor** - 2019.4.34f1
 - **Oculus Integration Asset** - Version 40.0.0
   > Unless you reimport this asset, the project will have this version.

## Scene Documentation
This section outlines all of the scenes in the Unity project, the interactions within, and the relevant assets/files.

- [Scene 0 - Introduction on Boat](#scene-0---introduction-on-boat)
- [Scene 1 - Tutorial](#scene-1---tutorial)
- [Scene 2 - Social Life](#scene-2---social-life)
- [Scene 3 - Transition](#scene-3---transition)
- [Scene 4 - Boat Hit](#scene-4---boat-hit)
- [Scene 5 - Ending](#scene-5---ending)

### Scene 0 - Introduction on Boat
> [Return to scene list](#scene-documentation)

Filename: `0 - Intro on Boat`

**Overview**:
This is the first scene of the game. On this boat, the player will learn about manatees, get adjusted in VR, name their manatee friends, and start the game.

**Intended gameplay**:
- Read the title
- Learn how to control the game in VR
- Listen to manatee stress vocalization by clicking the button
- Read and learn some facts about manatees
- Click on names to name the two adult manatees in the game
- Start the game

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

***Why are there so many canvases?***

[More information can be found here](https://unity.com/how-to/unity-ui-optimization-tips), but in a nutshell any changes to a UI element (timer change, button press, etc.), cause the parent canvas to refresh every object in the canvas, so canvases should be separated for optimization. The current canvas organization in the project could be improved for better performance.

**Player**

The player in this scene uses the `OVR Player Controller` and `UIHelpers` from the Oculus Integration Package. The `OVR Player Controller` allows the user to move around with the joystick, and the `UIHelpers` (found in the hierarchy) creates the red pointer coming out of the user's hand, and allows the user to interact with the canvas buttons. In the `OVR Input Module` component (part of the EventSystems, which is a child of the UIHelpers), you can adjust which buttons count as a click with the Joy Pad Click Button. Currently it is set to either of the triggers.

**AudioManager**

This object contains all of the sound effects in the scene. Currently the ocean sound effect is constant, and the manatee stress vocalization is activated with the button on the canvas.


### Scene 1 - Tutorial
> [Return to scene list](#scene-documentation)

Filename: `1 - Underwater Tutorial`

**Overview**: This scene introduces the player to the gameplay mechanics and prepares them for the rest of the game, playing underwater as a manatee.

### Scene 2 - Social Life
> [Return to scene list](#scene-documentation)

Filename: `2 - SocialLife`

**Overview**: This is the main game. In this scene, the user will swim around as a manatee and complete their two tasks: eat 10 seagrass, and pet a manatee friend. They must also make sure they do not run out of breath, and surface to breathe when it gets low.

### Scene 3 - Transition
> [Return to scene list](#scene-documentation)

Filename: `3 - Transition`

**Overview**: This scene is purely a transition from gameplay, where the user can swim around, to the boat scene, where the user will not be able to move.

### Scene 4 - Boat Hit
> [Return to scene list](#scene-documentation)

Filename: `4 - BoatScene`

**Overview**: In this scene, the player experiences the loud and annoying sound of boats speeding on the surface, and they witness a boat hitting one of their manatee friends. The goal of this scene is to demonstrate the issue that we are trying to address.

### Scene 5 - Ending
> [Return to scene list](#scene-documentation)

Filename: `5 - End Scene`

**Overview**: This scene has some final remarks about boat hit statistics, a farewell, and the option to either quit or replay the game.
