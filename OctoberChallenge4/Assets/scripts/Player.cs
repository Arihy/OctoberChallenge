using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    private float speed;
	
	// Use this for initialization
	void Start () {
	    speed = 7.0F;
        //rigidbody.
        
	}
	
	// Update is called once per frame
	void Update () {
        
        float y = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        float x = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        //transform.Translate(x, y, 0);
		/*
        bool errortouch = (Input.GetKey("up") &&  Input.GetKey("right")) || (Input.GetKey("up") &&  Input.GetKey("left")) || (Input.GetKey("down") &&  Input.GetKey("left")) || (Input.GetKey("down") &&  Input.GetKey("right"));   
        
        if(!errortouch){
            if (Input.GetKey("down") || Input.GetKey("up"))
            {
                transform.Translate(0, y, 0);
            }
            if (Input.GetKey("left") || Input.GetKey("right"))
            {
                transform.Translate(x, 0, 0);
            }
        }
        */
		
		if(Mathf.Abs(Input.GetAxis("Vertical")) >= Mathf.Abs(Input.GetAxis("Horizontal")))
			transform.Translate(0, y, 0);
		else if(Mathf.Abs(Input.GetAxis("Vertical")) < Mathf.Abs(Input.GetAxis("Horizontal")))
			transform.Translate(x, 0, 0);
    }
}
