using UnityEngine;
using System.Collections;

public class KillEnemy : MonoBehaviour
{

    public GameObject _killEnemy;
    private AudioSource _destroySound;

    // Use this for initialization
    void Start () {

        _destroySound = GameObject.FindGameObjectWithTag("SoundController").GetComponents<AudioSource>()[0];
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("Player"))
        {
            _destroySound.Play();
            Destroy(_killEnemy);
        }
    }
}
