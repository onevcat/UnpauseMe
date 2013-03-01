using UnityEngine;

public class Mover : MonoBehaviour {
	public GameObject cube0;
	public GameObject cube1;
	public GameObject cube2;
	public GameObject cube3;
	
	void Start () {
		cube0.animation.Play("PositionAnime");
		cube1.animation.Play("PositionAnime1");
		
		//Use Play(string clipName, bool ignoreTimeScale,Action onComplete)
		//to start a Unity animation to ignore timeScale.
		StartCoroutine( cube2.animation.Play("SizeAnime",true,() => Debug.Log("onComplete")));

		//Tips: For iTweens animation, use ignoretimescale to ignore timeScale. See more in iTween's docs.
	}
}
