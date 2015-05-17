using UnityEngine;
using System.Collections;

public class Chaser : MonoBehaviour {

	public float speed = 0.8f;
	public Transform target;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 moveDir = target.position - transform.position;

		transform.position += moveDir.normalized * speed * Time.deltaTime;
	
	}

	void OnCollisionEnter(Collision collision) {

		// visual feedback when collide with player
		StartCoroutine(CollideCoroutine(collision));

	}

	
	public IEnumerator CollideCoroutine(Collision collision) {

		// change flashlight color to red
		Component flashlight = collision.gameObject.transform.Find ("Flashlight");
		Color orig_color = flashlight.GetComponent<Light> ().color;
		
		flashlight.GetComponent<Light> ().color = Color.red;
		
		yield return new WaitForSeconds (1);
		
		flashlight.GetComponent<Light> ().color = orig_color;

	}
	
}
