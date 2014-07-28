using UnityEngine;
using System.Collections;

public class playerMove : MonoBehaviour
{

	void Start ()
	{

	}
	
	
	public float movementSpeed;
	public float rotationSmooth;
	
	void FixedUpdate ()
	{

		
		Vector3 temp = transform.position;
		temp.x = 0.0f;
		transform.position = temp;
		float h = Input.GetAxis("Horizontal");				

		if( h > 0 ) 
		{

		transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);
		transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (Vector3.forward), Time.deltaTime * rotationSmooth);
		
		}	

		if(h < 0 )
		{
			

			transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);
			transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (Vector3.back), Time.deltaTime * rotationSmooth);
			
		}

	}
}





	

