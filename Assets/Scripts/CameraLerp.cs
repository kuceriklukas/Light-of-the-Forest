﻿using UnityEditor;
using UnityEngine;

namespace Assets.Scripts
{
    public class CameraLerp : MonoBehaviour {

        //Camera Lerp variables
        private GameObject _player;
        public float Speed;
        
        //Camera Clamp variables
        public float xMax;
        public float xMin;
        public float yMax;
        public float yMin;

        // Use this for initialization
        void Start()
        {
            _player = GameObject.FindGameObjectWithTag("Fox");
        }

        // Update is called once per frame
        void Update()
        {           
            //Lerp setup
            Vector3 playerposition = new Vector3(
                _player.transform.position.x,
                _player.transform.position.y,
                transform.position.z);
            transform.position = Vector3.Lerp(transform.position, playerposition, Speed);

            //Clamp setup
            Vector3 v3 = transform.position;
            v3.x = Mathf.Clamp(v3.x, xMin, xMax);
            v3.y = Mathf.Clamp(v3.y, yMin, yMax);
            transform.position = v3;
        }
    }
}
