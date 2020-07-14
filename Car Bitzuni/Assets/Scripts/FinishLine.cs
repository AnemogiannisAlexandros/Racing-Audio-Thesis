using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            StartCoroutine(LoadNewScene());
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
