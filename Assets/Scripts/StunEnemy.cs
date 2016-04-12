using System;
using UnityEngine;
using System.Collections;
using System.Diagnostics;

public class StunEnemy : MonoBehaviour {

    //private AudioSource _destroySound;

    private SpiderBehaviour spiderObject;
    private BirdBehaviour birdObject;
    // Use this for initialization
    void Start ()
    {
        //_destroySound = GameObject.FindGameObjectWithTag("SoundController").GetComponents<AudioSource>()[0];
        spiderObject = (SpiderBehaviour) FindObjectOfType(typeof (SpiderBehaviour));
        birdObject = (BirdBehaviour)FindObjectOfType(typeof (BirdBehaviour));
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("Fox") && this.gameObject.name.Contains("SpiderEnemy"))
        {
            //_destroySound.Play();
            spiderObject.Stun();
        }
        if (coll.CompareTag("Fox") && this.gameObject.name.Contains("bird"))
        {
            birdObject.Stun();
        }
    }
}
