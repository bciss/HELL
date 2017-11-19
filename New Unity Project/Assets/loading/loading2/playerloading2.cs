using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerloading2 : MonoBehaviour {

	public Text	loadingtext;
	public Slider loadingslider;
	[HideInInspector] public float loading;
	public float speed;
	bool asjumped = false;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

		if (asjumped == true)
			transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
		loading = (transform.position.x + 4) * 100 / 8;
		loadingtext.text = Mathf.Round(loading).ToString() + "%";
		loadingslider.value = loading / 100;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		Debug.Log("fdsf");
		if (other.tag == "ouch")
			loading -= 2;
	}

	// void OnDrawGizmos()
	// {
	// 	Gizmos.color = Color.red;
	// 	Gizmos.DrawWireCube;
	// }
}
