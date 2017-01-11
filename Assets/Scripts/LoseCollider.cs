using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//collison detection void onCollisionEnter2D
//Triggers OnTriggerEnter2D : ignored physics
public class LoseCollider : MonoBehaviour {

    private LevelManager lvlMng;

	void OnTriggerEnter2D(Collider2D trigger)
    {
        //print("Triggered");
        lvlMng = GameObject.FindObjectOfType<LevelManager>();
        lvlMng.LoadNewLevel("Lose");
    }
    //void OnCollisionEnter2D(Collision2D collision)
    //{
    //    print("Collided");
    //}

    void Start()
    {
        
    }
}
