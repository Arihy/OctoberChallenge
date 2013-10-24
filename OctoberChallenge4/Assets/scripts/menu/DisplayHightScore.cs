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
		string s = "TOP 10 \n--------------\n";
		for(int i = 0; i < 10; i++)
		{
			if(PlayerPrefs.HasKey(i+"HScore"))
				s += i+1 +"       "+PlayerPrefs.GetInt(i+"HScore")+"       "+PlayerPrefs.GetString(i+"HScoreName")+"\n";
		}
		GUI.Label(new Rect(Screen.width/2 - 100, Screen.height/2 - 200, 300, 400), s);
	}
	
}
