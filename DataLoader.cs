using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DataLoader : MonoBehaviour {

	private string Attackers1AsString;
	private string Defenders1AsString;
	private string Attackers2AsString;
	private string Defenders2AsString;
	
	private string AttackersString1;
	private string DefendersString1;
	private string AttackersString2;
	private string DefendersString2;
	private string RemoveString = "|";

	GameObject TransferObjectAttackers1;
	GameObject TransferObjectDefenders1;
	GameObject TransferObjectAttackers2;
	GameObject TransferObjectDefenders2;
	int ArrayLimit = 108;

	Reference ipScript;
	static string IPAddress;
	
	private string DataReturn1;
	private string DataReturn2;
	private string DataReturn3;
	private string DataReturn4;

	private void Awake () {

		ipScript = GameObject.Find("GlobalReference").GetComponent<Reference>();
    	IPAddress = ipScript.Address;

		DataReturn1 = "http://" + IPAddress + "/characterstorage/ReturnData1.php";
		DataReturn2 = "http://" + IPAddress + "/characterstorage/ReturnData2.php";
		DataReturn3 = "http://" + IPAddress + "/characterstorage/ReturnData3.php";
		DataReturn4 = "http://" + IPAddress + "/characterstorage/ReturnData4.php";

	}

	void Start () {

		StartCoroutine ("waitReturnAttackers1");
		StartCoroutine ("waitReturnDefenders1");
		StartCoroutine ("waitReturnAttackers2");
		StartCoroutine ("waitReturnDefenders2");

	}

	IEnumerator waitReturnAttackers1 () {
		yield return new WaitForSeconds(1);
		WWW ReturnData1 = new WWW(DataReturn1);
		yield return ReturnData1;
		Attackers1AsString = ReturnData1.text;
		if (string.IsNullOrEmpty(Attackers1AsString) || (Attackers1AsString.Equals("<br />"))) {
            SceneManager.LoadScene("PleaseWait");
		}
		yield return new WaitForSeconds(2);
		ReturnAttackers1();
	}
	IEnumerator waitReturnDefenders1 () {
		yield return new WaitForSeconds(1);
		WWW ReturnData2 = new WWW(DataReturn2);
		yield return ReturnData2;
		Defenders1AsString = ReturnData2.text;
		if (string.IsNullOrEmpty(Defenders1AsString) || (Defenders1AsString.Equals("<br />"))) {
            SceneManager.LoadScene("PleaseWait");
		}
		yield return new WaitForSeconds(2);
		ReturnDefenders1();
	}
	IEnumerator waitReturnAttackers2 () {
		yield return new WaitForSeconds(1);
		WWW ReturnData3 = new WWW(DataReturn3);
		yield return ReturnData3;
		Attackers2AsString = ReturnData3.text;
		if (string.IsNullOrEmpty(Attackers2AsString) || (Attackers2AsString.Equals("<br />"))) {
            SceneManager.LoadScene("PleaseWait");
		}
		yield return new WaitForSeconds(2);
		ReturnAttackers2();
	}
	IEnumerator waitReturnDefenders2 () {
		yield return new WaitForSeconds(1);
		WWW ReturnData4 = new WWW(DataReturn4);
		yield return ReturnData4;
		Defenders2AsString = ReturnData4.text;
		if (string.IsNullOrEmpty(Defenders2AsString) || (Defenders2AsString.Equals("<br />"))) {
            SceneManager.LoadScene("PleaseWait");
		}
		yield return new WaitForSeconds(2);
		ReturnDefenders2();
	}

    /* IEnumerator WaitForRequest(WWW www) {
        
		yield return www;

	    // check for errors
        if (www.error == null) {
            Debug.Log("WWW Ok!: " + www.text);
        } else {
    	StartCoroutine ("waitReturnAttackers1");
		StartCoroutine ("waitReturnDefenders1");
		StartCoroutine ("waitReturnAttackers2");
		StartCoroutine ("waitReturnDefenders2");
        }    
    } */

	void ReturnAttackers1 () {

		if (string.IsNullOrEmpty(Attackers1AsString) || (Attackers1AsString.Equals("<br />"))) {
            SceneManager.LoadScene("PleaseWait");
		}

		//Debug.Log(Attackers1AsString);

		AttackersString1 = Attackers1AsString;
		//AttackersString1 = AttackersString1.Substring(0,AttackersString1.IndexOf('+'));
		//AttackersString = AttackersString.Remove(AttackersString.LastIndexOf("|"));

		int index = AttackersString1.IndexOf(RemoveString);
		AttackersString1 = (index < 0)
    	? AttackersString1
    	: AttackersString1.Remove(index, RemoveString.Length);
		//(https://stackoverflow.com/questions/2201595/c-sharp-simplest-way-to-remove-first-occurrence-of-a-substring-from-another-st)

		var AttackerObjects = AttackersString1.Split('|');

		int i = 0;
		while (i < ArrayLimit) {

			for (int x = 0; x < 6; x++) {

				for (int y = 0; y < 18; y++) {

					string TransferObjectName = AttackerObjects[i];

					if (TransferObjectName.IndexOf('(') != -1) {
						TransferObjectName = TransferObjectName.Substring(0,TransferObjectName.IndexOf('('));
					}
					TransferObjectName = TransferObjectName.Replace(" ", string.Empty);

					if (!TransferObjectName.Equals("null")) {
						TransferObjectAttackers1 = Instantiate(Resources.Load(TransferObjectName)) as GameObject;
						TransferObjectAttackers1.transform.position = new Vector3(x, 0.6f, y);
					}

					//GameObject.Find ("Board").GetComponent<BoardOrganization> ().attackers [x,y] = TransferObjectAttackers1;
					i++;
					
				}
			}
		}
	}

	void ReturnDefenders1 () {

		if (string.IsNullOrEmpty(Defenders1AsString) || (Defenders1AsString.Equals("<br />"))) {
            SceneManager.LoadScene("PleaseWait");
		}

		//Debug.Log(Defenders1AsString);

		DefendersString1 = Defenders1AsString;
		//DefendersString1 = DefendersString1.Substring(DefendersString1.LastIndexOf('+') + 1);
		//DefendersString = DefendersString.Remove(DefendersString.LastIndexOf("|"));

		int index = DefendersString1.IndexOf(RemoveString);
		DefendersString1 = (index < 0)
    	? DefendersString1
    	: DefendersString1.Remove(index, RemoveString.Length);

		var DefenderObjects = DefendersString1.Split('|');

		int i = 0;
		while (i < ArrayLimit) {

			for (int x = 0; x < 6; x++) {

				for (int y = 0; y < 18; y++) {

					string TransferObjectName = DefenderObjects[i];
					
					if (TransferObjectName.IndexOf('(') != -1) {
						TransferObjectName = TransferObjectName.Substring(0,TransferObjectName.IndexOf('('));
					}
					TransferObjectName = TransferObjectName.Replace(" ", string.Empty);

					if (!TransferObjectName.Equals("null")) {
						TransferObjectDefenders1 = Instantiate(Resources.Load(TransferObjectName)) as GameObject;
						TransferObjectDefenders1.transform.position = new Vector3(x, 0.6f, y);
					}
					
					//GameObject.Find ("Board").GetComponent<BoardOrganization> ().defenders [x,y] = TransferObjectDefenders1;
					i++;

				}
			}
		}
	}

	void ReturnAttackers2 () {

		if (string.IsNullOrEmpty(Attackers2AsString) || (Attackers2AsString.Equals("<br />"))) {
            SceneManager.LoadScene("PleaseWait");
		}

		//Debug.Log(Attackers2AsString);

		AttackersString2 = Attackers2AsString;

		int index = AttackersString2.IndexOf(RemoveString);
		AttackersString2 = (index < 0)
    	? AttackersString2
    	: AttackersString2.Remove(index, RemoveString.Length);

		var AttackerObjects = AttackersString2.Split('|');

		int i = 0;
		while (i < ArrayLimit) {

			for (int x = 0; x < 6; x++) {

				for (int y = 0; y < 18; y++) {

					string TransferObjectName = AttackerObjects[i];

					if (TransferObjectName.IndexOf('(') != -1) {
						TransferObjectName = TransferObjectName.Substring(0,TransferObjectName.IndexOf('('));
					}
					TransferObjectName = TransferObjectName.Replace(" ", string.Empty);

					if (!TransferObjectName.Equals("null")) {
						TransferObjectAttackers2 = Instantiate(Resources.Load(TransferObjectName)) as GameObject;
						TransferObjectAttackers2.transform.position = new Vector3(x, 0.6f, y);
					}

					i++;
					
				}
			}
		}
	}

	void ReturnDefenders2 () {

		if (string.IsNullOrEmpty(Defenders2AsString) || (Defenders2AsString.Equals("<br />"))) {
            SceneManager.LoadScene("PleaseWait");
		}

		//Debug.Log(Defenders2AsString);

		DefendersString2 = Defenders2AsString;

		int index = DefendersString2.IndexOf(RemoveString);
		DefendersString2 = (index < 0)
    	? DefendersString2
    	: DefendersString2.Remove(index, RemoveString.Length);

		var DefenderObjects = DefendersString2.Split('|');

		int i = 0;
		while (i < ArrayLimit) {

			for (int x = 0; x < 6; x++) {

				for (int y = 0; y < 18; y++) {
					
					string TransferObjectName = DefenderObjects[i];
					
					if (TransferObjectName.IndexOf('(') != -1) {
						TransferObjectName = TransferObjectName.Substring(0,TransferObjectName.IndexOf('('));
					}
					TransferObjectName = TransferObjectName.Replace(" ", string.Empty);

					if (!TransferObjectName.Equals("null")) {
						TransferObjectDefenders2 = Instantiate(Resources.Load(TransferObjectName)) as GameObject;
						TransferObjectDefenders2.transform.position = new Vector3(x, 0.6f, y);
					}
					
					i++;
					
				}
			}
		}
	}
}