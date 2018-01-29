# Jimmy Jam, The Shitty Wizard
A shitty game about a shitty wizard doing a shitty job. Game was made in Global Game Jam, Bengaluru, 2018.

![Jimmy Jam, The Shitty Wizard](https://i.imgur.com/TNxP6A1.png)

The basic premise of the game was that, Jimmy Jam, the Shitty Magician, was bound to
a very shitty job of helping ferrying lost souls from a lost realm. The souls in this
realm find their way back by visiting three lamps; the lamps of Fear, Guilt and
Redemption. Big words for a really shitty game, huh? Anyway, Jimmy's job is to protect
these lamps when a soul is hosted inside them, from other lost souls, who happen
to turn into little, floaty T-rex things. Once a soul is successfully hosted by
the Lamp of Redemption, it has been successfully salvaged from this realm and can
be sent on to the world of the dead.



# Repository Information

The repo is very stripped due to the actual folder being well over 2GB by the
time the game jam ended, mostly because I was pulling in assets from the Unity
Asset Store like crazy to test stuff out.

So if you plan to run this, which I HIGHLY don't suggest you do, it's a good idea
to have all the Standard Assets. We use the rain particle system from it, and
since I can't remember if it was inside the Standard Assets package, I suggest downloading
[Unity's Particle Pack](https://www.assetstore.unity3d.com/en/#!/content/73777) as well.

Other important thing is to download Mirza Beig's [Inferno VFX](https://assetstore.unity.com/packages/vfx/particles/fire-explosions/inferno-vfx-50735)
and using the material called **mat_vfx-inf_particle_sprite_glowSphere3-alpha-[3.0].mat**
and then apply it to the *Ambient* particle system in the scene, under the **Renderer**
section's material slot.

The other imported packages from the Asset Store were:
* Background Music - Nature's Cry (from the asset store) https://assetstore.unity.com/packages/audio/ambient/nature/nature-s-cry-...

* Terrain Texture - Yughues Sand Materials (from the asset store) https://assetstore.unity.com/packages/2d/textures-materials/floors/yughu...

* Milky Way Skybox - Adam Bilecki (from the asset store) https://assetstore.unity.com/packages/2d/textures-materials/milky-way-sk...


Some other packages you'll need from the Asset Store are **Text Mesh Pro** for the
text stuff and Unity's **Post Processing Stack**.



Here's the list of sound effects we've used:
* [Thunder and Rain](https://freesound.org/people/InspectorJ/sounds/360328/download/360328__inspectorj__thunder-very-close-rain-a.wav)
* [Spell Sound](https://freesound.org/people/Robinhood76/sounds/333787/download/333787__robinhood76__06250-dizzy-bolt-spell.wav)
* [Enemy Death](https://freesound.org/people/spookymodem/sounds/249813/download/249813__spookymodem__goblin-death.wav)
* [Player getting slammed](https://freesound.org/people/SexyNakedBunny/sounds/274717/download/274717__sexynakedbunny__ouch.mp3)
* [Lamp getting slammed](https://freesound.org/people/18hiltc/sounds/236793/download/236793__18hiltc__metal-table-hit3.wav)
* [Soul switching lamps](blob:http://beta.blendwave.net/aa2a9074-9ccf-4b30-af0a-b6281158749d)

Slot them into the appropriate clip slots in the AudioSource components.

That should be all, I'll update this README if I recall anything else after getting some sleep.
