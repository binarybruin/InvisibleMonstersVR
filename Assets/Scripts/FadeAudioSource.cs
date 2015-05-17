using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class FadeAudioSource : MonoBehaviour {

	public enum FadeState
	{
		None,
		FadingOut,
		FadingIn
	}

	private AudioSource curr_audio_source;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
