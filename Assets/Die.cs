﻿using UnityEngine;
using System.Collections;

public class Die : MonoBehaviour {

	public bool dead = false;

	public int burgers = 0;

	public AudioClip end;


	public AudioSource test;
	// Use this for initialization
	void Start () {
		test = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other) {
		print(other.gameObject.name);



		if(other.tag == "Burger"){
			Time.timeScale = 0.0f;
			dead = true;

			test.Play();
		}


	}

	void OnGUI () {
		if(dead){
			GUI.Box(new Rect(Screen.width/2-200,Screen.height/2-100,400,200), " You were caught in the Act\n\n Off Picking up burgers off the floor\n\n\n You got " + burgers);

			if (GUI.Button(new Rect(Screen.width/2-50, Screen.height/2+50, 100, 50), "Restart")){
				foreach(GameObject g in GameObject.FindGameObjectsWithTag("Burger"))
					Destroy(g);
				dead = false;
				Time.timeScale = 1.0f;
				GameObject.FindGameObjectWithTag("Spawner").GetComponent<Spawner>().speed = 0.5f;
				burgers = 0;
				test.Stop();
			}

			
		}
		
		GUI.Box(new Rect(Screen.width - 200,10,200,30), "Burgers Picked up : "+burgers);




	}
}

