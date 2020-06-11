using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VehiclePhysics;
/// <summary>
/// Need to display data about the AVERAGE_SPEED, MAX_SPEED, TIME (& LAP_TIME if at Circuit) at the end of the game,
/// </summary>


public class DataManager : MonoBehaviour
{
    public float countDownTimer;
    public float maxSpeed;
    public float averageSpeed;
    public float totalTime;
    public float lapTime;
    public VPVehicleController controller;

    private float speedCounter;
    private float addTimer;
    private float addCounter;
    private float currentSpeed;
    public bool isCounting = false;
    // Start is called before the first frame update
    void Start()
    {
        speedCounter = 0;
        maxSpeed = 0;
        currentSpeed = 0;
        averageSpeed = 0;
        totalTime = 0;
        lapTime = 0;
        addTimer = 0;
        addCounter = 0;
        StartCoroutine(StartCountDown());
    }

    // Update is called once per frame
    void Update()
    {
        if (isCounting)
        {
            currentSpeed = controller.speed * 3.6f;
           //Average Calculation
            if (addTimer < 2) 
            {
                speedCounter += currentSpeed;
                addCounter++;
            }
            //AverageSpeed
            averageSpeed = speedCounter / addCounter;

            //GetMaxSpeed
            if (currentSpeed > maxSpeed) 
            {
                maxSpeed = currentSpeed;
            }

            //RunTimers and Get Lap and total time
            totalTime += Time.deltaTime;
            lapTime += Time.deltaTime;
        }
    }
    public void TimerRunning(bool isRunning) 
    {
        isCounting = isRunning;
    }

    IEnumerator StartCountDown() 
    {
        while (countDownTimer >= 1) 
        {
            yield return new WaitForEndOfFrame();
            countDownTimer -= Time.deltaTime;
        }
        TimerRunning(true);
    }
    public int GetCountDown() 
    {
        return (int)countDownTimer;
    }
}
