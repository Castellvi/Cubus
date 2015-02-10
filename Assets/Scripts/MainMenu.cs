using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {
	public GUISkin skin;

	void OnGUI() {

		GUI.skin = skin;
		GUI.Label (new Rect (100, 20, 400, 75), "Cubus Macus");
		if (GUI.Button(new Rect(150,110,100,50), "Play")) {
			Application.LoadLevel(1);
		}
		if (GUI.Button(new Rect(150,185,100,50), "Exit")) {
			//Application.Quit();
		}

	}
}
