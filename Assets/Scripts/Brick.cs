using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public static int breakableCount = 0;//static wont show in inspector

    public GameObject smoke;
    public Sprite[] hitSprites;//get break effect
    public AudioClip[] crack;

    //private AudioSource sound;
    private bool isBreakable;
    private int maxHits;
    private int timesHit;
    private LevelManager lvlMng;
    private int lvl;
    //snap setting for snap and grid: more accurate placing

    // Use this for initialization
    void Start()
    {
        isBreakable = (this.tag == "Breakable");
        if (isBreakable)
        {
            breakableCount++;
        }
        // sound = GetComponent<AudioSource>();
       
        lvlMng = GameObject.FindObjectOfType<LevelManager>();
        timesHit = 0;
        lvl = lvlMng.getLvl()-1;
        //Debug.Log(lvl);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //print(timesHit);
       
        if (isBreakable)
        {   
            
            AudioSource.PlayClipAtPoint(crack[lvl], transform.position, 1.0f);//static function 2.0f for volume
            
            HandleHits();
        }
    }


    void HandleHits()
    {
        timesHit++;
        maxHits = hitSprites.Length + 1;
        if (timesHit >= maxHits)
        {
            breakableCount--;
            lvlMng.BrickDestroyed();

            GameObject smokePuff = Instantiate(smoke, gameObject.transform.position, Quaternion.identity);

            smokePuff.GetComponent<ParticleSystem>().startColor = gameObject.GetComponent<SpriteRenderer>().color;
           
            Destroy(gameObject);
        }
        else
        {
            LoadSprites();
        }
    }

    void LoadSprites()
    {
        int spriteIndex = timesHit - 1;
        if (hitSprites[spriteIndex])
        {
            this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }

    }
}
