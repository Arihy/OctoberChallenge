using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
	private float speed;
	
	private Transform _transform;

	// Use this for initialization
	void Start () {
		_transform = transform;
		speed = 6.0f;
	}
	
	// Update is called once per frame
	void Update () {
		_transform.Translate(0, speed * Time.deltaTime, 0);
	}
	
	void OnTriggerEnter(Collider other)
	{
		string tag = other.gameObject.tag;
		if(tag.Equals("Wall") || tag.Equals("Bullet") || tag.Equals("Enemy"))
			Destroy(gameObject);
	}
}
