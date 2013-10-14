using UnityEngine;
using System.Collections;

public class TryAgainButton : MonoBehaviour {

	void OnMouseDown()
	{
		Application.LoadLevel("scene1");
	}

	void OnGUI()
	{
	}
}