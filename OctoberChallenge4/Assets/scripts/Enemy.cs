using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	private float moveSpeed;
	private float speedMax;
	private float speedMin;
		
	private Transform _transform;

	// Use this for initialization
	void Start () {
		_transform = transform;
		speedMax = 2.0f;
		speedMin = 4.0f;
		//moveSpeed = Random.Range(speedMin, speedMax);
		moveSpeed = 3.0f;
	}
	
	// Update is called once per frame
	void Update () {
		_transform.Translate(0, -moveSpeed * Time.deltaTime, 0);
	}
	
	void OnTriggerEnter(Collider other)
	{
		string tag = other.gameObject.tag;
		if(tag.Equals("Wall") || tag.Equals("Bullet") || tag.Equals("Player"))
			Destroy(gameObject);
	}
}
