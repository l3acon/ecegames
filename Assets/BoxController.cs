using UnityEngine;
using System.Collections;


[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Camera))]
public class BoxController : MonoBehaviour {
	
	public float defaultForce = 1f; // default 
	public float speed = 10f;
	public float jumpForce = 20f;
	public float rotationSpeed= 3f;

	
	public Quaternion defaultOrientation;

	// Use this for initialization
	void Start () {
	 	defaultOrientation = rigidbody.transform.rotation;
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		// add a constant forward force		
		Vector3 forwardForce = this.transform.forward*speed;
		rigidbody.transform.position += forwardForce * Time.deltaTime; 
	
		Rotate(); // rotate the character based on player input

		
		// reset button
		if(Input.GetAxis("Jump") > .001)// if pressing jump key
		{
			Debug.Log("Here");
			rigidbody.AddForce(new Vector3(0,jumpForce,0));
		}
		
				// reset button
		if(Input.GetKey(KeyCode.R))
		{
			rigidbody.transform.rotation = defaultOrientation;
		}
				
	}
	
	// not entering loop
	void OnCollisionEnter(Collision collision)
	{
		Debug.Log("sup");
		Debug.Log("hei: " + collision.contacts[0].thisCollider.name);
	}
	
	public void Rotate()
	{
		/**
		 * rotation
		 * axis is float, 1 to -1. This way we can have multiple inputs.
		 * the axis is referenced from the point of the joystick
		 **/
		float verticalAxis = Input.GetAxis("Vertical");
		float horizontalAxis = Input.GetAxis("Horizontal");
		//Debug.Log("verticalAxis: " + verticalAxis);
		//Debug.Log("horizontalAxis: " + horizontalAxis);

		rigidbody.transform.Rotate(0,rotationSpeed*horizontalAxis,0); // rotate on the horizontal axis, left and right 
											
		rigidbody.transform.Rotate(rotationSpeed*verticalAxis,0,0); // rotate on the horizontal axis, up and down
	
		
	}
	
}
