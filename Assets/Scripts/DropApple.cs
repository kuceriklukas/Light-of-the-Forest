using UnityEngine;
using System.Collections;

public class DropApple : MonoBehaviour
{

    private GameObject _specialApple;

	// Use this for initialization
	void Start ()
    {
	    _specialApple = GameObject.FindGameObjectWithTag("CollectibleSpecial");
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.tag.Equals("Fox"))
        {
            _specialApple.GetComponent<Rigidbody2D>().isKinematic = false;
        }
    }
}
