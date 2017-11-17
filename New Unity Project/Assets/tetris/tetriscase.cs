using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tetriscase : MonoBehaviour {

	// Use this for initialization
	public tetriscase right = null;
	public tetriscase left = null;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void initpoof()
	{
		right = null;
		left = null;
	}

	public void checkpoof()
	{
		RaycastHit2D righthit = Physics2D.Raycast(transform.position, new Vector2(1, 0));
		right = righthit.collider.gameObject.GetComponent<tetriscase>();

		RaycastHit2D lefthit = Physics2D.Raycast(transform.position, new Vector2(-1, 0));
		left = lefthit.collider.gameObject.GetComponent<tetriscase>();
		
	}
}
