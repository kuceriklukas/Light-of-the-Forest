using UnityEngine;
using System.Collections;

public class KillPlayer : MonoBehaviour
{
    private GameObject _killPlayer;
    private GameObject _moveCamera;
    private float _cameraPositionZ;

    // Use this for initialization
    void Start()
    {
        _killPlayer = GameObject.FindGameObjectWithTag("Fox");
        _moveCamera = GameObject.FindGameObjectWithTag("MainCamera");
        _cameraPositionZ = _moveCamera.transform.position.z;

    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("Fox"))
        {
            _killPlayer.transform.position = CheckPoint.SpawnPoint;
            _moveCamera.transform.position = new Vector3(CheckPoint.SpawnPoint.x, _killPlayer.transform.position.y, _cameraPositionZ);
        }
    }
}
