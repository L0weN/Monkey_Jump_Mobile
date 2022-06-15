using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Background" || collision.tag == "Platform" ||
            collision.tag == "NormalPush" || collision.tag == "ExtraPush" ||
            collision.tag == "Bird")
        {
            collision.gameObject.SetActive(false);
        }
    }
}
