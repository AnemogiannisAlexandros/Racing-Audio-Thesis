using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CheckPointManager : MonoBehaviour
{
    public UnityEvent WrongWay, RightWay;
    public CheckPoint[] checkPoints;
    private int checkPointIndex = 0;

    public void SetCheckpointIndex(int value) 
    {
        checkPointIndex = value;
    }
    private void Start()
    {
        checkPoints = new CheckPoint[transform.childCount];
        for (int i = 0; i < transform.childCount; i++) 
        {
            checkPoints[i] = transform.GetChild(i).GetComponent<CheckPoint>();
        }
        checkPointIndex = 0;
    }

    public void CheckPointPassed(CheckPoint checkpoint) 
    {
       
        if (checkPointIndex <= checkPoints.Length - 1 && checkPointIndex >= 0)
        {
            if (checkpoint == checkPoints[checkPointIndex])
            {
                RightWay.Invoke();
                if (checkpoint.gameObject.name == FindObjectOfType<FinishLine>().lastCheckpoint.gameObject.name)
                {
                    FindObjectOfType<FinishLine>().allowFinish = true;
                    FindObjectOfType<FinishLine>().GetComponent<Collider>().isTrigger = true;
                }
                checkPointIndex++;
                Debug.Log("Good");
            }
            else
            {
                Debug.Log("BAD");
                WrongWay.Invoke();
                FindObjectOfType<FinishLine>().allowFinish = false;
                FindObjectOfType<FinishLine>().GetComponent<Collider>().isTrigger = false;
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
