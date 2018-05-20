using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public Button StartGame;
	public Button Tutorial;
	public Button Exit;

	public bool p1;
	public bool p2;
	public bool p3;
	public bool p4;
	public bool tv;

	public Toggle player1;
	public Toggle player2;
	public Toggle player3;
	public Toggle player4;
	public Toggle TV;
	
	public ReadyInput Assign;
	private string ReadyFalse = "0";


	// Use this for initialization
	void Start() {

		StartFalse();
		
		StartGame.onClick.AddListener (StartClicked);
		Tutorial.onClick.AddListener (TutorialClicked);
		Exit.onClick.AddListener (ExitClicked);

		Scene scene = SceneManager.GetActiveScene();

		if (scene.name == "MainMenuP1") {
			p1 = true;
		}
		else if (scene.name == "MainMenuP2") {
			p2 = true;
		}
		else if (scene.name == "MainMenuP3") {
			p3 = true;
		}
		else if (scene.name == "MainMenuP4") {
			p4 = true;
		}
		
	}

	void Update() {
		
		// if (player1.isOn) {
		// 	p1 = true;
		// }
		// else {
		// 	p1 = false;
		// }

		// if (player2.isOn) {
		// 	p2 = true;
		// }
		// else {
		// 	p2 = false;
		// }

		// if (player3.isOn) {
		// 	p3 = true;
		// }
		// else {
		// 	p3 = false;
		// }

		// if (player4.isOn) {
		// 	p4 = true;
		// }
		// else {
		// 	p4 = false;
		// }

		// if (TV.isOn) {
		// 	tv = true;
		// }
		// else {
		// 	tv = false;
		// }
	}

	void StartFalse() {

		Assign.UpdatePlayerOne(ReadyFalse);
		Assign.UpdatePlayerTwo(ReadyFalse);
		Assign.UpdatePlayerThree(ReadyFalse);
		Assign.UpdatePlayerFour(ReadyFalse);

	}

	void StartClicked() {

		if (p1 == true)
        {
            SceneManager.LoadScene("WaitingP1");
            Debug.Log("p1 ready");
        }
        if (p2 == true)
        {
            SceneManager.LoadScene("WaitingP2");
            Debug.Log("p2 ready");
        }
        if (p3 == true)
        {
            SceneManager.LoadScene("WaitingP3");
            Debug.Log("p3 ready");
        }
        if (p4 == true)
        {
            SceneManager.LoadScene("WaitingP4");
            Debug.Log("p4 ready");
        }
		if (tv == true)
		{
			SceneManager.LoadScene("WaitingAllPlayers1");
			Debug.Log("tv ready");
		}
    }

	void TutorialClicked(){
		SceneManager.LoadScene("HowToPlay");
	}

	void ExitClicked(){
		Debug.Log ("Player has quit");
		Application.Quit();
	}
}
