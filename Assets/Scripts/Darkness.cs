using UnityEngine;
using System.Collections;
using System.Diagnostics;

public class Darkness : MonoBehaviour
{
    private Vector3 _darknessCoordinates;
    private GameObject lightObject;

	// Use this for initialization
	void Start ()
	{
        _darknessCoordinates = transform.position;
	    _darknessCoordinates.z = -1;
	}
	
	// Update is called once per frame
	void Update () {
	    if (gameObject.activeInHierarchy)
	    {
	        Destroy(lightObject);
	    }
    }

    void OnMouseDown()
    {       
        gameObject.SetActive(false);
        lightObject = (GameObject)Instantiate(Resources.Load("Light"), _darknessCoordinates, Quaternion.identity);     
    }
}
