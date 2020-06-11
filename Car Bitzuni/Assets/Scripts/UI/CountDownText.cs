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
        man = FindObjectOfType<DataManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!man.isCounting)
        {
            text.text = "" + FindObjectOfType<DataManager>().GetCountDown();
        }
        else 
        {
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
