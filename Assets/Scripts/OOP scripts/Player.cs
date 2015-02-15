using UnityEngine;
using System.Collections;

public class Player : Tank {
    Rigidbody rb;
    	public float rotationSpeed = 3.50f;
	public float moveSpeed = 0.4f;

	// Use this for initialization

	
	// Update is called once per frame
	void Update () {
        Turret.LookAt(targetPos);

        Vector3 mousePos = Input.mousePosition;//(x,y,z)
        mousePos.z = camera.transform.position.y - Turret.transform.position.y;   //- (Turret.transform.localPosition.y - this.transform.position.y);

        Vector3 worldPos = camera.ScreenToWorldPoint(mousePos);

        targetPos = worldPos;

        	
		if(Input.GetKey(KeyCode.W))
		{
			transform.Translate(Vector3.forward * moveSpeed);
		}
		if (Input.GetKey (KeyCode.S)) 
		{
			transform.Translate (-Vector3.forward * moveSpeed);
		}
		if (Input.GetKey (KeyCode.A)) 
		{
			transform.Rotate (-Vector3.up * rotationSpeed);
		}
		if (Input.GetKey (KeyCode.D)) 
		{
			transform.Rotate (Vector3.up * rotationSpeed);
		}
	

	}

    	void Start () {
        rb = gameObject.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (rb.velocity != Vector3.zero)//(0,0,0)
        {
            rb.velocity = Vector3.zero;
        }
        if (rb.angularVelocity != Vector3.zero) 
        {
            rb.angularVelocity = Vector3.zero;
        }
	}
}

