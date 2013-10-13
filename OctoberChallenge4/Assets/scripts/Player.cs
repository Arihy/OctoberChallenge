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
        
        float y = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        float x = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
		
		if(Mathf.Abs(Input.GetAxis("Vertical")) >= Mathf.Abs(Input.GetAxis("Horizontal")))
			transform.Translate(0, y, 0);
		else if(Mathf.Abs(Input.GetAxis("Vertical")) < Mathf.Abs(Input.GetAxis("Horizontal")))
			transform.Translate(x, 0, 0);
		
		if((Input.GetKeyDown("space") || Input.GetKeyDown("joystick button 0")) && numberBullet > 0)
		{
			Instantiate(bulletPrefab, _transform.position, Quaternion.identity);
			numberBullet--;
		}
    }
	
	void OnCollisionEnter(Collision other)
	{
		string tag = other.gameObject.tag;
		if(tag.Equals("Enemy"))
		{
			Destroy(gameObject);
			MessageMgr.Instance.NotifyObservers(eMessageID.eLoose, this.gameObject);
		}
	}
	
	void OnTriggerEnter(Collider other)
	{
		string tag = other.gameObject.tag;
		if(tag.Equals("Ammunition"))
		{
			//ajouter la balle dans l'inventaire du joueur
			numberBullet += other.transform.GetComponent<Ammunition>().getNumberBullet();
			Debug.Log(other.transform.GetComponent<Ammunition>().getNumberBullet());
		}
	}
}
