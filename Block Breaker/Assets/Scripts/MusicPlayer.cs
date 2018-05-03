using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    private static MusicPlayer istance = null;
	// Use this for initialization

    void Avake()
    {
        Debug.Log("Music player awake " + GetInstanceID());
    }
	void Start () {
	    Debug.Log("Music player start " + GetInstanceID());
        if (istance != null)
	    {
	        Destroy(gameObject);
	    }
	    else
	    {
	        istance = this;
	        GameObject.DontDestroyOnLoad(gameObject);
	    }
	    	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
