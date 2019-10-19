using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
/// <summary>
/// File Name: GameController.cs
/// Author: Kevin Yuayan
/// Last Modified by: Kevin Yuayan
/// Date Last Modified: Oct. 19, 2019
/// Description: Controller that controls the game
/// Revision History:
/// </summary>
public class GameController : MonoBehaviour
{
    [Header("Scene Game Objects")]
    public GameObject cloud;
    public GameObject island;
    public int numberOfClouds;
    public List<GameObject> clouds;

    [Header("Audio Sources")]
    public SoundClip activeSoundClip;
    public AudioSource[] audioSources;

    [Header("Scoreboard")]
    [SerializeField]
    private int _lives;

    [SerializeField]
    private int _score;

    public Text livesLabel;
    public Text scoreLabel;
    public Text highScoreLabel;

    public GameObject scoreBoard;

    [Header("UI Control")]
    public GameObject startLabel;
    public GameObject startButton;
    public GameObject endLabel;
    public GameObject restartButton;

    // public properties
    public int Lives
    {
        get
        {
            return _lives;
        }

        set
        {
            _lives = value;
            if(_lives < 1)
            {
                
                SceneManager.LoadScene("End");
            }
            else
            {
                livesLabel.text = "Lives: " + _lives.ToString();
            }
           
        }
    }

    public int Score
    {
        get
        {
            return _score;
        }

        set
        {
            // When player gains score, updates highscore if it's higher
            _score = value;
            scoreBoard.GetComponent<ScoreBoard>().score = _score;
            if (scoreBoard.GetComponent<ScoreBoard>().highScore < _score)
            {
                scoreBoard.GetComponent<ScoreBoard>().highScore = _score;
            }
            scoreLabel.text = "Score: " + _score.ToString();
            // Checks if the player has 500 points to go to the next level
            if (_score == 100 && SceneManager.GetActiveScene().name != "Level2")
            {
                DontDestroyOnLoad(scoreBoard);
                SceneManager.LoadScene("Level2");
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        GameObjectInitialization();
        SceneConfiguration();

    }

    // Finds references to the game objects
    private void GameObjectInitialization()
    {
        scoreBoard = GameObject.Find("HighScore");

        startLabel = GameObject.Find("StartLabel");
        endLabel = GameObject.Find("EndLabel");
        startButton = GameObject.Find("StartButton");
        restartButton = GameObject.Find("RestartButton");
    }

    // Configures the Scene Objects
    private void SceneConfiguration()
    {

        switch (SceneManager.GetActiveScene().name)
        {
            case "Start":
                scoreLabel.enabled = false;
                livesLabel.enabled = false;
                highScoreLabel.enabled = false;
                endLabel.SetActive(false);
                restartButton.SetActive(false);
                activeSoundClip = SoundClip.NONE;
                break;
            case "Main":
            case "Level2":
                highScoreLabel.enabled = false;
                startLabel.SetActive(false);
                startButton.SetActive(false);
                endLabel.SetActive(false);
                restartButton.SetActive(false);
                activeSoundClip = SoundClip.ENGINE;
                break;
            case "End":
                scoreLabel.enabled = false;
                livesLabel.enabled = false;
                startLabel.SetActive(false);
                startButton.SetActive(false);
                activeSoundClip = SoundClip.NONE;
                highScoreLabel.text = "High Score: " + scoreBoard.GetComponent<ScoreBoard>().highScore;
                break;
        }


        if (SceneManager.GetActiveScene().name == "Main")
        {
            scoreBoard.GetComponent<ScoreBoard>().score = 0;
            scoreBoard.GetComponent<ScoreBoard>().lives = 5;
        }
        Lives = scoreBoard.GetComponent<ScoreBoard>().lives;
        Score = scoreBoard.GetComponent<ScoreBoard>().score;


        if ((activeSoundClip != SoundClip.NONE) && (activeSoundClip != SoundClip.NUM_OF_CLIPS))
        {
            AudioSource activeAudioSource = audioSources[(int)activeSoundClip];
            activeAudioSource.playOnAwake = true;
            activeAudioSource.loop = true;
            activeAudioSource.volume = 0.5f;
            activeAudioSource.Play();
        }



        // creates an empty container (list) of type GameObject
        clouds = new List<GameObject>();

        for (int cloudNum = 0; cloudNum < numberOfClouds; cloudNum++)
        {
            clouds.Add(Instantiate(cloud));
        }

        Instantiate(island);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Event Handlers
    public void OnStartButtonClick()
    {
        DontDestroyOnLoad(scoreBoard);
        SceneManager.LoadScene("Main");
    }

    public void OnRestartButtonClick()
    {
        SceneManager.LoadScene("Main");
    }
}
