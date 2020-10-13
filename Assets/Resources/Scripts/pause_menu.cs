using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pause_menu : MonoBehaviour {

    public bool paused = false;
    public GameObject pauseMenu;
    public CanvasGroup menu;

    public Text ScoreText;

    public GameObject gameOverMenu;
    public static CanvasGroup overMenu;


    private void Start()
    {
        pauseMenu = GameObject.FindGameObjectWithTag("PauseMenu");
        menu = pauseMenu.GetComponent<CanvasGroup>();
        Hide(menu);
        Debug.Log("Menu screen hiden!");


        gameOverMenu = GameObject.FindGameObjectWithTag("GameOverMenu");
        overMenu = gameOverMenu.GetComponent<CanvasGroup>();
        Hide(overMenu);
        Debug.Log("Game over screen hiden!");
    }

    public void Hide(CanvasGroup hidee)
    {
        hidee.alpha = 0f;
        hidee.blocksRaycasts = false;
        Debug.Log(hidee.ToString() + " hiden!");
    }

    public void Show(CanvasGroup hidee)
    {
        hidee.alpha = 1f;
        hidee.blocksRaycasts = true; 
    }

    void StoreHighscore(int newHighscore)
    {
        int oldHighscore = PlayerPrefs.GetInt("highscore", 0);
        if (newHighscore > oldHighscore)
            PlayerPrefs.SetInt("highscore", newHighscore);
    }

    public void Pause()
    {
        if (!paused && delete_ball.lives > 0)
        {
            GameObject kamera = GameObject.FindGameObjectWithTag("MainCamera");
            kamera.GetComponent<fps_throw_ball>().enabled = false;
            Time.timeScale = 0.0f;
            paused = true;
            Show(menu);
        }
        else if (paused && delete_ball.lives > 0)
        {
            GameObject kamera = GameObject.FindGameObjectWithTag("MainCamera");
            kamera.GetComponent<fps_throw_ball>().enabled = true;
            Time.timeScale = 1.0f;
            paused = false;
            Hide(menu);
        }
        else if(delete_ball.lives <= 0)
        {
            GameObject kamera = GameObject.FindGameObjectWithTag("MainCamera");
            kamera.GetComponent<fps_throw_ball>().enabled = false;
            Time.timeScale = 0.0f;
            paused = true;
            StoreHighscore(fps_throw_ball.score);
            ScoreText.text = fps_throw_ball.score.ToString();
            Show(overMenu);
        }
        
    }
}
