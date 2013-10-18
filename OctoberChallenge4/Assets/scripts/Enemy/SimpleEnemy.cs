using UnityEngine;
using System.Collections;

public class SimpleEnemy : Enemy {

	// Use this for initialization
	public override void Start () {
		base.Start();
	}
	
	// Update is called once per frame
	public override void Update () {
		base.Update();
	}
	
	public override void OnTriggerEnter(Collider other)
	{
		base.OnTriggerEnter(other);
		string tag = other.gameObject.tag;
		if(tag.Equals("SimpleBullet"))
		{
			Destroy(gameObject);
		}
	}
	
}
