using UnityEngine;
using System.Collections;

public class SpownManager : MonoBehaviour {
	public Transform[] spowns = new Transform[5];
	public Transform enemy;
	public Transform ammunation;
	
	private float spownRate;
	private float nextSpown;
	private float spownAmmuRate;
	private float nextSpownAmmu;
	
	// Use this for initialization
	void Start () {
		spownRate = 1.5f;
		nextSpown = 0.0f;
		spownAmmuRate = 10.0f;
		nextSpownAmmu = 10.0f;
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.time > nextSpown)
		{
			nextSpown = Time.time + spownRate;
			int random = Random.Range(0, 5);
			Instantiate(enemy, spowns[random].position, Quaternion.identity);
			int randNbSpown = Random.Range(0, 3);
			if(randNbSpown == 1)
				Instantiate(enemy, spowns[(random+(Random.Range(0, 3)))%5].position, Quaternion.identity);
		}
		
		if(Time.time > nextSpownAmmu)
		{
			nextSpownAmmu = Time.time + spownAmmuRate;
			int random = Random.Range(0, 10);
			Instantiate(ammunation, spowns[random%5].position, Quaternion.identity);
		}
		
	}
}
