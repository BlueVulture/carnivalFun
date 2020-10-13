using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class delete_ball : MonoBehaviour {

    public static int lives = 3;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Destroy(gameObject, 2);
    }

    void OnDestroy()
    {
        //Debug.Log("dekonstruktor klican");
        if(gameObject.tag == "LostBall")
        {
            fps_throw_ball.score -= 5;
            lives--;
        }
        
    }
}
