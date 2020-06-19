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
    public DataManager manager;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        manager = FindObjectOfType<DataManager>();
        MaxSpeed.text = "Max Speed : " + manager.data.maxSpeed.ToString("0.00");
        AverageSpeed.text = "Avg Speed : " + manager.data.averageSpeed.ToString("0.00");
        TotalTime.text = "Time : " + manager.data.totalTime.ToString("0.00");
        LapTime.text = "Lap : " + manager.data.lapTime.ToString("0.00");

    }
}
