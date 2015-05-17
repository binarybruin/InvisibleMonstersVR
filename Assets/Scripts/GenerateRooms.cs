using UnityEngine;
using System.Collections;

public class GenerateRooms : MonoBehaviour {

	public Transform player;

	public GameObject rooms;

	// public float room_count = 1;

	public float room_length = 25.5f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 pos = player.transform.position;
		Vector3 roompos = rooms.transform.position;

		int computedRoomCount = FindObjectsOfType<GenerateRooms>().Length;

		// Debug.Log ("(" + pos.z + " >= " + computedRoomCount + " * " + room_length + ")");

		if (pos.z >= computedRoomCount * room_length) {

			// Debug.Log (pos.z);

			GameObject newRoom = Instantiate(rooms);
			newRoom.transform.position = new Vector3(roompos.x, roompos.y, pos.z + room_length);

			// newRoom.GetComponent<GenerateRooms>().room_count = room_count + 1;

			// room_count += 1;

		}
	
	}
}
