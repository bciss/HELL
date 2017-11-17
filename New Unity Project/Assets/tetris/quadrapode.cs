using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quadrapode : MonoBehaviour {

	// Use this for initialization
	[HideInInspector] public int ismoving = 1;
	[HideInInspector] public int ascolitioner = 0;
	public int longueur;
	public int largeur;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (gameObject.GetComponent<Rigidbody2D>().velocity == new Vector2(0, 0))
			ismoving = 0;
		else
			ismoving = 1;
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.GetComponent<tetriscase>())
			ascolitioner = 1;
	}
}
