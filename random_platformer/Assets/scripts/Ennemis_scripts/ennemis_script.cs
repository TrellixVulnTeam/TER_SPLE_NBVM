﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ennemis_script : MonoBehaviour {

	public float speed = 150f;
	public float maxSpeed = 1f;

	public bool isBumper;
	private int direction;

	private Rigidbody2D rb2d;
	private Animator anim;

	private Niveau niveau;

	void Start(){
		//Init Component
		rb2d = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		direction = -1;
		if (!isBumper) {
			rb2d.constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
		}
	}

	void Update () {
		//Setup animation
		anim.SetBool("isBumper",isBumper);
		
		if (niveau == null) {
			niveau =  GameObject.Find("Handler").GetComponent<GenerationNiveau> ().getNiveau();
		}



		transform.localScale = new Vector2 (-1*direction * Mathf.Abs (transform.localScale.x), transform.localScale.y);

	}

	void FixedUpdate(){
		if (isBumper && niveau != null) {
			chooseDir();
		}
		if (isBumper) {
			//Movement
			rb2d.AddForce ((Vector2.right * speed) * direction);

			//Max  Speed
			if (rb2d.velocity.x > maxSpeed) {
				rb2d.velocity = new Vector2(maxSpeed, rb2d.velocity.y);
			}
			if (rb2d.velocity.x < -maxSpeed) {
				rb2d.velocity = new Vector2(-maxSpeed, rb2d.velocity.y);
			}
		}
	}

	public void init(bool b,Niveau n){
		isBumper = b;
		niveau = n;
		direction = -1;
	}

	public int getDirection(){
		return direction;
	}

	public void invDir(){
		direction = direction * -1;
	}

	public void setBumper(bool b){
		isBumper = b;
	}

    public void chooseDir() {
		float tmp = transform.position.x;

		if (tmp < 0.3f && direction == -1) {
			invDir ();
		} else if (tmp > niveau.taille - 1 && direction == 1) {
			if (tmp - Mathf.Floor (tmp) > 0.8) {
				invDir ();
			}
		} else if (tmp < niveau.taille && tmp > 1  && niveau.hauteurBlocs [Mathf.FloorToInt (tmp)] != niveau.hauteurBlocs [Mathf.FloorToInt (tmp) + direction]) {
			if(direction == -1 && tmp - Mathf.Floor (tmp) < 0.3f){
				invDir ();
			}else if(direction == 1 && tmp - Mathf.Floor (tmp) > 0.8f){
				invDir ();
			}
		}
    }

    public void shoot() {
        GameObject spear = Resources.Load("spear") as GameObject;
        (Instantiate(spear,transform.position, spear.transform.rotation)).GetComponent<spear_script>().init(direction);
    }
}
