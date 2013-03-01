/*
UnpauseParticleSystem.cs
By: @onevcat, 2013-01-10
Cancel the pause of particle after setting Time.timeScale = 0.0f;
For Shuriken Particle

Just drag & drop this script to the GameObject which has a ParticleSystem.
And you can get it continuing under Time.timeScale = 0
*/

using UnityEngine;
using System.Collections;

[RequireComponent (typeof (ParticleSystem))]
public class UnpauseParticleSystem : MonoBehaviour 
{
	private float _timeAtLastFrame;
	private ParticleSystem _particleSystem;
	private float _deltaTime;
	
	public void Awake() {
		_timeAtLastFrame = Time.realtimeSinceStartup;
		_particleSystem = gameObject.GetComponent<ParticleSystem>();
	}

	public void Update() {
		_deltaTime = Time.realtimeSinceStartup - _timeAtLastFrame;
		_timeAtLastFrame = Time.realtimeSinceStartup;
		if (Time.timeScale == 0 ) {
			_particleSystem.Simulate(_deltaTime,false,false);
			_particleSystem.Play();
		}
	}

}