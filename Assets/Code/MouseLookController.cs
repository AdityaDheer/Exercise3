using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLookController : MonoBehaviour
{
    float lookSpeedX = 3; // left/right mouse sensitivity
    float lookSpeedY = 3; // up/down mouse sensitivity

    float xRotation;
    float yRotation;

    public Transform camTrans; // a reference to the camera transform

    // Start is called before the first frame update
    void Start()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        lookSpeedX *= .65f; //WebGL has a bug where the mouse has higher sensitibity. This compensates for the change. 
        lookSpeedY *= .65f; //.65 is a rough guess based on testing in firefox.
#endif

        Cursor.lockState = CursorLockMode.Locked; // Hides the mouse and locks it to the center of the screen.
    }

    // Update is called once per frame
    void Update()
    {
        xRotation -= Input.GetAxis("Mouse Y") * lookSpeedY;
        yRotation += Input.GetAxis("Mouse X") * lookSpeedX;
        xRotation = Mathf.Clamp(xRotation, -80, 80); //Keeps up/down head rotation realistic
        camTrans.localEulerAngles = new Vector3(xRotation, yRotation, 0);
        transform.eulerAngles = new Vector3(xRotation, yRotation, 0);
    }
}
