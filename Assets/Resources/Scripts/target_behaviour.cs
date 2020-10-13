using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class target_behaviour : MonoBehaviour {

    public float speed;
    public Vector3 target;

    private void Start()
    {
        speed = 3.5f;
        //target = new Vector3(90.75f, 13.24f, 121.5f);
        target = gameObject.transform.position + new Vector3(0, 3, 0);
    }

    void Update()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target, step);
    }

    void OnCollisionEnter(Collision collision)
    {
        Collider m_Collider = GetComponent<Collider>();

        m_Collider.enabled = false;

        //print("Detected collision between " + gameObject.name + " and " + collision.collider.name);

        Destroy(gameObject);
        collision.collider.gameObject.tag = "Untagged";
        Destroy(collision.collider.gameObject);

        spawn_target_1.spawnNum = spawn_target_1.spawnNum - 0.5f;
        fps_throw_ball.score += 10;
    }
}
