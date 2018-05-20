using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReadyUI : MonoBehaviour {
	public  GameObject ReadyImage;
	public Button Ready;
	// Use this for initialization
	void Start () {
		Ready.onClick.AddListener (ReadyUp);
	}
	
	// Update is called once per frame
	void Update () {

	}

	void ReadyUp(){
		ReadyImage.SetActive (true);
	}
}
