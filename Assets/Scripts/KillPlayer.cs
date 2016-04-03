using UnityEngine;
using System.Collections;

public class KillPlayer : MonoBehaviour
{

    //public bool died;
    private GameObject _killPlayer;
	// Use this for initialization
	void Start () {
	_killPlayer = GameObject.FindGameObjectWithTag("Fox");
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("Fox"))
        {
            _killPlayer.transform.position = CheckPoint.SpawnPoint;
            //died = true;
        }
    }
}
