using UnityEngine;
using System.Collections;

public class CheckPoint : MonoBehaviour
{

    public static Vector3 SpawnPoint;

    // Use this for initialization
    void Start()
    {
        SpawnPoint = transform.position;     
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("CheckPoint"))
        {
            SpawnPoint = coll.gameObject.transform.position;
            Destroy(coll.gameObject);
        }
    }
}