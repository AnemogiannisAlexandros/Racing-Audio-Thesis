using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartRaceUI : MonoBehaviour
{
    public void StartRace() 
    {
        if (SceneManager.GetActiveScene().name != "PlayGround")
        {
            FindObjectOfType<DataManager>().AddData();
        }
        SceneOperator.Instance.LoadNewScene();

        //this.gameObject.SetActive(false);
    }
}
