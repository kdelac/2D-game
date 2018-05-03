using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cigla : MonoBehaviour
{
    public AudioClip crack;
    public Sprite[] HitSprites;
    public static int brickCount = 0;
    public GameObject smoke;
    public int score;
    private int timesHits;
    private LevelManager levelManager;
    private bool isBreakable;
    private LoseColider loseColider;
    
    
    // Use this for initialization
    void Start ()
	{
	    isBreakable = (this.tag == "Breakable");
        //brojimo cigle koje se unistavaju
	    if (isBreakable)
	    {
	        brickCount++;
	    }


        timesHits = 0;
	    levelManager = FindObjectOfType<LevelManager>();
    }
	
	// Update is called once per frame
	void Update () {
	    levelManager.text.text = "Score: " + LevelManager.countScore;

    }

    void OnCollisionEnter2D (Collision2D col)
    {
        //dodavanje zvuka pri udarcu u ciglu u trenutku unistenja cigle
        AudioSource.PlayClipAtPoint(crack, transform.position);

        if (isBreakable)
        {
            HandleHits();
            
        }
    }

    void HandleHits()
    {
        timesHits++;
        int maxHits = HitSprites.Length + 1;
        if (maxHits <= timesHits)
        {
            brickCount--;
            CountScore();
            levelManager.BrickDestroyed();
            Dim();
            
            Destroy(gameObject);
        }
        else
        {
            LoadSprites();

        }
    }

    void Dim()
    {
        GameObject smokePuff = Instantiate(smoke, gameObject.transform.position, Quaternion.identity);
        smokePuff.GetComponent<ParticleSystem>().startColor = gameObject.GetComponent<SpriteRenderer>().color;
    }

    void LoadSprites()
    {
        int spriteIndex = timesHits - 1;
        this.GetComponent<SpriteRenderer>().sprite = HitSprites[spriteIndex]; 
    }

    //void SimulateWin()
    //{
    //    levelManager.LoadNextLevel();
    //}

    void CountScore()
    {
        LevelManager.countScore += score;
        
    }


}
