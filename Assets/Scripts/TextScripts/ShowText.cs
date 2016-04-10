using UnityEngine;
using System.Collections;
using System.Threading;

public class ShowText : MonoBehaviour
{

    private GameObject thisGameObject;
    public float TimeLeft;
    private bool StartCountDown = false;

	// Use this for initialization
	void Start ()
	{
	    thisGameObject = this.gameObject;
	    thisGameObject.GetComponent<MeshRenderer>().enabled = false;

	}
	
	// Update is called once per frame
	void Update ()
    {
	    if (StartCountDown)
	    {
	        TimeLeft -= Time.deltaTime;
	        if (TimeLeft < 0)
	        {
	            Destroy(thisGameObject);
	        }
	    }
	}

    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.gameObject.tag.Equals("Fox"))
        {
            StartCountDown = true;
            thisGameObject.GetComponent<MeshRenderer>().enabled = true;
        }
    }
}
