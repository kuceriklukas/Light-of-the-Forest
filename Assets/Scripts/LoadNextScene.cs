using System;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadNextScene : MonoBehaviour
{
    public String SceneName;
    public float AfterSec;
	// Use this for initialization
	void Start ()
    {
	    
	}
	
	// Update is called once per frame
	void Update ()
	{
	    AfterSec -= Time.deltaTime;
	    if (AfterSec < 0)
	    {
	        SceneManager.LoadScene(SceneName);
	    }
	}
}
