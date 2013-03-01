# Don't Pause Me

---

Use for make Unity3D animations and particles not pause when you set the Time.timeScale to 0. It's useful when you want to play some pause menu animation or make some good effect while the game is paused by setting Time.timeScale 0.

---

How to use:

1. Download and add every thing to your project

2. For Unity3D animation:
Start a coroutine with below method to play the animation to ignore timeScale:
`Play(string clipName, bool ignoreTimeScale,Action onComplete)`
For example, you want to play an unpause-animation name "anim1" in gameObject, do this 		
`StartCoroutine( gameObject.animation.Play("anim1",true,() => Debug.Log("onComplete")));`
You will get a chance to notified by a completion Action when the animation finished.

3. For Particles
For Legacy particles, add UnpauseParticleEmitter.cs as a component to the gameObject in which a Particle Emitter attached.
And for Shuriken particles, add UnpauseParticleSystem.cs as a component to the gameObject in which a Particle System attached.
Done.

*Tips:
If you use iTween for some animation, you can use the ignoretimescale parameter to ignore timeScale. See more in iTween's docs.(http://itween.pixelplacement.com/)

----------------

You can also find a simple demo in the /DemoScene/UnpauseMe.unity

Enjoy!
----------------
Version 1.0

@onevcat, http://onevcat.com