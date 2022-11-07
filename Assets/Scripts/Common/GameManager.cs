using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Prefabs")] 
    public GameObject ballPrefab;

    [Header("Scripts")] 
    public UIController uiController;
    public WallSpawner wallSpawner;

    [Header("Parameters")]
    [Range(1f, 3f)] public static int HardMode = 1;
    public static bool IsRestart;
    public float verticalMovementUpgradeValue = 1.4f;
    public static int CountAttempt;

    private DateTime _startTime;

    //hidens
    private GameObject _ball;

    private void Awake()
    {
        if (Instance != null) Destroy(gameObject);
        else Instance = this;

        CountAttempt = PlayerPrefs.GetInt("countAttempt");
        
        if (IsRestart) StartGame();
        else
        {
            HardMode = 1;
        }
        
    }

    private void OnApplicationPause(bool pauseStatus)
    {
        PlayerPrefs.SetInt("countAttempt", CountAttempt);
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("countAttempt", CountAttempt);
    }

    public void StartGame()
    {
        //date time
        _startTime = DateTime.Now;
        
        //panels
        uiController.startPanel.panel.Close();
        uiController.endPanel.panel.Close();
        
        //instantiate
        _ball = Instantiate(ballPrefab);
        
        //Update followers
        var followers2D = FindObjectsOfType<Follow2D>();
        foreach (var follower in followers2D)
        {
            follower.SetStart();
        }

        //spawning wall
        wallSpawner.isOn = true;
        StartCoroutine(wallSpawner.Spawning());

        IsRestart = false;
    }

    public void EndGame()
    {
        CountAttempt++;

        uiController.endPanel.SetData((int)(DateTime.Now - _startTime).TotalSeconds+1, CountAttempt);
        uiController.endPanel.panel.Open();
        
        if (_ball) Destroy(_ball);
        wallSpawner.isOn = false;
    }

    public void Restart()
    {
        IsRestart = true;
        PlayerPrefs.SetInt("countAttempt", CountAttempt);
        SceneManager.LoadSceneAsync(0);
    }
    
    public void ChangeHardMode()
    {
        IsRestart = false;
        PlayerPrefs.SetInt("countAttempt", CountAttempt);
        SceneManager.LoadSceneAsync(0);
    }
    public void ChangeHardMode(int value)
    {
        HardMode = value;
    }

}
