using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class uiManager : MonoBehaviour {

   // private AudioSource[] allAudioSources;
    public Button[] buttons;
    public Text scoreText;
    public Text HighScore;
    public int score;
    public static int highestScore;
    bool gameOver;
    public audioManager am;

    // Use this for initialization
    void Start () {
        gameOver = false;
        score = 0;
        InvokeRepeating("scoreUpdate", 1.0f, 0.5f);
        //allAudioSources = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
        highestScore = PlayerPrefs.GetInt("Highscore", highestScore);
        highestScore = 5;
        setHighScore();
    }
	
	// Update is called once per frame
	void Update () {
        scoreText.text = "Score: " + score;
	}

    void setHighScore()
    {
        HighScore.text = "HighScore: " + highestScore.ToString();
    }

    public void scoreUpdate()
    {
        if(!gameOver)
            score++;
    }

    public void setGameOVer()
    {
        gameOver = true;
        if (score > highestScore)
        {
            highestScore = score;
            PlayerPrefs.SetInt("Highscore", highestScore);
            PlayerPrefs.Save();
        }
        foreach (Button button in buttons)
            button.gameObject.SetActive(true);
    }

    public void Play()
    {
        //Application.LoadLevel("level1");
        SceneManager.LoadScene("level1");
    }

    public void Pause()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
            am.carSound.Pause();
            //foreach (AudioSource audioS in allAudioSources)
            //{
            //    audioS.Pause();
            //}
        }
        else
        {
            Time.timeScale = 1;
            am.carSound.UnPause();
            //foreach (AudioSource audioS in allAudioSources)
            //{
            //    audioS.UnPause();
            //}
        }
    }

    public void Replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Menu()
    {
        SceneManager.LoadScene("menu");
        setHighScore();
    }

    public void Exit()
    {
        Application.Quit();
    }
}
