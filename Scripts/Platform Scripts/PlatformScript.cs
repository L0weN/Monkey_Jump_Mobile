using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScript : MonoBehaviour
{
    [SerializeField]
    public GameObject singleBanana, multiBanana;

    [SerializeField]
    public Transform spawnPoint;
    void Start()
    {
        GameObject newBanana = null;

        if (Random.Range(0, 10) > 3)
        {
            newBanana = Instantiate(singleBanana, spawnPoint.position, Quaternion.identity);
        }
        else
        {
            newBanana = Instantiate(multiBanana, spawnPoint.position, Quaternion.identity);
        }

        newBanana.transform.parent = transform;
    }

}
