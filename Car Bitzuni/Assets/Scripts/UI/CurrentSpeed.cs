using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VehiclePhysics;
using UnityEngine.UI;
using UnityEngine.Rendering;

public class CurrentSpeed : MonoBehaviour
{
    Text text;
    public VPVehicleController controller;

    private void Start()
    {
        text = GetComponent<Text>();
    }
    void Update()
    {
        text.text =  "" + (controller.speed * 3.6f).ToString("0.00");
    }
}
