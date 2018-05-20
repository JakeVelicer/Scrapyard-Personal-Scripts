using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ReadyLoader : MonoBehaviour {

	PlayersReady manager;
	private string PlayerOneIsReady = "0";
	private string PlayerTwoIsReady = "0";
	private string PlayerThreeIsReady = "0";
	private string PlayerFourIsReady = "0";

	Reference ipScript;
	static string IPAddress;

	private string PlayerOnePhp;
	private string PlayerTwoPhp;
	private string PlayerThreePhp;
	private string PlayerFourPhp;

	private string ReadyTrue = "1";
	private string ReadyFalse = "0";
	public bool KeepChecking = true;

	string phpAddress1;
	string phpAddress2;
	string phpAddress3;
	string phpAddress4;

	private void Awake () {
		
		ipScript = GameObject.Find("GlobalReference").GetComponent<Reference>();
    	IPAddress = ipScript.Address;

		PlayerOnePhp = "http://" + IPAddress + "/characterstorage/ReturnReadyPlayer1.php";
		PlayerTwoPhp = "http://" + IPAddress + "/characterstorage/ReturnReadyPlayer2.php";
		PlayerThreePhp = "http://" + IPAddress + "/characterstorage/ReturnReadyPlayer3.php";
		PlayerFourPhp = "http://" + IPAddress + "/characterstorage/ReturnReadyPlayer4.php";

	}

	IEnumerator Start () {

		while (KeepChecking == true) {

			ReturnPlayer();
			
			WWW ReturnData1 = new WWW(PlayerOnePhp);
			yield return ReturnData1;
			PlayerOneIsReady = ReturnData1.text;

			WWW ReturnData2 = new WWW(PlayerTwoPhp);
			yield return ReturnData2;
			PlayerTwoIsReady = ReturnData2.text;

			WWW ReturnData3 = new WWW(PlayerThreePhp);
			yield return ReturnData3;
			PlayerThreeIsReady = ReturnData3.text;

			WWW ReturnData4 = new WWW(PlayerFourPhp);
			yield return ReturnData4;
			PlayerFourIsReady = ReturnData4.text;

		}
	}

	public void ReturnPlayer () {

		Scene scene = SceneManager.GetActiveScene();
		manager = GameObject.Find ("PlayerManager").GetComponent<PlayersReady>();

		if (scene.name != "PlaceUnitsP1" || scene.name != "WaitingP1") {

			if (PlayerOneIsReady.Equals(ReadyTrue)) {
				manager.p1Ready = true;
			}
			else if (PlayerOneIsReady.Equals(ReadyFalse)) {
				manager.p1Ready = false;
			}
		}
		
		if (scene.name != "PlaceUnitsP2" || scene.name != "WaitingP2") {

			if (PlayerTwoIsReady.Equals(ReadyTrue)) {
				manager.p2Ready = true;
			}
			else if (PlayerTwoIsReady.Equals(ReadyFalse)) {
				manager.p2Ready = false;
			}
		}
		
		if (scene.name != "PlaceUnitsP3" || scene.name != "WaitingP3") {

			if (PlayerThreeIsReady.Equals(ReadyTrue)) {
				manager.p3Ready = true;
			}
			else if (PlayerThreeIsReady.Equals(ReadyFalse)) {
				manager.p3Ready = false;
			}
		}
		
		if (scene.name != "PlaceUnitsP4" || scene.name != "WaitingP4") {
			if (PlayerFourIsReady.Equals(ReadyTrue)) {
				manager.p4Ready = true;
			}
			else if (PlayerFourIsReady.Equals(ReadyFalse)) {
				manager.p4Ready = false;
			}
		}
	}
}
