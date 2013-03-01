using UnityEngine;
using System.Collections;

public class HUD : MonoBehaviour {
	public GameObject Cube1;

	void OnGUI() {
		if (GUI.Button(new Rect(0,0,100,50),"Pause")) {
			Time.timeScale = 0.0f;
		}
		if (GUI.Button(new Rect(100,0,100,50),"Resume")) {
			Time.timeScale = 1.0f;
		}
	}
}
