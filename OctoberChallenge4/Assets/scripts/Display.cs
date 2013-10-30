using UnityEngine;
using System.Collections;

public class Display : MonoBehaviour, IMessageListener {
	public GUIStyle scoreStyle;
	public GUIStyle comboStyle;
	
	
	private float delayCombo;
	private float nextDelay;
	private int combo;

	// Use this for initialization
	void Start () {
		MessageMgr.Instance.AddListener(this);
		
		delayCombo = 2.5f;
		nextDelay = 0.0f;
		combo = 1;	
	}

	// Update is called once per frame
	void Update () {
		if(Time.time > delayCombo + nextDelay && combo > 1)
		{
			nextDelay = Time.time;
			States.score += (50 * combo);
			combo = 1;
		}
	}

	public void OnMessage (eMessageID _messageID, GameObject _sender)
	{
		if(_messageID == eMessageID.eScore)
		{
			combo++;
			States.score += 50;
			nextDelay = Time.time;
		}
		if(_messageID == eMessageID.eCancelBonus)
		{
			combo = 1;
		}
		if(_messageID == eMessageID.eMinusBonus)
		{
			combo -=2;
			if(combo < 1)
				combo = 1;
		}
	}

	void OnGUI()
	{
		GUILayout.Button(""+States.score, scoreStyle);
		if(combo > 1)
			GUILayout.Button("X"+combo, comboStyle);
	}
}