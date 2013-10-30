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
		spownRate = 0.8f;
		nextSpown = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.time > nextSpown)
		{
			//prochain spown
			nextSpown = Time.time + spownRate;
			//random sur le spot qui va spown le prochain ennemi
			//entre 0 et 5-1 parce qu'il y a 5 spown
			int randomSpown = Random.Range(0, 5);
			
			//random sur le type d'ennemis qui sont spown
			//une chance sur 3 d'avoir un heavyEnemy
			int randomEnemy = Random.Range(0, 3);
			Transform enemy;
			if(randomEnemy == 1)
				enemy = heavyEnemy;
			else
				enemy = simpleEnemy;
			
			Instantiate(enemy, spowns[randomSpown].position, Quaternion.identity);
			
			
			//random sur le nombre d'ennemis sur la mm ligne, c'est a dire qui spown en mm temps
			int randNbSpown = Random.Range(0, 3);
			
			//une chance sur 3 d'avoir 2 ennemis sur la mm ligne
			if(randNbSpown == 1)
			{
				//un autre random pour choisir l'ennemi qui sera a coté du premier
				//une chance sur 3 d'avoir un heavyEnemy
				randomEnemy = Random.Range(0, 2);
				if(randomEnemy == 1)
					enemy = heavyEnemy;
				else
					enemy = simpleEnemy;
				
				Instantiate(enemy, spowns[(randomSpown+(Random.Range(0, 3)))%5].position, Quaternion.identity);
			}
		}
		
	}
}
