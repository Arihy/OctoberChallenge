using UnityEngine;
using System.Collections;

public class SpownManager : MonoBehaviour {
	public Transform[] spowns = new Transform[5];
	public Transform simpleEnemy;
	public Transform heavyEnemy;
	
	
	private float spownRate;
	private float nextSpown;
	
	// Use this for initialization
	void Start () {
		spownRate = 1.2f;
		nextSpown = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.time > nextSpown)
		{
			nextSpown = Time.time + spownRate;
			int randomSpown = Random.Range(0, 5);
			
			int randomEnemy = Random.Range(0, 3);
			Transform enemy;
			if(randomEnemy == 1)
				enemy = heavyEnemy;
			else
				enemy = simpleEnemy;
			
			Instantiate(enemy, spowns[randomSpown].position, Quaternion.identity);
			int randNbSpown = Random.Range(0, 3);
			
			randomEnemy = Random.Range(0, 3);
			if(randomEnemy == 1)
				enemy = heavyEnemy;
			else
				enemy = simpleEnemy;
			
			if(randNbSpown == 1)
				Instantiate(enemy, spowns[(randomSpown+(Random.Range(0, 3)))%5].position, Quaternion.identity);
		}
		
	}
}
