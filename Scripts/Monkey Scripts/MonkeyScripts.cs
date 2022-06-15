using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkeyScripts : MonoBehaviour
{
    public Rigidbody2D myBody;
    public float moveSpeed = 50f;
    public float normalPush = 10f;
    public float extraPush = 14f;

    private int pushCount;
    private bool playerDied;

    private Vector2 startTouchPosition;
    private Vector2 endTouchPosition;

    void Awake()
    {
        
    }

    void Update()
    {
        
    }

    void FixedUpdate()
    {
        Move();        
    }

    void Move()
    {
        if (playerDied)
            return;

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            startTouchPosition = Input.GetTouch(0).position;
        }
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            endTouchPosition = Input.GetTouch(0).position;

            if (endTouchPosition.x < startTouchPosition.x)
            {
                myBody.velocity = new Vector2(-moveSpeed, myBody.velocity.y);
            }
            if (endTouchPosition.x > startTouchPosition.x)
            {
                myBody.velocity = new Vector2(moveSpeed, myBody.velocity.y);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (playerDied)
            return;

        if (collision.tag == "ExtraPush")
        {
            myBody.velocity = new Vector2(myBody.velocity.x, extraPush);
            collision.gameObject.SetActive(false);
            SoundScript.instance.JumpSoundFX();
            pushCount++;
        }
        if (collision.tag == "NormalPush")
        {
            myBody.velocity = new Vector2(myBody.velocity.x, normalPush);
            collision.gameObject.SetActive(false);
            SoundScript.instance.JumpSoundFX();
            pushCount++;
        }

        if(pushCount == 2)
        {
            pushCount = 0;
            PlatformSpawn.instance.SpawnPlatforms();
        }

        if(collision.tag == "Fall Down" || collision.tag == "Bird")
        {
            playerDied = true;
            SoundScript.instance.GameOverSoundFX();
            GameManager.instance.RestartGame();
        }
    }
}
