using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParadeSword : MonoBehaviour {

	public GameObject TheSword;
	// 0 ' ready
	// 1 ' commencing the parade
	// 2 ' playing anymation
	// 3 ' block working
	public int SwordStatus;
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Block") && SwordStatus == 0 && AttackBlocker.BlockSword == 0) {
			StartCoroutine (ParadeSwordFunction ());
		}
	}

	
	IEnumerator ParadeSwordFunction () {
		SwordStatus = 1;
		TheSword.GetComponent<Animation> ().Play ("elvenparade");
		SwordStatus = 2;
		yield return new WaitForSeconds (0.2f);
		// now parrying works
		SwordStatus = 3;
		// now it doesn't
		yield return new WaitForSeconds (1.5f);
		SwordStatus = 2;
		yield return new WaitForSeconds (0.3017f);
		SwordStatus = 0;
	}

}
