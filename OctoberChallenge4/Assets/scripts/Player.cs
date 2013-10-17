using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    private float speed;
	private int numberBullet;
	private Transform _transform;
	
	public Transform bulletPrefab;
	
	// Use this for initialization
	void Start () {
		_transform = transform;
	    speed = 7.0F;
		numberBullet = 3;
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

		
		if((Input.GetKeyDown("space") || Input.GetKeyDown("joystick button 0")) && numberBullet > 0)
		{
			Instantiate(bulletPrefab, _transform.position, Quaternion.identity);
			numberBullet--;
		}
    }
	
	void OnTriggerEnter(Collider other)
	{
		string tag = other.gameObject.tag;
		if(tag.Equals("Ammunition"))
		{
			numberBullet += other.transform.GetComponent<Ammunition>().getNumberBullet();
		}
		if(tag.Equals("Enemy"))
		{
			Destroy(gameObject);
			MessageMgr.Instance.NotifyObservers(eMessageID.eLoose, this.gameObject);
		}
	}
	
	public int getNumberBullet()
	{
		return numberBullet;
	}
}
