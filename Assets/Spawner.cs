using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	private bool spawnRdy = true;
	public GameObject[] burger;
	public GameObject spawnPoint;
	public float speed = 0.5f;
	private int randomRange;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(spawnRdy){
			randomRange = Random.Range(0, burger.Length-1);
			spawnRdy = false;
			GameObject tmpBurg = GameObject.Instantiate(burger[randomRange], spawnPoint.transform.position, Quaternion.identity) as GameObject;
			tmpBurg.rigidbody2D.AddForce(new Vector2(-0.7f,Random.Range(0.2f,-0.7f))*700);
			//int randomRange = Random.Range(0, 360);
			//tmpBurg.transform.rotation.z = randomRange;
			StartCoroutine("ReadySpawn");
		}
		else
			return;

	}
	IEnumerator ReadySpawn(){
		if(speed >= 0.05)
			speed -= (0.5f / 120);
		yield return new WaitForSeconds (speed);
		spawnRdy = true;
	}
}
