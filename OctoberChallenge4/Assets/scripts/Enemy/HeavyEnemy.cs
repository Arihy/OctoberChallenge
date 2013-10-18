using UnityEngine;
using System.Collections;

public class HeavyEnemy : Enemy {

	// Use this for initialization
	public override void Start () {
		base.Start();
		moveSpeed = 6.0f;
	}
	
	// Update is called once per frame
	public override void Update () {
		base.Update();
	}
	
	public override void OnTriggerEnter(Collider other)
	{
		base.OnTriggerEnter(other);
		string tag = other.gameObject.tag;
		if(tag.Equals("HeavyBullet"))
		{
			Destroy(gameObject);
		}
	}
}
