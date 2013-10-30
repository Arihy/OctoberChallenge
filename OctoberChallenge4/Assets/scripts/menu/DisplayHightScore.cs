using UnityEngine;
using System.Collections;

public class DisplayHightScore : MonoBehaviour {
	public GUIStyle highscoreStyle;
	
	
	void OnGUI()
	{
		GUILayout.Button("TOP 10", highscoreStyle);
		for(int i = 0; i < 10; i++)
		{
			if(PlayerPrefs.HasKey(i+"HScore"))
				GUILayout.Button(i+1+"       "+PlayerPrefs.GetInt(i+"HScore")+"       "+PlayerPrefs.GetString(i+"HScoreName"), highscoreStyle);
		}
	}
}
