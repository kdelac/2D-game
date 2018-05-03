using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoseColider : MonoBehaviour
{
    public static int zivoti = 5;
    private LevelManager levelManager;
    public Text zivot;
    
    void OnTriggerEnter2D(Collider2D trigger)
    {
        if (zivoti <= 1)
        {
            Lost();
        }
        else
        {
            Zivoti();
            zivoti--;
        }   
    }

    void Lost()
    {
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        LevelManager.countScore = 0;
        LoseColider.zivoti = 5;
        levelManager.LoadLevel("Loose");
    }

    void Zivoti()
    { 
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void Update()
    {
        zivot.text = "x" + LoseColider.zivoti;

    }
}
