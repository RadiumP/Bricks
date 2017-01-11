using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{

    static MusicPlayer instance = null;//need static var to stop creating new

    //awake - start - update

    //singletion pattern 
    //http://gameprogrammingpatterns.com/singleton.html
    void Awake()
    {
        //Debug.Log("MP" + GetInstanceID());
        //fix the double playing glitch
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            GameObject.DontDestroyOnLoad(gameObject);//make bgm continue in every scene
        }

    }

    // Use this for initialization
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

    }
}
