using UnityEngine;
using System.Collections;

public class Ammunition : MonoBehaviour {
	private float speed;
	private int numberBullet;
	private Transform _transform;

	// Use this for initialization
	void Start () {
		speed = 2.0f;
		numberBullet = Random.Range(3, 5) - Random.Range(0, 2);
		_transform = transform;
	}
	
	// Update is called once per frame
	void Update () {
		_transform.Translate(0, -speed * Time.deltaTime, 0);
	}
	
	public int getNumberBullet()
	{
		return numberBullet;
	}
	
	void OnTriggerEnter(Collider other)
	{
		string tag = other.gameObject.tag;
		if(tag.Equals("Wall"))
			Destroy(gameObject);
		if(tag.Equals("Player"))
		{
			Destroy(gameObject);
		}
	}
}
