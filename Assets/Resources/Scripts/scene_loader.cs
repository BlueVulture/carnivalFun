using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class scene_loader : MonoBehaviour {


    public void NextScene()
    {
        SceneManager.LoadScene("carnivalfun");
        delete_ball.lives = 3;
        Time.timeScale = 1.0f;
        fps_throw_ball.score = 0;
    }

    public void LastScene()
    {
        gameObject.GetComponent<pause_menu>().Hide(pause_menu.overMenu);

        SceneManager.LoadScene("mainmenu");
    }
}
