﻿using UnityEngine;
using System.Collections;
using UnityEngine.Assertions.Comparers;

namespace Assets.Scripts.Leaves
{
    public class FallingLeaf : MonoBehaviour
    {

        public float Speed;
        public float YAxis;

        private float _screenBottom;
        private Vector3 _spawnPositon;
        

        // Use this for initialization
        void Start()
        {
            _spawnPositon = new Vector3(this.gameObject.transform.position.x,YAxis,0);
            _screenBottom = Camera.main.ViewportToWorldPoint(Vector3.zero).y;
        }

        // Update is called once per frame
        void Update()
        {

            transform.position -= new Vector3(0, Speed, 0);
            if (transform.position.y < _screenBottom - 0.5f)
            {
                this.gameObject.transform.position = _spawnPositon;
            }
        }
        
        //HERE LIES OUR BELOVED LEAFING METHOD... REQUIESCAT IN PACE
    }
}
