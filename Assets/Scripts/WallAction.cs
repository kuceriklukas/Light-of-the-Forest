using UnityEngine;
using System.Collections;

public class WallAction : MonoBehaviour
{

    //public GameObject AffectedEnemy;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        //AffectedEnemy.transform.position += new Vector3(0.05F * -1, 0, 0);
        //if ((SnailBehaviour.isGoingLeft) && (coll.CompareTag("Enemy")))
        //{
        //    Debug.Log("TRIGER");
        //    SnailBehaviour.isGoingLeft = false;
        //}
        //else if ((SnailBehaviour.isGoingLeft == false) && (coll.CompareTag("Enemy")))
        //{
        //    Debug.Log("TRIGERTWO");
        //    SnailBehaviour.isGoingLeft = true;
        //}
    }
}
