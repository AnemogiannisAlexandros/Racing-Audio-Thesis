using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VehiclePhysics;

public class CameraOverride : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<VPCameraController>().customCameraIndex = 2;

        GetComponent<VPCameraController>().mode = VPCameraController.Mode.SmoothFollow;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
