using UnityEngine;
using System.Collections;

public class KillPlayer : MonoBehaviour {

    private GameObject _killPlayer;
	// Use this for initialization
	void Start () {
	_killPlayer = GameObject.FindGameObjectWithTag("Fox");
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("Fox"))
        {
            Destroy(_killPlayer);
        }
    }
}
