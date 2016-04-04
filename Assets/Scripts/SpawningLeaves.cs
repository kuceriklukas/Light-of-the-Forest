using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawningLeaves : MonoBehaviour
{

    public GameObject[] Objects;
    public float SpawnTime = 2f;
    public float FromPosition;
    public float ToPosition;

    private Vector3 _spawnPosition;
    private GameObject _parent;
    private Queue<GameObject> leafPool = new Queue<GameObject>();

	// Use this for initialization
	void Start ()
    {  
        _parent = GameObject.FindGameObjectWithTag("Leaf");
        InvokeRepeating("Spawn",SpawnTime,SpawnTime);
	    
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    public void Spawn()
    {
        _spawnPosition.x = Random.Range(FromPosition, ToPosition);
        _spawnPosition.y = 13;

        if (leafPool.Count>0)
        {
            GameObject leaf = leafPool.Dequeue();
            leaf.SetActive(true);
            leaf.transform.position = _spawnPosition;
        }

        else
        {
            GameObject obj = Instantiate(Objects[Random.Range(0,Objects.Length-1)], _spawnPosition, Quaternion.identity) as GameObject;

            obj.transform.parent = _parent.transform;
        }
    }
}
