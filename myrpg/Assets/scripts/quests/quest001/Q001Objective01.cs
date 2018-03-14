using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Q001Objective01 : MonoBehaviour {

	public GameObject TheObjective;
	public int CloseObjective;


	void OnTriggerEnter() {
		StartCoroutine (FinishObjective ());
	}

	IEnumerator FinishObjective() {
		TheObjective.SetActive (true);
		yield return new WaitForSeconds (0.5f);
		CloseObjective = 1; // by default is 0
	}

	// Update is called once per frame
	void Update () {
		if (CloseObjective == 1) {
			if (TheObjective.transform.localScale.y <= 0.0f) {
				// trigger completed -> set inactive
				CloseObjective = 0;
				TheObjective.SetActive (false);
			} else {
				// shrink only on y axis
				TheObjective.transform.localScale -= new Vector3 (0.0f, 0.01f, 0.0f);
			}
		}
	}
}
