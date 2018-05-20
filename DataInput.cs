using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DataInput : MonoBehaviour {

	public string AttackersArrayInput1;
	public string DefendersArrayInput1;
	public string AttackersArrayInput2;
	public string DefendersArrayInput2;
	
	private string AttackersTemporaryStore1;
	private string DefendersTemporaryStore1;
	private string AttackersTemporaryStore2;
	private string DefendersTemporaryStore2;

	Reference ipScript;
	static string IPAddress;

	string phpAddress1;
	string phpAddress2;
	string phpAddress3;
	string phpAddress4;

	private void Awake () {

		ipScript = GameObject.Find("GlobalReference").GetComponent<Reference>();
    	IPAddress = ipScript.Address;

		phpAddress1 = "http://" + IPAddress + "/characterstorage/InsertData1.php";
		phpAddress2 = "http://" + IPAddress + "/characterstorage/InsertData2.php";
		phpAddress3 = "http://" + IPAddress + "/characterstorage/InsertData3.php";
		phpAddress4 = "http://" + IPAddress + "/characterstorage/InsertData4.php";
		
	}

	/*void Update () {

		if (CanUpdate == true) {
			AssignData();
		}

	} */
	
	public void AssignData () {

		Scene scene = SceneManager.GetActiveScene();

			if (scene.name == "PlaceUnitsP1") {
			CallingDefendersPostion1();
			UpdateArray2();
			}

			if (scene.name == "PlaceUnitsP2") {
			CallingDefendersPostion2();
			UpdateArray4();
			}

			if (scene.name == "PlaceUnitsP3") {
			CallingAttackersPosition1();
			UpdateArray1();
			}

			if (scene.name == "PlaceUnitsP4") {
			CallingAttackersPosition2();
			UpdateArray3();
			}

	}

	public void UpdateArray1() {
		WWWForm form = new WWWForm();
		form.AddField("arrayAttackersStringPost1", AttackersArrayInput1);
		WWW ServerConnection = new WWW(phpAddress1, form);
		StartCoroutine(WaitForRequest(ServerConnection));
	}

	public void UpdateArray2() {
		WWWForm form = new WWWForm();
		form.AddField("arrayDefendersStringPost1", DefendersArrayInput1);
		WWW ServerConnection = new WWW(phpAddress2, form);
		StartCoroutine(WaitForRequest(ServerConnection));
	}

	public void UpdateArray3() {
		WWWForm form = new WWWForm();
		form.AddField("arrayAttackersStringPost2", AttackersArrayInput2);
		WWW ServerConnection = new WWW(phpAddress3, form);
		StartCoroutine(WaitForRequest(ServerConnection));
	}

	public void UpdateArray4() {
		WWWForm form = new WWWForm();
		form.AddField("arrayDefendersStringPost2", DefendersArrayInput2);
		WWW ServerConnection = new WWW(phpAddress4, form);
		StartCoroutine(WaitForRequest(ServerConnection));
	}
 
	IEnumerator WaitForRequest(WWW www) {
		
    	yield return www;

    	// check for errors
    	if (www.error == null) {
        	Debug.Log("WWW Ok!: " + www.text);
        } else {
    	AssignData();
		}    
    }

	void CallingAttackersPosition1 () {

		for (int x = 0; x < 6; x++) {

			for (int y = 0; y < 18; y++) {

				if (GameObject.Find ("Board").GetComponent<BoardOrganization> ().attackers [x,y] == null) {

					AttackersArrayInput1 += "|null";
				}
				else {
					AttackersTemporaryStore1 = GameObject.Find ("Board").GetComponent<BoardOrganization> ().attackers
					[x,y].name;

					AttackersArrayInput1 += "|" + AttackersTemporaryStore1 + " ";
				}
			}
		}
	}

	void CallingDefendersPostion1 () {

		for (int x = 0; x < 6; x++) {

			for (int y = 0; y < 18; y++) {

				if (GameObject.Find ("Board").GetComponent<BoardOrganization> ().defenders [x,y] == null) {

					DefendersArrayInput1 += "|null";
				}
				else {
					DefendersTemporaryStore1 = GameObject.Find ("Board").GetComponent<BoardOrganization> ().defenders
					[x,y].name;

					DefendersArrayInput1 += "|" + DefendersTemporaryStore1 + " ";
				}
			}
		}
	}

	void CallingAttackersPosition2 () {

		for (int x = 0; x < 6; x++) {

			for (int y = 0; y < 18; y++) {

				if (GameObject.Find ("Board").GetComponent<BoardOrganization> ().attackers [x,y] == null) {

					AttackersArrayInput2 += "|null";
				}
				else {
					AttackersTemporaryStore2 = GameObject.Find ("Board").GetComponent<BoardOrganization> ().attackers
					[x,y].name;

					AttackersArrayInput2 += "|" + AttackersTemporaryStore2 + " ";
				}
			}
		}
	}
	
	void CallingDefendersPostion2 () {

		for (int x = 0; x < 6; x++) {

			for (int y = 0; y < 18; y++) {

				if (GameObject.Find ("Board").GetComponent<BoardOrganization> ().defenders [x,y] == null) {

					DefendersArrayInput2 += "|null";
				}
				else {
					DefendersTemporaryStore2 = GameObject.Find ("Board").GetComponent<BoardOrganization> ().defenders
					[x,y].name;

					DefendersArrayInput2 += "|" + DefendersTemporaryStore2 + " ";
				}
			}
		}
	}
}