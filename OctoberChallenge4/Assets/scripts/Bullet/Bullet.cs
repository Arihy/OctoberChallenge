using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
	protected float speed;
	
	private Transform _transform;

	// Use this for initialization
	public virtual void Start () {
		_transform = transform;
		//speed = 6.0f;
	}
	
	// Update is called once per frame
	public virtual void Update () {
		_transform.Translate(0, speed * Time.deltaTime, 0);
	}
	
	public virtual void OnTriggerEnter(Collider other)
	{
		string tag = other.gameObject.tag;
		if(tag.Equals("Wall"))
			Destroy(gameObject);
			
	}
}
