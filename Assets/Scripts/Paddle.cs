using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{

    public bool autoPlay = false;

    private Ball ball;

    float mousePosInBlocks;
   
    void Start()
    {
        ball = GameObject.FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!autoPlay)
        {
            MoveWithMouse();
        }
        else
        {
            AutoPlay();
        }

    }

    void MoveWithMouse()
    {
        Vector3 paddlePos = new Vector3(0.5f, this.transform.position.y, 0f);

        mousePosInBlocks = Input.mousePosition.x / Screen.width * 12.8f;

        paddlePos.x = Mathf.Clamp(mousePosInBlocks, 0.9f, 11.9f);

        this.transform.position = paddlePos;
    }
    //automated test
    void AutoPlay()
    {
        Vector3 paddlePos = new Vector3(0.5f, this.transform.position.y, 0f);
        float ballPos = ball.transform.position.x;
       
        paddlePos.x = Mathf.Clamp(ballPos, 0.9f, 11.9f);

        this.transform.position = paddlePos;
    }
}
