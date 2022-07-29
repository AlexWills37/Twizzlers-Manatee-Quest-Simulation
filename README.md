> This readme is currently under construction! More information and pictures coming soon!
# EDAP Internship - Twizzlers Manatee Simulation Game for Quest 2
 
> *Links to other documents*
>
> [Documentation](/documentation.md) - *Scene-by-scene breakdown of how everything works*
>
>[Resources](/resources.md) - *List of resources used to learn and assist development*

This project is a game developed for Oculus Quest 2, where you play as a manatee to learn about issues that manatees face, in particular boat strikes.

## Table of Contents
- [EDAP Internship - Twizzlers Manatee Simulation Game for Quest 2](#edap-internship---twizzlers-manatee-simulation-game-for-quest-2)
  - [Table of Contents](#table-of-contents)
  - [Trailer](#trailer)
  - [Background](#background)
  - [Purpose](#purpose)
  - [How to install this game](#how-to-install-this-game)
      - [Prerequisites](#prerequisites)
      - [Enabling developer mode on your headset](#enabling-developer-mode-on-your-headset)
      - [Installing the game](#installing-the-game)
  - [Status of the Game](#status-of-the-game)

## Trailer
> Trailer coming soon!
> 
> Full gameplay can be found [here](https://youtu.be/SXgbvRPEm6U).

## Background
![Picture of a manatee](/Twizzlers%20Manatee%20Quest2/Assets/Sprites/manatee-1600.jpg)
Manatees, also known as "sea cows," are marine mammals that are an iconic part of the Florida Gulf Bay ecosystem. Unfortunately, manatees face a variety of issues caused by humans. One such issue is boat strikes, when fast-moving boats hit manatees with their hulls or propellors. Since manatees are mammals, they breathe air, and must come to the surface periodically, where they are at risk of being hit by a boat. Some boat hits can be fatal, while others leave lifelong scars on the manatee. This issue is entirely preventable if boaters take steps to ensure they do not hit manatees. Boaters should follow recommended speeds as told by sign postings, and they should take care to be slow and on the lookout for manatees when in their habitats.

## Purpose
There are 2 central purposes to this game.
1. Raise awareness about manatees and boat strikes, and educate students on the ways they can prevent boat strikes.
2. Measure the effectivness of this simulation on the Quest 2 headset (data telemetry, usability, educational impact, etc.) against a simularly designed simiulation on the Google Cardboard headset.

By the end of this game, we hope that embodying a manatee and witnessing a boat strike build empathy within the user for these important marine mammals.

## How to install this game
Currently, since this game is collecting data for a study, this game is not available on the Quest store. With Unity, however, you can install this game on your Quest 2 headset.

#### Prerequisites
- Quest 2 headset
- Oculus developer account (to enable developer mode)
- Wired connection from Quest 2 to your computer
- Unity Editor version 2019.4.34f1

#### Enabling developer mode on your headset
1. Create an Oculus developer account: https://developer.oculus.com/
2. Download the Oculus app on a mobile phone
3. Log into your developer account on your Oculus Quest 2
4. Log into your developer account on the mobile app
5. Connect to your headset from the mobile app
6. Navigate in the mobile app to your Quest Device, then scroll down and click on "Developer Mode"
7. Enable Developer mode (this will allow you to download applications from unofficial sources)

#### Installing the game
1. Download this repository (or just the "Twizzlers Manatee Quest2" folder)
2. Open the "Twizzlers Manatee Quest2" folder with the Unity Editor version 2019.4.34f1
3. In the top bar of the window, click on File, then Build Settings
4. Connect your Quest headset to your computer
5. Click Build and Run. You can save the APK file anywhere on your computer
6. On the Oculus Quest 2, click "Allow to allow your computer to access your Quest files"
7. When the build is finished, the game should be running on your headset!
8. If the game did not automatically run, or if you closed out and would like to play the game, on your headset, open the Quest menu and go to your apps
9. In the top right corner, there should be a dropdown menu. By default, All is selected. Click on the dropdown menu
10. At the bottom of the dropdown menu, click on Unknown Sources
11. Click on the game, titled "Twizzlers Manatee"


## Status of the Game
*(Updated July 29, 2022)*

Currently, the summer 2022 internship is over and the first final iteration of the game is complete. There are a few known issues and unfinished parts to be addressed.
- The manatee prefab is using an old version (Vo3) of the manatee model. The prefab has the new model (V05), but still utilizes the old one because the new model does not yet have fully working animations.
  - When switching over to the new model, remember to consider the following:
    1. The new model uses a new version of the animation controller (manatee_Vo5 instead of manatee_Vo3). You may have to set up the animation states with the working animations.
    2. Currently, the **PhysicalManatee** needs a reference to the player's physical space collider, which can be drag & dropped in the inspector. It is easy to forget this, since the **PhysicalManatee** is a child of one of the spine bones, several layers down in the hierarchy.
    3. Like the **PhysicalManatee**, the **Nametag** is several layers down in the hierarchy, a child of the Neck bone. Every instance of the manatee prefab should have the Manatee Name Label script configured in the inspector. This script is in the TMPro object that is a child of **Nametag**.
    ![Image of the Nametag's text location in the manatee prefab hierarchy](/Documentation%20Resources/Manatee%20Hierarchy.jpg)

- The transitions between manatee animations should be edited for more natural transitions. In the [full gameplay video](https://youtu.be/SXgbvRPEm6U?t=120), you can see the manatee animate strangely when being pet, which is supposed to trigger the rolling animation.
