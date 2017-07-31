using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class uiManager : MonoBehaviour {

    public Text scoreText;
    public int score;
    bool gameOver;

	// Use this for initialization
	void Start () {
        gameOver = false;
        score = 0;
        InvokeRepeating("scoreUpdate", 1.0f, 0.5f);
	}
	
	// Update is called once per frame
	void Update () {
        scoreText.text = "Score: " + score;
	}

    public void scoreUpdate()
    {
        if(!gameOver)
            score++;
    }

    public void setGameOVer()
    {
        gameOver = true;
    }

    public void Play()
    {
        //Application.LoadLevel("level1");
        SceneManager.LoadScene("level1");
    }

    public void Pause()
    {
        if (Time.timeScale == 1)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
    }

    public void Replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Menu()
    {
        SceneManager.LoadScene("menu");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
