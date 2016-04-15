using System;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MovetoNextScene : MonoBehaviour
{
    public string SceneName;

	// Use this for initialization
	void Start ()
    {
	    
	}
	
	// Update is called once per frame
	void Update ()
    {
	    
	}

    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.gameObject.tag.Equals("Fox"))
        {
            SceneManager.LoadScene(SceneName);
        }
    }
}
