using UnityEngine;
using System.Collections;

public class DisplayHightScore : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnGUI()
	{
		string s = "Highscore \n\n";
		for(int i = 0; i < 10; i++)
		{
			if(PlayerPrefs.HasKey(i+"HScore"))
				s += PlayerPrefs.GetString(i+"HScoreName")+" -- "+PlayerPrefs.GetInt(i+"HScore")+"\n";
		}
		if(PlayerPrefs.HasKey("0HScore"))
			GUI.Label(new Rect(Screen.width / 3 , 20, 100, 300), s);
	}
	
}
