using UnityEngine;
using System.Collections;

public class SpownManager : MonoBehaviour {
	public Transform[] spowns = new Transform[5];
	public Transform enemy;
	
	private float spownRate;
	private float nextSpown;

	// Use this for initialization
	void Start () {
		spownRate = 1.5f;
		nextSpown = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.time > nextSpown)
		{
			nextSpown = Time.time + spownRate;
			int random = Random.Range(0, 10);
			Instantiate(enemy, spowns[random%5].position, Quaternion.identity);
		}
	}
}
