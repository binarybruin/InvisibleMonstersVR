using UnityEngine;
using System.Collections;

public class Walk : MonoBehaviour {

	public float speed = 1;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		/*Vector3 pos = transform.position;

		if (pos.z > 16) {
			pos.z = 0;
			transform.position = pos;
		}*/

		transform.position += transform.forward * speed * Time.deltaTime;

		Vector3 euler = transform.eulerAngles;
		euler.x = 0f;
	
	}
}
