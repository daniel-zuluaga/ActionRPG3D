using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOrbit : MonoBehaviour
{
    public float lookSensitivity;
    public float minXLook;
    public float maxXLook;
    public Transform camAnchor;

    public bool invertXRotation;

    private float curXRot;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // called at the end of each frame  
    private void LateUpdate()
    {
        // get the mouse X and Y inputs 
        float x = Input.GetAxis("Mouse X");
        float y = Input.GetAxis("Mouse Y");

        // rotate the player horizontally
        transform.eulerAngles += Vector3.up * x * lookSensitivity;


        // rotate the player vertical

        if (invertXRotation)
            curXRot += y * lookSensitivity;
        else
            curXRot -= y * lookSensitivity;

        curXRot = Mathf.Clamp(curXRot, minXLook, maxXLook);

        Vector3 clampedAngle = camAnchor.eulerAngles;
        clampedAngle.x = curXRot;

        camAnchor.eulerAngles = clampedAngle;

    }


}
