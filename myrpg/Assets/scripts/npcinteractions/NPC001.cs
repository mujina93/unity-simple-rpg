using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC001 : MonoBehaviour {

	public float TheDistance;
	public GameObject ActionDisplay;
	public GameObject ActionText;
	public GameObject ThePlayer;
	public GameObject TextBox;
	public GameObject NPCName;
	public GameObject NPCText;
	
	// Update is called once per frame
	void Update () {
		TheDistance = PlayerCasting.DistanceFromTarget;
	}

	void OnMouseOver(){
		if (TheDistance <= 3) {
			AttackBlocker.BlockSword = 1;
			ActionText.GetComponent<Text> ().text = "Talk";
			ActionDisplay.SetActive (true);
			ActionText.SetActive (true);
		}

		if (Input.GetButtonDown ("Action")) {
			if (TheDistance <= 3) {
				AttackBlocker.BlockSword = 2;
				Screen.lockCursor = false;
				Cursor.visible = true;
				ActionDisplay.SetActive (false);
				ActionText.SetActive (false);
				StartCoroutine (NPC001Active ());
			}
		}

		if (TheDistance > 3) {
			AttackBlocker.BlockSword = 0;
			ActionDisplay.SetActive (false);
			ActionText.SetActive (false);
		}
	}

	void OnMouseExit() {
		AttackBlocker.BlockSword = 0;
		ActionDisplay.SetActive (false);
		ActionText.SetActive (false);
	}

	IEnumerator NPC001Active() {
		TextBox.SetActive (true);
		NPCName.GetComponent<Text> ().text = "Gorg";
		NPCName.SetActive (true);
		NPCText.GetComponent<Text> ().text = "Hello friend, I may have a quest for you if you wish to accept it." +
		"Please come back later on this afternoon.";
		NPCText.SetActive (true);
		yield return new WaitForSeconds (5.5f);
		NPCName.SetActive (false);
		NPCText.SetActive (false);
		TextBox.SetActive (false);
		ActionDisplay.SetActive (true);
		ActionText.SetActive (true);
	}
}
