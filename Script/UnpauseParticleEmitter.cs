/*
UnpauseParticleEmitter.cs
By: @onevcat, 2013-01-10
Cancel the pause of particle after setting Time.timeScale = 0.0f;
For Legacy Particle

Just drag & drop this script to the GameObject which has a ParticleEmitter.
And you can get it continuing under Time.timeScale = 0
*/

using UnityEngine;
using System.Collections;

[RequireComponent (typeof (ParticleEmitter))]
public class UnpauseParticleEmitter : MonoBehaviour 
{
	private float _timeAtLastFrame;
	private ParticleEmitter _emitter;
	private float _deltaTime;

	public void Awake() {
		_timeAtLastFrame = Time.realtimeSinceStartup;
		_emitter = gameObject.particleEmitter;
	}

	public void Update() {
		_deltaTime = Time.realtimeSinceStartup - _timeAtLastFrame;
		_timeAtLastFrame = Time.realtimeSinceStartup;
		if (Time.timeScale == 0 ){
			_emitter.Simulate(_deltaTime);
			_emitter.emit = true;
		}
	}
}