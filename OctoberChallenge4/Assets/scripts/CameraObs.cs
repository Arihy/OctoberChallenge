using UnityEngine;
using System.Collections;

public enum eEtatID
{
	eInGame,
	eLoose
}

public class CameraObs : MonoBehaviour, IMessageListener {
	private eEtatID etat;
	private float timeToLoadGameOver;

	// Use this for initialization
	void Start () {
		MessageMgr.Instance.AddListener(this);
		timeToLoadGameOver = 0;
	}

	// Update is called once per frame
	void Update () {

	}

	public void OnMessage (eMessageID _messageID, GameObject _sender)
	{
		if(_messageID == eMessageID.eLoose)
		{
			etat = eEtatID.eLoose;
			timeToLoadGameOver = Time.time;
		}
	}

	void OnGUI()
	{
		switch(etat)
		{
			case eEtatID.eLoose:
				if(Time.time > timeToLoadGameOver + 1.5)
					Application.LoadLevel("gameOver");
				break;
			default:
				break;
		}
	}
}