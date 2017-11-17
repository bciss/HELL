using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tetriscase : MonoBehaviour {

	// Use this for initialization
	public tetriscase right = null;
	public tetriscase left = null;

	void Start () {
		Camera.main.GetComponent<controllertetris>().checkpoofneeded.AddListener(checkpoof);
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
			nballign++;
			tmp = tmp.left;
		}
		tmp = this;
		while (tmp.right != null)
		{
			nballign++;
			tmp = tmp.right;
		}
	
		if (nballign > 9)
		{
			tetriscase tmp2 = null;
			tmp = this.left;
			while (tmp != null)
			{
				tmp2 = tmp;
				tmp = tmp.left;
				GameObject.Destroy(tmp2.gameObject);
			}
			tmp = this.right;
			while (tmp != null)
			{
				tmp2 = tmp;
				tmp = tmp.right;
				GameObject.Destroy(tmp2.gameObject);
			}
			GameObject.Destroy(this);
		}
	}
}
