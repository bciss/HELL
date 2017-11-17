using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class controllertetris : MonoBehaviour {

	// Use this for initialization
	public quadrapode[] list;
	quadrapode current = null;
	[HideInInspector] public UnityEvent checkpoofneeded;

	int tmp36 = 0;

	void Awake()
	{
		if (checkpoofneeded == null)
			checkpoofneeded = new UnityEvent();
	}
	void Start () {
	}

	IEnumerator spawnnew()
	{
		current = null;
		checkpoofneeded.Invoke();
		yield return new WaitForSeconds(0.5f);
		if (current == null)
		{
			current = GameObject.Instantiate(list[Random.Range(0, list.Length - 1)]);
			current.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -0.001f);
			current.GetComponentsInChildren<tetriscase>();
		}
		tmp36 = 0;
	}

	// Update is called once per frame
	void FixedUpdate () {
		if (tmp36 == 0 && (current == null || current.ismoving == 0))
		{
			tmp36 = 1;
			StartCoroutine(spawnnew());
		}
		if (current == null)
			return ;
		
		if (current.ascolitioner == 0 && Input.GetKeyDown("right"))
			current.transform.position += new Vector3(1, 0, 0);

		if (current.ascolitioner == 0 && Input.GetKeyDown("left"))
			current.transform.position -= new Vector3(1, 0, 0);
	}
}
