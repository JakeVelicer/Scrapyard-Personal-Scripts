using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardOrganization : MonoBehaviour {

	public GameObject[,] attackers = new GameObject[6,18];
	public GameObject[,] defenders = new GameObject[6,18];
    public GameObject[,] traps = new GameObject[6,18];

	/*
	void Update () {

	for (int x = 0; x < 6; x++) {

		for (int y = 0; y < 18; y++) {

				Debug.Log(x + ":" + y + ":" + attackers[x,y]);
			}
		}
		for (int x = 0; x < 6; x++) {

			for (int y = 0; y < 18; y++) {

				Debug.Log(x + ":" + y + ":" + defenders[x,y]);
			}
		}
	}
	*/
}