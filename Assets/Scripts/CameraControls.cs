using UnityEngine;
using System.Collections;

public class CameraControls : MonoBehaviour {

    public float cameraMoveSpeed = 5.0f;
    public float cameraPanSpeed = 20.0f;
    public Transform camera;
    public Transform cameraTarget;

	// Use this for initialization
	void Start () {
        camera.transform.LookAt(cameraTarget);
	}
	
	// Update is called once per frame
	void Update () {

        UpdateMovement();
	}

    private void UpdateMovement()
    {
        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");

        // Sideways
        if (Input.GetAxis("Horizontal") != 0)
        {
            transform.Translate(camera.transform.right * horizontalMovement * Time.deltaTime * cameraMoveSpeed);
        }
        

        // Forwards and Backwards 
        if (Input.GetAxis("Vertical") != 0)
        {
            transform.Translate(new Vector3(camera.transform.forward.x, 0, camera.transform.forward.z) * verticalMovement * Time.deltaTime * cameraMoveSpeed);
        }
        
        // Zoom
        camera.transform.Translate(0,0,Input.GetAxis("Mouse ScrollWheel") * cameraMoveSpeed * Time.deltaTime);
        
        // Panning mode is active
        if(Input.GetMouseButton(1))
        {
            camera.transform.Translate(-Input.GetAxis("Mouse X") * cameraPanSpeed * Time.deltaTime, 0, 0);

            camera.transform.Translate(0, -Input.GetAxis("Mouse Y") * cameraPanSpeed * Time.deltaTime, 0);

            camera.transform.LookAt(cameraTarget);
        }
    }
}
