using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    private Paddle paddle;
    public Vector2 shootVel;

    private bool hasStarted = false;
    private Vector3 paddleToBallVector;
    private Rigidbody2D ball;
    private AudioSource sound;
    // Use this for initialization
    void Start()
    {
        paddle = GameObject.FindObjectOfType<Paddle>();//looling for the paddle
        paddleToBallVector = this.transform.position - paddle.transform.position;
        ball = GetComponent<Rigidbody2D>();
        sound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)//to make sure the ball launches
        {
            //lock the ball to paddle
            this.transform.position = paddle.transform.position + paddleToBallVector; //script execution order: paddle then ball --- to make the ball separation glitch in high speed

            //shoot the ball
            if (Input.GetMouseButtonDown(0))
            {
                
                hasStarted = true;
                //changing gravity in physics setting instead of changing gravity scale
                ball.velocity = shootVel + new Vector2(Random.Range(-1f, 1f), 0f);
            }
        }
       
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 tweak = new Vector2(Random.Range(-1f, 1f), Random.Range(0f, 0.2f));//avoid boring loop
        if (hasStarted)
        {
            sound.volume = 0.5f;
            sound.Play();
            ball.velocity += tweak;
            Debug.Log(ball.velocity);
            if (Mathf.Abs(ball.velocity.x) <= 0f || Mathf.Abs(ball.velocity.x) > 5f || Mathf.Abs(ball.velocity.y) > 9.5f)
            {
                ball.velocity = new Vector2(Random.Range(-1f, 1f), 8f);
            }
        }
        
    }
}
