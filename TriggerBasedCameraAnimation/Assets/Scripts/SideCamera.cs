    using UnityEngine;
    using System.Collections;
     
    public class SideCamera : MonoBehaviour {
     
	//Defines how far the camera wil lag behind player. 
    public float dampTime = 0.15f;
	//Sets the velocity of the Camera
    private Vector3 velocity = Vector3.zero;
	//Define the target and default target of the camera. (These should both be an empty gameObject that is parented to the player.)
    public Transform target;
	public Transform defaultTargetPos;
	//is Player Spawned?
    public bool targetSpawned;

	
	void Start ()
	{
		//sets the target as the default target.
		target = defaultTargetPos;
			
	}
    
	//Check for Player each frame.
	void Update()
	{
		checkForTarget();
		
	}
	

    void FixedUpdate ()
    {
		//SideScrolling camera movement.
    	if (targetSpawned)
    	{
			//This is the code that connects dynacam to your camera.
    		Vector3 point = camera.WorldToViewportPoint(target.position);
    		Vector3 delta = target.position - camera.ViewportToWorldPoint(new Vector3(dynaCam.camPanX, dynaCam.camPanY, point.z)); 
    		Vector3 destination = transform.position + delta;
   			transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime * Time.smoothDeltaTime);		
   		}
		
		
    }

	//Check for Player
	void checkForTarget()
	{
		if(target)
			{
				targetSpawned = true;
			
			}
	
		}
    }

	