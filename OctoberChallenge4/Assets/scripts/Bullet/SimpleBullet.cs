using UnityEngine;
using System.Collections;

public class SimpleBullet : Bullet {

	// Use this for initialization
	public override void Start () {
		base.Start();
		speed = 6.0f;
	}
	
	// Update is called once per frame
	public override void Update () {
		base.Update();
	}
	
	public override void OnTriggerEnter(Collider other)
	{
		base.OnTriggerEnter(other);
		string tag = other.gameObject.tag;
		if(tag.Equals("SimpleEnemy"))
		{
			MessageMgr.Instance.NotifyObservers(eMessageID.eScore, this.gameObject);
			Destroy(gameObject);
		}
		if(tag.Equals("HeavyEnemy"))
		{
			MessageMgr.Instance.NotifyObservers(eMessageID.eCancelBonus, this.gameObject);
			Destroy(gameObject);
		}
	}
}
