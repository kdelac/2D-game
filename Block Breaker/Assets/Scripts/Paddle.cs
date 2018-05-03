﻿using UnityEngine;

public class Paddle : MonoBehaviour
{

    public bool autoPlay = false;
    private Ball ball;
	void Start ()
	{
	    ball = GameObject.FindObjectOfType<Ball>();
	}
	
	// Update is called once per frame
	void Update ()
	{
	    if (!autoPlay)
	    {
	        miciMisa();
        }
	    else
	    {
	        AutoPlay();
	    }
        
	}

    void miciMisa()
    {
        Vector3 paddlePos = new Vector3(0.5f, this.transform.position.y, 0f);
        float mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;
        paddlePos.x = Mathf.Clamp(mousePosInBlocks, 0.77f, 15.25f);
        this.transform.position = paddlePos;
    }

    void AutoPlay()
    {
        Vector3 paddlePos = new Vector3(0.5f, this.transform.position.y, 0f);
        Vector3 ballPos = ball.transform.position;  
        paddlePos.x = Mathf.Clamp(ballPos.x, 0.77f, 15.25f);
        this.transform.position = paddlePos;
    }
}
