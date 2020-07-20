using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDownText : MonoBehaviour
{
    Text text;
    DataManager man;
    private bool runOnce = false;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
       
        runOnce = false;
    }

    // Update is called once per frame
    void Update()
    {
        man = FindObjectOfType<DataManager>();
        if (!man.isCounting)
        {

            text.text = "" + FindObjectOfType<DataManager>().GetCountDown();
        }
        else 
        {
            Debug.Log("Counting");

            if (!runOnce) 
            {
                StartCoroutine(CountDownTextChanger());
            }
        }
    }
    private IEnumerator CountDownTextChanger() 
    {
        text.text = "GO!";
        yield return new WaitForSeconds(1.2f);
        runOnce = true;
        text.gameObject.SetActive(false);
    }
}
