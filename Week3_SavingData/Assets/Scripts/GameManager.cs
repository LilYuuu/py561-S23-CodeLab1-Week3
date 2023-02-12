using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int score = 0;

    public int currentLevel = 0;

    public int targetScore = 5;

    public float currTime = 0.0f;

    // public float CurrTime
    // {
    //     get
    //     {
    //         return currTime;
    //     }
    //     set
    //     {
    //         currTime = value;
    //
    //         if (currTime <= ShortestTime && currentLevel == 2)
    //         {
    //             ShortestTime = currTime;
    //             Debug.Log("update record");
    //         }
    //     }
    //     
    // }
    
    private const string DIR_DATA = "/Data/";
    private const string FILE_SHORTEST_TIME = "shortestTime.txt";
    private string PATH_SHORTEST_TIME;
    
    private float shortestTime = 40.0f;

    public float ShortestTime
    {
        get
        {
            return shortestTime;
        }

        set
        {
            shortestTime = value;

            if (File.Exists(PATH_SHORTEST_TIME))
            {
                File.WriteAllText(PATH_SHORTEST_TIME, "" + shortestTime);
                Debug.Log("update file");
            }
            else
            {
                Directory.CreateDirectory(Application.dataPath + DIR_DATA);
                Debug.Log("create new file");
            }
        }
    }
    
    public TextMeshProUGUI textMeshPro;
    
    void Awake()    // Called when the script is being loaded
    {
        if (Instance == null)   // Instance has not been set
        {
            DontDestroyOnLoad(gameObject);  // Don't destroy
            Instance = this;    // Set Instance
        }
        else // Instance is set
        {
            Destroy(gameObject);
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        PATH_SHORTEST_TIME = Application.dataPath + DIR_DATA + FILE_SHORTEST_TIME;
        
        if (File.Exists(PATH_SHORTEST_TIME))
        {
            ShortestTime = float.Parse(File.ReadAllText(PATH_SHORTEST_TIME));    
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (currentLevel != 2 && currentLevel != -1)
        {
            // CurrTime = Time.time;
            currTime = Time.timeSinceLevelLoad;
        }

        if (currTime <= ShortestTime && currentLevel == 2)
        {
            ShortestTime = currTime;
            Debug.Log("update record");
        }
        
        textMeshPro.text = 
            "Level: " + (currentLevel + 1) + "\n" + 
            "Time used: " + currTime.ToString("N1") + "\n" + 
            "Best record: " + ShortestTime.ToString("N1");
        
        // if (score == targetScore || Input.GetKey(KeyCode.Return))   // for debugging purpose
        if (score == targetScore) 
        {
            currentLevel++;
            SceneManager.LoadScene(currentLevel);
            score = 0;
        }
        
        // winner scene
        if (currentLevel == 2)
        {
            WASDControl.Instance.rb2d.gameObject.SetActive(false);
        }
        
    }
}
