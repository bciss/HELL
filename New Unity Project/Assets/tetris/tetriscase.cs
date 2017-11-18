using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tetriscase : MonoBehaviour {

	// Use this for initialization
	public tetriscase right = null;
	public tetriscase left = null;
	[HideInInspector] public bool astobedestroy = false;

	void Start () {
		Camera.main.GetComponent<controllertetris>().checkpoofneeded.AddListener(checkpoof);
		Camera.main.GetComponent<controllertetris>().checkdestroyneeded.AddListener(checkdestroy);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void initpoof()
	{
		right = null;
		left = null;
	}

	public void checkdestroy()
	{
		if (astobedestroy == false)
			GameObject.Destroy(this);
	}

	public void checkpoof()
	{
		RaycastHit2D righthit = Physics2D.Raycast(transform.position, new Vector2(1, 0));
		if (righthit == false)
			right = null;
		else
			right = righthit.collider.gameObject.GetComponent<tetriscase>();

		RaycastHit2D lefthit = Physics2D.Raycast(transform.position, new Vector2(-1, 0));
		if (lefthit == false)
			left = null;
		else
			left = lefthit.collider.gameObject.GetComponent<tetriscase>();

		if (right == this || left == this)
		{
			Debug.Log("dafuq346");
			return ;
		}

		tetriscase tmp = this;
		int nballign = 1;
		while (tmp.left != null)
		{
			Debug.Log("dsf");
			nballign++;
			tmp = tmp.left;
		}
		tmp = this;
		while (tmp.right != null)
		{
			Debug.Log("dsf1");
			nballign++;
			tmp = tmp.right;
		}
	
		if (nballign > 11)
		{
			tetriscase tmp2 = null;
			tmp = this.left;
			while (tmp != null)
			{
			Debug.Log("dsf2");
				tmp2 = tmp;
				tmp = tmp.left;
				tmp2.astobedestroy = true;
			}
			tmp = this.right;
			while (tmp != null)
			{
			Debug.Log("dsf3");
				tmp2 = tmp;
				tmp = tmp.right;
				tmp2.astobedestroy = true;
			}
			this.astobedestroy = true;
			// GameObject.Destroy(this);
		}
	}
	// RaycastHit2D[] list2;
	// list2 = Physics2D.RaycastAll(new Vector2(-6.5f, transform.position.y), new Vector2(1, 0), 12.25f);
	// if  (list2.Length > 11)
	// {
	// 	;
	// }
}
