using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VehiclePhysics;
/// <summary>
/// Need to display data about the AVERAGE_SPEED, MAX_SPEED, TIME (& LAP_TIME if at Circuit) at the end of the game,
/// </summary>
[System.Serializable]
public struct TrackData 
{
    public float maxSpeed;
    public float averageSpeed;
    public float totalTime;
    public float lapTime;
}

public class DataManager : MonoBehaviour
{
    public static DataManager Instance { get; private set; }

    public TrackData data;
    public TrackData[] AllTracksData = new TrackData[4];
    private int dataIndex = 0;
    public VPVehicleController controller;

    private float speedCounter;
    private float addTimer;
    private float addCounter;
    private float currentSpeed;
    public float countDownTimer;
    public bool isCounting = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else 
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        Init();
    }
    public void AddData() 
    {
        AllTracksData[dataIndex] = data;
        dataIndex ++;
    }
    public void Init()
    {
        countDownTimer = 4;
        isCounting = false;
        speedCounter = 0;
        data.maxSpeed = 0;
        currentSpeed = 0;
        data.averageSpeed = 0;
        data.totalTime = 0;
        data.lapTime = 0;
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
            data.averageSpeed = speedCounter / addCounter;

            //GetMaxSpeed
            if (currentSpeed > data.maxSpeed) 
            {
                data.maxSpeed = currentSpeed;
            }

            //RunTimers and Get Lap and total time
            data.totalTime += Time.deltaTime;
            data.lapTime += Time.deltaTime;
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
            controller = FindObjectOfType<VPVehicleController>();
            countDownTimer -= Time.deltaTime;
        }
        TimerRunning(true);
    }
    public int GetCountDown() 
    {
        return (int)countDownTimer;
    }
}
