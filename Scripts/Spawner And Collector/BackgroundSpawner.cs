using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSpawner : MonoBehaviour
{
    private GameObject[] backgrounds;
    private float height;
    private float highest_Y_pos;
    void Awake()
    {
        backgrounds = GameObject.FindGameObjectsWithTag("Background");
    }
    void Start()
    {
        height = backgrounds[0].GetComponent<BoxCollider2D>().bounds.size.y;

        highest_Y_pos = backgrounds[0].transform.position.y;

        for(int i= 1; i < backgrounds.Length; i++)
        {
            if(backgrounds[i].transform.position.y > highest_Y_pos)
            {
                highest_Y_pos = backgrounds[i].transform.position.y;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Background")
        {
            if(collision.transform.position.y >= highest_Y_pos)
            {
                Vector3 temp = collision.transform.position;

                for(int i=0; i < backgrounds.Length; i++)
                {
                    if (!backgrounds[i].activeInHierarchy)
                    {
                        temp.y += height;
                        backgrounds[i].transform.position = temp;
                        backgrounds[i].gameObject.SetActive(true);
                        highest_Y_pos = temp.y;
                    }
                }
            }
        }
    }
}
