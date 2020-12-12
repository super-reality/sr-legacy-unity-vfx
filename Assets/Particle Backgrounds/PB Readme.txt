----------------------------------------
PARTICLE BACKGROUNDS
----------------------------------------

1. Introduction
2. Scale & Screen ratios
3. Recoloring
4. Bloom & Post-Processing
5. Contact

----------------------------------------
1. INTRODUCTION
----------------------------------------

Particle Backgrounds includes 15 scenes of background effects made with Unity's built-in particle system.

Each scene is made up from 3 main elements:

A) 'Main Emitter' which is a Particle System with one or several sub-emitters. Each scene uses one Material which is named the same as the scene.

B) 'Main Camera' which is a Camera with Post-processing attached to it. Each scene has its own Post-processing profile saved.

D) The DemoCanvas which is a simple GUI of buttons that lets you browse through the different scenes once you've added them to Build Settings. This can simply be deleted from the scene.

---

There are a few ways to use this asset, but suggested use is to make a copy of the scene you wish to use, then import your Menu / GUI prefabs into the scene.

Alternatively make the Main Emitter a child of the Main Camera and save it as a prefab and import to your own menu scene.

----------------------------------------
2. SCALE & SCREEN RATIOS
----------------------------------------

While the demo scenes and particles are made to an exact fit of 16:9 and a FOV of 60, you can adjust the Shape of the 'MainEmitter' Particle System to have a bigger or smaller Radius for different screen ratios.

If you wish to make the particle smaller, you can change the Start Size of the 'SubEmitter'.

To adjust the space between the patterns, adjust the Emission values in the MainEmitter and SubEmitter.

----------------------------------------
3. RECOLORING
----------------------------------------

Color of the scenes are set in 3 main locations:

A) Background Color is set near the top of the Main Camera

B) The color of the Particle System is usually set in 'Start Color' near the top of the Particle System, or in the 'Color over Lifetime'

C) Post-processing uses a Color for the Vignette which is usually the shadow around the border of the screen. This can be accessed directly at the bottom of the 'Main Camera' settings, or in the Post-processing Profile in the Project.

----------------------------------------
4. BLOOM & POST PROCESSING
----------------------------------------

In order to view the glowy effects of the particles, make sure to setup the Post Processing. You may need to make a new 'PostProcessing' layer and set that for the Camera, as well as selecting the same layer in the Post-processing option.

For Standard pipeline projects, you will have to find the Post-process Layer on the Main Camera, then select Layer.

For URP projects, go to the Camera and match the Camera Layer with the Volume Mask under the Camera's 'Environment' settings.

----------------------------------------
5. CONTACT
----------------------------------------

Need help? See my support page here: archanor.com/support.html

Follow me and my work on Twitter (@archanor) for updates and new VFX assets.

Ratings & reviews are much appreciated!

----------------------------------------

Made by Kenneth Foldal Moe (Archanor VFX)

archanor.work@gmail.com
