using UnityEngine;
using System.Collections;

public class dynaCam : MonoBehaviour {
	
	// Defines the main player camera
	public Transform gameCamera;

	// Defines the minimum zoom position of the camera
	public float minimumZoom;
	//Defines the maximum zoom position of the camera
	public float maximumZoom;
	// Defines the speed at which the camera zooms. For example a value of 0 will zoom the camera instantly. A value of 100 will smoothly zoom the camera back.	
	public float zoomRate;
	// Defines rotation smoothing for the camera. Higher values create smoother rotation.
	public float rotateRate;
	//Defines the initial position of the camera.
	public float defCamPosX;
	public float defCamPosY;
	public float defCamPosZ;

	//Define the default rotation of the camera.
	public float defCamRotX;
	public float defCamRotY;
	public float defCamRotZ;

	//Defines the position of the Camera when zoomed.
	public float positionZoomCamX;
	public float positionZoomCamY;
	public float positionZoomCamZ;

	//Define the rotation of the Camera when zoomed.
	public float rotateZoomCamX;
	public float rotateZoomCamY;
	public float rotateZoomCamZ;

	//Defines the speed at which the camera will pan when zooming out.
	public float panSpeed;

	//Used to fine tune the x and y offset of the camera.
	public float panCamX;
	public float panCamY;

	public static float camPanX;
	public static float camPanY;

	//check to see if the camera is zoomed or not
	bool isZoomedOut;
	Vector3 defaultCamPos;
	
	public static float camUp;
	public static bool camMoveY;
	// Use this for initialization
	void Start () {
		defaultCamPos = gameCamera.transform.position;
		defaultCamPos.x = minimumZoom;
		isZoomedOut = false;

		camMoveY = false;
		
	}
	
	// Update is called once per frame
	void Update () 
	{

		//connects panCam values to static variables that are used in the sideCamera.cs script.
		camPanX = panCamX;
		camPanY = panCamY;
	
	}
	
	private Vector3 velocity = Vector3.zero;
	void FixedUpdate ()
	{
		//Local variables for SmoothDamp and Slerp.
		Vector3 TargetPosition = gameCamera.transform.position;

		if (isZoomedOut)
		{

			//sets the zoom position if the player is outside of the trigger.
			TargetPosition.x = maximumZoom;
			TargetPosition.y = positionZoomCamY;
			TargetPosition.z = positionZoomCamZ;

			//Animates the camera when the player is outside of the trigger.
			gameCamera.transform.position = Vector3.SmoothDamp(gameCamera.transform.position, TargetPosition, ref velocity, zoomRate * Time.smoothDeltaTime);
			gameCamera.transform.rotation = Quaternion.Slerp(gameCamera.transform.rotation,Quaternion.Euler (rotateZoomCamX, rotateZoomCamY, rotateZoomCamZ), Time.smoothDeltaTime * rotateRate);
				
		}
		else if (!isZoomedOut)
		{
			//sets the zoom position if the player is inside the trigger.
			TargetPosition.x = minimumZoom;
			TargetPosition.y = defCamPosY;
			TargetPosition.z = defCamPosZ;
			//Animates the camera when the player is inside the trigger.
			gameCamera.transform.position = Vector3.SmoothDamp(gameCamera.transform.position, TargetPosition, ref velocity, zoomRate * Time.deltaTime);
			
			gameCamera.transform.rotation = Quaternion.Slerp(gameCamera.transform.rotation,Quaternion.Euler (defCamRotX, defCamRotY, defCamRotZ), Time.deltaTime * rotateRate);

		}
	
	}
	//Triggers the camera Movement.
	//Check to see if Player is in the Trigger
	void OnTriggerEnter (Collider cameraZoomTrigger)
	{
		if (cameraZoomTrigger.gameObject.tag == "Player")
		{
			isZoomedOut = true;
			camMoveY = true;

		}
		
	}
	//Check to see if Player Leaves the Trigger
	void OnTriggerExit (Collider cameraZoomTrigger)
	{
		if (cameraZoomTrigger.gameObject.tag == "Player")
		{
			isZoomedOut = false;
			camMoveY = false;
			
		}
		
	}
	
	
	
}
