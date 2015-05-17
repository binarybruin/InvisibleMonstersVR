using UnityEngine;
using System.Collections;

public class RandomPitch : MonoBehaviour {

	public AudioSource sfx;

	float rand_start;

	// Use this for initialization
	void Start () {

		rand_start = Random.Range (0.1f, 0.9f);

		sfx = GetComponent<AudioSource> ();
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		float rand_pitch = Mathf.PerlinNoise(rand_start, Time.time);

		sfx.pitch = rand_pitch;
	
	}
}
