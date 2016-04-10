using UnityEngine;
using System.Collections;

public class PickUpCollectible : MonoBehaviour
{

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
            DisplayCollectible.CollectibleCount++;
            Destroy(this.gameObject);
        }
    }
}
