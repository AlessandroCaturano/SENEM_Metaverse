using UnityEngine;

public class CameraFacer : MonoBehaviour
{
    GameObject vrCamera;

    private void LateUpdate()
    {
        if (!vrCamera)
            vrCamera = GameObject.FindWithTag("VRCamera");
        // Makes the player name always face the active camera
        if (Camera.main)
            transform.LookAt(Camera.main.transform);
        else if(vrCamera)
            transform.LookAt(vrCamera.transform);
        transform.Rotate(0, 180, 0);
    }
}
