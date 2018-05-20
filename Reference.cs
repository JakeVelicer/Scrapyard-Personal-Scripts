using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reference : MonoBehaviour {

	public string Address;
	public bool p1;
	public bool p2;
	public bool p3;
	public bool p4;
	public bool tv;

	void Awake () {

		//if (GameObject.Find("GlobalReference") == null) {
			
			DontDestroyOnLoad(transform.gameObject);
		//}
	}

	void Update () {

		Scene scene = SceneManager.GetActiveScene();

		if (scene.name == "MainMenuP1" || scene.name == "MainMenuP2" || scene.name == "MainMenuP3" || scene.name == "MainMenuP4" || scene.name == "MainMenuTV") {

			MainMenu PlayerNum = GameObject.Find("SceneManger").GetComponent<MainMenu>();

			p1 = PlayerNum.p1;
			p2 = PlayerNum.p2;
			p3 = PlayerNum.p3;
			p4 = PlayerNum.p4;
			tv = PlayerNum.tv;

		}
	}
}