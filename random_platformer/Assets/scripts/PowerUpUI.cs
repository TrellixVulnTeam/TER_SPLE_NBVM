﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpUI : MonoBehaviour {

	[SerializeField]
	private float fillAmount;

	[SerializeField]
	private Image content;

	public float MaxValue { get; set; }

	public float Value{
		set 
		{ 
			fillAmount = Map (value, 0, MaxValue, 0, 1);
		}
	}		

	// Update is called once per frame
	void Update () {
		HandleUI ();
	}


	public void HandleUI() {
		if (fillAmount != content.fillAmount) { // on update que s'il y a un changement
			content.fillAmount = fillAmount;
		}
	}

	private float Map(float value, float inMin, float inMax, float outMin, float outMax) {
		return ((value - inMin) * (outMax - outMin)) / ((inMax - inMin) + outMin); 
	}
}
