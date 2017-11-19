using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goombacontroller : MonoBehaviour {

new Rigidbody2D	rigidbody2D;
int dir = 1;
float speed = 10;


	// Use this for initialization
	void Start () {
				rigidbody2D = GetComponent< Rigidbody2D >();
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		rigidbody2D.velocity = new Vector2(dir * speed, 0);
	}
}
