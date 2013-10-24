using UnityEngine;
using System.Collections;

public class Display : MonoBehaviour, IMessageListener {
	private int score;
	
	public Transform multiplicator;
	public Transform comboBar;
	
	private float delayCombo;
	private float nextDelay;
	
	public Texture[] comboTexture = new Texture[16];
	private int numTex;
	
	public Texture[] multiTexture = new Texture[3];
	private int numMulti;

	// Use this for initialization
	void Start () {
		MessageMgr.Instance.AddListener(this);
		score = 0;
		
		delayCombo = 3.0f;
		nextDelay = 0.0f;
		numTex = 0;
		numMulti = 1;
		
	}

	// Update is called once per frame
	void Update () {
		if(Time.time > delayCombo + nextDelay)
		{
			nextDelay = Time.time;
			if(numTex < 0)
				numTex = 0;
			else
			{
				comboBar.renderer.material.SetTexture("_MainTex", comboTexture[numTex]);
				numTex--;
			}
		}
		if(numTex > 15)
		{
			if(numMulti < 3)
			{
				numMulti++;
				numTex = 0;
			}
			else
				numTex = 15;
		}
		if(numTex < 0)
		{
			if(numMulti > 1)
			{
				numMulti--;
				numTex = 15;
			}
			else
				numTex = 0;
		}
		multiplicator.renderer.material.SetTexture("_MainTex", multiTexture[numMulti - 1]);
		comboBar.renderer.material.SetTexture("_MainTex", comboTexture[numTex]);
	}

	public void OnMessage (eMessageID _messageID, GameObject _sender)
	{
		if(_messageID == eMessageID.eScore)
		{
			score += (3 * numMulti);
			States.score = score;
			numTex += 2;
			nextDelay = Time.time;
		}
		if(_messageID == eMessageID.eCancelBonus)
		{
			numTex = 0;
			numMulti = 1;
		}
		if(_messageID == eMessageID.eMinusBonus)
			numTex -= 2;
	}

	void OnGUI()
	{
		GUI.Label(new Rect(Screen.width - 100, 20, 100, 30), "score : "+score);
	}
}