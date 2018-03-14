using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Q001Objective03 : MonoBehaviour {

	public float TheDistance;
	public GameObject FakeSword;
	public GameObject RealSword;
	public GameObject ActionText;
	public GameObject ActionDisplay;
	public GameObject TheObjective;
	public int CloseObjective;
	public GameObject ChestBlock;
	public GameObject Xmark;
	public GameObject QuestComplete;

	void OnMouseOver() {
		if(TheDistance <= 4) {
			ActionText.GetComponent<Text>().text = "Take";
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

				FakeSword.SetActive (false);
				RealSword.SetActive (true);
				ChestBlock.SetActive (true);
				CloseObjective = 3;

				// question mark returns
				Xmark.SetActive(true);
				// activate new trigger for completing the quest
				QuestComplete.SetActive (true);

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
