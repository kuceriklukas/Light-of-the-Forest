using System;
using UnityEngine;
using System.Collections;
using System.Diagnostics;

public class StunEnemy : MonoBehaviour {

    //private AudioSource _destroySound;

    private SpiderBehaviour spiderObject;
    private BirdBehaviour birdObject;
    private GameObject spider;
    private GameObject bird;
    // Use this for initialization
    void Start ()
    {
        spider = gameObject.transform.parent.gameObject;
        spiderObject = spider.GetComponent<SpiderBehaviour>();

        bird = this.gameObject;
        birdObject = bird.GetComponent<BirdBehaviour>();
    }
	
	// Update is called once per frame
	void Update () {
	 
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("Fox") && spider && gameObject.transform.parent.name.Contains("SpiderEnemy"))
        {
            //_destroySound.Play();
            spiderObject.Stun();
        }
        if (coll.CompareTag("Fox") && gameObject.name.Contains("bird"))
        {
            birdObject.Stun();
        }
    }
}
