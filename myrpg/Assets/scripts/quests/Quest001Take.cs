using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest001Take : MonoBehaviour {

	public float TheDistance;
	public GameObject ActionDisplay; // ui action key
	public GameObject ActionText; 	// ui action name
	public GameObject UIQuest;
	public GameObject ThePlayer;
	public GameObject NoticeCam;

	void Start(){
		TheDistance = 0;
	}

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
			AttackBlocker.BlockSword = 1;
		}

		// if Action button is pressed (Action button defined in Input settings
		if (Input.GetButtonDown ("Action")) {
			if (TheDistance <= 4) {
				AttackBlocker.BlockSword = 2;
				Cursor.lockState = CursorLockMode.None;
				Cursor.visible = true;
				ActionDisplay.SetActive (false); //turn off action text
				ActionText.SetActive (false);
				UIQuest.SetActive (true); // on UI for displaying quest
				NoticeCam.SetActive(true); // turn on camera for quest
				ThePlayer.SetActive(false); // turn off player, AFTER the camera is set
				AttackBlocker.BlockSword = 0;
			}
		}

		if (TheDistance > 4) {
			// display action and key text
			ActionDisplay.SetActive (false);
			ActionText.SetActive (false);
			AttackBlocker.BlockSword = 0;
		}
	}

	// when mouse exits, remove texts
	void OnMouseExit() {
		ActionDisplay.SetActive (false);
		ActionText.SetActive (false);
		AttackBlocker.BlockSword = 0;
	}
}
