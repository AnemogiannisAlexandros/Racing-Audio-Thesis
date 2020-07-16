using UnityEngine;
using System.IO;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;
using UnityEditor;

public class NameData : ScriptableObject 
{
    public List<string> maleNames = new List<string>();
    public List<string> femaleNames = new List<string>();
    public List<string> sureNames = new List<string>();
    public void Init(List<string> maleNames, List<string> femaleNames, List<string> sureNames) 
    {
        this.maleNames = maleNames;
        this.femaleNames = femaleNames;
        this.sureNames = sureNames;
    }
}

public class Test : MonoBehaviour
{
    List<string> maleNames = new List<string>();
    List<string> femaleNames = new List<string>();
    List<string> sureNames = new List<string>();
    string name, surename;

    StreamReader reader = new StreamReader(@"c:\temp\m_f_surnames.csv");
    public Text UiText;

    private void Start()
    {
        ReadData();
        GenerateName();
        NameData nameData = ScriptableObject.CreateInstance<NameData>();
        nameData.Init(maleNames,femaleNames,sureNames);
        AssetDatabase.CreateAsset(nameData, "Assets/nameData.asset");
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            GenerateName();
        }
    }
    void GenerateName() 
    {
        int num = Random.Range(0, 2);
        switch (num)
        {
            case 0:
                {
                    name = maleNames[Random.Range(1, maleNames.Count - 1)];
                    break;
                }
            case 1:
                {
                    name = femaleNames[Random.Range(1, femaleNames.Count - 1)];
                    break;
                }
            default:
                {
                    name = "";
                    surename = "'";
                    break;
                }
        }
        surename = sureNames[Random.Range(1, sureNames.Count - 1)];
        UiText.text =  name + " " + surename[0] + surename.Trim(surename[0]).ToLower();
    }
    void ReadData() 
    {
        while (!reader.EndOfStream)
        {
            string line = reader.ReadLine();
            string[] values = line.Split(',');
            if (values[0] != "")
            {
                maleNames.Add(values[0]);
            }
            if (values[1] != "")
            {
                femaleNames.Add(values[1]);
            }
            if (values[2] != "")
            {
                sureNames.Add(values[2]);
            }
        }
    }
}
