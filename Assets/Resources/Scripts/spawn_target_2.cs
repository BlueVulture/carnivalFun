using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn_target_2 : MonoBehaviour
{

    public static bool doesExist = false;
    public Transform target;
    bool waitActive = false; //so wait function wouldn't be called many times per frame
    GameObject[] spawnedTargets = spawn_target_1.spawnedTargets;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
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

        Instantiate(target, new Vector3(Random.Range(82.2f, 97.9f), 7.5f, 121.5f), Quaternion.Euler(new Vector3(0, 180, 0)));
        //doesExist = true;
        //Debug.Log(spawn_target_1.spawnNum);
        spawn_target_1.spawnNum++;

        waitActive = false;
    }
}
