using UnityEngine;
using System.Collections;
using System.Diagnostics;

public class Darkness : MonoBehaviour
{
    private Stopwatch stopwatch;
    private bool illuminated;
    private Vector3 _darknessCoordinates;
    private GameObject lightObject;

	// Use this for initialization
	void Start ()
	{
        stopwatch = Stopwatch.StartNew();
	    _darknessCoordinates = transform.position;
	    _darknessCoordinates.z = -1;
	}
	
	// Update is called once per frame
	void Update () {
	    if (illuminated && stopwatch.ElapsedMilliseconds >= 2000)
	    {
            UnityEngine.Debug.Log("And now I am here!");
            Destroy(lightObject);
	        gameObject.SetActive(true);
	        illuminated = false;
            
	    }
	    if (stopwatch.ElapsedMilliseconds >= 10000)
	    {
	        Restart(stopwatch);
	    }
        
	}

    void OnMouseDown()
    {
        illuminated = true;
        Restart(stopwatch);
        gameObject.SetActive(false);
        lightObject = (GameObject)Instantiate(Resources.Load("Light"), _darknessCoordinates, Quaternion.identity);
        UnityEngine.Debug.Log("Hey I am here!");
    }

    //Unity is using a subset of .NET 2.0 and Restart() is added in .NET 4.0, 
    //so I just made my own since the other is not available
    public void Restart(Stopwatch internalStopwatch)
    {    
        internalStopwatch.Reset();
        internalStopwatch.Start();
    }
}
