using UnityEngine;
using System.Collections;

public class click_test : MonoBehaviour {



	void Update (){

		//clicksLeft = totalClicks - counter;
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit2D hit = Physics2D.GetRayIntersection(ray,Mathf.Infinity);

		// lose if you deliver wrong burger


		if (Input.GetMouseButtonDown(0)){ // TODO ontriggerenter with burger on the floor

			if(hit.collider != null && hit.collider.tag == "Burger"){
				hit.transform.GetComponent<burger>().counter ++;
				//GameObject.FindGameObjectWithTag("Finish").GetComponent<Die>().burgers ++;
				//print("mouse clicks on burger "+counter);
			}
		}
	}




}
