using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class foe_controller : MonoBehaviour {


	public	GameObject	Ammo;
	public	float		SpeedH;
	public	float		SpeedV;

	private	float		i;
	private float		j;
	private	GameObject	curShoot;


	// Use this for initialization
	void Start () {
		i = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if ((Input.GetKeyDown("space") && !curShoot) || (Random.Range(0, 1000) <= 0))
			Shoot();
		if (i == 0) {
			transform.position = new Vector3(transform.position.x, transform.position.y - SpeedV, transform.position.z);
			j = SpeedH;
		} else if (i == 25) {
			transform.position = new Vector3(transform.position.x, transform.position.y - SpeedV, transform.position.z);
			j = -SpeedH;
		} else {
			transform.position = new Vector3(transform.position.x + j, transform.position.y, transform.position.z);
		}
		i += j;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player")
			GameObject.Destroy(gameObject);
	}
	
	void Shoot() {
		curShoot = Instantiate(Ammo, transform.position, Quaternion.identity);
		// Debug.Log("shoot !!!");
	}
}
