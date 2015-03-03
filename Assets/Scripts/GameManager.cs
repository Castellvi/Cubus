using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	// Count
	public int currentScore;
	public int highScore;
	public int tokenCount;
	private int totalTokenCount;
	public int currentLevel = 1;
	public int unlockedLevel;

	// Timers
	public Rect timerRect;
	public Color warningColorTime;
	public Color defaultColorTime;
	public float startTime;
	private string currentTime;

	// Skin
	public GUISkin skin;

	// References
	public GameObject tokenParent;
	public int winScreenWidth, winScreenHeight;

	private bool showWinScreen = false;

	void Start() {
		totalTokenCount = tokenParent.transform.childCount;
		if (PlayerPrefs.GetInt ("Level") > 1) {
			currentLevel = PlayerPrefs.GetInt("Level");
		} else {
			currentLevel = 1;
		}

		//DontDestroyOnLoad(gameObject);
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

	public void AddToken() {
		tokenCount++;

	}

	public void CompleteLevel() {
		showWinScreen = true;
	}

	void LoadNextLevel() {
		if (currentLevel < 5) {
			SaveGame();
			Application.LoadLevel(currentLevel);
		} 
		else {
			currentLevel = 1;
			PlayerPrefs.SetInt("Level", ++currentLevel);
			Application.LoadLevel(0);
		}
	}

	void SaveGame() {
		PlayerPrefs.SetInt("Level", currentLevel);
	}

	void OnGUI() {
		GUI.skin = skin;
		 
		GUI.Label (new Rect(45,100,200,200), tokenCount.ToString() + "/" + totalTokenCount.ToString());

		if (showWinScreen) {
			Rect winScreenRect = new Rect(Screen.width/2 - (winScreenWidth/2), Screen.height/2 - (winScreenHeight/2), winScreenWidth, winScreenHeight);
			GUI.Box(winScreenRect, "Win!");

			GUI.Label(new Rect(winScreenRect.x + 20, winScreenRect.y + 40, 300, 50), tokenCount.ToString());

			if (GUI.Button(new Rect(winScreenRect.x + winScreenRect.width -170, winScreenRect.y + winScreenRect.height -70, 150, 50), "Continue")) {
				LoadNextLevel();
			}
			if (GUI.Button(new Rect(winScreenRect.x + 20, winScreenRect.y + winScreenRect.height -70, 150, 50), "Quit")) {
				Application.LoadLevel("Main Menu");
			}
		}

//		if (startTime < 5f) {
//			skin.GetStyle ("Timer").normal.textColor = warningColorTime;
//		} else {
//			skin.GetStyle("Timer").normal.textColor = defaultColorTime;
//		}
//
//		GUI.Label (timerRect, currentTime, skin.GetStyle("Timer"));
	}


}
