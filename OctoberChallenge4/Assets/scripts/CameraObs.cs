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
	public string name = "player";

	// Use this for initialization
	void Start () {
		MessageMgr.Instance.AddListener(this);
		timeToLoadGameOver = 0;
	}

	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.Escape))
			Application.LoadLevel("menu");
		if(Input.GetKey(KeyCode.R))
			Application.LoadLevel("scene1");
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
				{
					//make game pause
					Time.timeScale = 0;
					name = GUI.TextField(new Rect(Screen.width/2, Screen.height/2, 200, 20), name, 25);
					if(Event.current.type == EventType.KeyUp && Event.current.keyCode == KeyCode.Return) {
						addScore(name, States.score);
						Application.LoadLevel("gameOver");
					}
					
				}
				break;
			default:
				break;
		}
	}
	
	private void addScore(string name, int score)
	{
		int newScore = score;
		string newName = name;
		
		int oldScore;
		string oldName;
		
		for(int i = 0; i < 10; i++)
		{
			if(PlayerPrefs.HasKey(i+"HScore")){
				if(PlayerPrefs.GetInt(i+"HScore")<=newScore){ 
		            // new score is higher than the stored score
		            oldScore = PlayerPrefs.GetInt(i+"HScore");
		            oldName = PlayerPrefs.GetString(i+"HScoreName");
		            PlayerPrefs.SetInt(i+"HScore",newScore);
		            PlayerPrefs.SetString(i+"HScoreName",newName);
		            newScore = oldScore;
		            newName = oldName;
	         	}
			}else{
	         PlayerPrefs.SetInt(i+"HScore",newScore);
	         PlayerPrefs.SetString(i+"HScoreName",newName);
	         newScore = 0;
	         newName = "vide";
			}
		}
	}
}