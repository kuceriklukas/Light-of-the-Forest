using UnityEditor;
using UnityEngine;

namespace Assets.Scripts
{
    public class CameraLerp : MonoBehaviour {

        private GameObject _player;
        public float Speed;
        

        // Use this for initialization
        void Start()
        {
            _player = GameObject.FindGameObjectWithTag("Fox");
            
        }

        // Update is called once per frame
        void Update()
        {           
            var playerposition = new Vector3(
                _player.transform.position.x,
                _player.transform.position.y,
                transform.position.z);
            transform.position = Vector3.Lerp(transform.position, playerposition, Speed);
        }
    }
}
