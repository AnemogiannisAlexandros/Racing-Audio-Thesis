using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class SceneOperator : MonoBehaviour
{
    public static SceneOperator Instance { get; private set; }
    public SceneAsset[] scenes;
    public List<AudioClip> fastTracks = new List<AudioClip>(2);
    public List<AudioClip> slowTracks = new List<AudioClip>(2);
    public List<AudioClip> tracksArranged = new List<AudioClip>();
    private SceneAsset[] chosenScenes = new SceneAsset[2];
    public UnityEvent OnTrackFinished;
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
        ArangeTracks();
    }
    void ArangeTracks() 
    {
        int firstTrackRandom = Random.Range(0, 2);
        if (firstTrackRandom == 0)
        {
            for (int i = 0; i <= 1; i++)
            {
                int clipIndex = Random.Range(0, fastTracks.Count);
                tracksArranged.Add(fastTracks[clipIndex]);
                fastTracks.RemoveAt(clipIndex);
                clipIndex = Random.Range(0, slowTracks.Count);
                tracksArranged.Add(slowTracks[clipIndex]);
                slowTracks.RemoveAt(clipIndex);
            }
        }
        else 
        {
            for (int i = 0; i <= 1; i++)
            {
                int clipIndex = Random.Range(0, slowTracks.Count);
                tracksArranged.Add(slowTracks[clipIndex]);
                slowTracks.RemoveAt(clipIndex);
                clipIndex = Random.Range(0, fastTracks.Count);
                tracksArranged.Add(fastTracks[clipIndex]);
                fastTracks.RemoveAt(clipIndex);
            }
        }
        for (int i = 0; i <= tracksArranged.Count - 1; i++)
        {
            Debug.Log(tracksArranged[i].name);
        }
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

        Debug.Log(chosenScenes[0].name + "  " + chosenScenes[1].name);
    }
    public void LoadNewScene() 
    {
        if (SceneManager.GetActiveScene().name != "PlayGround")
        {
            OnTrackFinished.Invoke();
        }

        if (scenesTrackeds[0].timesPlayed == 0)
        {
            SceneManager.LoadScene(chosenScenes[0].name);
            AudioManager.Instance.LoadTrack(tracksArranged[0]);
            scenesTrackeds[0].timesPlayed = 1;
        }
        else if (scenesTrackeds[1].timesPlayed == 0)
        {
            SceneManager.LoadScene(chosenScenes[1].name);
            AudioManager.Instance.LoadTrack(tracksArranged[1]);
            scenesTrackeds[1].timesPlayed = 1;
        }
        else if (scenesTrackeds[0].timesPlayed == 1)
        {
            SceneManager.LoadScene(chosenScenes[0].name);
            AudioManager.Instance.LoadTrack(tracksArranged[2]);
            scenesTrackeds[0].timesPlayed = 2;

        }
        else if (scenesTrackeds[1].timesPlayed == 1)
        {
            SceneManager.LoadScene(chosenScenes[1].name);
            AudioManager.Instance.LoadTrack(tracksArranged[3]);
            scenesTrackeds[1].timesPlayed = 2;
        }
        else 
        {
            SceneManager.LoadScene("ThankYou");
        }
        DataManager.Instance.Init();
    }
}
