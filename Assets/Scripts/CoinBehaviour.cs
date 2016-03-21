using UnityEngine;
using System.Collections;

public class CoinBehaviour : MonoBehaviour
{
    private AudioSource pickUpCoinSound;
	// Use this for initialization
	void Start ()
	{

	    pickUpCoinSound = GameObject.FindGameObjectWithTag("Player").GetComponents<AudioSource>()[1];
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        pickUpCoinSound.Play();
        Destroy(this.gameObject);
    }
}
