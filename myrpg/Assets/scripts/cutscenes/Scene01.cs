using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene01 : MonoBehaviour {

	public GameObject Camera1;
	public GameObject Camera2;
	public GameObject FadeOut;
	public GameObject FadeIn;
	public GameObject ThePlayer;

	// Use this for initialization
	void Start () {
		StartCoroutine (CutSceneStart ());
	}
	
	IEnumerator CutSceneStart() {
		yield return new WaitForSeconds (10);

		Camera2.SetActive (true);
		Camera1.SetActive (false);

		FadeIn.SetActive (false);
		yield return new WaitForSeconds (10);

		FadeOut.SetActive (true);
		yield return new WaitForSeconds (1);

		ThePlayer.SetActive (true);
		FadeIn.SetActive (true);
		FadeOut.SetActive (false);
		Camera2.SetActive (false);

		yield return new WaitForSeconds (1);
		FadeIn.SetActive (false);
		FadeOut.SetActive (false);
	}
}
