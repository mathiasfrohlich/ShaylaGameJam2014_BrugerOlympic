using UnityEngine;
using System.Collections;

public class click_test : MonoBehaviour {

	
	int counter = 0;
	int elements;
	int clickPerElement;
	int totalClicks; 
	bool lost = false;
	int score = 0;
	// make order number
	// TODO max clicks per burger, set clicks random maybe
	// reset counter if clicks exceed max -> you have rushed and dropped the burger again
	// reset counter or add time delay if space is pressed before max -> you have not 
	// assign points to multiple burgers
	// make order number visible on mouse hover 

	// make burger spawner connected to guest
	// make guests that order two burgers

	// add one to counter for each small burger that has been picked up and sold
	// add two to counter for medium burger 
	// add three to counter for large burger 
	// game over if you dont pick up the burger before the customer has reached the desk
	// sounds: 
		// shoutout to large burgers (do-do-do-double whopper) and double orders (mu-mu-mu-multi order)
		// swoop sound when burger hits floor
		// coin dropping when burger has been sold succesfully. 
		// another sound for being discovered




	// Use this for initialization
	void Start () {

		elements = 5;
		clickPerElement = 2;

		totalClicks = elements*clickPerElement;
	
	}

	void Update (){

		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit2D hit = Physics2D.GetRayIntersection(ray,Mathf.Infinity);

		if (counter == totalClicks){
			print ("burger ready to pick up");
		}
		else if (counter > totalClicks){
			print ("you've picked to much up - burger is dirty"); // TODO vælg enten 'fjern burger' og en ny bliver sendt afsted fra tray som skal samles op, eller 'send burger afsted' og der er chance for at kunde opdager det (jo flere ekstra click, jo højere er chancen)
			lost = true;
		}


		if (Input.GetKeyDown(KeyCode.Space)){

			if(counter == totalClicks){
				print ("burger is delivered");
				Destroy (this.gameObject);
			}
			else if (counter < totalClicks){
				counter = 0;
				print ("you cannot deliver an incomplete burger - start again");
			}

		}

		// lose if you deliver wrong burger


		if (Input.GetMouseButtonDown(0)){ // TODO ontriggerenter with burger on the floor

			if(hit.collider != null && hit.collider.tag == "Burger"){
			counter ++;
			print("mouse clicks on burger "+counter);
			}
		}
	}

	void OnGUI(){
		GUI.Box(new Rect(10,10,200,30), "score: "+score);
		GUI.Box(new Rect(10,45,200,30), "Clicks to collect burger: "+totalClicks);
		GUI.Box(new Rect(10,80,200,30), "Missing parts of burger: "+totalClicks-counter);

		if(lost){
			GUI.Box(new Rect(10,125,200,30), "you've picked to much up - burger is dirty");

		}


	}


}
