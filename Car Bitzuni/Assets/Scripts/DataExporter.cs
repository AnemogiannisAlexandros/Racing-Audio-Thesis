using EdyCommonTools;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using System.Xml;
using UnityEngine;



public class DataExport : ScriptableObject 
{
    public TrackData[] trackData;
    public void Init(TrackData[] dataRecorded) 
    {
        this.trackData = dataRecorded;
         for(int i =0;i<trackData.Length;i++)
        {
            trackData[i].maxSpeed = Math.Round(dataRecorded[i].maxSpeed, 2);
            trackData[i].averageSpeed = Math.Round(dataRecorded[i].averageSpeed,2);
            trackData[i].lapTime = Math.Round(dataRecorded[i].lapTime,3);
            trackData[i].totalTime = Math.Round(dataRecorded[i].totalTime,3);
        }
    }
}
public class DataExporter : MonoBehaviour
{
    DataExport export;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(FindObjectOfType<SceneOperator>());
        export = ScriptableObject.CreateInstance<DataExport>();
        export.Init(FindObjectOfType<DataManager>().AllTracksData);
        StartCoroutine(SaveData());
    }

    IEnumerator SaveData() 
    {
        Debug.Log("Exporting Data : " + (DataExport)export);
        string data = JsonUtility.ToJson(export,true);
        string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/data.txt";
        Debug.Log(data);
        Debug.Log(path);
        int index = 0;
        while (File.Exists(path))
        {
            index++;
            Debug.Log("Noice");
            path  = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/data" + index + ".txt" ;
            yield return null;
        }
        File.WriteAllText(path, data,Encoding.UTF8);
    }
}
