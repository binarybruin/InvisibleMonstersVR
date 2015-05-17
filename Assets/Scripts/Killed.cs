using UnityEngine;
using System.Collections;

public class Killed : MonoBehaviour {

	public void KillObject() {

		StartCoroutine(KillObjCoroutine());

	}

	public IEnumerator KillObjCoroutine() {

		// move Fabric audio component to monster's location
		/*Component audio_comp = FindObjectOfType<Fabric.AudioComponent> ();
		audio_comp.gameObject.transform.position = gameObject.transform.position;*/

		FindObjectOfType<Fabric.EventManager> ().gameObject.transform.position = FindObjectOfType<Walk> ().gameObject.transform.position;

		// trigger event for dying SFX
		Fabric.EventManager.Instance.PostEvent ("KillMonster");

		yield return new WaitForSeconds (1);
		
		Destroy (gameObject);
	
	}
}
