using UnityEngine;
using System.Collections;

public class burger : MonoBehaviour {

	public int amount = 1;

	public int counter = 0 ;

	// Use this for initialization
	void Awake () {
	

	}

	

	// Update is called once per frame
	void Update () {
	
		if(counter == amount){
			GameObject.FindGameObjectWithTag("Finish").GetComponent<Die>().burgers ++;
			Destroy(this.gameObject);
		}


	}
}
