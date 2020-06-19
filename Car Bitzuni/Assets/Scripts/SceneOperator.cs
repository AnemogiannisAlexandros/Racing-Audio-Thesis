using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneOperator : MonoBehaviour
{
    public static SceneOperator Instance { get; private set; }
    public SceneAsset[] scenes;
    public AudioClip[] tracks = new AudioClip[2];
    private SceneAsset[] chosenScenes = new SceneAsset[2];
    private scenesTracked[] scenesTrackeds;

    private struct scenesTracked 
    {
        public SceneAsset scene;
        public int timesPlayed;
    }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }
    private void Start()
    {
        scenesTrackeds = new scenesTracked[2];
        ChooseCandidateScenes();
    }
    void ChooseCandidateScenes() 
    {
        for (int i = 0; i < 2; i++) 
        {
            chosenScenes[i] = scenes[Random.Range(0, 4)];
        }
        while (chosenScenes[0] == chosenScenes[1]) 
        {
            chosenScenes[1] = scenes[Random.Range(0, 4)];
        }
        for (int i = 0; i < 2; i++)
        {
            Debug.Log(chosenScenes[0].name + "  " + chosenScenes[1].name);
        }
    }
    public void LoadNewScene() 
    {
        if (scenesTrackeds[0].scene == null)
        {
            if (scenesTrackeds[0].timesPlayed == 0)
            {
                SceneManager.LoadScene(chosenScenes[0].name);
                AudioManager.Instance.LoadTrack(tracks[0]);
                scenesTrackeds[0].timesPlayed = 1;
            }
            else
            {
                SceneManager.LoadScene(chosenScenes[0].name);
                AudioManager.Instance.LoadTrack(tracks[1]);
                scenesTrackeds[0].scene = chosenScenes[0];
            }
        }
        else 
        {
            if (scenesTrackeds[1].timesPlayed == 0)
            {
                SceneManager.LoadScene(chosenScenes[1].name);
                AudioManager.Instance.LoadTrack(tracks[0]);
                scenesTrackeds[1].timesPlayed = 1;
            }
            else
            {
                SceneManager.LoadScene(chosenScenes[1].name);
                AudioManager.Instance.LoadTrack(tracks[1]);
                scenesTrackeds[1].scene = chosenScenes[1];
            }
        }
    }
}
