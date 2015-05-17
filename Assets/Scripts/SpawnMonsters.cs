using UnityEngine;
using System.Collections;

public class SpawnMonsters : MonoBehaviour {

	public Transform player;

	public GameObject monster;

	public AudioClip[] monsterSFX;

	// Use this for initialization
	void Start () {

		Component[] spawn_points = GetComponentsInChildren<SpawnPoint>();

		int num_monsters = FindObjectsOfType<Chaser>().Length;

		// load SFX
		monsterSFX = new AudioClip[9];
		monsterSFX [0] = (AudioClip)Resources.Load ("Sounds/tiger");
		monsterSFX [1] = (AudioClip)Resources.Load ("Sounds/lion");
		monsterSFX [2] = (AudioClip)Resources.Load ("Sounds/monster");
		monsterSFX [3] = (AudioClip)Resources.Load ("Sounds/ptero");
		monsterSFX [4] = (AudioClip)Resources.Load ("Sounds/strings");
		monsterSFX [5] = (AudioClip)Resources.Load ("Sounds/strings2");
		monsterSFX [6] = (AudioClip)Resources.Load ("Sounds/bird");
		monsterSFX [7] = (AudioClip)Resources.Load ("Sounds/bear");
		monsterSFX [8] = (AudioClip)Resources.Load ("Sounds/dragon");

		// generate monsters per room (maximum 10 total)
		if (num_monsters <= 4) {
			for (int i = 0; i < 2; i++) {

				// spawn randomly at one of the spawn points
				int random_index = Random.Range (0, spawn_points.Length);
				
				GameObject new_monster = Instantiate (monster);
				new_monster.transform.position = spawn_points [random_index].transform.position;

				// generate random color
				Color rand_color = new Color(Random.Range(0.3f, 1.0f), Random.Range(0.3f, 1.0f), Random.Range(0.3f, 1.0f));
				new_monster.GetComponent<Light>().color = rand_color;

				// generate random SFX
				int rand_SFX_idx = Random.Range(0, monsterSFX.Length);
				AudioSource sfx = new_monster.GetComponent<AudioSource>();
				sfx.clip = monsterSFX[rand_SFX_idx];
				sfx.Play();

				// set target
				new_monster.GetComponent<Chaser> ().target = player.transform;

			}

		}
	
	}
	
	// Update is called once per frame
	void Update () {

		// destroy monster if it is too far away
		Component[] monsters = FindObjectsOfType<Chaser> ();

		for (int i = 0; i < monsters.Length; i++) {
			if (player.transform.position.z - monsters[i].transform.position.z > 40) {
				Destroy(monsters[i].gameObject);
			}
		}
	
	}
}
