using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quest001Complete : MonoBehaviour {

	public float TheDistance;
	public GameObject ActionDisplay; // ui action key
	public GameObject ActionText; 	// ui action name
	public GameObject UIQuest;
	public GameObject ThePlayer;
	public GameObject XMark;
	public GameObject CompleteTrigger;

	// Update is called once per frame
	void Update () {
		// referecing PlayerCasting script
		TheDistance = PlayerCasting.DistanceFromTarget;
	}

	// When mouse crosses over, display action options if close,
	// and let, by pressing some button, the player read the quest
	void OnMouseOver(){
		if (TheDistance <= 4) {
			// display action and key text
			ActionDisplay.SetActive (true);
			ActionText.SetActive (true);
			ActionText.GetComponent<Text> ().text = "Complete Quest";
		}

		// if Action button is pressed (Action button defined in Input settings
		if (Input.GetButtonDown ("Action")) {
			if (TheDistance <= 4) {
				XMark.SetActive (false);
				GlobalExp.CurrentExp += 100;
				//Cursor.lockState = CursorLockMode.None;
				//Cursor.visible = true;
				ActionDisplay.SetActive (false); //turn off action text
				ActionText.SetActive (false);
				CompleteTrigger.SetActive (false);
			}
		}

		if (TheDistance > 4) {
			// display action and key text
			ActionDisplay.SetActive (false);
			ActionText.SetActive (false);
		}
	}

	// when mouse exits, remove texts
	void OnMouseExit() {
		ActionDisplay.SetActive (false);
		ActionText.SetActive (false);
	}
}
