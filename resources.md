# Resources used in development
> *Links to other documents*

> [Documentation](/documentation.md)

>[README]()


This file contains a list of helpful links and resources I used when developing this project. Before starting development, I had a basic understanding of C# with Unity and Oculus Quest and a background in Java and Python.

## Table of Contents
- [C#](#c-sharp)
- [Oculus Quest 2 Things](#oculus-quest-2-things)
- [Errors](#errors)
- [UI and Canvases](#ui-and-canvases)
- [Particles](#particles)
- [Post-Processing](#post-processing-camera-effects)
- [Audio](#audio)
- [Collision and Physics](#collisions-and-physics)
- [Coroutines](#coroutines-and-other-ways-to-delayprolong-methods)
- [Custom Editors](#editor-shenanigans)


## C Sharp
- [Enum classes](https://www.w3schools.com/cs/cs_enums.php)
- [Getting the number of items / the items themselves from an enum](https://stackoverflow.com/questions/856154/total-number-of-items-defined-in-an-enum)
- [Switch statements for checking a variable's value more efficiently than a bunch of if-else statements](https://www.w3schools.com/cs/cs_switch.php)
- [Calling methods from a super (base) class](https://stackoverflow.com/questions/6090614/calling-a-base-class-method)

## Oculus Quest 2 Things
- [Input Mapping](https://developer.oculus.com/documentation/unity/unity-ovrinput/)
  > This link has some useful diagrams that are edited to be in the project!
  

## Errors
- Visual Studio doesn't rexognize Unity code (`MonoBehavior` has red squiggles underneath)
  > In the editor, go to Edit > Preferences > External Tools > Regenerate project files

## UI and Canvases
- [How to optimally separate canvases](https://unity.com/how-to/unity-ui-optimization-tips)
- [Using Masks to make custom UI shapes](https://docs.unity3d.com/Packages/com.unity.ugui@1.0/manual/script-Mask.html)
  > In one version of the project, we considered making the breath meter in the shape of a manatee. a proof of concept worked, but did not make it to the final version.

## Particles
- [Particle Unity Docs](https://docs.unity3d.com/ScriptReference/ParticleSystem.html)
  > Particles are weird!

  > You can access a particle system’s modules with dot notation.

  > These modules only have `get`, no `set`, and the modules are C# structs (which are normally passed by value, not reference).

  > Unity is weird though, so you can modify the modules through this.

  > Store the module in a variable

  > `var emissionMod = particles.emission;`

  > then edit the variable

  > `emissionMod.rateOverTime = 2;`

## Post Processing (camera effects)
- [Scripting post processing effects](https://docs.unity3d.com/Packages/com.unity.postprocessing@3.0/manual/Manipulating-the-Stack.html)

## Audio
- [Making audio 3D](https://www.youtube.com/watch?v=hHaD4XbNNug)

## Collisions and Physics
![Unity's collision interaction matrix, describing what combinations of triggers and colliders cuase different events](/Documentation%20Resources/Interaction%20Matrix.png)

- [Different ways to manipulate rigidbody movement](https://forum.unity.com/threads/addforce-vs-addrelativeforce-vs-rigidbody-velocity.32808/)
- [Using Quaternion magic to rotate a vector easily](https://gamedevbeginner.com/how-to-rotate-in-unity-complete-beginners-guide/#rotate_vector)

## Coroutines and other ways to delay/prolong methods


- [Calling methods on a timer with `Invoke` vs Coroutines](https://www.codinblack.com/how-to-run-a-method-at-certain-time-intervals-in-unity/)
  > Coroutines have better performance
- [All about coroutines in Unity Docs](https://docs.unity3d.com/2019.4/Documentation/Manual/Coroutines.html)
  > Any method in the scripts that returns an `IEnumerator` is most likely a coroutine! (example: `private IEnumerator SetRotationAfterDelay(float delay)` in `ChangeCameraRotation.cs`)

  > Coroutine methods have a `yield return` statement, which will pause the method for a bit.

  > `yield return null` will pause the method until the next frame.

  > `yield return new WaitForSecond(float seconds)` will pause the method until the amount of time specified has passed.

## Editor Shenanigans
- [Making custom editor inspector panels](https://learn.unity.com/tutorial/editor-scripting#5c7f8528edbc2a002053b5f7)