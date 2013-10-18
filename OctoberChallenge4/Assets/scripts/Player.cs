using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    private float speed;
	private Transform _transform;
	
	public Transform particule;
	
	
	public Transform SimpleBulletPrefab;
	public Transform HeavyBulletPrefab;
	
	
	// Use this for initialization
	void Start () {
		_transform = transform;
	    speed = 7.0F;
	}
	
	// Update is called once per frame
	void Update () {
		CharacterController controller = GetComponent<CharacterController>();
		Vector3 moveDirection = Vector3.zero;
		
		if(Mathf.Abs(Input.GetAxis("Vertical")) >= Mathf.Abs(Input.GetAxis("Horizontal")))
			moveDirection = new Vector3(0, Input.GetAxis("Vertical"), 0);
		else if(Mathf.Abs(Input.GetAxis("Vertical")) < Mathf.Abs(Input.GetAxis("Horizontal")))
			moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
		
		moveDirection *= speed;
		controller.Move(moveDirection * Time.deltaTime);

		
		if((Input.GetKeyDown("k") || Input.GetKeyDown("joystick button 0")))
		{
			Instantiate(SimpleBulletPrefab, _transform.position, Quaternion.identity);
		}
		
		if((Input.GetKeyDown("j") || Input.GetKeyDown("joystick button 2")))
		{
			Instantiate(HeavyBulletPrefab, _transform.position, Quaternion.identity);
		}
    }
	
	void OnTriggerEnter(Collider other)
	{
		string tag = other.gameObject.tag;
		if(tag.Equals("SimpleEnemy") || tag.Equals("HeavyEnemy"))
		{
			//Instantiate(particule, _transform.position, Quaternion.identity);
			Destroy(gameObject);
			MessageMgr.Instance.NotifyObservers(eMessageID.eLoose, this.gameObject);
		}
	}
}
