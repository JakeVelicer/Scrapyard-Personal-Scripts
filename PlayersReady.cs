using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayersReady : MonoBehaviour {

	public Button Ready;
	public bool p1Ready;
	public bool p2Ready;
	public bool p3Ready;
	public bool p4Ready;

	public DataInput Assign;

	// Use this for initialization
	void Start () {

		Scene scene = SceneManager.GetActiveScene();

		p1Ready = false;
		p2Ready = false;
		p3Ready = false;
		p4Ready = false;

		if (scene.name == "PlaceUnitsP1" || scene.name == "PlaceUnitsP2" || scene.name == "PlaceUnitsP3" || scene.name == "PlaceUnitsP4")
		{
			Ready.onClick.AddListener (ReadyClicked);
		}

		if (scene.name == "WaitingP1")
		{
			p1Ready = true;
			StartCoroutine ("wait1");
		}

		if (scene.name == "WaitingP2")
		{
			p2Ready = true;
			StartCoroutine ("wait2");
		}

		if (scene.name == "WaitingP3")
		{
			p3Ready = true;
			StartCoroutine ("wait3");
		}

		if (scene.name == "WaitingP4")
		{
			p4Ready = true;
			StartCoroutine ("wait4");
		}
		if (scene.name == "WaitingAllPlayers1")
		{
			StartCoroutine ("waitTV1");
		}
		if (scene.name == "WaitingAllPlayers2")
		{
			StartCoroutine ("waitTV2");
		}

	}
	
	// Update is called once per frame
	void Update () {

		Scene scene = SceneManager.GetActiveScene();

		if (p1Ready == true && p2Ready == true && p3Ready == true && p4Ready == true) {
			if (scene.name == "PlaceUnitsP1" || scene.name == "PlaceUnitsP3") {
				SceneManager.LoadScene ("OrangeFiller");
			}
			if (scene.name == "PlaceUnitsP2" || scene.name == "PlaceUnitsP4") {
				SceneManager.LoadScene ("BlueFiller");
			}
			if (scene.name == "WaitingP1") {
				SceneManager.LoadScene ("PlaceUnitsP1");
			}
			if (scene.name == "WaitingP2") {
				SceneManager.LoadScene ("PlaceUnitsP2");
			}
			if (scene.name == "WaitingP3") {
				SceneManager.LoadScene ("PlaceUnitsP3");
			}
			if (scene.name == "WaitingP4") {
				SceneManager.LoadScene ("PlaceUnitsP4");
			}
			if (scene.name == "WaitingAllPlayers1") {
				SceneManager.LoadScene ("WaitingAllPlayers2");
			}
			if (scene.name == "WaitingAllPlayers2") {
				SceneManager.LoadScene ("PleaseWait");
			}
		}
	}

	void ReadyClicked () {

		Scene scene = SceneManager.GetActiveScene();

		if (scene.name == "PlaceUnitsP1")
		{
			Assign.AssignData();
			p1Ready = true;
			StartCoroutine ("wait1");
			Debug.Log ("p1 ready");
		}
		if (scene.name == "PlaceUnitsP2")
		{
			Assign.AssignData();
			p2Ready = true;
			StartCoroutine ("wait2");
			Debug.Log ("p2 ready");
		}
		if (scene.name == "PlaceUnitsP3")
		{
			Assign.AssignData();
			p3Ready = true;
			StartCoroutine ("wait3");
			Debug.Log ("p3 ready");
		}
		if (scene.name == "PlaceUnitsP4")
		{
			Assign.AssignData();
			p4Ready = true;
			StartCoroutine ("wait4");
			Debug.Log ("p4 ready");
		}

	}

	IEnumerator wait1(){
		yield return new WaitForSeconds (4);
		gameObject.GetComponent<ReadyInput>().enabled = false;
		gameObject.GetComponent<ReadyLoader>().enabled = true;
	}

	IEnumerator wait2(){
		yield return new WaitForSeconds (4);
		gameObject.GetComponent<ReadyInput>().enabled = false;
		gameObject.GetComponent<ReadyLoader>().enabled = true;
	}

	IEnumerator wait3(){
		yield return new WaitForSeconds (4);
		gameObject.GetComponent<ReadyInput>().enabled = false;
		gameObject.GetComponent<ReadyLoader>().enabled = true;
	}

	IEnumerator wait4(){
		yield return new WaitForSeconds (4);
		gameObject.GetComponent<ReadyInput>().enabled = false;
		gameObject.GetComponent<ReadyLoader>().enabled = true;
	}

	IEnumerator waitTV1(){
		yield return new WaitForSeconds (5);
		gameObject.GetComponent<ReadyLoader>().enabled = true;
	}
	IEnumerator waitTV2(){
		yield return new WaitForSeconds (5);
		gameObject.GetComponent<ReadyLoader>().enabled = true;
	}
}