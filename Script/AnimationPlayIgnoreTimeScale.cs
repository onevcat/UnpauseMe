using UnityEngine;
using System.Collections;
using System;

public static class AnimationPlayIgnoreTimeScale {

	public static IEnumerator Play( this Animation animation, string clipName, bool ignoreTimeScale, Action onComplete )
 	{
 		//We don't want to use timeScale, so we have to animate by frame..
 		if(ignoreTimeScale)
 		{
 			AnimationState _currState = animation[clipName];
     		bool isPlaying = true;

     		float _progressTime = 0F;
     		float _timeAtLastFrame = 0F;
     		float _timeAtCurrentFrame = 0F;
            bool _inReversePlaying = false;

     		float _deltaTime = 0F;
			animation.Play(clipName);
			_timeAtLastFrame = Time.realtimeSinceStartup;

         	while (isPlaying) {
             	_timeAtCurrentFrame = Time.realtimeSinceStartup;
             	_deltaTime = _timeAtCurrentFrame - _timeAtLastFrame;
             	_timeAtLastFrame = _timeAtCurrentFrame; 

                _progressTime += _deltaTime;
                
                _currState.normalizedTime = _inReversePlaying ? 1.0f - (_progressTime / _currState.length) 
                                                              : _progressTime / _currState.length; 
                animation.Sample();

                if (_progressTime >= _currState.length) {
                    switch (_currState.wrapMode) {
                        case WrapMode.Loop:
                            //Loop anim, continue.
                            _progressTime = 0.0f;
                            break;
                        case WrapMode.PingPong:
                            //PingPong anim, reversing continue.
                            _progressTime = 0.0f;
                            _inReversePlaying = !_inReversePlaying;
                            break;
                        case WrapMode.ClampForever:
                            //ClampForever anim, keep the last frame.
                            break;
                        case WrapMode.Default:
                            //We don't know how to handle it.
                            //In most time, this means it's a Once anim.
                            //Animation should be played with wrap mode specified.
                            Debug.LogWarning("A Default Anim Finished. Animation should be played with wrap mode specified.");
                            isPlaying = false;
                            break;
                        default:
                            //Once anim, kill it.
                            isPlaying = false;
                            break;
                    }
                }
             	yield return new WaitForEndOfFrame();
         	}
         	yield return null;
 			
 			if(onComplete != null) {
 				onComplete();
 			} 
 		} else {
            if (onComplete != null) {
                Debug.LogWarning("onComplete will not be called when you set \"ignoreTimeScale\" to true. Use Unity's animation handler instead!)");
                animation.Play(clipName);
            }
 		}
 	}
}
