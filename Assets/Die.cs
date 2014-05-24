using UnityEngine;
using System.Collections;

public class Die : MonoBehaviour {

	public bool dead = false;

	public int burgers = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other) {
		print(other.gameObject.name);



		if(other.tag == "Burger"){
			Time.timeScale = 0.0f;
			dead = true;
		}


	}

	void OnGUI () {
		if(dead){
			GUI.Box(new Rect(Screen.width/2-200,Screen.height/2-100,400,200), " You were caught in the Act\n\n Off Picking up burgers off the floor\n\n\n You got " + burgers);
		}

		GUI.Box(new Rect(10,10,200,30), "Burgers : "+burgers);




	}
}

