﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Front : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D trigger){
		if (trigger.gameObject.tag == "Player") {
			trigger.gameObject.GetComponent<Player> ().die (this.ToString());
		} else if (trigger.gameObject.tag == "Mur") {
			gameObject.GetComponentInParent<ennemis_script> ().invDir ();
		}
	}
}
