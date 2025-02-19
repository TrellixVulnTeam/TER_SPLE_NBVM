﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeVisibilityCanvas : MonoBehaviour {

	private Canvas CanvasWin;
	private Canvas CanvasLoose;
	private Canvas CanvasPause;

	void Start() {
		CanvasWin = GameObject.Find("CanvasWin").GetComponent<Canvas>();
		CanvasLoose = GameObject.Find("CanvasLoose").GetComponent<Canvas>();
		CanvasPause = GameObject.Find("CanvasPause").GetComponent<Canvas>();
		CanvasWin.enabled = false;
		CanvasLoose.enabled = false;
		CanvasPause.enabled = false;
		Time.timeScale = 1;
	}

	public void OnRejouer() {
		SceneManager.LoadScene("main_scene");
	}

	public void OnQuitter(){
		SceneManager.LoadScene("menu");
	}

	public void OnReprendre(){
		CanvasPause.enabled = false;
		Time.timeScale = 1;
	}
		
}
