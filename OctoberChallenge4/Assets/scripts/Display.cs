using UnityEngine;
using System.Collections;

public class Display : MonoBehaviour, IMessageListener {
	private int score;
	private int bullet;

	// Use this for initialization
	void Start () {
		MessageMgr.Instance.AddListener(this);
		score = 0;
		bullet = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().getNumberBullet();
	}

	// Update is called once per frame
	void Update () {
		if(GameObject.FindGameObjectWithTag("Player"))
			bullet = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().getNumberBullet();
	}

	public void OnMessage (eMessageID _messageID, GameObject _sender)
	{
		if(_messageID == eMessageID.eScore)
		{
			score += 3;
		}
	}

	void OnGUI()
	{
		GUI.Label(new Rect(Screen.width - 100, 20, 100, 30), "score : "+score);
		GUI.Label(new Rect(100, 20, 100, 30), "bullet : "+bullet);
	}
}