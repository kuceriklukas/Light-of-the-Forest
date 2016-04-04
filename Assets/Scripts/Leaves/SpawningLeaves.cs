using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Assets.Scripts.Leaves
{
    public class SpawningLeaves : MonoBehaviour
    {

        public static Queue<GameObject> leavesPool = new Queue<GameObject>();

        public GameObject[] Objects;
        public float SpawnTime = 2f;
        public float FromPosition;
        public float ToPosition;

        private Vector3 spawnPosition;
        private GameObject parent;

        // Use this for initialization
        void Start()
        {
            parent = GameObject.FindGameObjectWithTag("Leaf");
            InvokeRepeating("Spawn", SpawnTime, SpawnTime);

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void Spawn()
        {
            spawnPosition.x = Random.Range(FromPosition, ToPosition);
            spawnPosition.y = 13;

            if (leavesPool.Count > 0)
            {
                GameObject leaf = leavesPool.Dequeue();
                leaf.SetActive(true);
                leaf.transform.position = spawnPosition;
            }
            else
            {
                GameObject e =
                    Instantiate(Objects[Random.Range(0, Objects.Length - 1)], spawnPosition, Quaternion.identity) as
                        GameObject;
                e.transform.parent = parent.transform;
            }
        }
    }
}
