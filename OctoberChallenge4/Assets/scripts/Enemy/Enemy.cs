using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	protected float moveSpeed;
		
	private Transform _transform;

	// Use this for initialization
	public virtual void Start () {
		_transform = transform;
		moveSpeed = 4.0f;
	}
	
	// Update is called once per frame
	public virtual void Update () {
		_transform.Translate(0, -moveSpeed * Time.deltaTime, 0);
	}
	
	public virtual void OnTriggerEnter(Collider other)
	{
		string tag = other.gameObject.tag;
		if(tag.Equals("Wall") || tag.Equals("Player"))
		{
			//MessageMgr.Instance.NotifyObservers();
			Destroy(gameObject);
		}
	}
}
