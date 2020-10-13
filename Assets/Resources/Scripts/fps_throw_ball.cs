using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fps_throw_ball : MonoBehaviour {

    //var distance = 10.0;
    public static int score = 0;
    public Text ScoreText;

    public GameObject ball;

    public GameObject kanvas;


    public Image lifeBall;
    public Image Ball1;
    public Image Ball2;
    public Image Ball3;



    void OnGUI()
    {
        GUI.Box(new Rect(20, 50, 50, 25), spawn_target_1.spawnNum.ToString());
        GUI.Box(new Rect(20, 80, 50, 25), spawn_target_1.spawnedTargets.Length.ToString());
        GUI.Box(new Rect(80, 50, 50, 25), delete_ball.lives.ToString());
    }

    void Start () {
		
	}

    void RemoveLife(Image life)
    {
        lifeBall = life.GetComponent<Image>();

        Color c = lifeBall.color;
        c.a = 0;
        lifeBall.color = c;
    }
	
	void Update () {
        ScoreText.text = score.ToString();
        
        if(delete_ball.lives == 2)
        {
            RemoveLife(Ball1);
        }
        else if (delete_ball.lives == 1)
        {
            RemoveLife(Ball2);
        }
        else if (delete_ball.lives <= 0)
        {
            RemoveLife(Ball3);
            kanvas.GetComponent<pause_menu>().Pause();
        }

        if (Input.GetMouseButtonDown(0))
        {
            GameObject ball_thrown = (GameObject)Instantiate(ball, new Vector3(90, 8, 108), Quaternion.identity);
            ball_thrown.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);

            var position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f);
            position = Camera.main.ScreenToWorldPoint(position);

            ball_thrown.transform.LookAt(position);
            ball_thrown.GetComponent<Rigidbody>().AddForce(ball_thrown.transform.forward*35, ForceMode.Impulse);
        }
        else if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Touch touch = Input.GetTouch(0);
            GameObject ball_thrown = (GameObject)Instantiate(ball, new Vector3(90, 8, 108), Quaternion.identity);
            ball_thrown.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);

            var position = new Vector3(touch.position.x, touch.position.y, 10.0f);
            position = Camera.main.ScreenToWorldPoint(position);

            ball_thrown.transform.LookAt(position);
            ball_thrown.GetComponent<Rigidbody>().AddForce(ball_thrown.transform.forward * 35, ForceMode.Impulse);
        }


    }
}
