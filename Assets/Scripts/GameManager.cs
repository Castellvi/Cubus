using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	public static int currentScore;
	public static int highScore;

	public static int currentLevel = 1;
	public static int unlockedLevel;

	public GUISkin skin;
	public Rect timerRect;
	public Color warningColorTime;
	public Color defaultColorTime;

	public float startTime;
	private string currentTime;


	void Start() {
		DontDestroyOnLoad(gameObject);
	}

	void Update() {
//		if (startTime > 0) {
//			startTime -= Time.deltaTime;
//			currentTime = string.Format ("{0:0.0}", startTime);
//		} else {
//
//			Application.LoadLevel(0);
//		}
	}

	public static void CompleteLevel() {
		if (currentLevel < 5) {
			Application.LoadLevel(++currentLevel);
		} 
		else {
			currentLevel = 0;
			Application.LoadLevel(currentLevel);
		}
	}

	void OnGUI() {
//		GUI.skin = skin;
//
//		if (startTime < 5f) {
//			skin.GetStyle ("Timer").normal.textColor = warningColorTime;
//		} else {
//			skin.GetStyle("Timer").normal.textColor = defaultColorTime;
//		}
//
//		GUI.Label (timerRect, currentTime, skin.GetStyle("Timer"));
	}


}
