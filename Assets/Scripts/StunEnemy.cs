using UnityEngine;
using System.Collections;

public class StunEnemy : MonoBehaviour {

    private GameObject _enemyToStun;
    private AudioSource _destroySound;
    // Use this for initialization
    void Start ()
    {
        _destroySound = GameObject.FindGameObjectWithTag("SoundController").GetComponents<AudioSource>()[0];
        _enemyToStun = transform.parent.gameObject;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("Player"))
        {
            _destroySound.Play();
            //_enemyToStun;
        }
    }

    void Stun()
    {

    }
}
