using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Q001Objective02 : MonoBehaviour {

	public float TheDistance;
	public GameObject TreasureChest;
	public GameObject ActionDisplay;
	public GameObject ActionText;
	public GameObject TheObjective;
	public int CloseObjective;
	public GameObject TakeSword;

	void OnMouseOver() {
		if(TheDistance <= 4) {
			ActionText.GetComponent<Text>().text = "Open Chest";
			ActionText.SetActive(true);
			ActionDisplay.SetActive(true);
		}

		if(TheDistance > 4) {
			ActionText.SetActive(false);
			ActionDisplay.SetActive(false);
		}

		if (Input.GetButtonDown ("Action")) {
			if (TheDistance <= 4) {
				this.GetComponent<BoxCollider> ().enabled = false; // deactivate box collider

				TreasureChest.GetComponent<Animator> ().Play ("q01openchest");
				TakeSword.SetActive (true);
				CloseObjective = 3;
				// turn away action UI
				ActionText.SetActive (false);
				ActionDisplay.SetActive (false);
			}
		}
	}

	// Update is called once per frame
	void Update () {
		TheDistance = PlayerCasting.DistanceFromTarget; // calling PlayerCasting script

		if (CloseObjective == 3) {
			if (TheObjective.transform.localScale.y <= 0.0f) {
				CloseObjective = 0;
				TheObjective.SetActive (false);
			} else {
				TheObjective.transform.localScale -= new Vector3 (0.0f, 0.01f, 0.0f);
			}
		}
	}

	void OnMouseExit () {
		ActionDisplay.SetActive (false);
		ActionText.SetActive (false);
	}
}
