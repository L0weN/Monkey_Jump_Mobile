using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawn : MonoBehaviour
{
    public static PlatformSpawn instance;

    [SerializeField]
    private GameObject leftPlatform,rightPlatform;

    private float left_X_min = -4.4f, left_X_max = -2.8f, right_X_min = 4.4f, right_X_max = 2.8f;
    private float y_Treshold = 2.6f;
    private float last_Y;

    public int spawnCount = 8;
    private int platformSpawned;

    [SerializeField]
    public Transform platformParent;

    [SerializeField]
    private GameObject bird;
    public float bird_Y = 5f;
    private float bird_X_min = -2.3f, bird_X_max = 2.3f;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        last_Y = transform.position.y;

        SpawnPlatforms();
    }

    void Update()
    {
        
    }

    public void SpawnPlatforms()
    {
        Vector2 temp = transform.position;
        GameObject newPlatform = null;

        for(int i = 0; i < spawnCount; i++)
        {
            temp.y = last_Y;

            if ((platformSpawned % 2) == 0)
            {
                temp.x = Random.Range(left_X_min, left_X_max);
                newPlatform = Instantiate(rightPlatform, temp, Quaternion.identity);
            }
            else
            {
                temp.x = Random.Range(right_X_min, right_X_max);
                newPlatform = Instantiate(leftPlatform, temp, Quaternion.identity);
            }
            newPlatform.transform.parent = platformParent;
            last_Y += y_Treshold;
            platformSpawned++;
        }
        if (Random.Range(0, 2) > 0)
        {
            SpawnBird();
        }
    }

    void SpawnBird()
    {
        Vector2 temp = transform.position;
        temp.x = Random.Range(bird_X_min, bird_X_max);
        temp.y += bird_Y;
        
        GameObject newBird = Instantiate(bird, temp, Quaternion.identity);
        newBird.transform.parent = platformParent;
    }
}
