using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn_target_1 : MonoBehaviour {

    public static float spawnNum = 0;
    public Transform target;
    public static GameObject[] spawnedTargets;
    bool waitActive = false; //so wait function wouldn't be called many times per frame

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        spawnedTargets = GameObject.FindGameObjectsWithTag("Target");

        if (spawnedTargets.Length <= 3)
        {
            if (!waitActive)
            {
                StartCoroutine(Wait());
            }
        }

    //    if (spawnNum<1)
    //    {
    //        if (!waitActive)
    //        {
    //            StartCoroutine(Wait());
    //        }
    //    }
    }

    IEnumerator Wait()
    {
        waitActive = true;
        yield return new WaitForSeconds(Random.Range(1, 4));

        Instantiate(target, new Vector3(Random.Range(85.6f, 94.4f), 6.5f, 116.2f), Quaternion.Euler(new Vector3(0, 180, 0)));
        //Debug.Log(spawnNum);
        //doesExist = true;
        spawnNum++;

        waitActive = false;
    }
}
