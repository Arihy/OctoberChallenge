using UnityEngine;
using System.Collections;

public class TryAgainButton : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown("joystick button 2"))
		{
			Application.Quit();
		}
		if(Input.GetKeyDown("joystick button 0"))
		{
			Time.timeScale = 1;
			States.score = 0;
			Application.LoadLevel("scene1");
		}
	}

	void OnMouseDown()
	{
		Application.LoadLevel("scene1");
	}

	void OnGUI()
	{
	}
}