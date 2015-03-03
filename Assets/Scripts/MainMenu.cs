using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {
	public GUISkin skin;

	void OnGUI() {

		GUI.skin = skin;
		GUI.Label (new Rect (100, 20, 400, 75), "Cubus Macus");
		if (PlayerPrefs.GetInt("Level") > 0) {
			if (GUI.Button(new Rect(150,110,100,50), "Continue")) {
				Application.LoadLevel(PlayerPrefs.GetInt("Level"));
			}	
		}
		if (GUI.Button(new Rect(150,170,100,50), "New Game")) {
			PlayerPrefs.SetInt("Level", 0);
			Application.LoadLevel(1);
		}
		if (GUI.Button(new Rect(150,230,100,50), "Exit")) {
			Application.Quit();
		}

	}
}
