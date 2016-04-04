using UnityEngine;
using System.Collections;

namespace Assets.Scripts.Leaves
{
    public class FallingLeaf : MonoBehaviour
    {

        public float Speed;

        private float _screenBottom;
        private float _repeatTime = 1f;
        private float _xSpeed = 0.02f;

        // Use this for initialization
        void Start()
        {
            _screenBottom = Camera.main.ViewportToWorldPoint(Vector3.zero).y;
            InvokeRepeating("Leafing", _repeatTime, _repeatTime);

        }

        // Update is called once per frame
        void Update()
        {

            transform.position -= new Vector3(_xSpeed, Speed, 0);
            if (transform.position.y < _screenBottom - 0.5f)
            {
                gameObject.SetActive(false);
                SpawningLeaves.leavesPool.Enqueue(gameObject);
            }
        }

        public void Leafing()
        {
            _xSpeed = Random.Range (-0.02f, 0.02f);
        }

    }
}
