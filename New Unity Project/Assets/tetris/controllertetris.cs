using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class controllertetris : MonoBehaviour {

	// Use this for initialization
	public quadrapode[] list;
	public GameObject[] listimage;

	quadrapode current = null;
	GameObject next = null;
	int 		nextrange;
	float		nextrot;
	public Vector3 origin;
	public Vector3	nextorigin;
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
		newnext();
	}

	void		newnext()
	{
		if (next != null)
			GameObject.Destroy(next.gameObject);
		nextrange = Random.Range(0, list.Length);
		nextrot = Random.Range(0, 4);;
		next = GameObject.Instantiate(listimage[nextrange], nextorigin, Quaternion.identity);
		next.transform.Rotate(Vector3.forward, nextrot * 90);
	}

	IEnumerator spawnnew()
	{
		current = null;
		checkpoofneeded.Invoke();
		yield return new WaitForSeconds(0.01f);
		checkdestroyneeded.Invoke();
		yield return new WaitForSeconds(0.49f);
		if (current == null)
		{
			current = GameObject.Instantiate(list[nextrange], origin, Quaternion.identity);
			current.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -0.001f);
			current.transform.Rotate(Vector3.forward, nextrot * 90);
			newnext();
		}
		tmp36 = 0;
	}

	IEnumerator delay()
	{
		tmp32 = 1;
		yield return new WaitForSeconds(0.05f);
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
			current.rigid.MovePosition(current.transform.position + new Vector3(1, 0, 0));
			StartCoroutine(delay());
		}

		if (current.raycasthori(-1) && Input.GetKey("left"))
		{
			current.rigid.MovePosition(current.transform.position - new Vector3(1, 0, 0));
			StartCoroutine(delay());
		}
	}
}
