using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class controllertetris : MonoBehaviour {

	// Use this for initialization
	public quadrapode[] list;
	quadrapode current = null;
	[HideInInspector] public UnityEvent checkpoofneeded;
	[HideInInspector] public UnityEvent checkdestroyneeded;

	int tmp36 = 0;
	int tmp32 = 0;

	void Awake()
	{
		if (checkpoofneeded == null)
			checkpoofneeded = new UnityEvent();
		if (checkdestroyneeded == null)
			checkdestroyneeded = new UnityEvent();
	}
	void Start () {
	}

	IEnumerator spawnnew()
	{
		current = null;
		checkpoofneeded.Invoke();
		yield return new WaitForSeconds(0.25f);
		checkdestroyneeded.Invoke();
		yield return new WaitForSeconds(0.25f);
		if (current == null)
		{
			current = GameObject.Instantiate(list[Random.Range(0, list.Length - 1)]);
			current.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -0.001f);
			current.GetComponentsInChildren<tetriscase>();
		}
		tmp36 = 0;
	}

	IEnumerator delay()
	{
		tmp32 = 1;
		yield return new WaitForSeconds(0.1f);
		tmp32 = 0;
	}

	// Update is called once per frame
	void FixedUpdate () {
		if (tmp36 == 0 && (current == null || current.ismoving == 0))
		{
			tmp36 = 1;
			StartCoroutine(spawnnew());
		}
		if (current == null || tmp32 == 1)
			return ;
		
		if (current.raycasthori(1) && Input.GetKey("right"))
		{
			current.transform.position += new Vector3(1, 0, 0);
			StartCoroutine(delay());
		}

		if (current.raycasthori(-1) && Input.GetKey("left"))
		{
			StartCoroutine(delay());
			current.transform.position -= new Vector3(1, 0, 0);
		}
	}
}
