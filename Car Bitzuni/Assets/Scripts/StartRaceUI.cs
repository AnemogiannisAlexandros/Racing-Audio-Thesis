using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartRaceUI : MonoBehaviour
{
    public void StartRace() 
    {
        SceneOperator.Instance.LoadNewScene();
        this.gameObject.SetActive(false);
    }
}
