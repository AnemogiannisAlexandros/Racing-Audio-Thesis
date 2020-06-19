using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CheckPointManager : MonoBehaviour
{
    public UnityEvent WrongWay, RightWay;
    public CheckPoint[] checkPoints;
    private int checkPointIndex = 0;


    private void Start()
    {
        checkPointIndex = 0;
    }

    public void CheckPointPassed(CheckPoint checkpoint) 
    {
        if (checkPointIndex <= checkPoints.Length - 1 && checkPointIndex >= 0)
        {
            if (checkpoint == checkPoints[checkPointIndex])
            {
                RightWay.Invoke();
                checkPointIndex++;
                Debug.Log("Good");
            }
            else
            {
                Debug.Log("BAD");
                WrongWay.Invoke();
                checkPointIndex--;
            }
        }
        else if (checkPointIndex < 0)
        {
            checkPointIndex = 0;
        }
        else if (checkPointIndex >= checkPoints.Length) 
        {
            checkPointIndex = checkPoints.Length - 1;
        }
    }
}
