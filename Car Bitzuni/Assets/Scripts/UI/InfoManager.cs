using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InfoManager : MonoBehaviour
{

    public Text MaxSpeed;
    public Text AverageSpeed;
    public Text TotalTime;
    public Text LapTime;
    private DataManager manager;
    // Start is called before the first frame update
    void Start()
    {
       manager =  FindObjectOfType<DataManager>();
    }

    // Update is called once per frame
    void Update()
    {
        MaxSpeed.text = "Max Speed : " + manager.maxSpeed.ToString("0.00");
        AverageSpeed.text = "Avg Speed : " + manager.averageSpeed.ToString("0.00");
        TotalTime.text = "Time : " + manager.totalTime.ToString("0.00");
        LapTime.text = "Lap : " + manager.lapTime.ToString("0.00");

    }
}
