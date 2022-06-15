using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform monkey;
    private bool followMonkey;
    public float min_Y_Treshold = -2.6f;

    void Awake()
    {
        monkey = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        Follow();
    }

    void Follow()
    {
        if(monkey.position.y < (transform.position.y - min_Y_Treshold))
        {
            followMonkey = false;
        }

        if (monkey.position.y > transform.position.y)
        {
            followMonkey = true;
        }

        if (followMonkey)
        {
            Vector3 temp = transform.position;
            temp.y = monkey.position.y;
            transform.position = temp;
        }
    }
}
