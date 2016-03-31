using UnityEngine;
using System.Collections;
using System.Diagnostics;

public class StunEnemy : MonoBehaviour {

    //private AudioSource _destroySound;

    private SpiderBehaviour spiderObject;
    // Use this for initialization
    void Start ()
    {
        //_destroySound = GameObject.FindGameObjectWithTag("SoundController").GetComponents<AudioSource>()[0];
        spiderObject = (SpiderBehaviour) FindObjectOfType(typeof (SpiderBehaviour));
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("Fox") && spiderObject.stunned == false)
        {
            //_destroySound.Play();
            spiderObject.Stun();
        }
    }
}
