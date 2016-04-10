using UnityEngine;
using System.Collections;

public class CameraGauntlet : MonoBehaviour
{
    public float Speed;
	// Use this for initialization
	void Start ()
	{
	}
	
	// Update is called once per frame
	void Update ()
	{
	    transform.position += new Vector3((Speed * Time.deltaTime) * -1, 0);
	}
}
