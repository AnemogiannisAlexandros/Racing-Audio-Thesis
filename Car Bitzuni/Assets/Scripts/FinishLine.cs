using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    public int trackLaps;
    public int currentlap = 1;
    public Collider lastCheckpoint;
    public bool allowFinish=false;
    private void Start()
    {
        if (trackLaps != 0) 
        {
            FindObjectOfType<SceneOperator>().SetLaps(trackLaps);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            if (trackLaps == 0 || currentlap > trackLaps)
            {
                StartCoroutine(LoadNewScene());
                SceneOperator.Instance.OnTrackFinished.Invoke();
            }
            else 
            {
                currentlap++;
                FindObjectOfType<SceneOperator>().SetLaps(currentlap);
                FindObjectOfType<CheckPointManager>().SetCheckpointIndex(0);
                FindObjectOfType<DataManager>().countLapTime = false;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            FindObjectOfType<FinishLine>().allowFinish = false;
            FindObjectOfType<FinishLine>().GetComponent<Collider>().isTrigger = false;
        }
    }
    IEnumerator LoadNewScene() 
    {
        SceneOperator.Instance.trackFinished.gameObject.SetActive(true);
        float timer = 4;
        while (timer > 0) 
        {
            SceneOperator.Instance.trackFinished.text = "Track Finished!\nNew Track Begins In : " + Mathf.Round(timer);
            timer -= Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        SceneOperator.Instance.trackFinished.gameObject.SetActive(false);
        SceneOperator.Instance.LoadNewScene();
    }
}
