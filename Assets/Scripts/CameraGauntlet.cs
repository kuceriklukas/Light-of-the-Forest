using UnityEngine;
using System.Collections;
using Assets.Scripts;

public class CameraGauntlet : MonoBehaviour
{
    public float Speed;
    private float _playerY;
    private GameObject player;
    // Use this for initialization
    void Start ()
	{
        player = GameObject.FindGameObjectWithTag("Fox");	    
	}
	
	// Update is called once per frame
	void Update ()
	{
        _playerY = player.transform.position.y;
        transform.position += new Vector3((Speed * Time.deltaTime) * -1, 0);        
	}
}
