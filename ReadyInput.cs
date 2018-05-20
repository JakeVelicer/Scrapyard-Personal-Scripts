using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ReadyInput : MonoBehaviour {

	PlayersReady manager;
	private string ReadyTrue = "1";
	private string ReadyFalse = "0";
	private bool WaitToCheck = false;
	
	Reference ipScript;
	static string IPAddress;

	string phpAddress1;
	string phpAddress2;
	string phpAddress3;
	string phpAddress4;

	private void Awake () {
		
		ipScript = GameObject.Find("GlobalReference").GetComponent<Reference>();
    	IPAddress = ipScript.Address;

		phpAddress1 = "http://" + IPAddress + "/characterstorage/InsertReadyPlayer1.php";
		phpAddress2 = "http://" + IPAddress + "/characterstorage/InsertReadyPlayer2.php";
		phpAddress3 = "http://" + IPAddress + "/characterstorage/InsertReadyPlayer3.php";
		phpAddress4 = "http://" + IPAddress + "/characterstorage/InsertReadyPlayer4.php";

	}

	void Start () {

		StartCoroutine ("WaitForPlayers");

	}

	void Update () {

		if (WaitToCheck == true) {
			AssignData();
		}
		
	}

	public void AssignData () {

		Scene scene = SceneManager.GetActiveScene();

		if (scene.name != "MainMenuP1" && scene.name != "MainMenuP2" && scene.name != "MainMenuP3"
		&& scene.name != "MainMenuP4" && scene.name != "MainMenuTV")
		{
			manager = GameObject.Find ("PlayerManager").GetComponent<PlayersReady>();
		}

		if (scene.name == "PlaceUnitsP1" || scene.name == "WaitingP1") {
			if (manager.p1Ready == true) {
				UpdatePlayerOne(ReadyTrue);
			}
			else if (manager.p1Ready == false) {
				UpdatePlayerOne(ReadyFalse);
			}
		}
		
		if (scene.name == "PlaceUnitsP2" || scene.name == "WaitingP2") {
			if (manager.p2Ready == true) {
				UpdatePlayerTwo(ReadyTrue);
			}
			else if (manager.p2Ready == false) {
				UpdatePlayerTwo(ReadyFalse);
			}
		}
		
		if (scene.name == "PlaceUnitsP3" || scene.name == "WaitingP3") {

			if (manager.p3Ready == true) {
				UpdatePlayerThree(ReadyTrue);
			}
			else if (manager.p3Ready == false) {
				UpdatePlayerThree(ReadyFalse);
			}
		}

		if (scene.name == "PlaceUnitsP4" || scene.name == "WaitingP4") {

			if (manager.p4Ready == true) {
				UpdatePlayerFour(ReadyTrue);
			}
			else if (manager.p4Ready == false) {
				UpdatePlayerFour(ReadyFalse);
			}
		}
	}

	public void UpdatePlayerOne(string ReadyOrNot) {
		WWWForm form = new WWWForm();
		form.AddField("ReadyPlayerOneBool", ReadyOrNot);
		WWW ServerConnection = new WWW(phpAddress1, form);
	}

	public void UpdatePlayerTwo(string ReadyOrNot) {
		WWWForm form = new WWWForm();
		form.AddField("ReadyPlayerTwoBool", ReadyOrNot);
		WWW ServerConnection = new WWW(phpAddress2, form);
	}

	public void UpdatePlayerThree(string ReadyOrNot) {
		WWWForm form = new WWWForm();
		form.AddField("ReadyPlayerThreeBool", ReadyOrNot);
		WWW ServerConnection = new WWW(phpAddress3, form);
	}

	public void UpdatePlayerFour(string ReadyOrNot) {
		WWWForm form = new WWWForm();
		form.AddField("ReadyPlayerFourBool", ReadyOrNot);
		WWW ServerConnection = new WWW(phpAddress4, form);
	}

	IEnumerator WaitForPlayers(){
		yield return new WaitForSeconds (2);
		WaitToCheck = true;
	}
}
