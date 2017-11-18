using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour {

	public	GameObject	Ammo;
	public	float		speed;

	private	GameObject	curShoot;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey("left") && transform.position.x > -60f)
			transform.position = new Vector3(transform.position.x - 0.75f, transform.position.y, transform.position.z);
		else if (Input.GetKey("right") && transform.position.x < 60f)
			transform.position = new Vector3(transform.position.x + 0.75f, transform.position.y, transform.position.z);
		if (Input.GetKeyDown("space") && !curShoot)
			Shoot();
	}

	void	Shoot() {
		curShoot = Instantiate(Ammo, new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z), Quaternion.identity);
		Debug.Log("shoot !!!");
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Foe")
		{
			GameOver();
		}
	}

	void GameOver()
	{
		Debug.Log("GAME OVER");
	}
}
